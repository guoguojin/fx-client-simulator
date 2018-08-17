using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FIXClient;
using FXPricingControl;

namespace FXClientSimulator
{
    public partial class NewMultiLegOrderForm : Form
    {
        public event EventHandler OnNewOrderMulti;

        public NewMultiLegOrderForm()
        {
            InitializeComponent();

            cmbMultiLegOrderType.Items.AddRange(StaticData.MultiLegOrderTypes.Keys.Select(item => (object)item).ToArray());
            
            legOrderCtrl1.Symbols = StaticData.Symbols.Select(item => (object)item).ToArray();
            legOrderCtrl2.Symbols = StaticData.Symbols.Select(item => (object)item).ToArray();
            legOrderCtrl3.Symbols = StaticData.Symbols.Select(item => (object)item).ToArray();

            legOrderCtrl1.Sides = StaticData.Sides.Select(item => (object)item).ToArray();
            legOrderCtrl2.Sides = StaticData.Sides.Select(item => (object)item).ToArray();
            legOrderCtrl3.Sides = StaticData.Sides.Select(item => (object)item).ToArray();

            legOrderCtrl1.TIFTypes = StaticData.TIFs;
            legOrderCtrl2.TIFTypes = StaticData.TIFs;
            legOrderCtrl3.TIFTypes = StaticData.TIFs;

            legOrderCtrl1.TimeZones = StaticData.TimeZones;
            legOrderCtrl2.TimeZones = StaticData.TimeZones;
            legOrderCtrl3.TimeZones = StaticData.TimeZones;

            cmbTIF.Items.AddRange(StaticData.TIFs.Keys.Select(item => (object)item).ToArray());
            dtActivationTimeZone.Items.AddRange(StaticData.TimeZones.Select(Item => (object)Item).ToArray());
            dtExpirationTimeZone.Items.AddRange(StaticData.TimeZones.Select(Item => (object)Item).ToArray());
        }

        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> orderTypes = new Dictionary<string, string> {
                    {"Market", "1"},
                    {"Stop Loss", "3"},
                    {"Take Profit", "T"},
                };

            string type = cmbMultiLegOrderType.Text.ToUpper().Trim();
            if (type == "IF DONE" )
            {
                grpLeg1.Text = "IF";
                grpLeg2.Text = "DONE";
                grpLeg3.Text = "";

                grpLeg1.Enabled = legOrderCtrl1.Enabled = true;
                grpLeg2.Enabled = legOrderCtrl2.Enabled = true;
                grpLeg3.Enabled = legOrderCtrl3.Enabled = false;

                legOrderCtrl1.LegOrderTypes = orderTypes;
                legOrderCtrl2.LegOrderTypes = orderTypes;
                legOrderCtrl1.Touch();
                legOrderCtrl2.Touch();
            }
            else if (type == "OCO")
            {
                grpLeg1.Text = "OCO #1";
                grpLeg2.Text = "OCO #2";
                grpLeg3.Text = "";

                grpLeg1.Enabled = legOrderCtrl1.Enabled = true;
                grpLeg2.Enabled = legOrderCtrl2.Enabled = true;
                grpLeg3.Enabled = legOrderCtrl3.Enabled = false;

                legOrderCtrl1.LegOrderTypes = orderTypes;
                legOrderCtrl2.LegOrderTypes = orderTypes;

                legOrderCtrl1.Touch();
                legOrderCtrl2.Touch();

                legOrderCtrl1.Side = "SELL";
                legOrderCtrl2.Side = "SELL";
                legOrderCtrl1.OrderType = "Take Profit";
                legOrderCtrl2.OrderType = "Stop Loss";
            }
            else if (type == "IF DONE OCO")
            {
                grpLeg1.Text = "IF";
                grpLeg2.Text = "OCO #1";
                grpLeg3.Text = "OCO #2";

                grpLeg1.Enabled = legOrderCtrl1.Enabled = true;
                grpLeg2.Enabled = legOrderCtrl2.Enabled = true;
                grpLeg3.Enabled = legOrderCtrl3.Enabled = true;

                legOrderCtrl1.LegOrderTypes = orderTypes;
                legOrderCtrl2.LegOrderTypes = orderTypes;
                legOrderCtrl3.LegOrderTypes = orderTypes;

                legOrderCtrl1.Touch();
                legOrderCtrl2.Touch();
                legOrderCtrl3.Touch();
            }
        }

