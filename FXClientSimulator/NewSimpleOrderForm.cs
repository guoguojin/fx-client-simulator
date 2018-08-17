using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using FXPricingControl;
using FXClientSimulator.Properties;

namespace FXClientSimulator
{
    public partial class NewSimpleOrderForm : Form
    {
        public event EventHandler OnNewOrderSimple;

        public NewSimpleOrderForm()
        {
            InitializeComponent();

            cmbSymbol.Items.AddRange(StaticData.Symbols.Select(item => (object)item).ToArray());
            //cmbTier.Items.AddRange(StaticData.Tiers.Select(item => (object)item).ToArray());
            //cmbInstrumentType.Items.AddRange(StaticData.RFQTypes.Select(item => (object)item).ToArray());
            cmbOrderType.Items.AddRange(StaticData.OrderTypes.Keys.Select(item => (object)item).ToArray());
            cmbTIF.Items.AddRange(StaticData.TIFs.Keys.Select(item => (object)item).ToArray());
            cmbSide.Items.AddRange(StaticData.Sides.Select(item => (object)item).ToArray());
            dtActivationTimeZone.Items.AddRange(StaticData.TimeZones.Select(Item => (object)Item).ToArray());
            dtExpirationTimeZone.Items.AddRange(StaticData.TimeZones.Select(Item => (object)Item).ToArray());
        }

        private void NewSimpleOrderForm_Load(object sender, EventArgs e)
        {
            //cmbTier.SelectedIndex = 0;
            cmbSymbol.SelectedIndex = 1;
            makeOrderCurrency();
            //cmbInstrumentType.SelectedIndex = 0;
            cmbOrderType.SelectedIndex = 0;
            cmbOrderType.SelectedIndex = 0;
            cmbTIF.SelectedIndex = 1;
            cmbSide.SelectedIndex = 0;
            txtQuantity.Text = "1000000";
            dtActivationTimeZone.SelectedIndex = 0;
            dtExpirationTimeZone.SelectedIndex = 0;
        }

        private void makeOrderCurrency()
        {
            string[] parts = cmbSymbol.Text.Split('/');
            if (parts.Length == 2)
            {
                cmbCurrency.Items.Clear();
                cmbCurrency.Items.AddRange(parts);
                if (cmbCurrency.Items.Count > 0)
                {
                    cmbCurrency.SelectedIndex = 0;
                }
 
            }            
        }

        private void cmbSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            makeOrderCurrency();
        }

        private void txtSend_Click(object sender, EventArgs e)
        {
            var newOrderHandler = OnNewOrderSimple;

            decimal parseValue;

            int alertType = 0;
            if (chkAlertEmail.Checked)
            {
                alertType |= (int)1;
            }
            if (chkAlertSMS.Checked)
            {
                alertType |= (int)2;
            }

            var orderEventArgs = new NewAutoOrderEventArgs
            {
                Type = StaticData.OrderTypes[cmbOrderType.Text],
                //Tier = cmbTier.Text,
                Symbol = cmbSymbol.Text,
                Currency = cmbCurrency.Text,
                Side = cmbSide.Text,
                Amount = (decimal.TryParse(txtQuantity.Text, out parseValue)) ? parseValue : 0M,
                Price = (decimal.TryParse(txtPrice.Text, out parseValue)) ? parseValue : 0M,
                QuoteId = "",
                Tenor = "SP",
                SettlementDate = dtSettlement.Value,
                TIF = StaticData.TIFs[cmbTIF.Text],
                BenchmarkType = txtBenchmarkType.Text.Trim(),
                Account = txtAllocation.Text.Trim(),
                AlertType = alertType
                //Bid = (decimal.TryParse(lblBid.Text + lblBidPips.Text + lblBidBps.Text, out parseValue)) ? parseValue : 0M,
                //Ask = (decimal.TryParse(lblAsk.Text + lblAskPips.Text + lblAskBps.Text, out parseValue)) ? parseValue : 0M,
                //BidQuoteId = lblBidQuoteId.Text,
                //AskQuoteId = lblAskQuoteId.Text
            };

            if (dtActivationTS.Enabled)
            {
                orderEventArgs.ActiveTimeStamp = dtActivationTS.Text.Trim();
                orderEventArgs.ActiveTimeZone = dtActivationTimeZone.Text;
            }

            if (dtExpirationTS.Enabled)
            {
                orderEventArgs.ExpireTimeStamp = dtExpirationTS.Text.Trim();
                orderEventArgs.ExpireTimeZone = dtExpirationTimeZone.Text;
            }

            if (newOrderHandler != null) newOrderHandler(this, orderEventArgs);
        }

        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderType.Text == "Market")
            {
                txtPrice.Text = "";
            }
            else if (cmbOrderType.Text == "Benchmark")
            {
                txtBenchmarkType.Text = "BOE";
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Length < 1) return;

            var postFix = (txtQuantity.Text.Length > 1) ? txtQuantity.Text.Substring(txtQuantity.Text.Length - 1).ToUpper() : "";

            int lastDigit;
            float prefixNumber;

            var lastDigitIsNumeric = int.TryParse(postFix, out lastDigit);

            if (lastDigitIsNumeric) return;

            if (!float.TryParse(txtQuantity.Text.Substring(0, txtQuantity.Text.Length - postFix.Length), out prefixNumber))
            {
                MessageBox.Show(Resources.SysMsg_InvalidAmount, Resources.SysTitle_InvalidInput, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            switch (postFix)
            {
                case "T":
                    txtQuantity.Text = (prefixNumber * 1000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
                case "M":
                    txtQuantity.Text = (prefixNumber * 1000000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
            }
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

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            dtActivationTS.Enabled = !chkActive.Checked;
            dtActivationTimeZone.Enabled = !chkActive.Checked;            
        }

        private void btnQty1_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "5000000";
        }

        private void btnQty2_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "10000000";
        }

        private void btnQty3_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "20000000";
        }


        
    }
}
