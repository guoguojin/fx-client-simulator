using System;

namespace FIXClient {
    public class AutoSwapOrderSingle : INewOrderSingle {
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

        public decimal Amount2 { get; set; }
        public decimal Price2 { get; set; }

        public decimal LastSpotRate { get; set; }
        public decimal LastForwardPoints { get; set; }
        public decimal LastForwardPoints2 { get; set; }
        public string Tenor2 { get; set; }
        public DateTime SettlementDate2 { get; set; }
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

        public AutoSwapOrderSingle(string symbol, string farTenor, bool isRFQ, string requestId)
        {
            Symbol = symbol;
            Tenor2 = farTenor;
            IsRFQ = isRFQ;
            ClientRequestId = IsRFQ ? requestId : string.Format("SWRFQ.{0}.{1}.{2}{3:yyyyMMddHHmmss}{4, 12:D12}", Account, Symbol, Tenor2, DateTime.Now, RequestId);    
        }

        public AutoSwapOrderSingle() {
            ClientRequestId = string.Format("RFQSP.{0}.{1}{2:yyyyMMddHHmmss}.{3, 12:D12}", Symbol, Tenor, DateTime.Now, RequestId);
            IsRFQ = true;
        }
    }
}
