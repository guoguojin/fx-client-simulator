using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FXClientSimulator {

    public partial class OrderDetailSubform : Extensions.DataGridViewSubForm {
        private delegate void NewExecutionReportCallBack(ExecutionReportAddedEventArgs theReport);

        private readonly OrderRequest _orderRequest;
        private NewExecutionReportCallBack newExecutionReportCallBack;

        public OrderDetailSubform(object dataBoundItem, Extensions.DataGridViewSubformCell cell) : base(dataBoundItem, cell) {
            InitializeComponent();
            newExecutionReportCallBack = new NewExecutionReportCallBack(onNewExecutionReport);

            _orderRequest = (OrderRequest) dataBoundItem;
            executionBindingSource.DataSource = _orderRequest.Order.Executions;
            executionsNavigator.BindingSource = executionBindingSource;
            dataGridViewExecutions.DataSource = executionBindingSource;

            _orderRequest.Order.ExecutionReportAdded += OrderOnExecutionReportAdded;

            // details tab
            txtSymbol.Text = _orderRequest.Order.Symbol;
            txtSide.Text = _orderRequest.Order.Side;
            txtInstrumentType.Text = _orderRequest.Order.InstrumentType;
            txtOrderType.Text = _orderRequest.Order.OrderType;
            txtSummaryLastSpot.Text = _orderRequest.Order.LastSpotRate.ToString(CultureInfo.InvariantCulture);
            txtSummaryNearPoints.Text = _orderRequest.Order.LastNearForwardPoints.ToString(CultureInfo.InvariantCulture);
            txtSummaryNearAllIn.Text = _orderRequest.Order.LastNearAllInPrice.ToString(CultureInfo.InvariantCulture);
            txtSummaryFarPoints.Text = _orderRequest.Order.LastFarForwardPoints.ToString(CultureInfo.InvariantCulture);
            txtSummaryFarAllIn.Text = _orderRequest.Order.LastFarAllInPrice.ToString(CultureInfo.InvariantCulture);
            txtSummaryStatus.Text = _orderRequest.Order.Status;

            // near tab
            txtNearAmount.Text = _orderRequest.Order.NearAmount.ToString(CultureInfo.InvariantCulture);
            txtNearCurrency.Text = _orderRequest.Order.NearCurrency;
            txtNearTenor.Text = _orderRequest.Order.NearTenor;
            txtNearSettles.Text = _orderRequest.Order.NearSettlementDate.ToString("dd-MMM-yyyy");
            txtNearSpot.Text = _orderRequest.Order.LastSpotRate.ToString(CultureInfo.InvariantCulture);
            txtNearPoints.Text = _orderRequest.Order.LastNearForwardPoints.ToString(CultureInfo.InvariantCulture);
            txtNearAllIn.Text = _orderRequest.Order.LastNearAllInPrice.ToString(CultureInfo.InvariantCulture);
            lstNearAllocations.DataSource = _orderRequest.Order.NearAllocations;
            
            // far tab
            txtFarAmount.Text = _orderRequest.Order.FarAmount.ToString(CultureInfo.InvariantCulture);
            txtFarCurrency.Text = _orderRequest.Order.FarCurrency;
            txtFarTenor.Text = _orderRequest.Order.FarTenor;
            txtFarSettles.Text = _orderRequest.Order.FarSettlementDate.ToString("dd-MMM-yyyy");
            txtFarSpot.Text = _orderRequest.Order.LastSpotRate.ToString(CultureInfo.InvariantCulture);
            txtFarPoints.Text = _orderRequest.Order.LastFarForwardPoints.ToString(CultureInfo.InvariantCulture);
            txtFarAllIn.Text = _orderRequest.Order.LastFarAllInPrice.ToString(CultureInfo.InvariantCulture);
            lstFarAllocations.DataSource = _orderRequest.Order.FarAllocations;
        }

        private void OrderOnExecutionReportAdded(object sender, EventArgs eventArgs) {
            var executionReportArgs = (ExecutionReportAddedEventArgs)eventArgs;
            if ( InvokeRequired ) 
            {
                Invoke(newExecutionReportCallBack, new object[] { executionReportArgs } );
            }
            else
            {
                onNewExecutionReport(executionReportArgs);
            }
        }

        private void onNewExecutionReport(ExecutionReportAddedEventArgs reportArgs)
        {
            //executionBindingSource.Add(reportArgs.ExecutionReport);
            dataGridViewExecutions.Refresh();            
        }
    }
}
