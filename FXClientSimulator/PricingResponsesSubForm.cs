using System;

namespace FXClientSimulator {
    public partial class PricingResponsesSubForm : Extensions.DataGridViewSubForm {
        private readonly PricingRequest _pricingRequest;

        private delegate void UpdatePricingResponseGrid(object sender, EventArgs eventArgs);

        public PricingResponsesSubForm(object dataBoundItem, Extensions.DataGridViewSubformCell cell) : base (dataBoundItem, cell) {
            InitializeComponent();

            _pricingRequest = (PricingRequest) dataBoundItem;
            PricingResponseBindingSource.DataSource = _pricingRequest.Prices;
            PricingResponseBindingNavigator.BindingSource = PricingResponseBindingSource;
            PricingResponseDataGridView.DataSource = PricingResponseBindingSource;

            _pricingRequest.PricingResponseAdded += PricingRequestOnPricingResponseAdded;
        }

        private void PricingRequestOnPricingResponseAdded(object sender, EventArgs eventArgs) {
            if (PricingResponseDataGridView.InvokeRequired) {
                Invoke((UpdatePricingResponseGrid)PricingRequestOnPricingResponseAdded, sender, eventArgs);
            } else {
                var args = (PricingResponseEventArgs) eventArgs;
                var request = (PricingRequest) sender;

                var pricingResponse = new PricingResponse(request.RequestId, args.QuoteId, request) {
                                                                                                        Amount = args.Amount,
                                                                                                        LastSpotBid = args.LastSpotBid,
                                                                                                        LastSpotAsk = args.LastSpotAsk,
                                                                                                        NearBidPoints = args.NearBidPoints,
                                                                                                        NearAskPoints = args.NearAskPoints,
                                                                                                        NearAllInBid = args.NearAllInBid,
                                                                                                        NearAllInAsk = args.NearAllInAsk,
                                                                                                        FarBidPoints = args.FarBidPoints,
                                                                                                        FarAskPoints = args.FarAskPoints,
                                                                                                        FarAllInBid = args.FarAllInBid,
                                                                                                        FarAllInAsk = args.FarAllInAsk
                                                                                                    };

                PricingResponseBindingSource.Add(pricingResponse);
                PricingResponseDataGridView.Refresh();
            }
        }
    }
}
