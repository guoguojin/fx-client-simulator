using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIXClient
{
    public interface INewOrderMultiLeg
    {
        string OrderType { get; set; }
        string ClientRequestId { get; }
        INewOrderSingle[] Legs { get; set; }
        int AlertType { get; set; }
        string TIF { get; set; }
        string ActiveTimeStamp { get; set; }
        string ActiveTimeZone { get; set; }
        string ExpireTimeStamp { get; set; }
        string ExpireTimeZone { get; set; }
    }
}