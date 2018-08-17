using System;

namespace FXClientSimulator {
     class PricingResponseEventArgs : EventArgs {
         public string RequestId { get; set; }
         public string QuoteId { get; set; }
         public decimal Amount { get; set; }
         public decimal LastSpotBid { get; set; }
         public decimal LastSpotAsk { get; set; }
         public decimal NearBidPoints { get; set; }
         public decimal NearAskPoints { get; set; }
         public decimal NearAllInBid { get; set; }
         public decimal NearAllInAsk { get; set; }
         public decimal FarBidPoints { get; set; }
         public decimal FarAskPoints { get; set; }
         public decimal FarAllInBid { get; set; }
         public decimal FarAllInAsk { get; set; }
         public int RemainingTime { get; set; }
    }
}
