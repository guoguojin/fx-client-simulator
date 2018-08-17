using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIXClient
{
    public interface IAllocOrder
    {
        string ClOrdId { get; }
        decimal Quantity { get; }
        decimal AvgPrice { get; }
    }

    public interface IAllocation
    {
        string Account { get; }
        decimal Quantity { get; }
    }

    public interface IAllocationRequest
    {
        string AllocId { get; }
        string Side { get; }
        string Symbol { get; }
        decimal Quantity { get; }
        string Currency { get; }
        decimal AvgPrice { get;  }
        string TradeDate { get;  }
        string SettlementDate { get; }
        IList<IAllocOrder> Orders { get; }
        IList<IAllocation> Allocations { get; }        
    }
}
