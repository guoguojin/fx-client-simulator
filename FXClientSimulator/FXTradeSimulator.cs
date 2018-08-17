using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using Extensions;
using FIXClient;
using FXClientSimulator.Properties;
using FXPricingControl;
using System.ComponentModel;

namespace FXClientSimulator {   
    public partial class FXTradeSimulator : Form {
        private FixClient _mdclient;
        private FixClient _tdClient;
        private FixClient _rfqClient;

        private bool _showQuoteIds;

        private delegate void StatusBarUpdateCallBack(object sender, EventArgs e);

        private enum MDEntry {
            None,
            Bid,
            Ask
        }

        private readonly EntitySet<PricingRequest> _pricingRequests = new EntitySet<PricingRequest>();  
        private readonly EntitySet<OrderRequest> _clientOrders = new EntitySet<OrderRequest>();
        private Dictionary<string, FXPricingControl.FXPricingControl> _liveSubscriptions = new Dictionary<string, FXPricingControl.FXPricingControl>();
 
        public FXTradeSimulator() {
            InitializeComponent();

            fxPricingControl1.SetSymbols(StaticData.Symbols);
            fxPricingControl2.SetSymbols(StaticData.Symbols);
            fxPricingControl3.SetSymbols(StaticData.Symbols);
            fxPricingControl4.SetSymbols(StaticData.Symbols);
            fxPricingControl5.SetSymbols(StaticData.Symbols);
            fxPricingControl6.SetSymbols(StaticData.Symbols);
            fxPricingControl7.SetSymbols(StaticData.Symbols);
            fxPricingControl8.SetSymbols(StaticData.Symbols);
            fxPricingControl9.SetSymbols(StaticData.Symbols);
            fxPricingControl10.SetSymbols(StaticData.Symbols);
            fxPricingControl11.SetSymbols(StaticData.Symbols);
            fxPricingControl12.SetSymbols(StaticData.Symbols);
            fxPricingControl13.SetSymbols(StaticData.Symbols);
            fxPricingControl14.SetSymbols(StaticData.Symbols);
            fxPricingControl15.SetSymbols(StaticData.Symbols);
            fxPricingControl16.SetSymbols(StaticData.Symbols);

            fxPricingControl1.SetTenors(StaticData.Tenors);
            fxPricingControl2.SetTenors(StaticData.Tenors);
            fxPricingControl3.SetTenors(StaticData.Tenors);
            fxPricingControl4.SetTenors(StaticData.Tenors);
            fxPricingControl5.SetTenors(StaticData.Tenors);
            fxPricingControl6.SetTenors(StaticData.Tenors);
            fxPricingControl7.SetTenors(StaticData.Tenors);
            fxPricingControl8.SetTenors(StaticData.Tenors);
            fxPricingControl9.SetTenors(StaticData.Tenors);
            fxPricingControl10.SetTenors(StaticData.Tenors);
            fxPricingControl11.SetTenors(StaticData.Tenors);
            fxPricingControl12.SetTenors(StaticData.Tenors);
            fxPricingControl13.SetTenors(StaticData.Tenors);
            fxPricingControl14.SetTenors(StaticData.Tenors);
            fxPricingControl15.SetTenors(StaticData.Tenors);
            fxPricingControl16.SetTenors(StaticData.Tenors);

            fxPricingControl1.SetTiers(StaticData.Tiers);
            fxPricingControl2.SetTiers(StaticData.Tiers);
            fxPricingControl3.SetTiers(StaticData.Tiers);
            fxPricingControl4.SetTiers(StaticData.Tiers);
            fxPricingControl5.SetTiers(StaticData.Tiers);
            fxPricingControl6.SetTiers(StaticData.Tiers);
            fxPricingControl7.SetTiers(StaticData.Tiers);
            fxPricingControl8.SetTiers(StaticData.Tiers);
            fxPricingControl9.SetTiers(StaticData.Tiers);
            fxPricingControl10.SetTiers(StaticData.Tiers);
            fxPricingControl11.SetTiers(StaticData.Tiers);
            fxPricingControl12.SetTiers(StaticData.Tiers);
            fxPricingControl13.SetTiers(StaticData.Tiers);
            fxPricingControl14.SetTiers(StaticData.Tiers);
            fxPricingControl15.SetTiers(StaticData.Tiers);
            fxPricingControl16.SetTiers(StaticData.Tiers);

            fxPricingControl1.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl2.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl3.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl4.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl5.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl6.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl7.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl8.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl9.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl10.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl11.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl12.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl13.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl14.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl15.OnNewOrderSimple += HandleNewOrderSingle;
            fxPricingControl16.OnNewOrderSimple += HandleNewOrderSingle;

            fxPricingControl1.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl2.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl3.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl4.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl5.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl6.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl7.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl8.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl9.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl10.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl11.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl12.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl13.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl14.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl15.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;
            fxPricingControl16.OnUnsubscribeMarketData += HandleMarketDataUnsubscribe;

            fxPricingControl1.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl2.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl3.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl4.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl5.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl6.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl7.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl8.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl9.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl10.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl11.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl12.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl13.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl14.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl15.OnSubscribeMarketData += HandleMarketDataSubscriptions;
            fxPricingControl16.OnSubscribeMarketData += HandleMarketDataSubscriptions;

            fxPricingControl1.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl2.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl3.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl4.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl5.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl6.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl7.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl8.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl9.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl10.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl11.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl12.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl13.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl14.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl15.OnNewRFQRequest += HandleNewRFQContextRequest;
            fxPricingControl16.OnNewRFQRequest += HandleNewRFQContextRequest;

            fxPricingControl1.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl2.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl3.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl4.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl5.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl6.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl7.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl8.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl9.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl10.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl11.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl12.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl13.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl14.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl15.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;
            fxPricingControl16.OnNewOrderDetailed += HandleNewOrderDetailedContextRequest;

            _showQuoteIds = false;

            ColumnResponses.SubformShowing += ColumnResponsesOnSubformShowing;
            ColumnResponses.SubformClosing += ColumnResponsesOnSubformClosing;

            ColumnNearAllocations.SubformShowing += ColumnNearAllocationsOnSubformShowing;
            ColumnNearAllocations.SubformClosing += ColumnNearAllocationsOnSubformClosing;

            ColumnFarAllocations.SubformShowing += ColumnFarAllocationsOnSubformShowing;
            ColumnFarAllocations.SubformClosing += ColumnFarAllocationsOnSubformClosing;

            ColumnResponses.Subform = typeof (PricingResponsesSubForm);
            ColumnNearAllocations.Subform = typeof (AllocationsSubForm);
            ColumnFarAllocations.Subform = typeof (AllocationsSubForm);

            ColumnOrderDetails.SubformShowing += ColumnOrderDetailsSubfornShowing;
            ColumnOrderDetails.SubformClosing += ColumnOrderDetailsSubformClosing;

            ColumnOrderDetails.Subform = typeof (OrderDetailSubform);

            PricingRequestBindingSource.DataSource = _pricingRequests;
            ClientOrderBindingSource.DataSource = _clientOrders;
            
            dataGridPricingRequests.DataSource = PricingRequestBindingSource;
            dataGridClientOrders.DataSource = ClientOrderBindingSource;
        }

        private void ColumnOrderDetailsSubformClosing(DataGridViewSubformCell sender, SubformClosingEventArgs e) { CheckCancelEvent(e, false); }

        private void ColumnOrderDetailsSubfornShowing(DataGridViewSubformCell sender, SubformShowingEventArgs e) { CheckCancelEvent(e, true); }

        private void ColumnFarAllocationsOnSubformClosing(DataGridViewSubformCell sender, SubformClosingEventArgs subformClosingEventArgs) { CheckCancelEvent(subformClosingEventArgs, false); }

