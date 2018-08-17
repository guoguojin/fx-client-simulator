using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FIXClient;

namespace FXPricingControl {
    public partial class FXPricingControl : UserControl {
        private delegate void PriceUpdateCallBack(IEnumerable<Tuple<decimal, decimal, string>> bids, IEnumerable<Tuple<decimal, decimal, string>> asks);
        private delegate void TierChangeCallBack(object sender, EventArgs e);
        private delegate void SymbolChangeCallBack(object sender, EventArgs e);

        public string Symbol { get; private set; }
        public string Tier { get; private set; }
        public string SubscribedTenor { get; private set; }

        //private string GetTier() {
        //    if (cmbTier.InvokeRequired) {
        //        Invoke((GetTierCallBack) GetTier);
        //    } 

        //    return cmbTier.Text;
        //}

        //private string GetSymbol() {
        //    if (cmbSymbol.InvokeRequired) Invoke((GetSymbolCallBack) GetSymbol);
        //    return cmbSymbol.Text;
        //}

        private enum Side {
            Buy,
            Sell
        }

        private Tuple<decimal, decimal, string>[] _currentBidPrices;
        private Tuple<decimal, decimal, string>[] _currentAskPrices;

        public FXPricingControl() {
            InitializeComponent();

            lblAskQuoteId.Visible = false;
            lblBidQuoteId.Visible = false;

            setDefaultDate();
        }

        public void SetDisplayQuoteId(bool display) {
            lblAskQuoteId.Visible = display;
            lblBidQuoteId.Visible = display;
        }

        public void SetSymbols(string[] symbols) {
            cmbSymbol.Items.Clear();
            cmbSymbol.Items.AddRange(symbols.Select(item => (object) item).ToArray());
            cmbSymbol.SelectedIndex = -1;
        }

        public void SetTenors(string[] tenors) {
            cmbTenor.Items.Clear();
            cmbTenor.Items.AddRange(tenors.Select(item => (object) item).ToArray());
            cmbTenor.SelectedIndex = 0;
        }

        public void SetTiers(string[] tiers) {
            cmbTier.Items.Clear();
            cmbTier.Items.AddRange(tiers.Select(item => (object) item).ToArray());
            cmbTier.SelectedIndex = 0;
        }

        public void ResetControl() {
            cmbSymbol.SelectedIndex = -1;
            cmbTier.SelectedIndex = 0;
            cmbCcy.Items.Clear();
            cmbCcy.SelectedIndex = -1;
            cmbCcy.Text = string.Empty;

            cmbQuantity.Items.Clear();
            cmbQuantity.SelectedIndex = -1;

            lblAsk.Text = "0.00";
            lblAskBps.Text = "00";
            lblAskPips.Text = "00";
            lblBid.Text = "0.00";
            lblBidBps.Text = "00";
            lblBidPips.Text = "00";
            lblAskQuoteId.Text = string.Empty;
            lblBidQuoteId.Text = string.Empty;
        }

        public event EventHandler OnNewOrderSimple;
        public event EventHandler OnSubscribeMarketData;
        public event EventHandler OnNewOrderDetailed;
        public event EventHandler OnNewRFQRequest;
        public event EventHandler OnUnsubscribeMarketData;

        public void UpdatePrices(IEnumerable<Tuple<decimal, decimal, string>> bids, IEnumerable<Tuple<decimal, decimal, string>> asks) {
            if (cmbQuantity.InvokeRequired) {
                var priceUpdate = new PriceUpdateCallBack(UpdatePrices);
                Invoke(priceUpdate, bids, asks);
            } else {
                _currentBidPrices = bids.ToArray();
                _currentAskPrices = asks.ToArray();

                var amounts = new List<string>();

                foreach (var px in _currentBidPrices.Where(px => !amounts.Contains(px.Item1.ToString(CultureInfo.InvariantCulture)))) {
                    amounts.Add(px.Item1.ToString(CultureInfo.InvariantCulture));
                }

                foreach (var px in _currentAskPrices.Where(px => !amounts.Contains(px.Item1.ToString(CultureInfo.InvariantCulture)))) {
                    amounts.Add(px.Item1.ToString(CultureInfo.InvariantCulture));
                }

                cmbQuantity.Items.Clear();
                cmbQuantity.Items.AddRange(amounts.Select(item => (object) item).ToArray());

                UpdateDisplay();
            }
        }

        public Tuple<decimal, decimal, string> LookupPrice(decimal quantity, bool isBuy)
        {
            Tuple<decimal, decimal, string>[] prices = null;

            if (isBuy)
            {
                prices = _currentAskPrices;
            }
            else
            {
                prices = _currentBidPrices;
            }

            foreach (Tuple<decimal, decimal, string> price in prices)
            {
                if (price.Item1 == quantity)
                {
                    return price;
                }
            }

            return new Tuple<decimal, decimal, string>(quantity, -1.0m, "");
        }

