using System;
using System.Collections.Generic;
using System.Data.Linq;

namespace FXClientSimulator {
    public class ClientOrder {
        public event EventHandler ExecutionReportAdded;

        public string RequestId { get; set; }
        public string Symbol { get; set; }
        public string QuoteId { get; set; }
        public string InstrumentType { get; set; }
        public string OrderType { get; set; }
        public decimal NearAmount { get; set; }
        public string NearCurrency { get; set; }
        public string NearTenor { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime NearSettlementDate { get; set; }
        public List<Tuple<string, decimal>> NearAllocations { get; set; }
        public decimal FarAmount { get; set; }
        public string FarCurrency { get; set; }
        public string FarTenor { get; set; }
        public DateTime FarSettlementDate { get; set; }
        public List<Tuple<string, decimal>> FarAllocations { get; set; }
        public string Side { get; set; }
        public decimal LastSpotRate { get; set; }
        public decimal LastNearForwardPoints { get; set; }
        public decimal LastFarForwardPoints { get; set; }
        public decimal LastNearAllInPrice { get; set; }
        public decimal LastFarAllInPrice { get; set; }
        public EntitySet<ExecutionReport> Executions { get; private set; }
        public string Status { get; private set; }
        public string SpotQuoteId { get; set; }

        public decimal AvgPrice { get; private set; }

        public ClientOrder() {
            Executions = new EntitySet<ExecutionReport>();
            Status = "New";
        }

        public void AddExecutionReport(ExecutionReport executionReport) {
            Executions.Add(executionReport);
            AvgPrice = executionReport.AveragePrice;
            Status = executionReport.Status;

            var executionReportAddedEventArgs = new ExecutionReportAddedEventArgs {ExecutionReport = executionReport};
            var executionReportAddedHandler = ExecutionReportAdded;

            if (executionReportAddedHandler != null) executionReportAddedHandler(this, executionReportAddedEventArgs);
        }

        public override string ToString() { return Status; }
    }
}
