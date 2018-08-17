using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FIXClient;

namespace FXClientSimulator {
    public partial class RFQForm : Form {
        private Tuple<decimal, decimal, decimal, decimal, string> _nearBidPrices;
        private Tuple<decimal, decimal, decimal, decimal, string> _nearAskPrices;

        private Tuple<decimal, decimal, decimal, decimal, string> _farBidPrices;
        private Tuple<decimal, decimal, decimal, decimal, string> _farAskPrices;

        private int remainingQuotingTime;

        public event EventHandler OnSendRFQRequest;
        public event EventHandler OnSendRFQReject;
        public event EventHandler OnSendRFQNewOrder;
        public event EventHandler OnRFQClose;
        public event EventHandler OnPricingResponse;

        private string _quoteRequestId;
        private string _clientOrderId;

        private readonly List<Tuple<string, decimal>> _nearAllocations;
        private readonly List<Tuple<string, decimal>> _farAllocations;

        private bool _holdPrices;

        private delegate void EventHandlerCallBack(object sender, EventArgs e);

        public RFQForm() {
            InitializeComponent();
            
            setDefaultDate();

            _nearAllocations = new List<Tuple<string, decimal>>();
            _farAllocations = new List<Tuple<string, decimal>>();

            cmbSymbol.Items.AddRange(StaticData.Symbols.Select(item => (object)item).ToArray());
            cmbTier.Items.AddRange(StaticData.Tiers.Select(item => (object)item).ToArray());
            cmbInstrumentType.Items.AddRange(StaticData.RFQTypes.Select(item => (object)item).ToArray());
            cmbNearTenor.Items.AddRange(StaticData.Tenors.Select(item => (object)item).ToArray());
            cmbFarTenor.Items.AddRange(StaticData.Tenors.Select(item => (object)item).ToArray());
            cmbOrderType.Items.AddRange(StaticData.OrderTypes.Keys.Select(item => (object)item).ToArray());

            cmbInstrumentType.SelectedIndex = 0;
            cmbNearTenor.SelectedIndex = 0;
            cmbFarTenor.SelectedIndex = 0;
            cmbTier.SelectedIndex = 0;
            SetOrderType("Forex - Previously Quoted");

            _holdPrices = false;

            tabAllocations.TabPages.Remove(tabFarLeg);

            _nearBidPrices = new Tuple<decimal, decimal, decimal, decimal, string>(0, 0, 0, 0, string.Empty);
            _nearAskPrices = new Tuple<decimal, decimal, decimal, decimal, string>(0, 0, 0, 0, string.Empty);
            _farBidPrices = new Tuple<decimal, decimal, decimal, decimal, string>(0, 0, 0, 0, string.Empty);
            _farAskPrices = new Tuple<decimal, decimal, decimal, decimal, string>(0, 0, 0, 0, string.Empty);

            remainingQuotingTime = 0;
        }

