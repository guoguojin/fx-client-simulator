using System;

namespace FIXClient {
    public class SpotMarketDataRequest : IMarketDataRequest {
        private static long _requestId;

        private static long RequestId {
            get
            {
                if (_requestId == long.MaxValue) _requestId = 0L;
                return ++_requestId;
            }
        }

        static SpotMarketDataRequest() { _requestId = 0L; }

        public SpotMarketDataRequest(string symbol) : this(symbol, true) {}

        public SpotMarketDataRequest(string symbol, bool subscribe) {
            Symbol = symbol;
            Tenor = "SP";
            ClientRequestId = string.Format("SPMD.{0}.{1}{2:yyyyMMddHHmmss}.{3, 12:D12}", Symbol, Tenor, DateTime.Now, RequestId);
            IsSubscribe = subscribe;
        }

        public string ClientRequestId { get; private set; }
        public string Symbol { get; set; }
        public string Tenor { get; private set; }
        public DateTime SettlementDate { get; set; }
        public string Tier { get; set; }
        public bool IsSubscribe { get; private set; }
    }
}
