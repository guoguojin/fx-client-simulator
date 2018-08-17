using System;

namespace FIXClient {
    public class AutoSpotOrderSingle : INewOrderSingle {
        public string ClientRequestId { get; private set; }
        public string Account { get; set; }
        public string Symbol { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public string Tenor { get; set; }
        public string Currency { get; set; }
        public string QuoteId { get; set; }
        public string SpotQuoteId { get; set; }
        public int Side { get; set; }
        public DateTime SettlementDate { get; set; }
        public bool IsRFQ { get; private set; }
        public string OrderType { get; set; }
        public string TIF { get; set; }
        public string BenchmarkType { get; set; }
        public string ActiveTimeStamp { get; set; }
        public string ActiveTimeZone { get; set; }
        public string ExpireTimeStamp { get; set; }
        public string ExpireTimeZone { get; set; }
        public int AlertType { get; set; }

        private static long _requestId;

        private static long RequestId {
            get {
                if (_requestId == long.MaxValue) _requestId = 0;
                return ++_requestId;
            }
        }

        public AutoSpotOrderSingle(string symbol, string tenor, bool isRFQ, string requestId) {
            Symbol = symbol;
            Tenor = tenor;
            IsRFQ = isRFQ;
            ClientRequestId = IsRFQ ? requestId : string.Format("{0}.{1}.{2}{3:yyyyMMddHHmmss}.{4, 12:D12}", "STSP", Symbol, Tenor, DateTime.Now, RequestId);    
        }

        public AutoSpotOrderSingle(string type, string symbol) {
            OrderType = type;
            Symbol = symbol;
            Tenor = "SP";
            IsRFQ = false;
            ClientRequestId = string.Format("{0}.{1}.{2}{3:yyyyMMddHHmmss}.{4, 12:D12}", "STSP", Symbol, Tenor, DateTime.Now, RequestId);    
        }
    }
}