        private void UpdateDisplay() {
            if (_currentBidPrices.Length < 1 || _currentAskPrices.Length < 1) return;

            var currentBid = _currentBidPrices[0].Item2;
            var currentAsk = _currentAskPrices[0].Item2;

            decimal quantity ;

            if (!decimal.TryParse(cmbQuantity.Text, out quantity)) return;

            foreach (var bid in _currentBidPrices.Where(bid => bid.Item1 <= quantity).OrderBy(bid => bid.Item1)) {
                currentBid = bid.Item2;
                lblBidQuoteId.Text = bid.Item3;
            }

            foreach (var ask in _currentAskPrices.Where(ask => ask.Item1 <= quantity).OrderBy(ask => ask.Item1)) {
                currentAsk = ask.Item2;
                lblAskQuoteId.Text = ask.Item3;
            }

            lblSpread.Text = (currentAsk - currentBid).ToString("0.000");
            lblHighPrice.Text = currentAsk.ToString("0.000000");
            lblLowPrice.Text = currentBid.ToString("0.000000");

            UpdateBidPrice(FormatPrice(lblLowPrice.Text));
            UpdateAskPrice(FormatPrice(lblHighPrice.Text));
        }

        private Tuple<string, string, string> FormatPrice(string formattedPrice)
        {
            int len = formattedPrice.Length;
            string first = formattedPrice.Substring(0, len - 4);
            string second = formattedPrice.Substring(first.Length, 2);
            string third = formattedPrice.Substring(len - 2, 2);
            return Tuple.Create(first, second, third);
        }

        /*
        private Tuple<string, string, string> FormatPrice(decimal price) {
            var pips = (int)(price * 10000M) % 100;
            var bps = (int)(price * 1000000M) % 100;

            return Tuple.Create(price.ToString("0.00"), pips.ToString("00"), bps.ToString("00"));
        }
        */

        private void UpdateBidPrice(Tuple<string, string, string> formattedPrice) {
            lblBid.Text = formattedPrice.Item1;
            lblBidPips.Text = formattedPrice.Item2;
            lblBidBps.Text = formattedPrice.Item3;
        }

        private void UpdateAskPrice(Tuple<string, string, string> formattedPrice) {
            lblAsk.Text = formattedPrice.Item1;
            lblAskPips.Text = formattedPrice.Item2;
            lblAskBps.Text = formattedPrice.Item3;
        }

        private void CmbSymbolSelectedIndexChanged(object sender, EventArgs e) {
            if (cmbSymbol.InvokeRequired) {
                Invoke((SymbolChangeCallBack)CmbSymbolSelectedIndexChanged, sender, e);
            } else {
                if (cmbSymbol.SelectedIndex < 1) {
                    UnsubscribeMarketData();
                    cmbCcy.Items.Clear();
                    Symbol = string.Empty;
                    return;
                }

                Symbol = cmbSymbol.Text;

                cmbCcy.Items.Clear();
                cmbCcy.Items.Add(Symbol.Substring(0, 3));
                cmbCcy.Items.Add(Symbol.Substring(4));
                cmbCcy.SelectedIndex = 0;

                if (cmbSymbol.SelectedIndex < 1) return;

                SubscribeMarketData();
            }
        }

        private void CmbQuantitySelectedIndexChanged(object sender, EventArgs e) {
            UpdateDisplay();
        }

        private void CmbQuantityTextUpdate(object sender, EventArgs e) {
            UpdateDisplay();
        }

        private void LblBidPipsDoubleClick(object sender, EventArgs e) {
            HandleNewOrderEvent(Side.Sell);
        }

        private void HandleNewOrderEvent(Side side) {
            var newOrderHandler = OnNewOrderSimple;

            decimal parseValue;

            var orderEventArgs = new NewAutoOrderEventArgs {
                Type = "H", // Previously quoted
                Symbol = cmbSymbol.Text,
                Currency = cmbCcy.Text,
                Side = side.ToString(),
                Amount = (decimal.TryParse(cmbQuantity.Text, out parseValue)) ? parseValue : 0M, 
                Price = side == Side.Buy ?
                        (decimal.TryParse(lblAsk.Text + lblAskPips.Text + lblAskBps.Text, out parseValue)) ? parseValue : 0M :
                        (decimal.TryParse(lblBid.Text + lblBidPips.Text + lblBidBps.Text, out parseValue)) ? parseValue : 0M,
                QuoteId = side == Side.Sell ? lblBidQuoteId.Text : lblAskQuoteId.Text,
                Tenor = cmbTenor.Text,
                SettlementDate = dtSettlement.Value,
                Tier = cmbTier.Text,
                Bid = (decimal.TryParse(lblBid.Text + lblBidPips.Text + lblBidBps.Text, out parseValue)) ? parseValue : 0M,
                Ask = (decimal.TryParse(lblAsk.Text + lblAskPips.Text + lblAskBps.Text, out parseValue)) ? parseValue : 0M,
                BidQuoteId = lblBidQuoteId.Text,
                AskQuoteId = lblAskQuoteId.Text,
                TIF = "1",  // GTC,
                AlertType = 3 // Email & SMS
            };


            if (newOrderHandler != null) newOrderHandler(this, orderEventArgs);
            
        }

