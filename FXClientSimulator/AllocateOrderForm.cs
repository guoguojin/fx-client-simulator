using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FXClientSimulator.Properties;
using System.Globalization;

namespace FXClientSimulator
{
    public partial class AllocateOrderForm : Form
    {
        public event EventHandler OnAllocate;
        private readonly List<Tuple<string, decimal>> _allocations;
        private readonly List<Tuple<string, decimal, decimal>> _orders;

        public AllocateOrderForm()
        {
            InitializeComponent();
            _allocations = new List<Tuple<string, decimal>>();
            _orders = new List<Tuple<string, decimal, decimal>>();
        }

        public void InitializeOrderData(OrderRequest[] orders)
        {
            if (orders.Length > 0)
            {
                OrderRequest req = orders[0];
                txtSymbol.Text = req.Order.Symbol;
                txtCurrency.Text = req.Order.NearCurrency;
                txtQuantity.Text = req.Order.NearAmount.ToString();
                cmbSide.Text = req.Order.Side;
                txtTradeDate.Text = req.Order.TradeDate.ToString("yyyyMMdd");
                txtSettleDate.Text = req.Order.NearSettlementDate.ToString("yyyyMMdd");

                txtAllocAvgPrice.Text = req.Order.AvgPrice.ToString();
                Random rnd = new Random();
                txtAllocID.Text = string.Format("ALLOC-{0}", rnd.Next(0, 1000000));

                cmbAllocSide.SelectedIndex = 0;

                foreach (OrderRequest request in orders)
                {
                    addOrder(request.Order.RequestId, request.Order.NearAmount);
                }
            }
        }

        private void updateAllocationsTotalQuantity()
        {
            decimal qty = 0;
            foreach (Tuple<string, decimal> item in _allocations)
            {
                qty += item.Item2;
            }
            txtTotalQty.Text = qty.ToString();
        }

        private void btnRemoveNearAllocation_Click(object sender, EventArgs e)
        {
            if (listAllocations.SelectedIndices.Count <= 0) return;
            _allocations.RemoveAt(listAllocations.SelectedIndices[0]);
            listAllocations.Items.RemoveAt(listAllocations.SelectedIndices[0]);
            updateAllocationsTotalQuantity();
        }

        private void btnAddNearAllocation_Click(object sender, EventArgs e)
        {
            decimal parseValue;
            if (!decimal.TryParse(txtAllocation.Text, out parseValue))
            {
                MessageBox.Show("Quantity for the allocation provided is invalid, cannot add this allocation.", "Invalid Allocation Amount", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cmbAllocSide.Text == "SELL")
            {
                parseValue *= -1;
            }

            _allocations.Add(new Tuple<string, decimal>(cmbAccount.Text, parseValue));
            ListViewItem item = new ListViewItem(cmbAccount.Text);
            item.SubItems.Add(parseValue.ToString());
            listAllocations.Items.Add(item);
            updateAllocationsTotalQuantity();
        }

        private void txtSend_Click(object sender, EventArgs e)
        {
            decimal parseValue;

            var handler = OnAllocate;
            var args = new AllocationRequestEventArgs() {
                AllocId = txtAllocID.Text.Trim(),
                Side = cmbSide.Text.Trim(),
                Symbol = txtSymbol.Text.Trim(),
                Quantity = (decimal.TryParse(txtTotalQty.Text, out parseValue)) ? parseValue : 0M,
                Currency = txtCurrency.Text.Trim(),
                AvgPrice = (decimal.TryParse(txtAllocAvgPrice.Text, out parseValue)) ? parseValue : 0M,
                TradeDate = txtTradeDate.Text.Trim(),
                SettlementDate = txtSettleDate.Text.Trim(),
                Allocations = _allocations,
                Orders = _orders
            };

            /*
            args.Orders = new List<Tuple<string, decimal, decimal>>();
            decimal orderQty = (decimal.TryParse(txtQuantity.Text, out parseValue)) ? parseValue : 0M;
            decimal orderAvgPrice = (decimal.TryParse(txtAvgPrice.Text, out parseValue)) ? parseValue : 0M;
            args.Orders.Add(new Tuple<string, decimal, decimal>(txtTradeID.Text.Trim(), orderQty, orderAvgPrice));
            */

            if (handler != null) handler(this, args);
        }

        private void AllocateOrderForm_Load(object sender, EventArgs e)
        {
            cmbSide.Items.AddRange(StaticData.Sides.Select(item => (object)item).ToArray());
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

        private void txtAllocation_TextChanged(object sender, EventArgs e)
        {
            if (txtAllocation.Text.Length < 1) return;

            var postFix = (txtAllocation.Text.Length > 1) ? txtAllocation.Text.Substring(txtAllocation.Text.Length - 1).ToUpper() : "";

            int lastDigit;
            float prefixNumber;

            var lastDigitIsNumeric = int.TryParse(postFix, out lastDigit);

            if (lastDigitIsNumeric) return;

            if (!float.TryParse(txtAllocation.Text.Substring(0, txtAllocation.Text.Length - postFix.Length), out prefixNumber))
            {
                MessageBox.Show(Resources.SysMsg_InvalidAmount, Resources.SysTitle_InvalidInput, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            switch (postFix)
            {
                case "T":
                    txtAllocation.Text = (prefixNumber * 1000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
                case "M":
                    txtAllocation.Text = (prefixNumber * 1000000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
            }
        }

        private void addOrder(string id, decimal qty)
        {
            ListViewItem item = listOrders.Items.Add(id);
            item.SubItems.Add(qty.ToString());

            decimal parseValue;
            decimal orderAvgPrice = (decimal.TryParse(txtAllocAvgPrice.Text, out parseValue)) ? parseValue : 0M;
            _orders.Add(new Tuple<string, decimal, decimal>(id, qty, orderAvgPrice));
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            decimal parseValue;
            if (!decimal.TryParse(txrOrderAmount.Text, out parseValue))
            {
                MessageBox.Show("Quantity for the order provided is invalid, cannot add this order.", "Invalid Order Amount", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }
            addOrder(cmbOrder.Text.Trim(), parseValue);
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (listOrders.SelectedIndices.Count <= 0) return;
            _orders.RemoveAt(listOrders.SelectedIndices[0]);
            listOrders.Items.RemoveAt(listOrders.SelectedIndices[0]);
        }

        private void cmbOrder_TextChanged(object sender, EventArgs e)
        {

        }

        private void txrOrderAmount_TextChanged(object sender, EventArgs e)
        {
            if (txrOrderAmount.Text.Length < 1) return;

            var postFix = (txrOrderAmount.Text.Length > 1) ? txrOrderAmount.Text.Substring(txrOrderAmount.Text.Length - 1).ToUpper() : "";

            int lastDigit;
            float prefixNumber;

            var lastDigitIsNumeric = int.TryParse(postFix, out lastDigit);

            if (lastDigitIsNumeric) return;

            if (!float.TryParse(txrOrderAmount.Text.Substring(0, txrOrderAmount.Text.Length - postFix.Length), out prefixNumber))
            {
                MessageBox.Show(Resources.SysMsg_InvalidAmount, Resources.SysTitle_InvalidInput, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            switch (postFix)
            {
                case "T":
                    txrOrderAmount.Text = (prefixNumber * 1000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
                case "M":
                    txrOrderAmount.Text = (prefixNumber * 1000000f).ToString("############0", NumberFormatInfo.InvariantInfo);
                    break;
            }
        }


    }
}
