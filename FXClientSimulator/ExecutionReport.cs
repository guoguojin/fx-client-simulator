namespace FXClientSimulator {
    public class ExecutionReport {
        public string RequestId { get; set; }
        public string ReportType { get; set; }
        public string ExecutionType { get; set; }
        public decimal OrderAmount { get; set; }
        public decimal FilledAmount { get; set; }
        public decimal CumulativeAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal FillPrice { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal LastSpotRate { get; set; }
        public string TransactionTime { get; set; }
        public string Status { get; set; }
    }
}
