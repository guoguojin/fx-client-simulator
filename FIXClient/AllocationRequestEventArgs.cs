using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIXClient
{
    public class AllocationRequestEventArgs : EventArgs
    {
        public string AllocId { get; set; }
        public FixSide Side { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public string Currency { get; set; }
        public decimal AvgPrice { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime SettlementDate { get; set; }
        public List<Tuple<string, decimal, decimal>> Orders { get; set; }
        public List<Tuple<string, decimal>> Allocations { get; set; }
    }
}