        private void txtSend_Click(object sender, EventArgs e)
        {
            var newOrderHandler = OnNewOrderMulti;

            int alertType = 0;
            if (chkAlertEmail.Checked)
            {
                alertType |= (int)1;
            }
            if (chkAlertSMS.Checked)
            {
                alertType |= (int)2;
            }

            var orderEventArgs = new NewMultiLegOrderEventArgs()
            {
                OrderType = StaticData.MultiLegOrderTypes[cmbMultiLegOrderType.Text],
                AlertType = alertType,
                TIF = StaticData.TIFs[cmbTIF.Text],
            };

            if (dtActivationTS.Enabled)
            {
                orderEventArgs.ActiveTimeStamp = dtActivationTS.Text;
                orderEventArgs.ActiveTimeZone = dtActivationTimeZone.Text;
            }

            if (dtExpirationTS.Enabled)
            {
                orderEventArgs.ExpireTimeStamp = dtExpirationTS.Text;
                orderEventArgs.ExpireTimeZone = dtExpirationTimeZone.Text;
            }

            IList<NewAutoOrderEventArgs> legs = new List<NewAutoOrderEventArgs>();
            if ((cmbMultiLegOrderType.Text.ToUpper() == "IF DONE") || (cmbMultiLegOrderType.Text.ToUpper() == "OCO"))
            {
                legs.Add(new NewAutoOrderEventArgs()
                    {
                        Symbol = legOrderCtrl1.Symbol,
                        Currency = legOrderCtrl1.Curency,
                        Side = legOrderCtrl1.Side,
                        Type = legOrderCtrl1.OrderType,
                        TIF = legOrderCtrl1.TIF,
                        Amount = legOrderCtrl1.Amount,
                        Price = legOrderCtrl1.Price,
                        ActiveTimeStamp = legOrderCtrl1.ActivationTimeStamp,
                        ActiveTimeZone= legOrderCtrl1.ActivationTimeZone,
                        ExpireTimeStamp = legOrderCtrl1.ExpirationTimeStamp,
                        ExpireTimeZone = legOrderCtrl1.ExpirationTimeZone,
                        SettlementDate = legOrderCtrl1.SettlementDate,
                        Account = legOrderCtrl1.Account
                        //Tier = cmbTier.Text,
                        //Symbol = cmbSymbol.Text,
                        //Currency = cmbCurrency.Text,
                        //Amount = (decimal.TryParse(txtQuantity.Text, out parseValue)) ? parseValue : 0M,
                        //Price = (decimal.TryParse(txtPrice.Text, out parseValue)) ? parseValue : 0M,
                        //QuoteId = "",
                        //Tenor = "SP",
                        //SettlementDate = dtSettlement.Value,
                    }
                );

                legs.Add(new NewAutoOrderEventArgs()
                {
                    Symbol = legOrderCtrl2.Symbol,
                    Currency = legOrderCtrl2.Curency,
                    Side = legOrderCtrl2.Side,
                    Type = legOrderCtrl2.OrderType,
                    TIF = legOrderCtrl2.TIF,
                    Amount = legOrderCtrl2.Amount,
                    Price = legOrderCtrl2.Price,
                    ActiveTimeStamp = legOrderCtrl2.ActivationTimeStamp,
                    ActiveTimeZone = legOrderCtrl2.ActivationTimeZone,
                    ExpireTimeStamp = legOrderCtrl2.ExpirationTimeStamp,
                    ExpireTimeZone = legOrderCtrl2.ExpirationTimeZone,
                    SettlementDate = legOrderCtrl2.SettlementDate,
                    Account = legOrderCtrl2.Account
                    //Tier = cmbTier.Text,
                    //Symbol = cmbSymbol.Text,
                    //Currency = cmbCurrency.Text,
                    //Amount = (decimal.TryParse(txtQuantity.Text, out parseValue)) ? parseValue : 0M,
                    //Price = (decimal.TryParse(txtPrice.Text, out parseValue)) ? parseValue : 0M,
                    //QuoteId = "",
                    //Tenor = "SP",
                    //SettlementDate = dtSettlement.Value,
                }
                );
            }
            else if (cmbMultiLegOrderType.Text.ToUpper() == "IF DONE OCO")
            {
                legs.Add(new NewAutoOrderEventArgs()
                {
                    Symbol = legOrderCtrl1.Symbol,
                    Currency = legOrderCtrl1.Curency,
                    Side = legOrderCtrl1.Side,
                    Type = legOrderCtrl1.OrderType,
                    TIF = legOrderCtrl1.TIF,
                    Amount = legOrderCtrl1.Amount,
                    Price = legOrderCtrl1.Price,
                    ActiveTimeStamp = legOrderCtrl1.ActivationTimeStamp,
                    ActiveTimeZone = legOrderCtrl1.ActivationTimeZone,
                    ExpireTimeStamp = legOrderCtrl1.ExpirationTimeStamp,
                    ExpireTimeZone = legOrderCtrl1.ExpirationTimeZone,
                    SettlementDate = legOrderCtrl1.SettlementDate,
                    Account = legOrderCtrl1.Account
                    //Tier = cmbTier.Text,
                    //Symbol = cmbSymbol.Text,
                    //Currency = cmbCurrency.Text,
                    //Amount = (decimal.TryParse(txtQuantity.Text, out parseValue)) ? parseValue : 0M,
                    //Price = (decimal.TryParse(txtPrice.Text, out parseValue)) ? parseValue : 0M,
                    //QuoteId = "",
                    //Tenor = "SP",
                    //SettlementDate = dtSettlement.Value,
                }
                );

                legs.Add(new NewAutoOrderEventArgs()
                {
                    Symbol = legOrderCtrl2.Symbol,
                    Currency = legOrderCtrl2.Curency,
                    Side = legOrderCtrl2.Side,
                    Type = legOrderCtrl2.OrderType,
                    TIF = legOrderCtrl2.TIF,
                    Amount = legOrderCtrl2.Amount,
                    Price = legOrderCtrl2.Price,
                    ActiveTimeStamp = legOrderCtrl2.ActivationTimeStamp,
                    ActiveTimeZone = legOrderCtrl2.ActivationTimeZone,
                    ExpireTimeStamp = legOrderCtrl2.ExpirationTimeStamp,
                    ExpireTimeZone = legOrderCtrl2.ExpirationTimeZone,
                    SettlementDate = legOrderCtrl2.SettlementDate,
                    Account = legOrderCtrl2.Account
                    //Tier = cmbTier.Text,
                    //Symbol = cmbSymbol.Text,
                    //Currency = cmbCurrency.Text,
                    //Amount = (decimal.TryParse(txtQuantity.Text, out parseValue)) ? parseValue : 0M,
                    //Price = (decimal.TryParse(txtPrice.Text, out parseValue)) ? parseValue : 0M,
                    //QuoteId = "",
                    //Tenor = "SP",
                    //SettlementDate = dtSettlement.Value,
                }
                );

                legs.Add(new NewAutoOrderEventArgs()
                {
                    Symbol = legOrderCtrl3.Symbol,
                    Currency = legOrderCtrl3.Curency,
                    Side = legOrderCtrl3.Side,
                    Type = legOrderCtrl3.OrderType,
                    TIF = legOrderCtrl3.TIF,
                    Amount = legOrderCtrl3.Amount,
                    Price = legOrderCtrl3.Price,
                    ActiveTimeStamp = legOrderCtrl3.ActivationTimeStamp,
                    ActiveTimeZone = legOrderCtrl3.ActivationTimeZone,
                    ExpireTimeStamp = legOrderCtrl3.ExpirationTimeStamp,
                    ExpireTimeZone = legOrderCtrl3.ExpirationTimeZone,
                    SettlementDate = legOrderCtrl3.SettlementDate,
                    Account = legOrderCtrl3.Account
                    //Tier = cmbTier.Text,
                    //Symbol = cmbSymbol.Text,
                    //Currency = cmbCurrency.Text,
                    //Amount = (decimal.TryParse(txtQuantity.Text, out parseValue)) ? parseValue : 0M,
                    //Price = (decimal.TryParse(txtPrice.Text, out parseValue)) ? parseValue : 0M,
                    //QuoteId = "",
                    //Tenor = "SP",
                    //SettlementDate = dtSettlement.Value,
                }
                );
            }

            orderEventArgs.Legs = legs.ToArray<NewAutoOrderEventArgs>();

            if (newOrderHandler != null) newOrderHandler(this, orderEventArgs);
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            dtActivationTS.Enabled = !chkActive.Checked;
            dtActivationTimeZone.Enabled = !chkActive.Checked;  
        }

        private void NewMultiLegOrderForm_Load(object sender, EventArgs e)
        {
            cmbTIF.SelectedIndex = 1;
            dtActivationTimeZone.SelectedIndex = 0;
            dtExpirationTimeZone.SelectedIndex = 0;
        }

        private void cmbTIF_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtExpirationTS.Enabled = false;
            dtExpirationTimeZone.Enabled = false;

            string tif = cmbTIF.Text.Trim();
            switch (tif)
            {
                case "GTC":
                    break;

                case "GFD":
                    dtExpirationTS.Enabled = false;
                    dtExpirationTimeZone.Enabled = false;
                    break;

                case "GTD":
                    dtExpirationTS.Enabled = true;
                    dtExpirationTimeZone.Enabled = true;
                    break;
            }
        }
    }
}