        private void ColumnFarAllocationsOnSubformShowing(DataGridViewSubformCell sender, SubformShowingEventArgs subformShowingEventArgs) { CheckCancelEvent(subformShowingEventArgs, true); }

        private void ColumnNearAllocationsOnSubformClosing(DataGridViewSubformCell sender, SubformClosingEventArgs subformClosingEventArgs) { CheckCancelEvent(subformClosingEventArgs, false); }

        private void ColumnNearAllocationsOnSubformShowing(DataGridViewSubformCell sender, SubformShowingEventArgs subformShowingEventArgs) { CheckCancelEvent(subformShowingEventArgs, true); }

        private void ColumnResponsesOnSubformClosing(DataGridViewSubformCell sender, SubformClosingEventArgs subformClosingEventArgs) { CheckCancelEvent(subformClosingEventArgs, false); }

        private void ColumnResponsesOnSubformShowing(DataGridViewSubformCell sender, SubformShowingEventArgs subformShowingEventArgs) { CheckCancelEvent(subformShowingEventArgs, true); }

        private void HandleNewOrderDetailedContextRequest(object sender, EventArgs e) { ShowOrderForm((NewOrderEventArgs) e); }

        private void HandleNewRFQContextRequest(object sender, EventArgs e) { ShowQuoteForm((RFQRequestArgs) e); }

