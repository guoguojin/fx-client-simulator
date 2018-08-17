using System;
using System.Collections.Generic;

namespace FIXClient {
    public class NewOrderEventArgs : EventArgs {
        public string ClientRequestId { get; set; }
        public string Symbol { get; set; }
        public string Tier { get; set; }
        public string QuoteId { get; set; }
        public string InstrumentType { get; set; }
        public string OrderType { get; set; }
        public decimal NearAmount { get; set; }
        public string NearCurrency { get; set; }
        public string NearTenor { get; set; }
        public DateTime NearSettlementDate { get; set; }
        public List<Tuple<string, decimal>> NearAllocations { get; set; }
        public decimal FarAmount { get; set; }
        public string FarCurrency { get; set; }
        public string FarTenor { get; set; }
        public DateTime FarSettlementDate { get; set; }
        public List<Tuple<string, decimal>> FarAllocations { get; set; }
        public string Side { get; set; }
        public string TIF { get; set; }
        public decimal LastSpotRate { get; set; }
        public decimal LastNearForwardPoints { get; set; }
        public decimal LastFarForwardPoints { get; set; }
        public decimal LastNearAllInPrice { get; set; }
        public decimal LastFarAllInPrice { get; set; }
        public int AlertType { get; set; }
    }
}
