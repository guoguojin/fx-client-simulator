using System;

namespace FIXClient {
    public interface INewOrderSingle {
        string ClientRequestId { get; }
        string Account { get; set; }
        string Symbol { get; set; }
        decimal Amount { get; set; }
        decimal Price { get; set; }
        string Tenor { get; set; }
        string Currency { get; set; }
        string QuoteId { get; set; }
        string SpotQuoteId { get; set; }
        int Side { get; set; }
        DateTime SettlementDate { get; set; }
        string OrderType { get; set; }
        string TIF { get; set; }
        string BenchmarkType { get; set; }
        string ActiveTimeStamp { get; set; }
        string ActiveTimeZone { get; set; }
        string ExpireTimeStamp { get; set; }
        string ExpireTimeZone { get; set; }
        int AlertType { get; set; }
    }
}
