using System;

namespace FIXClient {
    public class UpdateStatusEventArgs : EventArgs {
        public FIXClientStatus Status { get; set; }
        public string Message { get; set; }
    }
}
