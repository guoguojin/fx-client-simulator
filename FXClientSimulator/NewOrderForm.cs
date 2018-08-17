using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FIXClient;
using FXClientSimulator.Properties;

namespace FXClientSimulator {
    public partial class NewOrderForm : Form {
        private delegate void PriceUpdateCallBack(IEnumerable<Tuple<decimal, decimal, string>> bids, IEnumerable<Tuple<decimal, decimal, string>> asks);

        private Tuple<decimal, decimal, string>[] _currentBidPrices;
        private Tuple<decimal, decimal, string>[] _currentAskPrices;

        public event EventHandler OnSubmitNewOrder;

        public NewOrderForm() {
            InitializeComponent();

            cmbSymbol.Items.AddRange(StaticData.Symbols.Select(item => (object) item).ToArray());
            cmbTier.Items.AddRange(StaticData.Tiers.Select(item => (object) item).ToArray());
            cmbInstrumentType.Items.AddRange(StaticData.RFQTypes.Select(item => (object) item).ToArray());
            cmbNearTenor.Items.AddRange(StaticData.Tenors.Select(item => (object) item).ToArray());
            cmbFarTenor.Items.AddRange(StaticData.Tenors.Select(item => (object) item).ToArray());
            cmbOrderType.Items.AddRange(StaticData.OrderTypes.Keys.Select(item => (object) item).ToArray());
        }

        public NewOrderForm(NewOrderEventArgs args) : this() { 
            cmbSymbol.Text = args.Symbol;
            cmbTier.Text = args.Tier;
            cmbInstrumentType.Text = args.InstrumentType;
            cmbNearCcy.Text = args.NearCurrency;
            cmbNearTenor.Text = args.NearTenor;
            txtNearAmount.Text = args.NearAmount.ToString(CultureInfo.InvariantCulture);
            dtNearSettleDate.Value = args.NearSettlementDate <= DateTime.MinValue ? DateTime.Today : args.NearSettlementDate;
            cmbFarCcy.Text = args.FarCurrency;
            cmbFarTenor.Text = args.FarTenor;
            txtFarAmount.Text = args.FarAmount.ToString(CultureInfo.InvariantCulture);
            dtFarSettleDate.Value = args.FarSettlementDate <= DateTime.MinValue ? DateTime.Today : args.FarSettlementDate;
        }

        public void UpdatePrices(IEnumerable<Tuple<decimal, decimal, string>> bids, IEnumerable<Tuple<decimal, decimal, string>> asks) {
            if (txtNearAmount.InvokeRequired) {
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

                UpdateDisplay();
            }
        }

        private void UpdateDisplay() {
            if (_currentBidPrices.Length < 1 || _currentAskPrices.Length < 1) return;

            var currentBid = _currentBidPrices[0].Item2;
            var currentAsk = _currentAskPrices[0].Item2;

            decimal quantity;

            if (!decimal.TryParse(txtNearAmount.Text, out quantity)) return;

            foreach (var bid in _currentBidPrices.Where(bid => bid.Item1 <= quantity).OrderBy(bid => bid.Item1)) {
                currentBid = bid.Item2;
                lblBidQuoteId.Text = bid.Item3;
            }

            foreach (var ask in _currentAskPrices.Where(ask => ask.Item1 <= quantity).OrderBy(ask => ask.Item1)) {
                currentAsk = ask.Item2;
                lblAskQuoteId.Text = ask.Item3;
            }

            UpdateBidPrice(FormatPrice(currentBid));
            UpdateAskPrice(FormatPrice(currentAsk));
        }

        private Tuple<string, string, string> FormatPrice(decimal price) {
            var pips = (int)(price * 10000M) % 100;
            var bps = (int)(price * 1000000M) % 100;

            return Tuple.Create(price.ToString("0.00"), pips.ToString("00"), bps.ToString("00"));
        }

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

        private void TxtNearAmountTextChanged(object sender, EventArgs e) {
            if (txtNearAmount.Text.Length < 1) return;

            var postFix = (txtNearAmount.Text.Length > 1) ? txtNearAmount.Text.Substring(txtNearAmount.Text.Length - 1).ToUpper() : "";

            int lastDigit;
            float prefixNumber;

            var lastDigitIsNumeric = int.TryParse(postFix, out lastDigit);

            if (lastDigitIsNumeric) return;

            if (!float.TryParse(txtNearAmount.Text.Substring(0, txtNearAmount.Text.Length - postFix.Length), out prefixNumber)) {
                MessageBox.Show(Resources.SysMsg_InvalidAmount, Resources.SysTitle_InvalidInput, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            switch (postFix) {
                case "T":
                    txtNearAmount.Text = (prefixNumber * 1000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
                case "M":
                    txtNearAmount.Text = (prefixNumber * 1000000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
            }
        }

        private void TxtFarAmountTextChanged(object sender, EventArgs e) {
            if (txtFarAmount.Text.Length < 1) return;

            var postFix = (txtFarAmount.Text.Length > 1) ? txtFarAmount.Text.Substring(txtFarAmount.Text.Length - 1).ToUpper() : "";

            int lastDigit;
            float prefixNumber;

            var lastDigitIsNumeric = int.TryParse(postFix, out lastDigit);

            if (lastDigitIsNumeric) return;

            if (!float.TryParse(txtFarAmount.Text.Substring(0, txtFarAmount.Text.Length - postFix.Length), out prefixNumber)) {
                MessageBox.Show(Resources.SysMsg_InvalidAmount, Resources.SysTitle_InvalidInput, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            switch (postFix) {
                case "T":
                    txtFarAmount.Text = (prefixNumber * 1000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
                case "M":
                    txtFarAmount.Text = (prefixNumber * 1000000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
            }
        }

        private void SellOrderDoubleClick(object sender, EventArgs e) {
            var orderHandler = OnSubmitNewOrder;

            if (orderHandler != null) orderHandler(sender, e);
        }

        private void BuyOrderDoubleClick(object sender, EventArgs e) {
            var orderHandler = OnSubmitNewOrder;

            if (orderHandler != null) orderHandler(sender, e);
        }

        private void BtnExitClick(object sender, EventArgs e) {
            Close();
        }

        private void panelSell_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
