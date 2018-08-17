using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using FIXClient;

namespace FXClientSimulator {
    class PricingRequest : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler PricingResponseAdded;

        private void SendPropertyChanged(string property) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string RequestId { get; private set; }
        public string Symbol { get; private set; }
        public string Tier { get; private set; }
        private string _nearTenor;
        private string _farTenor;
        private DateTime _nearSettlementDate;
        private DateTime _farSettlementDate;
        private string _side;
        private string _account;
        private string _currency;
        private decimal _nearAmount;
        private decimal _farAmount;
        private List<Tuple<string, decimal>> _nearAllocations;
        private List<Tuple<string, decimal>> _farAllocations;
        
        public string NearTenor {
            get { return _nearTenor; }
            set {
                _nearTenor = value;
                SendPropertyChanged("NearTenor");
            }
        }

        public string FarTenor { 
            get { return _farTenor; } 
            set {
                _farTenor = value;
                SendPropertyChanged("FarTenor");
            } 
        }

        public DateTime NearSettlementDate {
            get { return _nearSettlementDate; } 
            set {
                _nearSettlementDate = value;
                SendPropertyChanged("NearSettlementDate");
            }
        }
        
        public DateTime FarSettlementDate {
            get { return _farSettlementDate; } 
            set {
                _farSettlementDate = value;
                SendPropertyChanged("FarSettlementDate");
            }
        }

        public string Side {
            get { return _side; } 
            set {
                _side = value;
                SendPropertyChanged("Side");
            }
        }
        
        public string Account {
            get { return _account; } 
            set {
                _account = value;
                SendPropertyChanged("Account");
            }
        }

        public string Currency {
            get { return _currency; } 
            set {
                _currency = value;
                SendPropertyChanged("Currency");
            }
        }

        public decimal NearAmount {
            get { return _nearAmount; } 
            set {
                _nearAmount = value;
                SendPropertyChanged("NearAmount");
            }
        }

        public decimal FarAmount {
            get { return _farAmount; } 
            set {
                _farAmount = value;
                SendPropertyChanged("FarAmount");
            }
        }

        public List<Tuple<string, decimal>> NearAllocations {
            get { return _nearAllocations; } 
            set {
                _nearAllocations = value;
                SendPropertyChanged("NearAllocations");
            }
        }

        public List<Tuple<string, decimal>> FarAllocations {
            get { return _farAllocations; } 
            set {
                _farAllocations = value;
                SendPropertyChanged("FarAllocations");
            }
        }

        public EntitySet<PricingResponse> Prices { get; private set; }

        public void AddPrice(PricingResponse price) {
            Prices.Add(price);

            var pricingResponseEventHandler = PricingResponseAdded;

            var args = new PricingResponseEventArgs {
                                                        QuoteId = price.QuoteId,
                                                        Amount = price.Amount,
                                                        LastSpotBid = price.LastSpotBid,
                                                        LastSpotAsk = price.LastSpotAsk,
                                                        NearBidPoints = price.NearBidPoints,
                                                        NearAskPoints = price.NearAskPoints,
                                                        NearAllInBid = price.NearAllInBid,
                                                        NearAllInAsk = price.NearAllInAsk,
                                                        FarBidPoints = price.FarBidPoints,
                                                        FarAskPoints = price.FarAskPoints,
                                                        FarAllInBid = price.FarAllInBid,
                                                        FarAllInAsk = price.FarAllInAsk
                                                    };

            if (pricingResponseEventHandler != null) pricingResponseEventHandler(this, args);
        }

        public PricingRequest(string requestId, string symbol, string tier) { 
            RequestId = requestId;
            Symbol = symbol;
            Tier = tier;
            Prices = new EntitySet<PricingResponse>();
            NearAllocations = new List<Tuple<string, decimal>>();
            FarAllocations = new List<Tuple<string, decimal>>();
        }

        public PricingRequest(IMarketDataRequest request) : this(request.ClientRequestId, request.Symbol, request.Tier) {
            NearTenor = request.Tenor;
            NearSettlementDate = request.SettlementDate;
            Side = "2-Way";
        }

        public PricingRequest(IQuoteRequest request) : this(request.ClientRequestId, request.Symbol, string.Empty) {
            NearTenor = request.Tenor;
            NearAmount = request.Amount;
            Account = request.Account;
            Side = request.Side.ToString();
            NearSettlementDate = request.SettlementDate;
            Currency = request.Currency;

            if (request.GetType() != typeof (SwapQuoteRequest)) {
                NearAllocations = request.GetType() == typeof(SpotQuoteRequest) ? ((SpotQuoteRequest) request).Allocations : ((ForwardQuoteRequest)request).Allocations;
                return;
            }

            var swapRequest = (SwapQuoteRequest) request;
            NearAllocations = swapRequest.Allocations;
            FarTenor = swapRequest.FarTenor;
            FarSettlementDate = swapRequest.FarSettleDate;
            FarAmount = swapRequest.FarAmount;
            FarAllocations = swapRequest.FarAllocations;

            Prices = new EntitySet<PricingResponse>();
        }
    }
}