        private void UpdateDisplay(object sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke((EventHandlerCallBack) UpdateDisplay, sender, e);
            } else {

                decimal currentBid;
                decimal currentAsk;

                switch (cmbInstrumentType.SelectedIndex) {
                    case 0: // SPOT
                        currentBid = _nearBidPrices.Item2;
                        currentAsk = _nearAskPrices.Item2;

                        lblBidAllIn.Text = _nearBidPrices.Item2.ToString("0.000000");
                        lblBidLastSpot.Text = _nearBidPrices.Item2.ToString("0.000000");
                        lblBidQuoteId.Text = _nearBidPrices.Item5;

                        lblAskAllIn.Text = _nearAskPrices.Item4.ToString("0.000000");
                        lblAskLastSpot.Text = _nearAskPrices.Item2.ToString("0.000000");
                        lblAskQuoteId.Text = _nearAskPrices.Item5;
                        break;
                    case 1: // FORWARD
                        currentBid = _nearBidPrices.Item3;
                        currentAsk = _nearAskPrices.Item3;

                        lblBidAllIn.Text = _nearBidPrices.Item4.ToString("0.000000");
                        lblBidLastSpot.Text = _nearBidPrices.Item2.ToString("0.000000");
                        lblBidQuoteId.Text = _nearBidPrices.Item5;

                        lblAskAllIn.Text = _nearAskPrices.Item4.ToString("0.000000");
                        lblAskLastSpot.Text = _nearAskPrices.Item2.ToString("0.000000");
                        lblAskQuoteId.Text = _nearAskPrices.Item5;
                        break;
                    case 2: // SWAP
                        currentBid = _farBidPrices.Item3 - _nearAskPrices.Item3;
                        currentAsk = _farAskPrices.Item3 - _nearBidPrices.Item3;

                        lblBidAllIn.Text = (_nearAskPrices.Item2 + currentBid).ToString("0.000000");
                        lblBidLastSpot.Text = _nearAskPrices.Item2.ToString("0.000000");
                        lblBidQuoteId.Text = _farBidPrices.Item5;

                        lblAskAllIn.Text = (_nearBidPrices.Item2 + currentAsk).ToString("0.000000");
                        lblAskLastSpot.Text = _nearBidPrices.Item2.ToString("0.000000");
                        lblAskQuoteId.Text = _farAskPrices.Item5;
                        break;
                    default:
                        return;
                }

                UpdateBidPrice(currentBid);
                UpdateAskPrice(currentAsk);

                lblRemainingTime.Text = (remainingQuotingTime >= 0) ? remainingQuotingTime.ToString() : "N/A";
            }
        }

        /*
        private Tuple<string, string, string> FormatPrice(decimal price) {
            var pips = (int)(price * 10000M) % 100;
            var bps = (int)(price * 1000000M) % 100;

            return Tuple.Create(price.ToString("0.00"), pips.ToString("00"), bps.ToString("00"));
        }
        */

        private Tuple<string, string, string> FormatPrice(string formattedPrice)
        {
            int len = formattedPrice.Length;
            string first = formattedPrice.Substring(0, len - 4);
            string second = formattedPrice.Substring(first.Length, 2);
            string third = formattedPrice.Substring(len - 2, 2);
            return Tuple.Create(first, second, third);
        }

        private void UpdateBidPrice(decimal price) {
            //var formattedPrice = FormatPrice(price);
            var formattedPrice = FormatPrice(price.ToString("0.000000"));
            lblBid.Text = formattedPrice.Item1;
            lblBidPips.Text = formattedPrice.Item2;
            lblBidBps.Text = formattedPrice.Item3;
        }

        private void UpdateAskPrice(decimal price) {
            //var formattedPrice = FormatPrice(price);
            var formattedPrice = FormatPrice(price.ToString("0.000000"));
            lblAsk.Text = formattedPrice.Item1;
            lblAskPips.Text = formattedPrice.Item2;
            lblAskBps.Text = formattedPrice.Item3;
        }

        private void TxtNearAmountTextChanged(object sender, EventArgs e) {
            HandleAmountTextChanged((TextBox)sender);
        }

        private void TxtFarAmountTextChanged(object sender, EventArgs e) {
            HandleAmountTextChanged((TextBox) sender);
        }

