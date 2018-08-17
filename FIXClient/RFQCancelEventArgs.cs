using System;

namespace FIXClient {
    public class RFQCancelEventArgs : EventArgs {
        public string QuoteRequestId { get; set; }
    }
}
