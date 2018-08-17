using System;
using System.Collections.Generic;

namespace FIXClient {
    public class FixMessageEventArgs : EventArgs {
        public string FixMessageType { get; private set; }
        public string Symbol { get; private set; }
        public string RequestId { get; set; }
        public string Tier { get; set; }

        public IEnumerable<Tuple<int, string>> FixTags { get; private set; }
        
        public FixMessageEventArgs(string messageType, string symbol, IEnumerable<Tuple<int, string>> fixTags) {
            FixMessageType = messageType;
            Symbol = symbol;
            FixTags = fixTags;
        }
    }
}
