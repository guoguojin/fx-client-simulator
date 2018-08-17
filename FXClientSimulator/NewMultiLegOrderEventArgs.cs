using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FXPricingControl;

namespace FIXClient
{
    public class NewMultiLegOrderEventArgs : EventArgs
    {
        public string OrderType { get; set; }
        public NewAutoOrderEventArgs[] Legs { get; set; }
        public int AlertType { get; set; }
        public string TIF { get; set; }
        public string ActiveTimeStamp { get; set; }
        public string ActiveTimeZone { get; set; }
        public string ExpireTimeStamp { get; set; }
        public string ExpireTimeZone { get; set; }
    } 
}
