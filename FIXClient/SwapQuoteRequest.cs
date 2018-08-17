using System;
using System.Collections.Generic;

namespace FIXClient {
    public class SwapQuoteRequest : IQuoteRequest {
        private static long _requestId;

        static SwapQuoteRequest() { _requestId = 0L; }
        private static long RequestId {
            get {
                if (_requestId == long.MaxValue) {
                    _requestId = 0L;
                }

                return ++_requestId;
            }
        }

        public SwapQuoteRequest(string account, string symbol, string farTenor) {
            Account = account;
            Symbol = symbol;
            FarTenor = farTenor;
            ClientRequestId = string.Format("SWRFQ.{0}.{1}.{2}{3:yyyyMMddHHmmss}{4, 12:D12}", Account, Symbol, FarTenor, DateTime.Now, RequestId);
            Allocations = new List<Tuple<string, decimal>>();
            FarAllocations = new List<Tuple<string, decimal>>();
        }

        public SwapQuoteRequest(string quoteRequestId) { ClientRequestId = quoteRequestId; }

        public string ClientRequestId { get; private set; }
        public string Account { get; set; }
        public string Symbol { get; set; }
        public decimal Amount { get; set; }
        public string Tenor { get; set; }
        public DateTime SettlementDate { get; set; }
        public string Currency { get; set; }
        public decimal FarAmount { get; set; }
        public string FarTenor { get; set; }
        public DateTime FarSettleDate { get; set; }
        public FixSide Side { get; set; }
        public List<Tuple<string, decimal>> Allocations { get; set; }
        public List<Tuple<string, decimal>> FarAllocations { get; set; } 
    }
}
