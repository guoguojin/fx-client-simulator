using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FXClientSimulator
{
    public class AllocationRequestEventArgs : EventArgs
    {
        public string AllocId { get; set; }
        public string Side { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public string Currency { get; set; }
        public decimal AvgPrice { get; set; }
        public string TradeDate { get; set; }
        public string SettlementDate { get; set; }
        public List<Tuple<string, decimal, decimal>> Orders { get; set; }
        public List<Tuple<string, decimal>> Allocations { get; set; }
    }
}
