using System;
using System.Collections.Generic;

namespace FIXClient {
    public class SpotQuoteRequest : IQuoteRequest {
        private static long _requestId;

        static SpotQuoteRequest() { _requestId = 0L; }
        private static long RequestId {
            get {
                if (_requestId == long.MaxValue) {
                    _requestId = 0L;
                }

                return ++_requestId;
            }
        }

        public SpotQuoteRequest(string account, string symbol) {
            Tenor = "SP";
            Account = account;
            Symbol = symbol;
            ClientRequestId = string.Format("SPRFQ.{0}.{1}.{2}{3:yyyyMMddHHmmss}{4, 12:D12}", Account, Symbol, Tenor, DateTime.Now, RequestId);

            Allocations = new List<Tuple<string, decimal>>();
        }

        public SpotQuoteRequest(string quoteRequestId) { ClientRequestId = quoteRequestId; }

        public string ClientRequestId { get; private set; }
        public string Account { get; set; }
        public string Symbol { get; set; }
        public decimal Amount { get; set; }
        public string Tenor { get; private set; }
        public DateTime SettlementDate { get; set; }
        public string Currency { get; set; }
        public FixSide Side { get; set; }
        public List<Tuple<string, decimal>> Allocations { get; set; }
    }
}
