using System;

namespace FXPricingControl {
    public class NewAutoOrderEventArgs : EventArgs {
        public string Type { get; set; }
        public string Symbol { get; set; }
        public string Tier { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Tenor { get; set; }
        public DateTime SettlementDate { get; set; }
        public string QuoteId { get; set; }
        public string Side { get; set; }
        public decimal Price { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public string BidQuoteId { get; set; }
        public string AskQuoteId { get; set; }
        public string TIF { get; set; }
        public string BenchmarkType { get; set; }
        public string ActiveTimeStamp { get; set; }
        public string ActiveTimeZone { get; set; }
        public string ExpireTimeStamp { get; set; }
        public string ExpireTimeZone { get; set; }
        public string Account { get; set; }
        public int AlertType { get; set; }
    }
}
