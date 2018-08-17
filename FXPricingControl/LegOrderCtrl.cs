using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FXPricingControl
{
    public partial class LegOrderCtrl : UserControl
    {
        private Dictionary<string, string> OrderTypes = new Dictionary<string, string> {};
        private Dictionary<string, string> TIFs = new Dictionary<string, string> { };

        public object[] Symbols
        {
            set
            {
                cmbSymbol.Items.AddRange(value.Select(item => (object)item).ToArray());
            }
        }

        public Dictionary<string, string> TIFTypes
        {
            set
            {
                TIFs = value;
                cmbTIF.Items.Clear();
                cmbTIF.Items.AddRange(TIFs.Keys.Select(item => (object)item).ToArray());
            }
        }

        public Dictionary<string, string> LegOrderTypes
        {
            set
            {
                OrderTypes = value;
                cmbOrderType.Items.Clear();
                cmbOrderType.Items.AddRange(OrderTypes.Keys.Select(item => (object)item).ToArray());
            }
        }

        public object[] Sides
        {
            set
            {
                cmbSide.Items.AddRange(value.Select(item => (object)item).ToArray());
            }
        }

        public object[] TimeZones
        {
            set
            {
                dtActivationTimeZone.Items.AddRange(value.Select(item => (object)item).ToArray());
                dtExpirationTimeZone.Items.AddRange(value.Select(item => (object)item).ToArray());
            }
        }

        public string Symbol { get { return cmbSymbol.Text; } }
        public string Curency { get { return cmbCurrency.Text; } }
        public string Side { get { return cmbSide.Text; } set { cmbSide.Text = value; } }
        public string OrderType { get { return OrderTypes[cmbOrderType.Text]; } set { cmbOrderType.Text = value; } }
        public decimal Price { get { decimal parseValue; return (decimal.TryParse(txtPrice.Text, out parseValue)) ? parseValue : 0M; } }
        public decimal Amount { get { decimal parseValue; return (decimal.TryParse(txtQuantity.Text, out parseValue)) ? parseValue : 0M; } }
        public string TIF { get { return TIFs[cmbTIF.Text]; } }
        public bool Active { get { return chkActive.Checked; } }
        public string ActivationTimeStamp { get { return dtActivationTS.Enabled ? dtActivationTS.Text : null; } }
        public string ActivationTimeZone { get { return dtActivationTimeZone.Enabled ? dtActivationTimeZone.Text : null; } }
        public string ExpirationTimeStamp { get { return dtExpirationTS.Enabled ? dtExpirationTS.Text : null; } }
        public string ExpirationTimeZone { get { return dtExpirationTimeZone.Enabled ? dtExpirationTimeZone.Text : null; } }
        public DateTime SettlementDate { get { return dtSettleDate.Value; } }
        public string Account { get { return txtAllocation.Text; } }

        public LegOrderCtrl()
        {
            InitializeComponent();
        }

        public void Touch()
        {
            cmbSide.SelectedIndex = 0;
            cmbOrderType.SelectedIndex = 0;
            txtQuantity.Text = "1000000";
            cmbTIF.SelectedIndex = 1;
            chkActive.Checked = true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "5000000";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "10000000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = "20000000";
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            dtActivationTS.Enabled = !chkActive.Checked;
            dtActivationTimeZone.Enabled = !chkActive.Checked;
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
