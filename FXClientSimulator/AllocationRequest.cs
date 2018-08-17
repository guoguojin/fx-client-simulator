using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIXClient;

namespace FXClientSimulator
{
    public class AllocationAlloc : IAllocation
    {
        public string Account { get; set; }
        public decimal Quantity { get; set; }
    }

    public class AllocationOrder : IAllocOrder
    {
        public string ClOrdId { get; set; }
        public decimal Quantity { get; set; }
        public decimal AvgPrice { get; set; }
    }

    public class AllocationRequest : IAllocationRequest
    {
        public string AllocId { get; set; }
        public string Side { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public string Currency { get; set; }
        public decimal AvgPrice { get; set; }
        public string TradeDate { get; set; }
        public string SettlementDate { get; set; }
        public IList<IAllocOrder> Orders { get; set; }
        public IList<IAllocation> Allocations { get; set; }

        public AllocationRequest()
        {
            Orders = new List<IAllocOrder>();
            Allocations = new List<IAllocation>();
        }
    }
}