        private static void CheckCancelEvent(CancelEventArgs e, bool openSubForm) {
            if (e.Cancel) {
                MessageBox.Show(string.Format("Cannot {0} sub form at this time, please try again.", openSubForm ? "open" : "close"), Resources.SysMsg_ActionInterupted, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private FXPricingControl.FXPricingControl lookupSpotSubscription(string symbol)
        {
            FXPricingControl.FXPricingControl output = null;

            foreach (FXPricingControl.FXPricingControl ctrl in _liveSubscriptions.Values)
            {
                if (ctrl != null)
                {
                    if (ctrl.Symbol == symbol && ctrl.SubscribedTenor == "SP")
                    {
                        output = ctrl;
                        break;
                    }
                }
            }

            return output;
        }

        //
        // Call back for RFS orders (SPOT & FORWARD)
        //
        private void HandleNewOrderSingle(object sender, EventArgs args) {
            if (_tdClient == null || !_tdClient.LoggedOn) {
                toolStripApplicationStatus.Text = Resources.toolStrip_MDNotConnected_Orders;
                return;
            }

            if (!ValidateOrderDetails(args)) return;

            var newOrderArgs = (NewAutoOrderEventArgs) args;
            var settings = new Settings();

            var instrType = "SPOT";
            Tuple<decimal, decimal, string> spotPriceData = new Tuple<decimal, decimal, string>(0.0m, 0.0m, "");

            if ( newOrderArgs.Tenor != "SP" )
            {
                instrType = "FORWARD";

                FXPricingControl.FXPricingControl subscription = lookupSpotSubscription(newOrderArgs.Symbol);
                if (subscription != null)
                {
                    Tuple<decimal, decimal, string> price = subscription.LookupPrice(newOrderArgs.Amount, newOrderArgs.Side.ToUpper() == "BUY");
                    if (price.Item1 == newOrderArgs.Amount && price.Item2 > 0.0m && price.Item3 != "")
                    {
                        spotPriceData = price;
                    }
                    else
                    {
                        MessageBox.Show("Cannot find spot price for " + newOrderArgs.Symbol);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Spot prices " + newOrderArgs.Symbol + " are not subscribed");
                    return;
                }
            }

            INewOrderSingle order = null;

            if (instrType == "SPOT")
            {
                var autoSpotOrder = new AutoSpotOrderSingle(newOrderArgs.Type, newOrderArgs.Symbol) {
                    TIF = newOrderArgs.TIF,
                    Price = newOrderArgs.Price,
                    //Account = settings.DefaultAccount,
                    Account = newOrderArgs.Account,
                    Amount = newOrderArgs.Amount,
                    Currency = newOrderArgs.Currency,
                    Symbol = newOrderArgs.Symbol,
                    QuoteId = newOrderArgs.QuoteId,
                    Tenor = newOrderArgs.Tenor,
                    Side = newOrderArgs.Side.ToUpper() == "BUY" ? 1 : 2,
                    BenchmarkType = newOrderArgs.BenchmarkType,
                    ActiveTimeStamp = newOrderArgs.ActiveTimeStamp,
                    ActiveTimeZone = newOrderArgs.ActiveTimeZone,
                    ExpireTimeStamp = newOrderArgs.ExpireTimeStamp,
                    ExpireTimeZone = newOrderArgs.ExpireTimeZone,
                    AlertType = newOrderArgs.AlertType,
                    SettlementDate = newOrderArgs.SettlementDate
                };

                if (autoSpotOrder.Price > 0)
                {
                    autoSpotOrder.Price = newOrderArgs.Price;
                }

                var orderRequest = new OrderRequest(autoSpotOrder.ClientRequestId, "AUTOQUOTE")
                {
                    Order = new ClientOrder
                    {
                        TradeDate = DateTime.Now,
                        NearAmount = autoSpotOrder.Amount,
                        NearCurrency = autoSpotOrder.Currency,
                        NearTenor = autoSpotOrder.Tenor,
                        Symbol = autoSpotOrder.Symbol,
                        InstrumentType = instrType,
                        OrderType = autoSpotOrder.OrderType,
                        QuoteId = autoSpotOrder.QuoteId,
                        RequestId = autoSpotOrder.ClientRequestId,
                        Side = (autoSpotOrder.Side == (int)FixSide.Buy) ? "BUY" : "SELL",
                        LastSpotRate = autoSpotOrder.Price,
                        NearSettlementDate = autoSpotOrder.SettlementDate,
                        NearAllocations = new List<Tuple<string, decimal>> { new Tuple<string, decimal>(autoSpotOrder.Account, autoSpotOrder.Amount) }
                    }
                };
                ClientOrderBindingSource.Add(orderRequest);

                order = autoSpotOrder;
            }
            else if (instrType == "FORWARD")
            {
                decimal allInPrice = spotPriceData.Item2 + newOrderArgs.Price;

                var autoForwardOrder = new AutoOutrightOrderSingle(newOrderArgs.Symbol, newOrderArgs.Tenor, false, "") {
                    Account = settings.DefaultAccount,
                    Amount = newOrderArgs.Amount,
                    Currency = newOrderArgs.Currency,
                    Price = allInPrice,
                    QuoteId = newOrderArgs.QuoteId,                    // Points quote ID
                    SpotQuoteId = spotPriceData.Item3,
                    //Symbol = newOrderArgs.Symbol,
                    Side = newOrderArgs.Side.ToUpper() == "BUY" ? 1 : 2,
                    //Tenor = newOrderArgs.Tenor,
                    SettlementDate = newOrderArgs.SettlementDate,
                    LastSpotRate = spotPriceData.Item2,
                    LastForwardPoints = newOrderArgs.Price,
                    OrderType = newOrderArgs.Type,
                    AlertType = newOrderArgs.AlertType
                };

                var orderRequest = new OrderRequest(autoForwardOrder.ClientRequestId, "AUTOQUOTE")
                {
                    Order = new ClientOrder
                    {
                        TradeDate = DateTime.Now,
                        NearAmount = autoForwardOrder.Amount,
                        NearCurrency = autoForwardOrder.Currency,
                        NearTenor = autoForwardOrder.Tenor,
                        Symbol = autoForwardOrder.Symbol,
                        InstrumentType = instrType,
                        OrderType = autoForwardOrder.OrderType,
                        QuoteId = autoForwardOrder.QuoteId,
                        SpotQuoteId = autoForwardOrder.SpotQuoteId,
                        RequestId = autoForwardOrder.ClientRequestId,
                        Side = (autoForwardOrder.Side == (int)FixSide.Buy) ? "BUY" : "SELL",
                        LastSpotRate = spotPriceData.Item2,
                        LastNearForwardPoints = autoForwardOrder.LastForwardPoints,
                        NearSettlementDate = autoForwardOrder.SettlementDate,
                        NearAllocations = new List<Tuple<string, decimal>> { new Tuple<string, decimal>(autoForwardOrder.Account, autoForwardOrder.Amount) }
                    }
                };
                ClientOrderBindingSource.Add(orderRequest);

                order = autoForwardOrder;
            }

            if (order != null)
            {
                toolStripApplicationStatus.Text = _tdClient.SendNewOrderSingle(order) ? "Order submitted" : "Could not submit order";
            }
        }

        private void HandleNewOrderMulti(object sender, EventArgs args)
        {
            if (_tdClient == null || !_tdClient.LoggedOn)
            {
                toolStripApplicationStatus.Text = Resources.toolStrip_MDNotConnected_Orders;
                return;
            }

            //if (!ValidateOrderDetails(args)) return;

            var newOrderArgs = (NewMultiLegOrderEventArgs)args;
            var settings = new Settings();


            INewOrderMultiLeg order = new SpotOrderMulti(newOrderArgs.OrderType);
            order.AlertType = newOrderArgs.AlertType;
            order.TIF = newOrderArgs.TIF;
            order.ActiveTimeStamp = newOrderArgs.ActiveTimeStamp;
            order.ActiveTimeZone = newOrderArgs.ActiveTimeZone;
            order.ExpireTimeStamp = newOrderArgs.ExpireTimeStamp;
            order.ExpireTimeZone = newOrderArgs.ExpireTimeZone;

            var mlegOrderRequest = new OrderRequest(order.ClientRequestId, "AUTOQUOTE")
            {
                Order = new ClientOrder
                {
                    InstrumentType = "SPOT",
                }
            };
            ClientOrderBindingSource.Add(mlegOrderRequest);

            IList<INewOrderSingle> legs = new List<INewOrderSingle>();
            int i = 0;
            while (i < newOrderArgs.Legs.Length)
            {
                NewAutoOrderEventArgs legArgs = newOrderArgs.Legs[i];

                INewOrderSingle legOrder = new AutoSpotOrderSingle(legArgs.Type, legArgs.Symbol)
                {
                    TIF = legArgs.TIF,
                    Price = legArgs.Price,
                    Account = legArgs.Account,
                    Amount = legArgs.Amount,
                    Currency = legArgs.Currency,
                    Symbol = legArgs.Symbol,
                    QuoteId = legArgs.QuoteId,
                    Tenor = legArgs.Tenor,
                    Side = legArgs.Side.ToUpper() == "BUY" ? 1 : 2,
                    SettlementDate = legArgs.SettlementDate,
                    ActiveTimeStamp = legArgs.ActiveTimeStamp,
                    ActiveTimeZone = legArgs.ActiveTimeZone,
                    ExpireTimeStamp = legArgs.ExpireTimeStamp,
                    ExpireTimeZone = legArgs.ExpireTimeZone,
                };

                if (legOrder.Price > 0)
                {
                    legOrder.Price = legArgs.Price;
                }

                var orderRequest = new OrderRequest(legOrder.ClientRequestId, "AUTOQUOTE")
                {
                    Order = new ClientOrder
                    {
                        TradeDate = DateTime.Now,
                        NearAmount = legOrder.Amount,
                        NearCurrency = legOrder.Currency,
                        NearTenor = legOrder.Tenor,
                        Symbol = legOrder.Symbol,
                        InstrumentType = "SPOT",
                        OrderType = legOrder.OrderType,
                        QuoteId = legOrder.QuoteId,
                        RequestId = legOrder.ClientRequestId,
                        Side = (legOrder.Side == (int)FixSide.Buy) ? "BUY" : "SELL",
                        LastSpotRate = legOrder.Price,
                        NearSettlementDate = legOrder.SettlementDate,
                        NearAllocations = new List<Tuple<string, decimal>> { new Tuple<string, decimal>(legOrder.Account, legOrder.Amount) }
                    }
                };
                ClientOrderBindingSource.Add(orderRequest);
                 
                legs.Add(legOrder);
                i++;
            }

            order.Legs = legs.ToArray<INewOrderSingle>();

            if (order != null)
            {
                toolStripApplicationStatus.Text = _tdClient.SendNewOrderMultileg(order) ? "Order submitted" : "Could not submit order";
            }
        }

        private void HandleMarketDataSubscriptions(object sender, EventArgs args) {

            if (_mdclient == null || !_mdclient.LoggedOn) {
                toolStripApplicationStatus.Text = Resources.toolStrip_MDNotConnected_Pricing;
                var control = (FXPricingControl.FXPricingControl) sender;
                control.ResetControl();
                return;
            }

            var requestArgs = (MarketDataRequestArgs) args;

            if (requestArgs.Tenor == "SP") {
                var spotMDRequest = new SpotMarketDataRequest(requestArgs.Symbol) { SettlementDate = requestArgs.SettlementDate, Tier = requestArgs.Tier };
                _mdclient.RequestMarketData(spotMDRequest);
                PricingRequestBindingSource.Add(new PricingRequest(spotMDRequest));
                _liveSubscriptions[spotMDRequest.ClientRequestId] = sender as FXPricingControl.FXPricingControl;
            } else {
                var forwardMDRequest = new ForwardMarketDataRequest(requestArgs.Symbol, requestArgs.Tenor) { SettlementDate = requestArgs.SettlementDate, Tier = requestArgs.Tier };
                _mdclient.RequestMarketData(forwardMDRequest);
                PricingRequestBindingSource.Add(new PricingRequest(forwardMDRequest));
                _liveSubscriptions[forwardMDRequest.ClientRequestId] = sender as FXPricingControl.FXPricingControl;
            }

            dataGridPricingRequests.Refresh();
        }

        private void HandleMarketDataUnsubscribe(object sender, EventArgs args) {
            if (_mdclient == null || !_mdclient.LoggedOn) {
                toolStripApplicationStatus.Text = Resources.toolStrip_MDNotConnected_Pricing;
                var control = (FXPricingControl.FXPricingControl)sender;
                control.ResetControl();
                return;
            }

            var requestArgs = (MarketDataRequestArgs) args;

            if (requestArgs.Tenor == "SP") {
                var spotMDRequest = new SpotMarketDataRequest(requestArgs.Symbol, false) { SettlementDate = requestArgs.SettlementDate, Tier = requestArgs.Tier };
                _mdclient.RequestMarketData(spotMDRequest);
                _liveSubscriptions.Remove(spotMDRequest.ClientRequestId);
            } else {
                var forwardMDRequest = new ForwardMarketDataRequest(requestArgs.Symbol, requestArgs.Tenor, false) { SettlementDate = requestArgs.SettlementDate, Tier = requestArgs.Tier };
                _mdclient.RequestMarketData(forwardMDRequest);
                _liveSubscriptions.Remove(forwardMDRequest.ClientRequestId);
            }
        }

        private void HandleOrderAllocationInstruction(object sender, EventArgs args)
        {
            if (_tdClient == null || !_tdClient.LoggedOn)
            {
                toolStripApplicationStatus.Text = Resources.toolStrip_MDNotConnected_Orders;
                return;
            }

            AllocationRequestEventArgs reqArgs = (AllocationRequestEventArgs)args;
            AllocationRequest request = new AllocationRequest
            {
                AllocId = reqArgs.AllocId,
                Side = reqArgs.Side,
                Symbol = reqArgs.Symbol,
                Quantity = reqArgs.Quantity,
                Currency = reqArgs.Currency,
                AvgPrice = reqArgs.AvgPrice,
                TradeDate = reqArgs.TradeDate,
                SettlementDate = reqArgs.SettlementDate
            };

            foreach (Tuple<string, decimal, decimal> order in reqArgs.Orders)
            {
                request.Orders.Add(new AllocationOrder 
                {
                    ClOrdId = order.Item1,
                    Quantity = order.Item2,
                    AvgPrice = order.Item3
                });
            }

            foreach (Tuple<string, decimal> allocation in reqArgs.Allocations)
            {
                request.Allocations.Add(new AllocationAlloc
                {
                    Account = allocation.Item1,
                    Quantity = allocation.Item2
                });
            }

            toolStripApplicationStatus.Text = _tdClient.RequestOrderAllocation(request) ? "Allocation request succesfully sent" : "Could not submit allocation request";
        }

        private bool ValidateOrderDetails(EventArgs orderArgs) {
            var args = (NewAutoOrderEventArgs) orderArgs;

            if (string.IsNullOrEmpty(args.Symbol.Trim())) {
                MessageBox.Show(Resources.AutoQuoteNewOrder_UnknownSymbol, Resources.AutoQuoteNewOrder_ValidateOrderDetails, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                ApplicationStatusLabel.Text = Resources.AutoQuoteNewOrder_UnknownSymbol;
                return false;
            }

            if (string.IsNullOrEmpty(args.Side)) {
                MessageBox.Show(Resources.AutoQuoteNewOrder_InvalidSide, Resources.AutoQuoteNewOrder_ValidateOrderDetails, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                ApplicationStatusLabel.Text = Resources.AutoQuoteNewOrder_InvalidSide;
                return false;
            }

            if (args.Amount <= 0M) {
                MessageBox.Show(Resources.AutoQuoteNewOrder_InvalidQuantity, Resources.AutoQuoteNewOrder_ValidateOrderDetails, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                ApplicationStatusLabel.Text = Resources.AutoQuoteNewOrder_InvalidQuantity;
                return false;
            } 

            /*
            if (args.Price <= 0M) {
                MessageBox.Show(Resources.AutoQuoteNewOrder_InvalidPrice, Resources.AutoQuoteNewOrder_ValidateOrderDetails, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                ApplicationStatusLabel.Text = Resources.AutoQuoteNewOrder_InvalidPrice;
                return false;
            }
            

            if (string.IsNullOrEmpty(args.QuoteId.Trim())) {
                MessageBox.Show(Resources.AutoQuoteNewOrder_InvalidQuoteId, Resources.AutoQuoteNewOrder_ValidateOrderDetails, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                ApplicationStatusLabel.Text = Resources.AutoQuoteNewOrder_InvalidQuoteId;
                return false;
            }
            */

            return true;
        }

        private void ConnectMenuItemEditClick(object sender, EventArgs e) {
            var editConnection = new EditConnectionForm();
            editConnection.ShowDialog(this);
        }

        private void ConnectMenuItemConnectClick(object sender, EventArgs e) {
            Connect();
        }

        private void DestroyFixClient(FixClient client)
        {
            IDisposable obj = client as IDisposable;
            if (obj != null)
            {
                obj.Dispose();
            }
        }

        private void Connect()
        {
            var settings = new Settings();

            DestroyFixClient(_mdclient);
            DestroyFixClient(_tdClient);
            DestroyFixClient(_rfqClient);

            _mdclient = new FixClient(settings.FIXHostMD, settings.FIXPortMD, settings.SenderIdMD, settings.TargetIdMD, settings.EncryptionMethodMD, settings.HeartbeatIntervalMD, settings.ResetSequenceNumberMD, settings.MDLogPath);
            _tdClient = new FixClient(settings.FIXHostTD, settings.FIXPortTD, settings.SenderIdTD, settings.TargetIdTD, settings.EncryptionMethodTD, settings.HeartbeatIntervalTD, settings.ResetSequenceNumberTD, settings.TDLogPath);
            _rfqClient = new FixClient(settings.FIXHostRFQ, settings.FIXPortRFQ, settings.SenderIdRFQ, settings.TargetIdRFQ, settings.EncryptionMethodRFQ, settings.HeartbeatIntervalRFQ, settings.ResetSequenceNumberRFQ, settings.RFQLogPath);

            SetConnectedStatus();

            _mdclient.OnLogon += MDFixClientOnLogon;
            _tdClient.OnLogon += TDFixClientOnLogon;
            _rfqClient.OnLogon += RFQFixClientOnLogon;

            _mdclient.OnBehalfOf = settings.OnBehalfOf;
            _tdClient.OnBehalfOf = settings.OnBehalfOf;
            _rfqClient.OnBehalfOf = settings.OnBehalfOf;

            _mdclient.Connect();
            _tdClient.Connect();
            _rfqClient.Connect();
        }

        private void HandleStatusUpdate(object sender, EventArgs e) { throw new NotImplementedException(); }

        private void HandleMarketDataSnapshot(object sender, EventArgs e) {
            var fixArgs = (FixMessageEventArgs) e;

            List<Tuple<decimal, decimal, string>> bids;
            List<Tuple<decimal, decimal, string>> asks;

            ExtractMDEntries(fixArgs.FixTags, out bids, out asks);
            AddPricingResponsesToRequest(fixArgs.RequestId, bids, asks);

            FXPricingControl.FXPricingControl ctrl = null;
            if (_liveSubscriptions.TryGetValue(fixArgs.RequestId, out ctrl))
            {
                if (ctrl != null)
                {
                    ctrl.UpdatePrices(bids, asks);
                }
            }

            /*
            if (fxPricingControl1.Symbol == fixArgs.Symbol && fxPricingControl1.Tier == fixArgs.Tier) fxPricingControl1.UpdatePrices(bids, asks);
            if (fxPricingControl2.Symbol == fixArgs.Symbol && fxPricingControl2.Tier == fixArgs.Tier) fxPricingControl2.UpdatePrices(bids, asks);
            if (fxPricingControl3.Symbol == fixArgs.Symbol && fxPricingControl3.Tier == fixArgs.Tier) fxPricingControl3.UpdatePrices(bids, asks);
            if (fxPricingControl4.Symbol == fixArgs.Symbol && fxPricingControl4.Tier == fixArgs.Tier) fxPricingControl4.UpdatePrices(bids, asks);
            if (fxPricingControl5.Symbol == fixArgs.Symbol && fxPricingControl5.Tier == fixArgs.Tier) fxPricingControl5.UpdatePrices(bids, asks);
            if (fxPricingControl6.Symbol == fixArgs.Symbol && fxPricingControl6.Tier == fixArgs.Tier) fxPricingControl6.UpdatePrices(bids, asks);
            if (fxPricingControl7.Symbol == fixArgs.Symbol && fxPricingControl7.Tier == fixArgs.Tier) fxPricingControl7.UpdatePrices(bids, asks);
            if (fxPricingControl8.Symbol == fixArgs.Symbol && fxPricingControl8.Tier == fixArgs.Tier) fxPricingControl8.UpdatePrices(bids, asks);
            if (fxPricingControl9.Symbol == fixArgs.Symbol && fxPricingControl9.Tier == fixArgs.Tier) fxPricingControl9.UpdatePrices(bids, asks);
            if (fxPricingControl10.Symbol == fixArgs.Symbol && fxPricingControl10.Tier == fixArgs.Tier) fxPricingControl10.UpdatePrices(bids, asks);
            if (fxPricingControl11.Symbol == fixArgs.Symbol && fxPricingControl11.Tier == fixArgs.Tier) fxPricingControl11.UpdatePrices(bids, asks);
            if (fxPricingControl12.Symbol == fixArgs.Symbol && fxPricingControl12.Tier == fixArgs.Tier) fxPricingControl12.UpdatePrices(bids, asks);
            if (fxPricingControl13.Symbol == fixArgs.Symbol && fxPricingControl13.Tier == fixArgs.Tier) fxPricingControl13.UpdatePrices(bids, asks);
            if (fxPricingControl14.Symbol == fixArgs.Symbol && fxPricingControl14.Tier == fixArgs.Tier) fxPricingControl14.UpdatePrices(bids, asks);
            if (fxPricingControl15.Symbol == fixArgs.Symbol && fxPricingControl15.Tier == fixArgs.Tier) fxPricingControl15.UpdatePrices(bids, asks);
            if (fxPricingControl16.Symbol == fixArgs.Symbol && fxPricingControl16.Tier == fixArgs.Tier) fxPricingControl16.UpdatePrices(bids, asks);
             */
        }

        private void AddPricingResponsesToRequest(string requestId, List<Tuple<decimal, decimal, string>> bids, List<Tuple<decimal, decimal, string>> asks) {
            var bidQty = bids.Select(item => item.Item1).ToArray();
            var askQty = asks.Select(item => item.Item1).ToArray();

            var allQty = bidQty.Union(askQty).OrderBy(item => item).ToArray();
            var requests = _pricingRequests.Where(item => item.RequestId == requestId).ToArray();

            if (requests.Length == 0) return;

            var pricingRequest = requests[requests.Length - 1];

            foreach (var qty in allQty) {
                var bidPrices = bids.Where(item => item.Item1 == qty).ToArray();
                var askPrices = asks.Where(item => item.Item1 == qty).ToArray();

                var bidPrice = 0M;
                var askPrice = 0M;
                var quoteId = string.Empty;

                if (bidPrices.Length > 0) {
                    bidPrice = bidPrices[0].Item2;
                    quoteId = bidPrices[0].Item3;
                }

                if (askPrices.Length > 0) {
                    askPrice = askPrices[0].Item2;
                    if (quoteId != string.Empty) quoteId += " | ";
                    quoteId += askPrices[0].Item3;
                }

                pricingRequest.AddPrice(new PricingResponse(requestId, quoteId, pricingRequest) { Amount = qty, LastSpotBid = bidPrice, LastSpotAsk = askPrice, NearBidPoints = 0M, NearAskPoints = 0M, NearAllInBid = bidPrice, NearAllInAsk = askPrice, FarBidPoints = 0M, FarAskPoints = 0M, FarAllInBid = 0M, FarAllInAsk = 0M });
            }
        }

        private void ExtractMDEntries(IEnumerable<Tuple<int, string>> fixTags, out List<Tuple<decimal, decimal, string>> bids, out List<Tuple<decimal, decimal,string>> asks) {
            bids = new List<Tuple<decimal, decimal, string>>();
            asks = new List<Tuple<decimal, decimal, string>>();

            // now traverse through the args and get the data we want
            var mdEntryType = MDEntry.None;


            var gotSize = false;
            var gotPrice = false;
            var gotQuoteId = false;
            var indicativePrice = false;

            var size = 0M;
            var price = 0M;
            var quoteId = string.Empty;

            foreach (var arg in fixTags) {
                decimal parseValue;

                switch (arg.Item1) {
                    case 269:
                        mdEntryType = arg.Item2 == "0" ? MDEntry.Bid : MDEntry.Ask;
                        break;
                    case 270:
                        gotPrice = decimal.TryParse(arg.Item2, out parseValue);
                        price = gotPrice ? parseValue : 0M;
                        break;
                    case 271:
                        gotSize = decimal.TryParse(arg.Item2, out parseValue);
                        size = gotSize ? parseValue : 0M;
                        break;
                    case 276:
                        indicativePrice = (arg.Item2 == "B");
                        break;

                    case 299:
                        quoteId = arg.Item2;
                        gotQuoteId = true;
                        break;
                }

                if (!gotSize || !gotPrice || !gotQuoteId) continue;

                if (!indicativePrice)
                {
                    switch (mdEntryType)
                    {
                        case MDEntry.Bid:
                            bids.Add(new Tuple<decimal, decimal, string>(size, price, quoteId));
                            break;
                        case MDEntry.Ask:
                            asks.Add(new Tuple<decimal, decimal, string>(size, price, quoteId));
                            break;
                    }
                }

                gotSize = gotPrice = gotQuoteId = indicativePrice = false;
                size = 0M;
                price = 0M;
                quoteId = string.Empty;
            }
        }

        private void SetConnectedStatus() {
            if (_mdclient.LoggedOn && _tdClient.LoggedOn && _rfqClient.LoggedOn) {
                toolStripApplicationStatus.Text = Resources.toolStrip_FIXConnected;
            } else {
                toolStripApplicationStatus.Text = Resources.toolStrip_FIXConnecting;
            }
        }

        private void SetDisconnectedStatus() {
            if (!_mdclient.LoggedOn && !_tdClient.LoggedOn && !_rfqClient.LoggedOn) {
                toolStripApplicationStatus.Text = Resources.toolStrip_FIXDisconnected;
            } else {
                toolStripApplicationStatus.Text = Resources.toolStrip_FIXDisconnecting;
            }
        }

        private void MDHandleLoggedOff(object sender, EventArgs e) {
            try {
                if (StatusStrip.InvokeRequired) {
                    if (!StatusStrip.IsHandleCreated) return;
                    Invoke((StatusBarUpdateCallBack)MDHandleLoggedOff, sender, e);
                } else {
                    toolStripMDStatus.BackColor = System.Drawing.Color.Red;

                    _mdclient.OnLogon -= MDFixClientOnLogon;
                    _mdclient.OnMarketDataRequestReject -= HandleMarketDataReject;
                    _mdclient.OnMarketDataSnapshot -= HandleMarketDataSnapshot;
                    _mdclient.OnUpdateStatus -= HandleStatusUpdate;

                    SetDisconnectedStatus();
                }
            } catch (InvalidOperationException) { }
        }

        private void HandleMarketDataReject(object sender, EventArgs e) { throw new NotImplementedException(); }

        private void MDFixClientOnLogon(object sender, EventArgs e) {
            if (StatusStrip.InvokeRequired) {
                Invoke((StatusBarUpdateCallBack)MDFixClientOnLogon, sender, e);
            } else {
                toolStripMDStatus.BackColor = System.Drawing.Color.Green;
                _mdclient.OnMarketDataRequestReject += HandleMarketDataReject;
                _mdclient.OnLogoff += MDHandleLoggedOff;
                _mdclient.OnMarketDataSnapshot += HandleMarketDataSnapshot;
                _mdclient.OnUpdateStatus += HandleStatusUpdate;

                SetConnectedStatus();
            }
        }

        private void TDFixClientOnLogon(object sender, EventArgs e) {
            if (StatusStrip.InvokeRequired) {
                Invoke((StatusBarUpdateCallBack)TDFixClientOnLogon, sender, e);
            } else {
                toolStripTDStatus.BackColor = System.Drawing.Color.Green;
                _tdClient.OnLogoff += TDHandleLoggedOff;
                _tdClient.OnExecutionReport += TDHandleExecution;
                _tdClient.OnFXAllocation += TDHandleAllocations;
                _tdClient.OnFXAllocationAcknowledgement += TDHandleAllocationAck;
                _tdClient.OnUpdateStatus += HandleStatusUpdate;

                SetConnectedStatus();
            }
        }

        private void TDHandleLoggedOff(object sender, EventArgs e) {
            try {
                if (StatusStrip.InvokeRequired) {
                    if (!StatusStrip.IsHandleCreated) return;
                    Invoke((StatusBarUpdateCallBack) TDHandleLoggedOff, sender, e);
                } else {
                    toolStripTDStatus.BackColor = System.Drawing.Color.Red;
                    _tdClient.OnLogon -= TDFixClientOnLogon;
                    _tdClient.OnExecutionReport -= TDHandleExecution;
                    _tdClient.OnFXAllocation -= TDHandleAllocations;
                    _tdClient.OnFXAllocationAcknowledgement -= TDHandleAllocationAck;
                    _tdClient.OnUpdateStatus -= HandleStatusUpdate;

                    SetDisconnectedStatus();
                }
            } catch(InvalidOperationException) {}
        }

        private void TDHandleExecution(object sender, EventArgs e) {
            var args = (FixMessageEventArgs) e;

            var execType = ExtractTag(150, args.FixTags);

            decimal parseValue;

            if (string.IsNullOrEmpty(execType) || string.IsNullOrWhiteSpace(execType)) return;
            var clientOrderId = ExtractTag(11, args.FixTags);
            var reportType = ExtractTag(20, args.FixTags);
            var orderStatus = ExtractTag(39, args.FixTags);
            var text = ExtractTag(58, args.FixTags);
            //var price = decimal.TryParse(ExtractTag(44, args.FixTags), out parseValue) ? parseValue : 0M;
            var price = decimal.TryParse(ExtractTag(31, args.FixTags), out parseValue) ? parseValue : 0M;
            var side = ExtractTag(54, args.FixTags);
            var filledQty = decimal.TryParse(ExtractTag(38, args.FixTags), out parseValue) ? parseValue : 0M;
            var cumulativeQty = decimal.TryParse(ExtractTag(14, args.FixTags), out parseValue) ? parseValue : 0M;
            var remainingQty = decimal.TryParse(ExtractTag(151, args.FixTags), out parseValue) ? parseValue : 0M;
            var avgPrice = decimal.TryParse(ExtractTag(6, args.FixTags), out parseValue) ? parseValue : 0M;
            var transactionTime = ExtractTag(60, args.FixTags);
            var lastSpotRate = decimal.TryParse(ExtractTag(194, args.FixTags), out parseValue) ? parseValue : 0M;
            
            var status = string.Empty;
            
            switch (orderStatus) {
                case "1":
                    //MessageBox.Show(string.Format("Order {0} was partially filled for {1} {2} at {3}", args.RequestId, side == "1" ? "BUY" : "SELL", filledQty, price));
                    status = "Partially Filled";
                    break;
                case "2":
                    //MessageBox.Show(string.Format("Order {0} was filled for {1} {2} at {3}", args.RequestId, side, filledQty, price));
                    status = "Filled";
                    break;
                case "4":
                    //MessageBox.Show(string.Format("Order {0} was cancelled - {1}", args.RequestId, text));
                    status = "Cancelled";
                    break;
                case "8":
                    //MessageBox.Show(string.Format("Order {0} was rejected - {1}", args.RequestId, text));
                    status = "Rejected - " + text;
                    break;
            }

            // TQ:

            var orders = _clientOrders.Where(item => item.RequestId == clientOrderId).ToArray();
            if (orders.Length > 0)
            {
                var order = orders[orders.Length - 1];

                order.Order.AddExecutionReport(new ExecutionReport
                {
                    RequestId = clientOrderId,
                    ReportType = reportType,
                    ExecutionType = execType,
                    OrderAmount = order.Order.NearAmount - order.Order.FarAmount,
                    FilledAmount = filledQty,
                    CumulativeAmount = cumulativeQty,
                    RemainingAmount = remainingQty,
                    FillPrice = price,
                    AveragePrice = avgPrice,
                    LastSpotRate = lastSpotRate,
                    TransactionTime = transactionTime,
                    Status = status
                });
            }

        }

        private static string ExtractTag(int tag, IEnumerable<Tuple<int, string>> tagList) {
            var tags = tagList.Where(item => item.Item1 == tag).ToArray();
            
            if (tags.Length > 0) {
                return tags[0].Item2;
            }

            return string.Empty;
        }

        private void TDHandleAllocations(object sender, EventArgs e) { throw new NotImplementedException(); }

        private void TDHandleAllocationAck(object sender, EventArgs e) { throw new NotImplementedException(); }

        private void RFQFixClientOnLogon(object sender, EventArgs e) {
            if (StatusStrip.InvokeRequired) {
                Invoke((StatusBarUpdateCallBack)RFQFixClientOnLogon, sender, e);
            } else {
                toolStripRFQStatus.BackColor = System.Drawing.Color.Green;
                _rfqClient.OnLogoff += RFQHandleLoggedOff;
                _rfqClient.OnUpdateStatus += HandleStatusUpdate;

                SetConnectedStatus();
            }
        }

        private void RFQHandleLoggedOff(object sender, EventArgs e) {
            try {
                if (StatusStrip.InvokeRequired) {
                    if (!StatusStrip.IsHandleCreated) return;
                    Invoke((StatusBarUpdateCallBack)RFQHandleLoggedOff, sender, e);
                } else {
                    toolStripRFQStatus.BackColor = System.Drawing.Color.Red;
                    _rfqClient.OnLogoff -= RFQHandleLoggedOff;
                    _rfqClient.OnUpdateStatus -= HandleStatusUpdate;

                    SetDisconnectedStatus();
                }
            } catch (InvalidOperationException) { }
        }

        private void ConnectMenuItemExitClick(object sender, EventArgs e) {
            ConnectMenuItemDisconnectClick(sender, e);
            Close();
        }

        private void ViewMenuItemShowQuoteIdClick(object sender, EventArgs e) {
            _showQuoteIds = !_showQuoteIds;
            ViewMenuItem_ShowQuoteId.Text = _showQuoteIds ? "Hide Quote Ids" : "Show Quote Ids";
            fxPricingControl1.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl2.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl3.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl4.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl5.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl6.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl7.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl8.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl9.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl10.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl11.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl12.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl13.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl14.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl15.SetDisplayQuoteId(_showQuoteIds);
            fxPricingControl16.SetDisplayQuoteId(_showQuoteIds);
        }

        private void NewQuoteRequestOnClick(object sender, EventArgs e) { ShowQuoteForm(new RFQRequestArgs()); }
        private void NewOrderRequestOnClick(object sender, EventArgs e) { ShowOrderForm(new NewOrderEventArgs()); }

        private void ShowQuoteForm(RFQRequestArgs args) {
            if (_rfqClient == null || !_rfqClient.LoggedOn) {
                toolStripApplicationStatus.Text = Resources.toolStrip_RFQNotConnected_Quotes;
                return;
            }
            var quoteForm = new RFQForm();

            quoteForm.OnSendRFQRequest += HandleNewRequestForQuote;
            quoteForm.OnSendRFQReject += HandleRequestForQuoteReject;
            quoteForm.OnSendRFQNewOrder += HandleRequestForQuoteOrder;
            quoteForm.OnRFQClose += HandleRFQClose;
            quoteForm.OnPricingResponse += QuoteFormOnPricingResponse;
            if (!string.IsNullOrEmpty(args.Symbol)) {
                quoteForm.SetSymbol(args.Symbol);
                quoteForm.SetTier(args.Tier);
            }

            quoteForm.Show(this);
        }

        private void QuoteFormOnPricingResponse(object sender, EventArgs eventArgs) {
            var pricingResponseEventArgs = (PricingResponseEventArgs) eventArgs;

            var requests = _pricingRequests.Where(item => item.RequestId == pricingResponseEventArgs.RequestId).ToArray();

            if (requests.Length == 0) return;

            var request = requests[requests.Length - 1];

            var response = new PricingResponse(pricingResponseEventArgs.RequestId, pricingResponseEventArgs.QuoteId, request) {
                Amount = request.NearAmount - request.FarAmount,
                LastSpotBid = pricingResponseEventArgs.LastSpotBid,
                LastSpotAsk = pricingResponseEventArgs.LastSpotAsk,
                NearBidPoints = pricingResponseEventArgs.NearBidPoints,
                NearAskPoints = pricingResponseEventArgs.NearAskPoints,
                NearAllInBid = pricingResponseEventArgs.NearAllInBid,
                NearAllInAsk = pricingResponseEventArgs.NearAllInAsk,
                FarBidPoints = pricingResponseEventArgs.FarBidPoints,
                FarAskPoints = pricingResponseEventArgs.FarAskPoints,
                FarAllInBid = pricingResponseEventArgs.FarAllInBid,
                FarAllInAsk = pricingResponseEventArgs.FarAllInAsk
            };

            request.AddPrice(response);
        }

        private void HandleRFQClose(object sender, EventArgs e) { 
            if (_rfqClient == null || !_rfqClient.LoggedOn) return;

            _rfqClient.OnQuote -= ((RFQForm) sender).HandleQuote;
            _rfqClient.OnQuoteAcknowledgement -= ((RFQForm)sender).HandleQuoteReject;
            _rfqClient.OnQuoteCancel -= ((RFQForm)sender).HandleQuoteCancel;
            _rfqClient.OnExecutionReport -= ((RFQForm) sender).HandleExecutionReport;
            _rfqClient.OnExecutionReport -= TDHandleExecution;
        }

        private void HandleRequestForQuoteOrder(object sender, EventArgs e) { 
            if (_rfqClient == null || !_rfqClient.LoggedOn) return;

            var args = (NewOrderEventArgs) e;

            INewOrderSingle order;

            var settings = new Settings();
            ClientOrder clientOrder;

            switch (args.InstrumentType) {
                case "SPOT":
                    order = new AutoSpotOrderSingle(args.Symbol, args.NearTenor, true, args.ClientRequestId) {
                                                              Account = settings.DefaultAccount,
                                                              Amount = args.NearAmount,
                                                              Currency = args.NearCurrency,
                                                              Price = args.LastSpotRate,
                                                              QuoteId = args.QuoteId,
                                                              Side = args.Side.ToUpper() == "BUY" ? 1 : 2,
                                                              SettlementDate = args.NearSettlementDate,
                                                              OrderType = args.OrderType
                                                          };

                    clientOrder = new ClientOrder {
                        TradeDate = DateTime.Now,
                        NearAmount = order.Amount, 
                        NearCurrency = order.Currency, 
                        NearTenor = order.Tenor, 
                        Symbol = order.Currency, 
                        InstrumentType = "SPOT",
                        OrderType = order.OrderType, 
                        QuoteId = order.QuoteId, 
                        RequestId = order.ClientRequestId, 
                        Side = order.Side == (int) FixSide.Buy ? "BUY" : "SELL", 
                        LastSpotRate = order.Price, 
                        NearSettlementDate = order.SettlementDate, 
                        NearAllocations = new List<Tuple<string, decimal>> { new Tuple<string, decimal>(order.Account, order.Amount)}
                    };
                    break;
                case "FORWARD":
                    order = new AutoOutrightOrderSingle(args.Symbol, args.NearTenor, true, args.ClientRequestId) {
                                                                  Account = settings.DefaultAccount,
                                                                  Amount = args.NearAmount,
                                                                  Currency = args.NearCurrency,
                                                                  Price = args.LastFarAllInPrice,
                                                                  QuoteId = args.QuoteId,
                                                                  //Symbol = args.Symbol,
                                                                  Side = args.Side.ToUpper() == "BUY" ? 1 : 2,
                                                                  //Tenor = args.NearTenor,
                                                                  SettlementDate = args.NearSettlementDate,
                                                                  LastSpotRate = args.LastSpotRate,
                                                                  LastForwardPoints = args.LastFarForwardPoints,
                                                                  OrderType = args.OrderType
                                                              };

                    clientOrder = new ClientOrder {
                        TradeDate = DateTime.Now,
                        NearAmount = order.Amount,
                        NearCurrency = order.Currency,
                        NearTenor = order.Tenor,
                        Symbol = order.Currency,
                        InstrumentType = "FORWARD",
                        OrderType = order.OrderType,
                        QuoteId = order.QuoteId,
                        RequestId = order.ClientRequestId,
                        Side = order.Side == (int)FixSide.Buy ? "BUY" : "SELL",
                        LastSpotRate = ((AutoOutrightOrderSingle)order).LastSpotRate,
                        LastNearForwardPoints = ((AutoOutrightOrderSingle)order).LastForwardPoints,
                        NearSettlementDate = order.SettlementDate,
                        NearAllocations = new List<Tuple<string, decimal>> { new Tuple<string, decimal>(order.Account, order.Amount) }
                    };
                    break;
                case "SWAP":
                    order = new AutoSwapOrderSingle(args.Symbol, args.FarTenor, true, args.ClientRequestId) {
                                                        Account = settings.DefaultAccount,
                                                        Amount = args.NearAmount,
                                                        Currency = args.NearCurrency,
                                                        Price = args.LastNearAllInPrice,
                                                        QuoteId = args.QuoteId,
                                                        Symbol = args.Symbol,
                                                        Side = args.Side.ToUpper() == "BUY" ? 1 : 2,
                                                        Tenor = args.NearTenor,
                                                        SettlementDate = args.NearSettlementDate,
                                                        Amount2 = args.FarAmount,
                                                        LastSpotRate = args.LastSpotRate,
                                                        LastForwardPoints = args.LastNearForwardPoints,
                                                        LastForwardPoints2 = args.LastFarForwardPoints,
                                                        Price2 = args.LastFarAllInPrice,
                                                        Tenor2 = args.FarTenor,
                                                        SettlementDate2 = args.FarSettlementDate,
                                                        OrderType = args.OrderType
                                                    };

                    clientOrder = new ClientOrder {
                        TradeDate = DateTime.Now,
                        NearAmount = order.Amount,
                        NearCurrency = order.Currency,
                        NearTenor = order.Tenor,
                        Symbol = order.Currency,
                        InstrumentType = "FORWARD",
                        OrderType = order.OrderType,
                        QuoteId = order.QuoteId,
                        RequestId = order.ClientRequestId,
                        Side = order.Side == (int)FixSide.Buy ? "BUY" : "SELL",
                        LastSpotRate = ((AutoSwapOrderSingle)order).LastSpotRate,
                        LastNearForwardPoints = ((AutoSwapOrderSingle)order).LastForwardPoints,
                        NearSettlementDate = order.SettlementDate,
                        // NearAllocations = new List<Tuple<string, decimal>> { new Tuple<string, decimal>(order.Account, order.Amount) },
                        LastFarForwardPoints = ((AutoSwapOrderSingle)order).LastForwardPoints2,
                        LastNearAllInPrice = order.Price,
                        LastFarAllInPrice = ((AutoSwapOrderSingle)order).Price2,
                        FarTenor = ((AutoSwapOrderSingle)order).Tenor2,
                        FarSettlementDate = ((AutoSwapOrderSingle)order).SettlementDate2,
                        FarCurrency = order.Currency,
                        FarAmount = ((AutoSwapOrderSingle)order).Amount2
                    };

                    break;
                default:
                    return;
            }

            if (_rfqClient.SendNewOrderSingle(order)) {
                ((RFQForm)sender).SetClientOrderId(order.ClientRequestId);
                ClientOrderBindingSource.Add(new OrderRequest(clientOrder.RequestId, "RFQ") {Order = clientOrder});
            }
        }

        private void HandleRequestForQuoteReject(object sender, EventArgs e) {
            if (_rfqClient == null || !_rfqClient.LoggedOn) return;

/*
            IQuoteRequest request;

            switch (((RFQEventArgs) e).InstrumentType) {
                case "SPOT":
                    request = new SpotQuoteRequest(((RFQEventArgs)e).ClientRequestId);
                    break;
                case "FORWARD":
                    request = new ForwardQuoteRequest(((RFQEventArgs)e).ClientRequestId);
                    break;
                case "SWAP":
                    request = new SwapQuoteRequest(((RFQEventArgs)e).ClientRequestId);
                    break;
                default:
                    return;
            }

            _rfqClient.RejectQuote(request, ((RFQEventArgs) e).QuoteId);
 * */
            RFQCancelEventArgs args = (RFQCancelEventArgs)e;
            _rfqClient.CancelQuoteRequest(args.QuoteRequestId);
        }

        private void HandleNewRequestForQuote(object sender, EventArgs e)
        {
            if (_rfqClient == null || !_rfqClient.LoggedOn) return;

            var args = (RFQEventArgs) e;

            IQuoteRequest qr;
            var settings = new Settings();

            switch (args.InstrumentType) {
                case "SPOT":
                    qr = new SpotQuoteRequest(settings.DefaultAccount, args.Symbol) {
                        Allocations = args.NearAllocations,
                        Amount = args.NearAmount,
                        Currency = args.NearCurrency,
                        SettlementDate = args.NearSettlementDate,
                        Side = FixSide.TwoWay
                    };

                    break;
                case "FORWARD":
                    qr = new ForwardQuoteRequest(settings.DefaultAccount, args.Symbol, args.FarTenor) {
                        Allocations = args.FarAllocations,
                        Amount = args.FarAmount,
                        Currency = args.FarCurrency,
                        Side = FixSide.TwoWay,
                        SettlementDate = args.FarSettlementDate
                    };
                    
                    break;
                case "SWAP":
                    qr = new SwapQuoteRequest(settings.DefaultAccount, args.Symbol, args.FarTenor) {
                        Allocations = args.NearAllocations,
                        FarAllocations = args.FarAllocations,
                        Amount = args.NearAmount,
                        FarAmount = args.FarAmount,
                        Currency = args.FarCurrency,
                        Side = FixSide.TwoWay,
                        Tenor = args.NearTenor,
                        SettlementDate = args.NearSettlementDate,
                        FarSettleDate = args.FarSettlementDate
                    };
                    break;
                default:
                    return;
            }

            ((RFQForm)sender).SetQuoteRequestId(qr.ClientRequestId);

            _rfqClient.OnQuote += ((RFQForm)sender).HandleQuote;
            _rfqClient.OnQuoteAcknowledgement += ((RFQForm)sender).HandleQuoteReject;
            _rfqClient.OnQuoteCancel += ((RFQForm)sender).HandleQuoteCancel;
            _rfqClient.OnExecutionReport += ((RFQForm) sender).HandleExecutionReport;
            _rfqClient.OnExecutionReport += TDHandleExecution;

            if (_rfqClient.RequestQuote(qr)) {
                // MessageBox.Show(string.Format("Quote Request {0} has been submitted", qr.ClientRequestId), "Quote Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);                
            }

            PricingRequestBindingSource.Add(new PricingRequest(qr));
            dataGridPricingRequests.Refresh();
        }


        private void ShowOrderForm(NewOrderEventArgs args) {
            if (_tdClient == null || !_tdClient.LoggedOn) {
                toolStripApplicationStatus.Text = Resources.toolStrip_TDNotConnected_Orders;
                return;
            }

            var orderForm = new NewOrderForm(args);
            orderForm.Show(this);
        }

        private void ConnectMenuItemDisconnectClick(object sender, EventArgs e) {
            if (_mdclient != null && _mdclient.LoggedOn) {
                _mdclient.Disconnect();

            }

            if (_tdClient != null && _tdClient.LoggedOn) {
                _tdClient.Disconnect();
            }

            if (_rfqClient != null && _rfqClient.LoggedOn) {
                _rfqClient.Disconnect();
            }
        }

        private void FXTradeSimulatorFormClosing(object sender, FormClosingEventArgs e) {
            ConnectMenuItemDisconnectClick(sender, e);
        }

        private void newSimpleOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSimpleOrderForm f = new NewSimpleOrderForm();
            f.OnNewOrderSimple += HandleNewOrderSingle;
            f.ShowDialog();
        }

        private void newMultiOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMultiLegOrderForm f = new NewMultiLegOrderForm();
            f.OnNewOrderMulti += HandleNewOrderMulti;
            f.ShowDialog();

        }

        private void FXTradeSimulator_Load(object sender, EventArgs e)
        {
            var settings = new Settings();
            if (settings.AutoConnect)
            {
                Connect();
            }
        }

        private void activateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridClientOrders.SelectedRows.Count == 0) return;
            OrderRequest req = dataGridClientOrders.SelectedRows[0].DataBoundItem as OrderRequest;
            if (req != null)
            {
                _tdClient.ToggleOrder(req.RequestId, true);
            }
        }

        private void deactivateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridClientOrders.SelectedRows.Count == 0) return;
            OrderRequest req = dataGridClientOrders.SelectedRows[0].DataBoundItem as OrderRequest;
            if (req != null)
            {
                _tdClient.ToggleOrder(req.RequestId, false);
            }
        }

        private void cancelOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridClientOrders.SelectedRows.Count == 0) return;
            OrderRequest req = dataGridClientOrders.SelectedRows[0].DataBoundItem as OrderRequest;
            if (req != null)
            {
                string side = req.Order.Side == "BUY" ? "1" : "2";
                toolStripApplicationStatus.Text = _tdClient.CancelOrder(req.Order.Symbol, req.RequestId, side) ? "Order cancelled" : "Could not cancel order";
            }
        }

