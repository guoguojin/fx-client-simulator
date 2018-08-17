using System;

namespace FIXClient {
    public class ForwardMarketDataRequest : IMarketDataRequest {
        private static long _requestId;

        private static long RequestId {
            get {
                if (_requestId == long.MaxValue) _requestId = 0L;
                return ++_requestId;
            }
        }

        static ForwardMarketDataRequest() { _requestId = 0L; }

        public ForwardMarketDataRequest(string symbol, string tenor) : this (symbol, tenor, true) { }

        public ForwardMarketDataRequest(string symbol, string tenor, bool subscribe) {
            Symbol = symbol;
            Tenor = tenor;
            IsSubscribe = subscribe;
            ClientRequestId = string.Format("FWMD.{0}.{1}{2:yyyyMMddHHmmss}.{3, 12:D12}", Symbol, Tenor, DateTime.Now, RequestId);
        }

        public string ClientRequestId { get; private set; }
        public string Symbol { get; set; }
        public string Tenor { get; set; }
        public DateTime SettlementDate { get; set; }
        public string Tier { get; set; }
        public bool IsSubscribe { get; private set; }
    }
}