        private void LblBidDoubleClick(object sender, EventArgs e) {
            HandleNewOrderEvent(Side.Sell);
        }

        private void LblBidBpsDoubleClick(object sender, EventArgs e) {
            HandleNewOrderEvent(Side.Sell);
        }

        private void LblAskDoubleClick(object sender, EventArgs e) {
            HandleNewOrderEvent(Side.Buy);
        }

        private void LblAskPipsDoubleClick(object sender, EventArgs e) {
            HandleNewOrderEvent(Side.Buy);
        }

        private void LblAskBpsDoubleClick(object sender, EventArgs e) {
            HandleNewOrderEvent(Side.Buy);
        }

        private void PanelBuyDoubleClick(object sender, EventArgs e) {
            HandleNewOrderEvent(Side.Sell);
        }

        private void PanelSellDoubleClick(object sender, EventArgs e) {
            HandleNewOrderEvent(Side.Buy);
        }

        private void CmbTierSelectedIndexChanged(object sender, EventArgs e) {
            if (cmbTier.InvokeRequired) {
                Invoke((TierChangeCallBack) CmbTierSelectedIndexChanged, sender, e);
            } else {
                Tier = cmbTier.Text;
                
                if (cmbSymbol.SelectedIndex < 1) return; 

                SubscribeMarketData();
            }
        }
        
        private void SubscribeMarketData() {
            var bids = new[] { Tuple.Create(0M, 0M, string.Empty) };
            var asks = new[] { Tuple.Create(0M, 0M, string.Empty) };

            UpdatePrices(bids, asks);

            var symbolChangedHandler = OnSubscribeMarketData;

            if (symbolChangedHandler != null) symbolChangedHandler(this, new MarketDataRequestArgs { Symbol = cmbSymbol.Text, Tier = cmbTier.Text, Tenor = cmbTenor.Text, SettlementDate = dtSettlement.Value });

            // We should be set this flag based on the response to the market data request...
            SubscribedTenor = cmbTenor.Text;
        }

        private void UnsubscribeMarketData() {
            var bids = new[] { Tuple.Create(0M, 0M, string.Empty) };
            var asks = new[] { Tuple.Create(0M, 0M, string.Empty) };

            UpdatePrices(bids, asks);

            var symbolChangedHandler = OnUnsubscribeMarketData;

            if (symbolChangedHandler != null) symbolChangedHandler(this, new MarketDataRequestArgs { Symbol = Symbol, Tier = cmbTier.Text, Tenor = cmbTenor.Text, SettlementDate = dtSettlement.Value });

            // We should be set this flag based on the response to the market data request...
            SubscribedTenor = cmbTenor.Text;
        }

        private void NewRFQContextMenuItemClick(object sender, EventArgs e) {
            var newRFQHandler = OnNewRFQRequest;

            if (newRFQHandler != null) newRFQHandler(this, new RFQRequestArgs {Symbol = cmbSymbol.Text, Tier = cmbTier.Text});
        }

        private void NewOrderContextMenuItemClick(object sender, EventArgs e) {
            var newOrderHandler = OnNewOrderDetailed;

            decimal parseValue;

            var orderEventArgs = new NewOrderEventArgs {
                Symbol = cmbSymbol.Text,
                NearCurrency = cmbCcy.Text,
                Side = string.Empty,
                NearAmount = (decimal.TryParse(cmbQuantity.Text, out parseValue)) ? parseValue : 0M,
                LastSpotRate = 0M,
                QuoteId = string.Empty,
                NearTenor = cmbTenor.Text,
                NearSettlementDate = dtSettlement.Value,
                Tier = cmbTier.Text,
                FarSettlementDate = dtSettlement.Value,                
            };


            if (newOrderHandler != null) newOrderHandler(this, orderEventArgs);

        }

        private void setDefaultDate()
        {
            // Set a T+3  as default value (skipping weekend)
            DateTime dt = DateTime.Today;
            int offset = 0;
            while (offset < 2)
            {
                dt = dt.AddDays(1);
                if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                offset++;
            }
            dtSettlement.Text = dt.ToLongDateString();
        }
    }
}