        private static void HandleAmountTextChanged(TextBox textBox) {
            if (textBox.Text.Length < 1) return;

            var postFix = (textBox.Text.Length > 1) ? textBox.Text.Substring(textBox.Text.Length - 1).ToUpper() : "";

            int lastDigit;
            float prefixNumber;

            var lastDigitIsNumeric = int.TryParse(postFix, out lastDigit);

            if (lastDigitIsNumeric) return;

            if (!float.TryParse(textBox.Text.Substring(0, textBox.Text.Length - postFix.Length), out prefixNumber)) {
                MessageBox.Show("Error the number you have entered is not a valid amount", "Error Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            switch (postFix) {
                case "T":
                    textBox.Text = (prefixNumber * 1000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
                case "M":
                    textBox.Text = (prefixNumber * 1000000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
            }
        }

        private void TxtFarAllocationOnTextChanged(object sender, EventArgs e) {
            HandleAmountTextChanged((TextBox) sender);
        }

        private void TxtNearAllocationOnTextChanged(object sender, EventArgs e) {
            HandleAmountTextChanged((TextBox) sender);
        }

        private void BtnSendClick(object sender, EventArgs e) {
            var sendRFQRequestHandler = OnSendRFQRequest;

            decimal parseValue;

            RFQEventArgs rfqEventArgs;

            switch (cmbInstrumentType.SelectedIndex) {
                case 0:
                    rfqEventArgs = new RFQEventArgs {
                                                        Symbol = cmbSymbol.Text,
                                                        Tier = cmbTier.Text,
                                                        InstrumentType = cmbInstrumentType.Text,
                                                        OrderType = string.IsNullOrEmpty(cmbOrderType.Text) ? "" : StaticData.OrderTypes[cmbOrderType.Text],
                                                        NearAmount = decimal.TryParse(txtNearAmount.Text, out parseValue) ? parseValue : 0M,
                                                        NearCurrency = cmbNearCcy.Text,
                                                        NearTenor = cmbNearTenor.Text,
                                                        NearSettlementDate = dtNearSettleDate.Value,
                                                        NearAllocations = _nearAllocations
                                                    };
                    break;
                case 1:
                    rfqEventArgs = new RFQEventArgs {
                                                        Symbol = cmbSymbol.Text,
                                                        Tier = cmbTier.Text,
                                                        InstrumentType = cmbInstrumentType.Text,
                                                        OrderType = string.IsNullOrEmpty(cmbOrderType.Text) ? "" : StaticData.OrderTypes[cmbOrderType.Text],
                                                        FarAmount = decimal.TryParse(txtNearAmount.Text, out parseValue) ? parseValue : 0M,
                                                        FarCurrency = cmbNearCcy.Text,
                                                        FarTenor = cmbNearTenor.Text,
                                                        FarSettlementDate = dtNearSettleDate.Value,
                                                        FarAllocations = _nearAllocations
                                                    };
                    break;
                case 2:
                    rfqEventArgs = new RFQEventArgs {
                                                        Symbol = cmbSymbol.Text,
                                                        Tier = cmbTier.Text,
                                                        InstrumentType = cmbInstrumentType.Text,
                                                        OrderType = string.IsNullOrEmpty(cmbOrderType.Text) ? "" : StaticData.OrderTypes[cmbOrderType.Text],
                                                        NearAmount = decimal.TryParse(txtNearAmount.Text, out parseValue) ? parseValue : 0M,
                                                        NearCurrency = cmbNearCcy.Text,
                                                        NearTenor = cmbNearTenor.Text,
                                                        NearSettlementDate = dtNearSettleDate.Value,
                                                        NearAllocations = _nearAllocations,
                                                        FarAmount = decimal.TryParse(txtFarAmount.Text, out parseValue) ? parseValue : 0M,
                                                        FarCurrency = cmbFarCcy.Text,
                                                        FarTenor = cmbFarTenor.Text,
                                                        FarSettlementDate = dtFarSettleDate.Value,
                                                        FarAllocations = _farAllocations
                                                    };
                    break;
                default:
                    return;
            }

            if (sendRFQRequestHandler != null) sendRFQRequestHandler(this, rfqEventArgs);
        }

        public void SetQuoteRequestId(string quoteRequestId) { _quoteRequestId = quoteRequestId; }

        private void BtnAddNearAllocationClick(object sender, EventArgs e) { 
            decimal parseValue;
            if (!decimal.TryParse(txtNearAllocation.Text, out parseValue)) {
                MessageBox.Show("Quantity for the allocation provided is invalid, cannot add this allocation.", "Invalid Allocation Amount", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }

            _nearAllocations.Add(new Tuple<string, decimal>(cmbNearAccount.Text, parseValue));
            ((CurrencyManager)lstNearAllocations.BindingContext[_nearAllocations]).Refresh();
            lstNearAllocations.SelectedIndex = -1;
        }

        private void BtnRemoveNearAllocationClick(object sender, EventArgs e) {
            if (lstNearAllocations.SelectedIndex < 0) return;
            _nearAllocations.RemoveAt(lstNearAllocations.SelectedIndex);
            ((CurrencyManager)lstNearAllocations.BindingContext[_nearAllocations]).Refresh();
            lstNearAllocations.SelectedIndex = -1;
        }

        private void BtnAddFarAllocationClick(object sender, EventArgs e) {
            decimal parseValue;

            if (!decimal.TryParse(txtFarAllocation.Text, out parseValue)) {
                MessageBox.Show("Quantity for the allocation provided is invalid, cannot add this allocation.", "Invalid Allocation Amount", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }

            _farAllocations.Add(new Tuple<string, decimal>(cmbFarAccount.Text, parseValue));
            ((CurrencyManager)lstFarAllocations.BindingContext[_farAllocations]).Refresh();
            lstFarAllocations.SelectedIndex = -1;
        }

        private void BtnRemoveFarAllocationClick(object sender, EventArgs e) {
            if (lstFarAllocations.SelectedIndex < 0) return;
            _farAllocations.RemoveAt(lstFarAllocations.SelectedIndex);
            ((CurrencyManager)lstFarAllocations.BindingContext[_farAllocations]).Refresh();
            lstFarAllocations.SelectedIndex = -1;
        }

        private void BtnRejectClick(object sender, EventArgs e) {
            if (_quoteRequestId != string.Empty) {
                var quoteRejectHandler = OnSendRFQReject;

                var rejectEventArgs = new RFQCancelEventArgs {
                    QuoteRequestId = _quoteRequestId
                };

                if (quoteRejectHandler != null) quoteRejectHandler(this, rejectEventArgs);    
            }
            
            Close();
        }

        private void SendNewOrder(StaticData.Side side) {
            if (_quoteRequestId == string.Empty) return;

            decimal parseValue;

            var orderHandler = OnSendRFQNewOrder;

            var orderArgs = new NewOrderEventArgs {
                                                      ClientRequestId = _quoteRequestId,
                                                      Symbol = cmbSymbol.Text,
                                                      Tier = cmbTier.Text,
                                                      InstrumentType = cmbInstrumentType.Text,
                                                      //OrderType = StaticData.OrderTypes[cmbOrderType.Text],
                                                      OrderType = "H", // Previously quoted
                                                      NearAmount = decimal.TryParse(txtNearAmount.Text, out parseValue) ? parseValue : 0M,
                                                      NearCurrency = cmbNearCcy.Text,
                                                      NearTenor = cmbNearTenor.Text,
                                                      NearSettlementDate = dtNearSettleDate.Value,
                                                      NearAllocations = _nearAllocations,
                                                      FarAmount = decimal.TryParse(txtFarAmount.Text, out parseValue) ? parseValue : 0M,
                                                      FarCurrency = cmbFarCcy.Text,
                                                      FarTenor = cmbFarTenor.Text,
                                                      FarSettlementDate = dtFarSettleDate.Value,
                                                      FarAllocations = _farAllocations,
                                                      Side = side.ToString(),
                                                      LastSpotRate = side == StaticData.Side.Buy ? _nearAskPrices.Item2 : _nearBidPrices.Item2,
                                                      QuoteId = side == StaticData.Side.Buy ? _nearAskPrices.Item5 : _nearBidPrices.Item5
                                                  };

            if (orderArgs.InstrumentType == "SWAP") {
                if (side == StaticData.Side.Buy) {
                    // we're buying the far leg, and selling the near leg
                    orderArgs.LastNearForwardPoints = _nearBidPrices.Item3;
                    orderArgs.LastNearAllInPrice = _nearBidPrices.Item4;
                    orderArgs.LastFarForwardPoints = _farAskPrices.Item3;
                    orderArgs.LastFarAllInPrice = _farAskPrices.Item4;
                } else {
                    orderArgs.LastNearForwardPoints = _nearAskPrices.Item3;
                    orderArgs.LastNearAllInPrice = _nearAskPrices.Item4;
                    orderArgs.LastFarForwardPoints = _farBidPrices.Item3;
                    orderArgs.LastFarAllInPrice = _farBidPrices.Item4;
                }
            } else {
                orderArgs.LastNearForwardPoints = 0M;
                orderArgs.LastNearAllInPrice = orderArgs.LastSpotRate;

                if (orderArgs.InstrumentType == "FORWARD") {
                    if (side == StaticData.Side.Buy) {
                        orderArgs.LastFarForwardPoints = _nearAskPrices.Item3;
                        orderArgs.LastFarAllInPrice = _nearAskPrices.Item4;
                    } else {
                        orderArgs.LastFarForwardPoints = _nearBidPrices.Item3;
                        orderArgs.LastFarAllInPrice = _nearBidPrices.Item4;
                    }
                }
            }

            if (orderHandler != null) orderHandler(this, orderArgs);
        }

        #region Bid Price Handlers
        private void LblBidAllInDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Sell);
        }

        private void LblBidQuoteIdDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Sell);
        }

        private void LblBidDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Sell);
        }

        private void LblBidBpsDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Sell);
        }

        private void LblBidPipsDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Sell);
        }

        private void PanelBuyDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Sell);
        }

        private void LblBidLastSpotDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Sell);
        }
        #endregion

        #region Ask Price Handlers
        private void LblAskAllInDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Buy);
        }

        private void LblAskQuoteIdDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Buy);
        }

        private void LblAskDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Buy);
        }

        private void LblAskBpsDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Buy);
        }

        private void LblAskPipsDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Buy);
        }

        private void PanelSellDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Buy);
        }

        private void LblAskLastSpotDoubleClick(object sender, EventArgs e) {
            SendNewOrder(StaticData.Side.Buy);
        }
        #endregion

        private void CmbInstrumentTypeSelectedIndexChanged(object sender, EventArgs e) {
            switch (cmbInstrumentType.SelectedIndex) {
                case 0:
                    lblBidAllIn.Visible = false;
                    lblBidLastSpot.Visible = false;
                    lblAskAllIn.Visible = false;
                    lblAskLastSpot.Visible = false;
                    if (tabAllocations.TabPages.Count > 1) tabAllocations.TabPages.Remove(tabFarLeg);
                    SetOrderType("Forex - Previously Quoted");
                    break;
                case 1:
                    lblBidAllIn.Visible = true;
                    lblBidLastSpot.Visible = true;
                    lblAskAllIn.Visible = true;
                    lblAskLastSpot.Visible = true;
                    if (tabAllocations.TabPages.Count > 1) tabAllocations.TabPages.Remove(tabFarLeg);
                    SetOrderType("Forex - Previously Quoted");
                    break;
                case 2:
                    lblBidAllIn.Visible = true;
                    lblBidLastSpot.Visible = true;
                    lblAskAllIn.Visible = true;
                    lblAskLastSpot.Visible = true;
                    if (tabAllocations.TabPages.Count == 1) tabAllocations.TabPages.Add(tabFarLeg);
                    SetOrderType("Forex - Swap");
                    break;
            }
        }

        public void SetSymbol(string symbol) {
            for (var i = 0; i < cmbSymbol.Items.Count; i++) {
                if (cmbSymbol.Items[i].ToString() != symbol) continue;
                cmbSymbol.SelectedIndex = i;
                break;
            }
        }

        public void SetTier(string tier) {
            for (var i = 0; i < cmbTier.Items.Count; i++) {
                if (cmbTier.Items[i].ToString() != tier) continue;
                cmbTier.SelectedIndex = i;
                break;
            }
        }

        public void HandleQuote(object sender, EventArgs e) {
            var args = (FixMessageEventArgs) e;

            if (args.RequestId != _quoteRequestId) return;
            
            if (_holdPrices) return;

            // otherwise we process the price tags and update the prices
            ExtractQuoteData(args.RequestId, args.FixTags);
            UpdateDisplay(sender, e);
        }

        public void HandleQuoteReject(object sender, EventArgs e) {
            var args = (FixMessageEventArgs)e;

            if (args.RequestId != _quoteRequestId) return;

            var rejectMessage = string.Empty;

            var status = args.FixTags.Where(item => item.Item1 == 297).ToArray();
            var text = args.FixTags.Where(item => item.Item1 == 58).ToArray();
            var reason = args.FixTags.Where(item => item.Item1 == 300).ToArray();

            if (status.Length > 0 && status[0].Item2 != "5") return;
            if (reason.Length > 0) rejectMessage = reason[0].Item2;
            if (text.Length > 0) rejectMessage += text[0].Item2;

            if (string.IsNullOrEmpty(rejectMessage)) rejectMessage = "Request rejected for unknown reason.";

            MessageBox.Show(rejectMessage, "RFQ Rejected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public void HandleQuoteCancel(object sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke((EventHandlerCallBack)HandleQuoteCancel, sender, e);
            } else {
                Close();
            }
        }

        private void RFQFormFormClosed(object sender, FormClosedEventArgs e) {
            var closeHandler = OnRFQClose;

            if (closeHandler != null) closeHandler(this, e);
        }

        private void ExtractQuoteData(string requestId, IEnumerable<Tuple<int, string>> tags) {

            var quoteId = string.IsNullOrEmpty(_nearBidPrices.Item5) ? "" : _nearBidPrices.Item5;
            
            var nearBidSpot = _nearBidPrices.Item2;
            var nearBidPoints = _nearBidPrices.Item3;
            var nearBidAll = _nearBidPrices.Item4;

            var nearAskSpot = _nearAskPrices.Item2;
            var nearAskPoints = _nearAskPrices.Item3;
            var nearAskAll = _nearAskPrices.Item4;

            var farBidSpot = _farBidPrices.Item2;
            var farBidPoints = _farBidPrices.Item3;
            var farBidAll = _farBidPrices.Item4;

            var farAskSpot = _farAskPrices.Item2;
            var farAskPoints = _farAskPrices.Item3;
            var farAskAll = _farAskPrices.Item4;

            decimal parseValue;
            var nearQuantity = decimal.TryParse(txtNearAmount.Text, out parseValue) ? parseValue : 0M;
            var farQuantity = decimal.TryParse(txtFarAmount.Text, out parseValue) ? parseValue : 0M;

            int remainingTime = -1;

            foreach(var tag in tags) {
                switch (tag.Item1) {
                    case 117:
                        quoteId = tag.Item2;
                        break;
                    case 132:
                        nearBidAll = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        break;
                    case 6050:
                        farBidAll = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        break;
                    case 188:
                        nearBidSpot = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        farBidSpot = nearBidSpot;
                        break;
                    case 189:
                        nearBidPoints = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        break;
                    case 642:
                        farBidPoints = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        break;
                    case 133:
                        nearAskAll = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        break;
                    case 6051:
                        farAskAll = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        break;
                    case 190:
                        nearAskSpot = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        farAskSpot = nearAskSpot;
                        break;
                    case 191:
                        nearAskPoints = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        break;
                    case 643:
                        farAskPoints = decimal.TryParse(tag.Item2, out parseValue) ? parseValue : 0M;
                        break;
                    case 6256:
                        remainingTime = decimal.TryParse(tag.Item2, out parseValue) ? (int)parseValue : 0;
                        break;
                }
            }

            _nearBidPrices = new Tuple<decimal, decimal, decimal, decimal, string>(nearQuantity, nearBidSpot, nearBidPoints, nearBidAll, quoteId);
            _nearAskPrices = new Tuple<decimal, decimal, decimal, decimal, string>(nearQuantity, nearAskSpot, nearAskPoints, nearAskAll, quoteId);
            _farBidPrices = new Tuple<decimal, decimal, decimal, decimal, string>(farQuantity, farBidSpot, farBidPoints, farBidAll, quoteId);
            _farAskPrices = new Tuple<decimal, decimal, decimal, decimal, string>(farQuantity, farAskSpot, farAskPoints, farAskAll, quoteId);
            remainingQuotingTime = remainingTime;

            var pricingResponseHandler = OnPricingResponse;
            var pricingResponseEventArgs = new PricingResponseEventArgs() { RequestId = requestId, QuoteId = quoteId, LastSpotBid = nearBidSpot, LastSpotAsk = nearAskSpot, NearBidPoints = nearBidPoints, NearAskPoints = nearAskPoints, NearAllInBid = nearBidAll, NearAllInAsk = nearAskAll, FarBidPoints = farBidPoints, FarAskPoints = farAskPoints, FarAllInBid = farBidAll, FarAllInAsk = farAskAll, RemainingTime = remainingTime};

            if (pricingResponseHandler != null) pricingResponseHandler(this, pricingResponseEventArgs);
        }

        private void TxtNearAmountEnter(object sender, EventArgs e) { txtNearAmount.Text = string.Empty; }

        private void TxtFarAmountEnter(object sender, EventArgs e) { txtFarAmount.Text = string.Empty; }

        private void CmbSymbolSelectedIndexChanged(object sender, EventArgs e) { 
            if (cmbSymbol.Text.Length < 7) {
                cmbNearCcy.Items.Clear();
                cmbFarCcy.Items.Clear();
                return;
            }

            var ccyBase = (object) cmbSymbol.Text.Substring(0, 3);
            var ccyTerm = (object) cmbSymbol.Text.Substring(4);

            cmbNearCcy.Items.AddRange(new [] { ccyBase, ccyTerm });
            cmbFarCcy.Items.AddRange(new[] { ccyBase, ccyTerm });

            cmbNearCcy.SelectedIndex = 0;
            cmbFarCcy.SelectedIndex = 0;

            // Set default quantity
            txtNearAmount.Text = "1000000";
        }

        private void SetOrderType(string ordType) {
            for (var i = 0; i < cmbOrderType.Items.Count; i++) {
                if (cmbOrderType.Items[i].ToString() != ordType) continue;
                cmbOrderType.SelectedIndex = i;
                break;
            }
        }
        
        private void TxtNearAmountLeave(object sender, EventArgs e) { txtFarAmount.Text = txtNearAmount.Text; }

        public void HandleExecutionReport(object sender, EventArgs e) {
            var args = (FixMessageEventArgs) e;

            if (args.RequestId != _clientOrderId) return;

            var execTypeTags = args.FixTags.Where(item => item.Item1 == 150).ToArray();
            var textTags = args.FixTags.Where(item => item.Item1 == 58).ToArray();

            var message = textTags.Length > 0 ? textTags[0].Item2 : string.Empty;

            if (execTypeTags.Length == 0) return;

            switch (execTypeTags[0].Item2) {
                case "2":
                case "F":
                    CloseRFQ(this, new EventArgs());
                    break;
                case "8":
                    MessageBox.Show(string.Format("Order was rejected: {0}", message), "Order Rejected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    break;
            }            
        }

        private void CloseRFQ(object sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke((EventHandlerCallBack) CloseRFQ, sender, e);
            } else {
                Close();
            }
        }

        public void SetClientOrderId(string clientOrderId) { _clientOrderId = clientOrderId; }

        private void TxtNearAllocationEnter(object sender, EventArgs e) { txtNearAllocation.Text = string.Empty; }

        private void TxtFarAllocationEnter(object sender, EventArgs e) { txtFarAllocation.Text = string.Empty; }

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
            dtNearSettleDate.Text = dt.ToLongDateString();
        }

    }
}
