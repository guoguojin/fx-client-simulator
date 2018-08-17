using System;

namespace FXPricingControl {
    public class MarketDataRequestArgs : EventArgs {
        public string Symbol { get; set; }
        public string Tenor { get; set; }
        public string Tier { get; set; }
        public DateTime SettlementDate { get; set; }
    }
}
