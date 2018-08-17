using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FXPricingControl {
    public class RFQRequestArgs : EventArgs {
        public string Symbol { get; set; }
        public string Tier { get; set; }
    }
}
