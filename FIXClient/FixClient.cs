using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace FIXClient {
    public class FixClient : IFixClient, IDisposable {
        public event EventHandler OnMarketDataSnapshot;
        public event EventHandler OnMarketDataRequestReject;
        public event EventHandler OnQuoteAcknowledgement;
        public event EventHandler OnQuote;
        public event EventHandler OnQuoteCancel;
        public event EventHandler OnLogon;
        public event EventHandler OnLogoff;
        public event EventHandler OnNewOrderSingle;
        public event EventHandler OnExecutionReport;
        public event EventHandler OnFXAllocation;
        public event EventHandler OnFXAllocationAcknowledgement;
        public event EventHandler OnUpdateStatus;
        
        public string Host { get; private set; }
        public int Port { get; private set; }
        public string SenderId { get; private set; }
        public string TargetId { get; private set; }
        public FileInfo LogFile { get; private set; }
        public string EncryptionMethod { get; private set; }
        public int HeartBeatInterval { get; private set; }
        public bool ResetSequenceNumber { get; private set; }
        public bool LoggedOn { get; private set; }
        public string OnBehalfOf { get; set; }

        private readonly StreamWriter _logger;

        private readonly Dictionary<Tuple<string, string, string>, Tuple<string, int>> _marketDataRequests; 
        

        public FixClient(string host, int port, string senderId, string targetId, string encryptionMethod, int heartBeatInterval, bool resetSequenceNum, string logFilePath) { 
            Host = host;
            Port = port;
            SenderId = senderId;
            TargetId = targetId;
            EncryptionMethod = encryptionMethod;
            HeartBeatInterval = heartBeatInterval;
            ResetSequenceNumber = resetSequenceNum;
            LogFile = new FileInfo(logFilePath);
            _marketDataRequests = new Dictionary<Tuple<string, string, string>, Tuple<string, int>>();
            _logger = new StreamWriter(LogFile.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.UTF8) { AutoFlush = true };
        }

        private long _sequenceId;

        public long SequenceId { get { return ++_sequenceId; } }

        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _clientThread;

        private const string BEGINSTRING = "FIX.4.4";
        private const char FIXSEPARATOR = (char) 1;
        private const int DEFAULTMESSAGESIZE = 64 * 1024 * 1024;

        public void Dispose()
        {
            if (_logger != null)
            {
                _logger.Close();
            }
        }

        public bool Connect() {
            try {
                _client = new TcpClient(Host, Port);

                _clientThread = new Thread(StartClientListener);
                _clientThread.Start();

                return SendLogonRequest();
            } catch (SocketException ex) {
                UpdateStatus(FIXClientStatus.ConnectionError, ex.Message);
                return false;
            }
        }

        private void StartClientListener() {
            _stream = _client.GetStream();

            var encoder = new UTF8Encoding();
            var message = new byte[DEFAULTMESSAGESIZE];
            string buffer = "";

            // stay connected until we have received a Logout message
            while (true) {
                int bytesRead;

                try {
                    bytesRead = _stream.Read(message, 0, DEFAULTMESSAGESIZE);
                } catch {
                    break;
                }

                if (bytesRead == 0) break;

                buffer = encoder.GetString(message, 0, bytesRead);

                int idx = buffer.IndexOf("8=FIX.");
                while ( idx >= 0 )
                {
                    string msg = "";
                    int idx2 = buffer.IndexOf("8=FIX.", idx + 1);
                    if (idx2 < 0)
                    {
                        idx2 = buffer.Length;   
                    }

                    msg = buffer.Substring(idx, idx2 - idx);

                    _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Receiving: {1}", DateTime.Now, msg.Replace(FIXSEPARATOR, '|'));
                    if (HandleMessage(msg) == "5") break;   // it's a log out message;

                    idx = buffer.IndexOf("8=FIX.", idx2);
                }
            }

            try {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - LoggedOut acknowledged, stopping FIX Client", DateTime.Now);
                _client.Close();
            } catch(ObjectDisposedException ex) {
                UpdateStatus(FIXClientStatus.DisconnectionError, ex.Message);
            }
        }

        private void UpdateStatus(FIXClientStatus status, string message) {
            // always log to file
            _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - {1}: {2}", DateTime.Now, status, message);

            // if we have a client listening for the event then we should send this to the event handler.
            if (OnUpdateStatus == null) return;
            OnUpdateStatus(this, new UpdateStatusEventArgs {Status = status, Message = message});
        }
        
        private string HandleMessage(string message) {

            var tags = message.Split(new[] {FIXSEPARATOR}).Where(t => !string.IsNullOrEmpty(t));

            var fixTags = tags.Select(t => t.Split(new[] {'='})).Select(t => new Tuple<int, string>(int.Parse(t[0]), t[1])).ToArray();

            var msgTypes = ExtractTagData(fixTags, 35);
            var symbols = ExtractTagData(fixTags, 55);

            var msgType = msgTypes.Length > 0 ? msgTypes[0] : string.Empty;
            var symbol = symbols.Length > 0 ? symbols[0] : string.Empty;

            if (msgType == string.Empty) return msgType;

            switch (msgType) {
                case "0":
                    SendHeartBeatReply();
                    break;
                case "A":
                    LoggedOn = true;
                    var loggedOnEventHandler = OnLogon;
                    if (loggedOnEventHandler != null) {
                        loggedOnEventHandler(this, new EventArgs());
                    }
                    break;
                case "5":
                    LoggedOn = false;
                    var loggedOffEventHandler = OnLogoff;

                    if (loggedOffEventHandler != null) { loggedOffEventHandler(this, new EventArgs()); }
                    break;
                case "W":
                    var marketDataEventHandler = OnMarketDataSnapshot;
                    var marketDataRequestIds = ExtractTagData(fixTags, 262);

                    var requestId = marketDataRequestIds.Length > 0 ? marketDataRequestIds[0] : string.Empty;


                    if (string.IsNullOrEmpty(requestId)) break;

                    var mdRequestKeys = _marketDataRequests.Where(item => item.Value.Item1 == requestId).Select(item => item.Key).ToArray();
                    if (mdRequestKeys.Length < 1) break;

                    var mdEventArgs = new FixMessageEventArgs(msgType, symbol, fixTags) {RequestId = requestId, Tier = mdRequestKeys[0].Item2};

                    if (marketDataEventHandler != null) marketDataEventHandler(this, mdEventArgs);
                    break;
                case "1":
                    SendTestReply(fixTags);
                    break;
                case "S":
                    var quoteEventHandler = OnQuote;
                    var quoteEventArgs = new FixMessageEventArgs(msgType, symbol, fixTags);

                    var quoteReqIdTag = fixTags.Where(item => item.Item1 == 131).ToArray();
                    if (quoteReqIdTag.Length > 0) quoteEventArgs.RequestId = quoteReqIdTag[0].Item2;

                    if (quoteEventHandler != null) quoteEventHandler(this, quoteEventArgs);
                    break;
                case "Z":
                    var quoteCancelEventHandler = OnQuoteCancel;
                    var quoteCancelEventArgs = new FixMessageEventArgs(msgType, symbol, fixTags);

                    if (quoteCancelEventHandler != null) quoteCancelEventHandler(this, quoteCancelEventArgs);
                    break;
                case "8":
                    var executionReportHandler = OnExecutionReport;
                    var executionReportEventArgs = new FixMessageEventArgs(msgType, symbol, fixTags);
                    var clOrdIdTag = fixTags.Where(item => item.Item1 == 11).ToArray();
                    if (clOrdIdTag.Length > 0) executionReportEventArgs.RequestId = clOrdIdTag[0].Item2;

                    if (executionReportHandler != null) executionReportHandler(this, executionReportEventArgs);
                    break;
            }

            return msgType;
        }

        private static string[] ExtractTagData(IEnumerable<Tuple<int, string>> fixTags, int tagNumber) {
            var dataTags = fixTags.Where(tag => tag.Item1 == tagNumber).ToArray();

            return dataTags.Select(tag => tag.Item2).ToArray();
        }

        public bool Disconnect()
        {
            if (LoggedOn)
            {
                bool ret = SendLogoutRequest();
                return ret;
            }

            _clientThread.Abort();
            return true;
        }

        public bool RequestMarketData(IMarketDataRequest mdRequest) {
            var key = new Tuple<string, string, string>(mdRequest.Symbol, mdRequest.Tier, mdRequest.Tenor);
            var unsubscribe = false;
            var requestId = string.Empty;

            if (mdRequest.IsSubscribe) {
                if (_marketDataRequests.ContainsKey(key)) {
                    _marketDataRequests[key] = new Tuple<string, int>(_marketDataRequests[key].Item1, _marketDataRequests[key].Item2 + 1);
                    return true;
                }

                _marketDataRequests.Add(key, new Tuple<string, int>(mdRequest.ClientRequestId, 1));
                requestId = mdRequest.ClientRequestId;

            } else {
                if (!_marketDataRequests.ContainsKey(key)) return false;

                _marketDataRequests[key] = new Tuple<string, int>(_marketDataRequests[key].Item1, _marketDataRequests[key].Item2 - 1);
                
                if (_marketDataRequests[key].Item2 <= 0) {
                    unsubscribe = true;
                    requestId = _marketDataRequests[key].Item1;
                    _marketDataRequests.Remove(key);
                }
            }

            string tag6217 = "";
            if ( mdRequest.Tenor == "SP" ) 
            {
                tag6217 = "0";   // Spot
            }
            else
            {
                tag6217 = "2";  // FORWARD_POINT
            }

            try {
                var tags = new[] {
                    new Tuple<int, string>(35, "V"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(50, mdRequest.Tier), 
                    new Tuple<int, string>(115, OnBehalfOf),
                    //new Tuple<int, string>(116, "Tan Quach"), 
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(262, requestId),
                    new Tuple<int, string>(263, unsubscribe ? "2" : "1"),
                    new Tuple<int, string>(264, "0"),
                    new Tuple<int, string>(265, "0"),
                    new Tuple<int, string>(146, "1"),
                    new Tuple<int, string>(55, mdRequest.Symbol),
                    // new Tuple<int, string>(167, "FOR"),
                    new Tuple<int, string>(64, mdRequest.SettlementDate.ToString("yyyyMMdd")),
                    new Tuple<int, string>(6215, mdRequest.Tenor),
                    new Tuple<int, string>(6217, tag6217),
                    new Tuple<int, string>(267, "2"),
                    new Tuple<int, string>(269, "0"),
                    new Tuple<int, string>(269, "1")
                };
 
                SendFixMessage(tags);
                
            } catch(Exception ex) {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Failed to send market data requests, {1}", DateTime.Now, ex.Message);
                return false;
            }

            return true;
        }

        public bool RequestQuote(IQuoteRequest quoteRequest) {
            try {
                var tags = new List<Tuple<int, string>> {
                    new Tuple<int, string>(35, "R"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(131, quoteRequest.ClientRequestId),
                    new Tuple<int, string>(146, "1"),
                    new Tuple<int, string>(55, quoteRequest.Symbol),
                    new Tuple<int, string>(15, quoteRequest.Currency),
                    new Tuple<int, string>(167, "FOR"),
                    new Tuple<int, string>(54, ((int) quoteRequest.Side).ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(38, quoteRequest.Amount.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(40, quoteRequest.GetType() == typeof (SwapQuoteRequest) ? "G" : "H"),
                    new Tuple<int, string>(64, quoteRequest.SettlementDate.ToString("yyyyMMdd")),
                    new Tuple<int, string>(6215, quoteRequest.Tenor),
                    new Tuple<int, string>(1, quoteRequest.Account)
                };

                if (quoteRequest.GetType() == typeof(SwapQuoteRequest)) {
                    var swapQuoteRequest = (SwapQuoteRequest) quoteRequest;
                    tags.AddRange(new [] {
                        new Tuple<int, string>(192, swapQuoteRequest.FarAmount.ToString(CultureInfo.InvariantCulture)), 
                        new Tuple<int, string>(193, swapQuoteRequest.FarSettleDate.ToString("yyyyMMdd")),
                        new Tuple<int, string>(6216, swapQuoteRequest.FarTenor) 
                    });
                }

                SendFixMessage(tags);

            } catch(Exception ex) {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Failed to send Quote Request, {1}", DateTime.Now, ex.Message);
                return false;
            }

            return true;
        }

        public bool CancelQuoteRequest(string requestId)
        {
            try
            {
                var tags = new[] {
                    new Tuple<int, string>(35, "b"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(131, requestId),
                    new Tuple<int, string>(117, ""),  
                    new Tuple<int, string>(297, "5"), // quote ack status rejected
                    new Tuple<int, string>(58, "Taker declined manually quoted price") 
                };

                SendFixMessage(tags);
            }
            catch (Exception ex)
            {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Quote Cancellation failed, {1}", DateTime.Now, ex.Message);
                return false;
            }

            return true;
        }
        public bool RejectQuote(IQuoteRequest quoteRequest, string quoteId) {
            try {
                var tags = new[] {
                    new Tuple<int, string>(35, "b"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(131, quoteRequest.ClientRequestId),
                    new Tuple<int, string>(117, quoteId),
                    new Tuple<int, string>(297, "5") // quote ack status rejected
                };

                SendFixMessage(tags);
            } catch(Exception ex) {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Quote Rejection failed, {1}", DateTime.Now, ex.Message);
                return false;
            }

            return true;
        }
        
        public bool SendNewOrderSingle(INewOrderSingle newOrderSingle) {
            try {
                var tags = new List<Tuple<int, string>> {
                    new Tuple<int, string>(35, "D"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(115, OnBehalfOf),
                    new Tuple<int, string>(167, "FOR"),
                    new Tuple<int, string>(21, "2"),
                    new Tuple<int, string>(117, newOrderSingle.QuoteId),
                    new Tuple<int, string>(11, newOrderSingle.ClientRequestId),
                    new Tuple<int, string>(55, newOrderSingle.Symbol),
                    new Tuple<int, string>(15, newOrderSingle.Currency),
                    new Tuple<int, string>(54, newOrderSingle.Side.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(38, newOrderSingle.Amount.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(60, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(75, DateTime.Today.ToString("yyyyMMdd")),                    
                    new Tuple<int, string>(6215, newOrderSingle.Tenor),
                };

                // Add tags that are appropriate for all auto-quotable order types
                if (newOrderSingle.GetType() == typeof(AutoSpotOrderSingle) || newOrderSingle.GetType() == typeof(AutoOutrightOrderSingle)) {
                    tags.Add(new Tuple<int, string>(40, newOrderSingle.OrderType));
                }

                if (newOrderSingle.GetType() == typeof(AutoSwapOrderSingle)) {
                    tags.Add(new Tuple<int, string>(40, "G"));
                }

                if (newOrderSingle.OrderType != "1") // Market
                {
                     tags.Add(new Tuple<int, string>(44, newOrderSingle.Price.ToString(CultureInfo.InvariantCulture)));
                }

                if (newOrderSingle.GetType() == typeof(AutoSpotOrderSingle))
                {
                    tags.Add(new Tuple<int, string>(64, newOrderSingle.SettlementDate.ToString("yyyyMMdd")));
                }

                // Add tags that are appropriate for auto-quotable forward outrights and swaps
                if (newOrderSingle.GetType() == typeof(AutoOutrightOrderSingle)) {
                    var outrightOrder = (AutoOutrightOrderSingle) newOrderSingle;

                    tags.Add(new Tuple<int, string>(64, newOrderSingle.SettlementDate.ToString("yyyyMMdd")));
                    tags.Add(new Tuple<int, string>(194, outrightOrder.LastSpotRate.ToString(CultureInfo.InvariantCulture)));
                    tags.Add(new Tuple<int, string>(195, outrightOrder.LastForwardPoints.ToString(CultureInfo.InvariantCulture)));

                    // Spot quote ID (Forward orders)
                    if (newOrderSingle.SpotQuoteId != null && newOrderSingle.SpotQuoteId.Trim() != "")
                    {
                        tags.Add(new Tuple<int, string>(9222, newOrderSingle.SpotQuoteId));
                    }
                }

                // Add tags that are appropriate only for auto-quotable swaps
                if (newOrderSingle.GetType() == typeof(AutoSwapOrderSingle)) {
                    var swapOrder = (AutoSwapOrderSingle) newOrderSingle;

                    tags.Add(new Tuple<int, string>(64, newOrderSingle.SettlementDate.ToString("yyyyMMdd")));
                    tags.Add(new Tuple<int, string>(194, swapOrder.LastSpotRate.ToString(CultureInfo.InvariantCulture)));
                    tags.Add(new Tuple<int, string>(195, swapOrder.LastForwardPoints.ToString(CultureInfo.InvariantCulture)));
                    tags.Add(new Tuple<int, string>(6160, swapOrder.Price2.ToString(CultureInfo.InvariantCulture)));
                    tags.Add(new Tuple<int, string>(192, swapOrder.Amount2.ToString(CultureInfo.InvariantCulture)));
                    tags.Add(new Tuple<int, string>(5191, swapOrder.LastForwardPoints2.ToString(CultureInfo.InvariantCulture)));
                    tags.Add(new Tuple<int, string>(193, swapOrder.SettlementDate2.ToString("yyyyMMdd")));
                    tags.Add(new Tuple<int, string>(6216, swapOrder.Tenor2));
                }

                // Benchmark orders
                if (newOrderSingle.OrderType == "X")
                {
                    tags.Add(new Tuple<int, string>(6219, newOrderSingle.BenchmarkType));
                }

                // TIF
                if (newOrderSingle.TIF != null && newOrderSingle.TIF != "")
                {
                    tags.Add(new Tuple<int, string>(59, newOrderSingle.TIF));
                }

                // Expiration
                if (newOrderSingle.ExpireTimeStamp != null && newOrderSingle.ExpireTimeStamp != "")
                {
                    tags.Add(new Tuple<int, string>(6222, newOrderSingle.ExpireTimeStamp));
                }
                if (newOrderSingle.ExpireTimeZone != null && newOrderSingle.ExpireTimeZone != "")
                {
                    tags.Add(new Tuple<int, string>(6223, newOrderSingle.ExpireTimeZone));
                }

                // Activation
                if (newOrderSingle.ActiveTimeStamp != null && newOrderSingle.ActiveTimeStamp != "")
                {
                    tags.Add(new Tuple<int, string>(6220, newOrderSingle.ActiveTimeStamp));
                }
                if (newOrderSingle.ActiveTimeZone != null && newOrderSingle.ActiveTimeZone != "")
                {
                    tags.Add(new Tuple<int, string>(6221, newOrderSingle.ActiveTimeZone));
                }

                // Pre-allocation
                if ( newOrderSingle.Account != null &&  newOrderSingle.Account.Trim() != "" )
                {
                    tags.Add(new Tuple<int, string>(1, newOrderSingle.Account));
                }

                // Alert
                if (newOrderSingle.AlertType > 0)
                {
                    tags.Add(new Tuple<int, string>(6224, newOrderSingle.AlertType.ToString()));
                }

                SendFixMessage(tags);
                return true;
            } 
            catch(Exception ex) {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Send New Order Single failed, {1}", DateTime.Now, ex.Message);
                return false;
            }
        }

        public bool SendNewOrderMultileg(INewOrderMultiLeg newOrder)
        {
            try
            {
                var tags = new List<Tuple<int, string>> {
                    new Tuple<int, string>(35, "E"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(115, OnBehalfOf),
                    //new Tuple<int, string>(167, "FOR"),
                    //new Tuple<int, string>(21, "2"),
                    //new Tuple<int, string>(55, "MLEG"),
                    //new Tuple<int, string>(11, newOrder.ClientRequestId),
                    //new Tuple<int, string>(54, "B"), //"As Defined" (for use with multileg instruments)
                    //new Tuple<int, string>(60, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    //new Tuple<int, string>(75, DateTime.Today.ToString("yyyyMMdd")),
                    new Tuple<int, string>(1385, newOrder.OrderType),       // Contingency type
                    new Tuple<int, string>(66, newOrder.ClientRequestId),  
                    new Tuple<int, string>(394, "1"),
                    new Tuple<int, string>(59, newOrder.TIF),
                };

                // Expiration
                if (newOrder.ExpireTimeStamp != null && newOrder.ExpireTimeStamp != "")
                {
                    tags.Add(new Tuple<int, string>(6222, newOrder.ExpireTimeStamp));
                }
                if (newOrder.ExpireTimeZone != null && newOrder.ExpireTimeZone != "")
                {
                    tags.Add(new Tuple<int, string>(6223, newOrder.ExpireTimeZone));
                }

                // Activation
                if (newOrder.ActiveTimeStamp != null && newOrder.ActiveTimeStamp != "")
                {
                    tags.Add(new Tuple<int, string>(6220, newOrder.ActiveTimeStamp));
                }
                if (newOrder.ActiveTimeZone != null && newOrder.ActiveTimeZone != "")
                {
                    tags.Add(new Tuple<int, string>(6221, newOrder.ActiveTimeZone));
                }

                // Alert
                if (newOrder.AlertType > 0)
                {
                    tags.Add(new Tuple<int, string>(6224, newOrder.AlertType.ToString()));
                }

                tags.Add(new Tuple<int, string>(68, newOrder.Legs.Length.ToString()));
                tags.Add(new Tuple<int, string>(73, newOrder.Legs.Length.ToString()));

                int idx = 0;
                while (idx < newOrder.Legs.Length)
                {
                    INewOrderSingle leg = newOrder.Legs[idx];
                    if (leg != null)
                    {
                        int legId = idx + 1;
                        tags.Add(new Tuple<int, string>(11, leg.ClientRequestId.ToString()));
                        tags.Add(new Tuple<int, string>(67, legId.ToString()));
                        tags.Add(new Tuple<int, string>(55, leg.Symbol));
                        tags.Add(new Tuple<int, string>(54, leg.Side.ToString(CultureInfo.InvariantCulture)));
                        tags.Add(new Tuple<int, string>(38, leg.Amount.ToString(CultureInfo.InvariantCulture)));
                        tags.Add(new Tuple<int, string>(40, leg.OrderType));
                        tags.Add(new Tuple<int, string>(15, leg.Currency));
                        tags.Add(new Tuple<int, string>(64, leg.SettlementDate.ToString("yyyyMMdd")));
                        tags.Add(new Tuple<int, string>(59, leg.TIF));

                        if (leg.OrderType != "1") // Market
                        {
                            tags.Add(new Tuple<int, string>(44, leg.Price.ToString(CultureInfo.InvariantCulture)));
                        }

                        // Expiration
                        if (leg.ExpireTimeStamp != null && leg.ExpireTimeStamp != "")
                        {
                            tags.Add(new Tuple<int, string>(6222, leg.ExpireTimeStamp));
                        }
                        if (leg.ExpireTimeZone != null && leg.ExpireTimeZone != "")
                        {
                            tags.Add(new Tuple<int, string>(6223, leg.ExpireTimeZone));
                        }

                        // Activation
                        if (leg.ActiveTimeStamp != null && leg.ActiveTimeStamp != "")
                        {
                            tags.Add(new Tuple<int, string>(6220, leg.ActiveTimeStamp));
                        }
                        if (leg.ActiveTimeZone != null && leg.ActiveTimeZone != "")
                        {
                            tags.Add(new Tuple<int, string>(6221, leg.ActiveTimeZone));
                        }

                        if (leg.Account != null && leg.Account.Trim() != "")
                        {
                            tags.Add(new Tuple<int, string>(1, leg.Account));
                        }
                    }
                    idx++;
                }

                SendFixMessage(tags);
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Send New Order Single failed, {1}", DateTime.Now, ex.Message);
                return false;
            }
        }

        public bool CancelOrder(string symbol, string clientRequestId, string side)
        {
            try
            {
                var tags = new List<Tuple<int, string>> {
                    new Tuple<int, string>(35, "F"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(167, "FOR"),
                    new Tuple<int, string>(41, clientRequestId),
                    new Tuple<int, string>(11, "Cancel-" + clientRequestId),
                    new Tuple<int, string>(54, side),
                    new Tuple<int, string>(60, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(55, symbol)
                };

                SendFixMessage(tags);
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Cancel order failed, {1}", DateTime.Now, ex.Message);
                return false;
            }
        }

        public bool ToggleOrder(string clOrdID, bool activated)
        {
            try
            {
                var tags = new List<Tuple<int, string>> {
                    new Tuple<int, string>(35, "TO"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(41, clOrdID),
                    new Tuple<int, string>(11, "Toggle-" + clOrdID),
                    new Tuple<int, string>(6218, activated ? "1" : "0")
                };

                SendFixMessage(tags);
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Cancel order failed, {1}", DateTime.Now, ex.Message);
                return false;
            }
        }

        public bool RequestOrderAllocation(IAllocationRequest request)
        {
            try
            {
                var tags = new List<Tuple<int, string>> {
                    new Tuple<int, string>(35, "J"),
                    new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                    new Tuple<int, string>(49, SenderId),
                    new Tuple<int, string>(56, TargetId),
                    new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                    new Tuple<int, string>(70, request.AllocId),
                    new Tuple<int, string>(71, "0"), // AllocTransType: New
                    new Tuple<int, string>(626, "1"), // AllocType: Calculated
                    new Tuple<int, string>(857, "1"), // AllocNoOrdersType: Explicit
                    new Tuple<int, string>(55, request.Symbol),
                    new Tuple<int, string>(15, request.Currency),
                    new Tuple<int, string>(54, request.Side.ToUpper() == "BUY" ? "1" : "2"),
                    new Tuple<int, string>(53, request.Quantity.ToString()),
                    new Tuple<int, string>(6, request.AvgPrice.ToString()),
                    new Tuple<int, string>(75, request.TradeDate),
                    new Tuple<int, string>(64, request.SettlementDate)
                };

                tags.Add(new Tuple<int, string>(73, request.Orders.Count.ToString()));
                foreach (IAllocOrder allocOrder in request.Orders)
                {
                    tags.Add(new Tuple<int, string>(11, allocOrder.ClOrdId));
                    tags.Add(new Tuple<int, string>(38, allocOrder.Quantity.ToString()));
                    tags.Add(new Tuple<int, string>(799, allocOrder.AvgPrice.ToString()));
                }

                tags.Add(new Tuple<int, string>(78, request.Allocations.Count.ToString()));
                foreach (IAllocation alloc in request.Allocations)
                {
                    tags.Add(new Tuple<int, string>(79, alloc.Account));
                    tags.Add(new Tuple<int, string>(80, alloc.Quantity.ToString()));
                }

                SendFixMessage(tags);
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Cancel order failed, {1}", DateTime.Now, ex.Message);
                return false;
            }
        }

        private static string CreateFixMessage(IEnumerable<Tuple<int, string>> tags) {
            var body = tags.Aggregate(string.Empty, (msg, tag) => string.Format("{1}{2}={3}{0}",FIXSEPARATOR, msg, tag.Item1, tag.Item2));
            body = string.Format("8={1}{0}9={2}{0}{3}", FIXSEPARATOR, BEGINSTRING, body.Length, body);
            return string.Format("{0}{1}", body, GenerateFixCheckSum(body));
        }

        public static string GenerateFixCheckSum(string fixMessage) {
            var checksum = fixMessage.ToCharArray().Aggregate(0, (current, c) => current + c);
            return string.Format("10={0:D3}{1}", checksum % 256, FIXSEPARATOR);
        }

        private void SendTestReply(IEnumerable<Tuple<int, string>> fixTags) {
            var testIdTag = fixTags.Where(tag => tag.Item1 == 112).ToArray();

            if (testIdTag.Length < 1) return;

            var tags = new[] {
                new Tuple<int, string>(35, "1"), 
                new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)), 
                new Tuple<int, string>(49, SenderId), 
                new Tuple<int, string>(56, TargetId), 
                new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                new Tuple<int, string>(112, testIdTag[0].Item2)
            };

            SendFixMessage(tags);
            
        }

        private void SendHeartBeatReply() {
            var tags = new [] {
                new Tuple<int, string>(35, "0"), 
                new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)), 
                new Tuple<int, string>(49, SenderId), 
                new Tuple<int, string>(56, TargetId), 
                new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff"))
            };

            SendFixMessage(tags);
            
        }

        private bool SendLogonRequest() {
            if (ResetSequenceNumber) _sequenceId = 0;
            try {
                var tags = new[] {
                                     new Tuple<int, string>(35, "A"),
                                     new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                                     new Tuple<int, string>(49, SenderId),
                                     new Tuple<int, string>(56, TargetId),
                                     new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")),
                                     new Tuple<int, string>(98, EncryptionMethod),
                                     new Tuple<int, string>(108, HeartBeatInterval.ToString(CultureInfo.InvariantCulture)),
                                     new Tuple<int, string>(141, ResetSequenceNumber ? "Y" : "N")
                                 };

                SendFixMessage(tags);
                return true;
            } catch(Exception ex) {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Log On Request Failed, {1}", DateTime.Now, ex.Message);
                return false;
            }
        }

        private bool SendLogoutRequest() {
            try {
                var tags = new[] {
                                     new Tuple<int, string>(35, "5"),
                                     new Tuple<int, string>(34, SequenceId.ToString(CultureInfo.InvariantCulture)),
                                     new Tuple<int, string>(49, SenderId),
                                     new Tuple<int, string>(56, TargetId),
                                     new Tuple<int, string>(52, DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff"))
                                 };

                SendFixMessage(tags);
                
                return true;
            } catch(Exception ex) {
                _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - LoggedOut failed, {1}", DateTime.Now, ex.Message);
                _logger.WriteLine();
                return false;
            }
        }

        private void SendFixMessage(IEnumerable<Tuple<int, string>> tags) {
            var message = CreateFixMessage(tags);

            _logger.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff} - Sending: {1}", DateTime.Now, message.Replace(FIXSEPARATOR, '|'));

            var stream = _client.GetStream();
            var encoder = new UTF8Encoding();

            var buffer = encoder.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
    }
}
