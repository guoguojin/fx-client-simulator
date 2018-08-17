using System;

namespace FIXClient {
    public interface IMarketDataRequest {
        string ClientRequestId { get; }
        string Symbol { get; set; }
        string Tenor { get; }
        DateTime SettlementDate { get; set; }
        string Tier { get; set; }
        bool IsSubscribe { get; }
    }
}