        private void allocateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridClientOrders.SelectedRows.Count == 0) return;
            IList<OrderRequest> selectedOrders = new List<OrderRequest>();
            for (int i = 0; i < dataGridClientOrders.SelectedRows.Count; i++)
            {
                selectedOrders.Add(dataGridClientOrders.SelectedRows[i].DataBoundItem as OrderRequest);
            }

            bool validSelection = true;
            if (selectedOrders.Count > 0)
            {
                OrderRequest firstOrder = selectedOrders[0];
                for (int i = 1; i < selectedOrders.Count; i++)
                {
                    OrderRequest order = selectedOrders[i];
                    if (order.Order.Symbol != firstOrder.Order.Symbol)
                    {
                        validSelection = false;
                    }
                    if (order.Order.Side != firstOrder.Order.Side)
                    {
                        validSelection = false;
                    }
                    if (order.Order.TradeDate.ToString("yyyyMMdd") != firstOrder.Order.TradeDate.ToString("yyyyMMdd"))
                    {
                        validSelection = false;
                    }
                    if (order.Order.NearSettlementDate.ToString("yyyyMMdd") != firstOrder.Order.NearSettlementDate.ToString("yyyyMMdd"))
                    {
                        validSelection = false;
                    }
                }
            }

            /*
            if (!validSelection)
            {
                MessageBox.Show("All selected orders must have the same instrument, side, trade and settlement dates");
                return;
            }
            */

            AllocateOrderForm f = new AllocateOrderForm();
            f.OnAllocate += HandleOrderAllocationInstruction;
            f.InitializeOrderData(selectedOrders.ToArray());
            f.ShowDialog();
        }


    }
}
