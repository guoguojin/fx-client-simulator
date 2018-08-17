using System;

namespace FIXClient {
    public interface IFixClient {
        event EventHandler OnMarketDataSnapshot;
        event EventHandler OnMarketDataRequestReject;
        event EventHandler OnQuoteAcknowledgement;
        event EventHandler OnQuote;
        event EventHandler OnQuoteCancel;
        event EventHandler OnLogon;
        event EventHandler OnLogoff;
        event EventHandler OnNewOrderSingle;
        event EventHandler OnExecutionReport;
        event EventHandler OnFXAllocation;
        event EventHandler OnFXAllocationAcknowledgement;
        event EventHandler OnUpdateStatus;

        string Host { get; }
        int Port { get; }
        string SenderId { get; }
        string TargetId { get; }

        bool Connect();
        bool Disconnect();
        bool RequestMarketData(IMarketDataRequest mdRequest);
        bool RequestQuote(IQuoteRequest quoteRequest);
        bool RejectQuote(IQuoteRequest quoteRequest, string quoteId);
        bool SendNewOrderSingle(INewOrderSingle newOrderSingle);
        bool CancelQuoteRequest(string requestId);
        bool RequestOrderAllocation(IAllocationRequest request);
    }
}
