using System;
using System.ComponentModel;
using System.Data.Linq;
using Extensions;

namespace FXClientSimulator {
    partial class PricingResponsesSubForm {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PricingResponsesSubForm));
            this.PricingResponseBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.PricingResponseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PricingResponseDataGridView = new Extensions.DataGridViewExtension();
            this.ColumnRequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuoteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastSpotBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastSpotAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNearBidPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNearAskPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNearAllInBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNearAllInAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFarBidPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFarAskPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFarAllInBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFarAllInAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PricingResponseBindingNavigator)).BeginInit();
            this.PricingResponseBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PricingResponseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PricingResponseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PricingResponseBindingNavigator
            // 
            this.PricingResponseBindingNavigator.AddNewItem = null;
            this.PricingResponseBindingNavigator.BindingSource = this.PricingResponseBindingSource;
            this.PricingResponseBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.PricingResponseBindingNavigator.DeleteItem = null;
            this.PricingResponseBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.PricingResponseBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.PricingResponseBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.PricingResponseBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.PricingResponseBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.PricingResponseBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.PricingResponseBindingNavigator.Name = "PricingResponseBindingNavigator";
            this.PricingResponseBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.PricingResponseBindingNavigator.Size = new System.Drawing.Size(1160, 25);
            this.PricingResponseBindingNavigator.TabIndex = 0;
            this.PricingResponseBindingNavigator.Text = "pricingResponseNavigator";
            // 
            // PricingResponseBindingSource
            // 
            this.PricingResponseBindingSource.DataSource = typeof(System.Data.Linq.EntitySet<FXClientSimulator.PricingResponse>);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(33, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // PricingResponseDataGridView
            // 
            this.PricingResponseDataGridView.AlternateRowColor = System.Drawing.Color.LightGray;
            this.PricingResponseDataGridView.AutoGenerateColumns = false;
            this.PricingResponseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PricingResponseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnRequestId,
            this.ColumnQuoteId,
            this.Amount,
            this.ColumnLastSpotBid,
            this.ColumnLastSpotAsk,
            this.ColumnNearBidPoints,
            this.ColumnNearAskPoints,
            this.ColumnNearAllInBid,
            this.ColumnNearAllInAsk,
            this.ColumnFarBidPoints,
            this.ColumnFarAskPoints,
            this.ColumnFarAllInBid,
            this.ColumnFarAllInAsk});
            this.PricingResponseDataGridView.DataSource = this.PricingResponseBindingSource;
            this.PricingResponseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PricingResponseDataGridView.Location = new System.Drawing.Point(0, 25);
            this.PricingResponseDataGridView.Name = "PricingResponseDataGridView";
            this.PricingResponseDataGridView.Size = new System.Drawing.Size(1160, 123);
            this.PricingResponseDataGridView.TabIndex = 1;
            // 
            // ColumnRequestId
            // 
            this.ColumnRequestId.DataPropertyName = "RequestId";
            this.ColumnRequestId.HeaderText = "Request Id";
            this.ColumnRequestId.Name = "ColumnRequestId";
            this.ColumnRequestId.ReadOnly = true;
            this.ColumnRequestId.Visible = false;
            // 
            // ColumnQuoteId
            // 
            this.ColumnQuoteId.DataPropertyName = "QuoteId";
            this.ColumnQuoteId.HeaderText = "Quote Id";
            this.ColumnQuoteId.Name = "ColumnQuoteId";
            this.ColumnQuoteId.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // ColumnLastSpotBid
            // 
            this.ColumnLastSpotBid.DataPropertyName = "LastSpotBid";
            this.ColumnLastSpotBid.HeaderText = "Last Spot Bid";
            this.ColumnLastSpotBid.Name = "ColumnLastSpotBid";
            this.ColumnLastSpotBid.ReadOnly = true;
            // 
            // ColumnLastSpotAsk
            // 
            this.ColumnLastSpotAsk.DataPropertyName = "LastSpotAsk";
            this.ColumnLastSpotAsk.HeaderText = "Last Spot Ask";
            this.ColumnLastSpotAsk.Name = "ColumnLastSpotAsk";
            this.ColumnLastSpotAsk.ReadOnly = true;
            // 
            // ColumnNearBidPoints
            // 
            this.ColumnNearBidPoints.DataPropertyName = "NearBidPoints";
            this.ColumnNearBidPoints.HeaderText = "Near Bid Points";
            this.ColumnNearBidPoints.Name = "ColumnNearBidPoints";
            this.ColumnNearBidPoints.ReadOnly = true;
            // 
            // ColumnNearAskPoints
            // 
            this.ColumnNearAskPoints.DataPropertyName = "NearAskPoints";
            this.ColumnNearAskPoints.HeaderText = "Near Ask Points";
            this.ColumnNearAskPoints.Name = "ColumnNearAskPoints";
            this.ColumnNearAskPoints.ReadOnly = true;
            // 
            // ColumnNearAllInBid
            // 
            this.ColumnNearAllInBid.DataPropertyName = "NearAllInBid";
            this.ColumnNearAllInBid.HeaderText = "Near All-In Bid";
            this.ColumnNearAllInBid.Name = "ColumnNearAllInBid";
            this.ColumnNearAllInBid.ReadOnly = true;
            // 
            // ColumnNearAllInAsk
            // 
            this.ColumnNearAllInAsk.DataPropertyName = "NearAllInAsk";
            this.ColumnNearAllInAsk.HeaderText = "Near All-In Ask";
            this.ColumnNearAllInAsk.Name = "ColumnNearAllInAsk";
            this.ColumnNearAllInAsk.ReadOnly = true;
            // 
            // ColumnFarBidPoints
            // 
            this.ColumnFarBidPoints.DataPropertyName = "FarBidPoints";
            this.ColumnFarBidPoints.HeaderText = "Far Bid Points";
            this.ColumnFarBidPoints.Name = "ColumnFarBidPoints";
            this.ColumnFarBidPoints.ReadOnly = true;
            // 
            // ColumnFarAskPoints
            // 
            this.ColumnFarAskPoints.DataPropertyName = "FarAskPoints";
            this.ColumnFarAskPoints.HeaderText = "Far Ask Points";
            this.ColumnFarAskPoints.Name = "ColumnFarAskPoints";
            this.ColumnFarAskPoints.ReadOnly = true;
            // 
            // ColumnFarAllInBid
            // 
            this.ColumnFarAllInBid.DataPropertyName = "FarAllInBid";
            this.ColumnFarAllInBid.HeaderText = "Far All-In Bid";
            this.ColumnFarAllInBid.Name = "ColumnFarAllInBid";
            this.ColumnFarAllInBid.ReadOnly = true;
            // 
            // ColumnFarAllInAsk
            // 
            this.ColumnFarAllInAsk.DataPropertyName = "FarAllInAsk";
            this.ColumnFarAllInAsk.HeaderText = "Far All-In Ask";
            this.ColumnFarAllInAsk.Name = "ColumnFarAllInAsk";
            this.ColumnFarAllInAsk.ReadOnly = true;
            // 
            // PricingResponsesSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PricingResponseDataGridView);
            this.Controls.Add(this.PricingResponseBindingNavigator);
            this.Name = "PricingResponsesSubForm";
            this.Size = new System.Drawing.Size(1160, 148);
            ((System.ComponentModel.ISupportInitialize)(this.PricingResponseBindingNavigator)).EndInit();
            this.PricingResponseBindingNavigator.ResumeLayout(false);
            this.PricingResponseBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PricingResponseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PricingResponseDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PricingResponseBindingSourceOnAddingNew(object sender, AddingNewEventArgs addingNewEventArgs) {
            //var response = new PricingResponse(_pricingRequest.RequestId, string.Empty, _pricingRequest);
            //addingNewEventArgs.NewObject = response;
        }

        #endregion

        private System.Windows.Forms.BindingNavigator PricingResponseBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private Extensions.DataGridViewExtension PricingResponseDataGridView;
        private System.Windows.Forms.BindingSource PricingResponseBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuoteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastSpotBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastSpotAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNearBidPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNearAskPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNearAllInBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNearAllInAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFarBidPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFarAskPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFarAllInBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFarAllInAsk;
    }
}
