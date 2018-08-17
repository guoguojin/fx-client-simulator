namespace FIXClient {
    public enum FIXClientStatus {
        ConnectionError,
        Connected,
        DisconnectionError,
        Disconnected,
        MarketDataSubscribed,
        MarketDataRequestRejected,
        Quoting,
        QuoteRequestRejected,
        OrderSubmitted,
        OrderPending,
        OrderAccepted,
        OrderRejected,
        OrderCancelPending,
        OrderCancelAccepted,
        OrderCancelRejected,
        OrderFilled,
        AllocationsSubmitted,
        AllocationsAccepted,
        AllocationsRejected
    }
}
