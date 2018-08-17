namespace FXClientSimulator {
    public class OrderRequest {
        public string RequestId { get; private set; }
        public string RequestSource { get; private set; }
        public ClientOrder Order { get; set; }

        public OrderRequest(string requestId, string source) { 
            RequestId = requestId;
            RequestSource = source;
        }
    }
}
