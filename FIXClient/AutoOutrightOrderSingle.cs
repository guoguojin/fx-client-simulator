using System;

namespace FIXClient {
    public class AutoOutrightOrderSingle : INewOrderSingle {
        public string ClientRequestId { get; private set; }
        public string Account { get; set; }
        public string Symbol { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public string Tenor { get; set; }
        public string Currency { get; set; }
        public string QuoteId { get; set; }
        public int Side { get; set; }
        public DateTime SettlementDate { get; set; }
        public bool IsRFQ { get; set; }
        public string OrderType { get; set; }
        public string TIF { get; set; }
        public string BenchmarkType { get; set; }
        public string ActiveTimeStamp { get; set; }
        public string ActiveTimeZone { get; set; }
        public string ExpireTimeStamp { get; set; }
        public string ExpireTimeZone { get; set; }
        public decimal LastForwardPoints { get; set; }
        public decimal LastSpotRate { get; set; }
        public int AlertType { get; set; }
        public string SpotQuoteId { get; set; }

        private static long _requestId;

        private static long RequestId {
            get {
                if (_requestId == long.MaxValue) _requestId = 0;
                return ++_requestId;
            }
        }

        public AutoOutrightOrderSingle(string symbol, string tenor, bool isRFQ, string clientReqId) {
            Symbol = symbol;
            Tenor = tenor;
            IsRFQ = isRFQ;
            if (IsRFQ)
            {
                ClientRequestId = clientReqId;
            }
            else
            {
                ClientRequestId = string.Format("{0}.{1}.{2}{3:yyyyMMddHHmmss}.{4, 12:D12}", isRFQ ? "RFQFW" : "STFW", Symbol, Tenor, DateTime.Now, RequestId);
            }
        }
    }
}
