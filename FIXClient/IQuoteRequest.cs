using System;

namespace FIXClient {
    public interface IQuoteRequest {
        string ClientRequestId { get; }
        string Account { get; set; }
        string Symbol { get; set; }
        decimal Amount { get; set; }
        string Tenor { get; }
        DateTime SettlementDate { get; set; }
        string Currency { get; set; }
        FixSide Side { get; set; }
    }
}
