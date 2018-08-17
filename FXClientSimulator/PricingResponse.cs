using System.ComponentModel;

namespace FXClientSimulator {
    class PricingResponse : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SendPropertyChanged(string property) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string RequestId { get; private set; }
        public string QuoteId { get; private set; }
        public PricingRequest Request { get; private set; }

        private decimal _amount;
        private decimal _lastSpotBid;
        private decimal _lastSpotAsk;
        private decimal _nearBidPoints;
        private decimal _nearAskPoints;
        private decimal _nearAllInBid;
        private decimal _nearAllInAsk;
        private decimal _farBidPoints;
        private decimal _farAskPoints;
        private decimal _farAllInBid;
        private decimal _farAllInAsk;

        public decimal Amount {
            get { return _amount; }
            set {
                _amount = value;
                SendPropertyChanged("Amount");
            }
        }

        public decimal LastSpotBid {
            get { return _lastSpotBid; } 
            set {
                _lastSpotBid = value;
                SendPropertyChanged("LastSpotBid");
            }
        }

        public decimal LastSpotAsk {
            get { return _lastSpotAsk; } 
            set {
                _lastSpotAsk = value;
                SendPropertyChanged("LastSpotAsk");
            }
        }

        public decimal NearBidPoints {
            get { return _nearBidPoints; } 
            set {
                _nearBidPoints = value;
                SendPropertyChanged("NearBidPoints");
            }
        }

        public decimal NearAskPoints {
            get { return _nearAskPoints; } 
            set {
                _nearAskPoints = value;
                SendPropertyChanged("NearAskPoints");
            }
        }

        public decimal NearAllInBid {
            get { return _nearAllInBid; } 
            set {
                _nearAllInBid = value;
                SendPropertyChanged("NearAllInBid");
            }
        }

        public decimal NearAllInAsk {
            get { return _nearAllInAsk; } 
            set {
                _nearAllInAsk = value;
                SendPropertyChanged("NearAllInAsk");
            }
        }

        public decimal FarBidPoints {
            get { return _farBidPoints; } 
            set {
                _farBidPoints = value;
                SendPropertyChanged("FarBidPoints");
            }
        }

        public decimal FarAskPoints {
            get { return _farAskPoints; } 
            set {
                _farAskPoints = value;
                SendPropertyChanged("FarAskPoints");
            }
        }

        public decimal FarAllInBid {
            get { return _farAllInBid; } 
            set {
                _farAllInBid = value;
                SendPropertyChanged("FarAllInBid");
            }
        }

        public decimal FarAllInAsk {
            get { return _farAllInAsk; } 
            set {
                _farAllInAsk = value;
                SendPropertyChanged("FarAllInAsk");
            }
        }

        public PricingResponse(string requestId, string quoteId, PricingRequest request) {
            RequestId = requestId;
            QuoteId = quoteId;
            Request = request;
        }
    }
}
