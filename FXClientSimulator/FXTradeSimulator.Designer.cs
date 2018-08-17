using Extensions;

namespace FXClientSimulator {
    partial class FXTradeSimulator {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.MenuStripMainMenu = new System.Windows.Forms.MenuStrip();
            this.ConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectMenuItem_Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectMenuItem_Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectMenuItem_ConnectionSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ConnectMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.QuotesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuoteMenuItem_NewQuoteRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersMenuItem_NewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.newSimpleOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMultiOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuItem_ShowQuoteId = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripMDStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTDStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripRFQStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripApplicationStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ApplicationStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PricingRequestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClientOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fxPricingControl1 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl11 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl12 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl8 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl4 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl2 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl3 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl5 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl6 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl7 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl9 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl10 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl13 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl14 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl15 = new FXPricingControl.FXPricingControl();
            this.fxPricingControl16 = new FXPricingControl.FXPricingControl();
            this.dataGridClientOrders = new Extensions.DataGridViewExtension();
            this.ColumnOrderDetails = new Extensions.DataGridViewSubformColumn();
            this.ColumnOrderRequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridPricingRequests = new Extensions.DataGridViewExtension();
            this.ColumnResponses = new Extensions.DataGridViewSubformColumn();
            this.ColumnRequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNearTenor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarTenor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNearSettle = new Extensions.DataGridViewDateTimeColumn();
            this.ColumnFarSettle = new Extensions.DataGridViewDateTimeColumn();
            this.ColumnSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNearAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFarAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNearAllocations = new Extensions.DataGridViewSubformColumn();
            this.ColumnFarAllocations = new Extensions.DataGridViewSubformColumn();
            this.allocateOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripMainMenu.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PricingRequestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientOrderBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPricingRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStripMainMenu
            // 
            this.MenuStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectMenuItem,
            this.QuotesMenuItem,
            this.OrdersMenuItem,
            this.ViewMenuItem});
            this.MenuStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMainMenu.Name = "MenuStripMainMenu";
            this.MenuStripMainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MenuStripMainMenu.Size = new System.Drawing.Size(1696, 28);
            this.MenuStripMainMenu.TabIndex = 1;
            this.MenuStripMainMenu.Text = "Main Menu";
            // 
            // ConnectMenuItem
            // 
            this.ConnectMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectMenuItem_Edit,
            this.ConnectMenuItem_Connect,
            this.ConnectMenuItem_Disconnect,
            this.ConnectMenuItem_ConnectionSeparator,
            this.ConnectMenuItem_Exit});
            this.ConnectMenuItem.Name = "ConnectMenuItem";
            this.ConnectMenuItem.Size = new System.Drawing.Size(120, 24);
            this.ConnectMenuItem.Text = "FIX &Connection";
            // 
            // ConnectMenuItem_Edit
            // 
            this.ConnectMenuItem_Edit.Name = "ConnectMenuItem_Edit";
            this.ConnectMenuItem_Edit.Size = new System.Drawing.Size(151, 24);
            this.ConnectMenuItem_Edit.Text = "&Edit...";
            this.ConnectMenuItem_Edit.Click += new System.EventHandler(this.ConnectMenuItemEditClick);
            // 
            // ConnectMenuItem_Connect
            // 
            this.ConnectMenuItem_Connect.Name = "ConnectMenuItem_Connect";
            this.ConnectMenuItem_Connect.Size = new System.Drawing.Size(151, 24);
            this.ConnectMenuItem_Connect.Text = "Connec&t";
            this.ConnectMenuItem_Connect.Click += new System.EventHandler(this.ConnectMenuItemConnectClick);
            // 
            // ConnectMenuItem_Disconnect
            // 
            this.ConnectMenuItem_Disconnect.Name = "ConnectMenuItem_Disconnect";
            this.ConnectMenuItem_Disconnect.Size = new System.Drawing.Size(151, 24);
            this.ConnectMenuItem_Disconnect.Text = "Di&sconnect";
            this.ConnectMenuItem_Disconnect.Click += new System.EventHandler(this.ConnectMenuItemDisconnectClick);
            // 
            // ConnectMenuItem_ConnectionSeparator
            // 
            this.ConnectMenuItem_ConnectionSeparator.Name = "ConnectMenuItem_ConnectionSeparator";
            this.ConnectMenuItem_ConnectionSeparator.Size = new System.Drawing.Size(148, 6);
            // 
            // ConnectMenuItem_Exit
            // 
            this.ConnectMenuItem_Exit.Name = "ConnectMenuItem_Exit";
            this.ConnectMenuItem_Exit.Size = new System.Drawing.Size(151, 24);
            this.ConnectMenuItem_Exit.Text = "E&xit";
            this.ConnectMenuItem_Exit.Click += new System.EventHandler(this.ConnectMenuItemExitClick);
            // 
            // QuotesMenuItem
            // 
            this.QuotesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuoteMenuItem_NewQuoteRequest});
            this.QuotesMenuItem.Name = "QuotesMenuItem";
            this.QuotesMenuItem.Size = new System.Drawing.Size(68, 24);
            this.QuotesMenuItem.Text = "&Quotes";
            // 
            // QuoteMenuItem_NewQuoteRequest
            // 
            this.QuoteMenuItem_NewQuoteRequest.Name = "QuoteMenuItem_NewQuoteRequest";
            this.QuoteMenuItem_NewQuoteRequest.Size = new System.Drawing.Size(139, 24);
            this.QuoteMenuItem_NewQuoteRequest.Text = "New &RFQ";
            this.QuoteMenuItem_NewQuoteRequest.Click += new System.EventHandler(this.NewQuoteRequestOnClick);
            // 
            // OrdersMenuItem
            // 
            this.OrdersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrdersMenuItem_NewOrder,
            this.newSimpleOrderToolStripMenuItem,
            this.newMultiOrderToolStripMenuItem});
            this.OrdersMenuItem.Name = "OrdersMenuItem";
            this.OrdersMenuItem.Size = new System.Drawing.Size(65, 24);
            this.OrdersMenuItem.Text = "&Orders";
            // 
            // OrdersMenuItem_NewOrder
            // 
            this.OrdersMenuItem_NewOrder.Enabled = false;
            this.OrdersMenuItem_NewOrder.Name = "OrdersMenuItem_NewOrder";
            this.OrdersMenuItem_NewOrder.Size = new System.Drawing.Size(297, 24);
            this.OrdersMenuItem_NewOrder.Text = "New &Order";
            this.OrdersMenuItem_NewOrder.Click += new System.EventHandler(this.NewOrderRequestOnClick);
            // 
            // newSimpleOrderToolStripMenuItem
            // 
            this.newSimpleOrderToolStripMenuItem.Name = "newSimpleOrderToolStripMenuItem";
            this.newSimpleOrderToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.newSimpleOrderToolStripMenuItem.Text = "New Simple Non-Quoted Order...";
            this.newSimpleOrderToolStripMenuItem.Click += new System.EventHandler(this.newSimpleOrderToolStripMenuItem_Click);
            // 
            // newMultiOrderToolStripMenuItem
            // 
            this.newMultiOrderToolStripMenuItem.Name = "newMultiOrderToolStripMenuItem";
            this.newMultiOrderToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.newMultiOrderToolStripMenuItem.Text = "New Multi Non-Quoted Order...";
            this.newMultiOrderToolStripMenuItem.Click += new System.EventHandler(this.newMultiOrderToolStripMenuItem_Click);
            // 
            // ViewMenuItem
            // 
            this.ViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewMenuItem_ShowQuoteId});
            this.ViewMenuItem.Name = "ViewMenuItem";
            this.ViewMenuItem.Size = new System.Drawing.Size(53, 24);
            this.ViewMenuItem.Text = "View";
            // 
            // ViewMenuItem_ShowQuoteId
            // 
            this.ViewMenuItem_ShowQuoteId.Name = "ViewMenuItem_ShowQuoteId";
            this.ViewMenuItem_ShowQuoteId.Size = new System.Drawing.Size(182, 24);
            this.ViewMenuItem_ShowQuoteId.Text = "Show Quote Ids";
            this.ViewMenuItem_ShowQuoteId.Click += new System.EventHandler(this.ViewMenuItemShowQuoteIdClick);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMDStatus,
            this.toolStripTDStatus,
            this.toolStripRFQStatus,
            this.toolStripApplicationStatus});
            this.StatusStrip.Location = new System.Drawing.Point(0, 918);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip.Size = new System.Drawing.Size(1696, 30);
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Text = "Status Strip";
            // 
            // toolStripMDStatus
            // 
            this.toolStripMDStatus.BackColor = System.Drawing.Color.Red;
            this.toolStripMDStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMDStatus.ForeColor = System.Drawing.Color.White;
            this.toolStripMDStatus.Name = "toolStripMDStatus";
            this.toolStripMDStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripMDStatus.Size = new System.Drawing.Size(44, 25);
            this.toolStripMDStatus.Text = "MD";
            // 
            // toolStripTDStatus
            // 
            this.toolStripTDStatus.BackColor = System.Drawing.Color.Red;
            this.toolStripTDStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTDStatus.ForeColor = System.Drawing.Color.White;
            this.toolStripTDStatus.Name = "toolStripTDStatus";
            this.toolStripTDStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripTDStatus.Size = new System.Drawing.Size(37, 25);
            this.toolStripTDStatus.Text = "TD";
            // 
            // toolStripRFQStatus
            // 
            this.toolStripRFQStatus.BackColor = System.Drawing.Color.Red;
            this.toolStripRFQStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripRFQStatus.ForeColor = System.Drawing.Color.White;
            this.toolStripRFQStatus.Name = "toolStripRFQStatus";
            this.toolStripRFQStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripRFQStatus.Size = new System.Drawing.Size(48, 25);
            this.toolStripRFQStatus.Text = "RFQ";
            // 
            // toolStripApplicationStatus
            // 
            this.toolStripApplicationStatus.Name = "toolStripApplicationStatus";
            this.toolStripApplicationStatus.Size = new System.Drawing.Size(0, 25);
            // 
            // ApplicationStatusLabel
            // 
            this.ApplicationStatusLabel.Name = "ApplicationStatusLabel";
            this.ApplicationStatusLabel.Size = new System.Drawing.Size(0, 20);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelOrderToolStripMenuItem,
            this.activateOrderToolStripMenuItem,
            this.deactivateOrderToolStripMenuItem,
            this.allocateOrderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 122);
            // 
            // cancelOrderToolStripMenuItem
            // 
            this.cancelOrderToolStripMenuItem.Name = "cancelOrderToolStripMenuItem";
            this.cancelOrderToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.cancelOrderToolStripMenuItem.Text = "Cancel Order";
            this.cancelOrderToolStripMenuItem.Click += new System.EventHandler(this.cancelOrderToolStripMenuItem_Click);
            // 
            // activateOrderToolStripMenuItem
            // 
            this.activateOrderToolStripMenuItem.Name = "activateOrderToolStripMenuItem";
            this.activateOrderToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.activateOrderToolStripMenuItem.Text = "Activate Order";
            this.activateOrderToolStripMenuItem.Click += new System.EventHandler(this.activateOrderToolStripMenuItem_Click);
            // 
            // deactivateOrderToolStripMenuItem
            // 
            this.deactivateOrderToolStripMenuItem.Name = "deactivateOrderToolStripMenuItem";
            this.deactivateOrderToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.deactivateOrderToolStripMenuItem.Text = "Deactivate Order";
            this.deactivateOrderToolStripMenuItem.Click += new System.EventHandler(this.deactivateOrderToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl1);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl11);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl12);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl8);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl4);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl2);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl3);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl5);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl6);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl7);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl9);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl10);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl13);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl14);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl15);
            this.splitContainer1.Panel1.Controls.Add(this.fxPricingControl16);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridClientOrders);
            this.splitContainer1.Size = new System.Drawing.Size(1696, 599);
            this.splitContainer1.SplitterDistance = 1216;
            this.splitContainer1.TabIndex = 5;
            // 
            // fxPricingControl1
            // 
            this.fxPricingControl1.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl1.Location = new System.Drawing.Point(0, 3);
            this.fxPricingControl1.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl1.Name = "fxPricingControl1";
            this.fxPricingControl1.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl1.TabIndex = 20;
            // 
            // fxPricingControl11
            // 
            this.fxPricingControl11.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl11.Location = new System.Drawing.Point(870, 361);
            this.fxPricingControl11.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl11.Name = "fxPricingControl11";
            this.fxPricingControl11.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl11.TabIndex = 30;
            // 
            // fxPricingControl12
            // 
            this.fxPricingControl12.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl12.Location = new System.Drawing.Point(1305, 361);
            this.fxPricingControl12.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl12.Name = "fxPricingControl12";
            this.fxPricingControl12.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl12.TabIndex = 31;
            // 
            // fxPricingControl8
            // 
            this.fxPricingControl8.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl8.Location = new System.Drawing.Point(1305, 181);
            this.fxPricingControl8.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl8.Name = "fxPricingControl8";
            this.fxPricingControl8.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl8.TabIndex = 27;
            // 
            // fxPricingControl4
            // 
            this.fxPricingControl4.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl4.Location = new System.Drawing.Point(1305, 3);
            this.fxPricingControl4.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl4.Name = "fxPricingControl4";
            this.fxPricingControl4.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl4.TabIndex = 23;
            // 
            // fxPricingControl2
            // 
            this.fxPricingControl2.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl2.Location = new System.Drawing.Point(436, 3);
            this.fxPricingControl2.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl2.Name = "fxPricingControl2";
            this.fxPricingControl2.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl2.TabIndex = 21;
            // 
            // fxPricingControl3
            // 
            this.fxPricingControl3.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl3.Location = new System.Drawing.Point(870, 3);
            this.fxPricingControl3.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl3.Name = "fxPricingControl3";
            this.fxPricingControl3.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl3.TabIndex = 22;
            // 
            // fxPricingControl5
            // 
            this.fxPricingControl5.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl5.Location = new System.Drawing.Point(0, 183);
            this.fxPricingControl5.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl5.Name = "fxPricingControl5";
            this.fxPricingControl5.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl5.TabIndex = 24;
            // 
            // fxPricingControl6
            // 
            this.fxPricingControl6.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl6.Location = new System.Drawing.Point(436, 181);
            this.fxPricingControl6.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl6.Name = "fxPricingControl6";
            this.fxPricingControl6.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl6.TabIndex = 25;
            // 
            // fxPricingControl7
            // 
            this.fxPricingControl7.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl7.Location = new System.Drawing.Point(870, 181);
            this.fxPricingControl7.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl7.Name = "fxPricingControl7";
            this.fxPricingControl7.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl7.TabIndex = 26;
            // 
            // fxPricingControl9
            // 
            this.fxPricingControl9.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl9.Location = new System.Drawing.Point(0, 360);
            this.fxPricingControl9.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl9.Name = "fxPricingControl9";
            this.fxPricingControl9.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl9.TabIndex = 28;
            // 
            // fxPricingControl10
            // 
            this.fxPricingControl10.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl10.Location = new System.Drawing.Point(436, 361);
            this.fxPricingControl10.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl10.Name = "fxPricingControl10";
            this.fxPricingControl10.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl10.TabIndex = 29;
            // 
            // fxPricingControl13
            // 
            this.fxPricingControl13.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl13.Location = new System.Drawing.Point(0, 538);
            this.fxPricingControl13.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl13.Name = "fxPricingControl13";
            this.fxPricingControl13.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl13.TabIndex = 16;
            // 
            // fxPricingControl14
            // 
            this.fxPricingControl14.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl14.Location = new System.Drawing.Point(436, 539);
            this.fxPricingControl14.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl14.Name = "fxPricingControl14";
            this.fxPricingControl14.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl14.TabIndex = 17;
            // 
            // fxPricingControl15
            // 
            this.fxPricingControl15.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl15.Location = new System.Drawing.Point(870, 539);
            this.fxPricingControl15.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl15.Name = "fxPricingControl15";
            this.fxPricingControl15.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl15.TabIndex = 18;
            // 
            // fxPricingControl16
            // 
            this.fxPricingControl16.BackColor = System.Drawing.Color.Azure;
            this.fxPricingControl16.Location = new System.Drawing.Point(1305, 539);
            this.fxPricingControl16.Margin = new System.Windows.Forms.Padding(5);
            this.fxPricingControl16.Name = "fxPricingControl16";
            this.fxPricingControl16.Size = new System.Drawing.Size(436, 172);
            this.fxPricingControl16.TabIndex = 19;
            // 
            // dataGridClientOrders
            // 
            this.dataGridClientOrders.AlternateRowColor = System.Drawing.Color.LightGray;
            this.dataGridClientOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClientOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOrderDetails,
            this.ColumnOrderRequestId,
            this.ColumnOrderSource});
            this.dataGridClientOrders.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridClientOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridClientOrders.Location = new System.Drawing.Point(0, 0);
            this.dataGridClientOrders.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridClientOrders.Name = "dataGridClientOrders";
            this.dataGridClientOrders.Size = new System.Drawing.Size(476, 599);
            this.dataGridClientOrders.TabIndex = 4;
            // 
            // ColumnOrderDetails
            // 
            this.ColumnOrderDetails.HeaderText = "Order Details";
            this.ColumnOrderDetails.Name = "ColumnOrderDetails";
            this.ColumnOrderDetails.Subform = null;
            this.ColumnOrderDetails.Width = 50;
            // 
            // ColumnOrderRequestId
            // 
            this.ColumnOrderRequestId.DataPropertyName = "RequestId";
            this.ColumnOrderRequestId.HeaderText = "Request Id";
            this.ColumnOrderRequestId.Name = "ColumnOrderRequestId";
            // 
            // ColumnOrderSource
            // 
            this.ColumnOrderSource.DataPropertyName = "RequestSource";
            this.ColumnOrderSource.HeaderText = "Source";
            this.ColumnOrderSource.Name = "ColumnOrderSource";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 28);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridPricingRequests);
            this.splitContainer2.Size = new System.Drawing.Size(1696, 890);
            this.splitContainer2.SplitterDistance = 599;
            this.splitContainer2.TabIndex = 6;
            // 
            // dataGridPricingRequests
            // 
            this.dataGridPricingRequests.AlternateRowColor = System.Drawing.Color.LightGray;
            this.dataGridPricingRequests.AutoGenerateColumns = false;
            this.dataGridPricingRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPricingRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnResponses,
            this.ColumnRequestId,
            this.ColumnSymbol,
            this.ColumnTier,
            this.ColumnNearTenor,
            this.FarTenor,
            this.ColumnNearSettle,
            this.ColumnFarSettle,
            this.ColumnSide,
            this.ColumnAccount,
            this.ColumnCurrency,
            this.ColumnNearAmount,
            this.ColumnFarAmount,
            this.ColumnNearAllocations,
            this.ColumnFarAllocations});
            this.dataGridPricingRequests.DataSource = this.PricingRequestBindingSource;
            this.dataGridPricingRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPricingRequests.Location = new System.Drawing.Point(0, 0);
            this.dataGridPricingRequests.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridPricingRequests.Name = "dataGridPricingRequests";
            this.dataGridPricingRequests.Size = new System.Drawing.Size(1696, 287);
            this.dataGridPricingRequests.TabIndex = 3;
            // 
            // ColumnResponses
            // 
            this.ColumnResponses.HeaderText = "Responses";
            this.ColumnResponses.Name = "ColumnResponses";
            this.ColumnResponses.ReadOnly = true;
            this.ColumnResponses.Subform = null;
            // 
            // ColumnRequestId
            // 
            this.ColumnRequestId.DataPropertyName = "RequestId";
            this.ColumnRequestId.HeaderText = "Request Id";
            this.ColumnRequestId.Name = "ColumnRequestId";
            // 
            // ColumnSymbol
            // 
            this.ColumnSymbol.DataPropertyName = "Symbol";
            this.ColumnSymbol.HeaderText = "Symbol";
            this.ColumnSymbol.Name = "ColumnSymbol";
            this.ColumnSymbol.ReadOnly = true;
            // 
            // ColumnTier
            // 
            this.ColumnTier.DataPropertyName = "Tier";
            this.ColumnTier.HeaderText = "Tier";
            this.ColumnTier.Name = "ColumnTier";
            this.ColumnTier.ReadOnly = true;
            // 
            // ColumnNearTenor
            // 
            this.ColumnNearTenor.DataPropertyName = "NearTenor";
            this.ColumnNearTenor.HeaderText = "Near Tenor";
            this.ColumnNearTenor.Name = "ColumnNearTenor";
            this.ColumnNearTenor.ReadOnly = true;
            // 
            // FarTenor
            // 
            this.FarTenor.HeaderText = "Far Tenor";
            this.FarTenor.Name = "FarTenor";
            this.FarTenor.ReadOnly = true;
            // 
            // ColumnNearSettle
            // 
            this.ColumnNearSettle.CustomFormat = null;
            this.ColumnNearSettle.DataPropertyName = "NearSettlementDate";
            this.ColumnNearSettle.HeaderText = "Near Value Date";
            this.ColumnNearSettle.Name = "ColumnNearSettle";
            this.ColumnNearSettle.ReadOnly = true;
            this.ColumnNearSettle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnFarSettle
            // 
            this.ColumnFarSettle.CustomFormat = null;
            this.ColumnFarSettle.DataPropertyName = "FarSettlementDate";
            this.ColumnFarSettle.HeaderText = "Far Value Date";
            this.ColumnFarSettle.Name = "ColumnFarSettle";
            this.ColumnFarSettle.ReadOnly = true;
            this.ColumnFarSettle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnSide
            // 
            this.ColumnSide.DataPropertyName = "Side";
            this.ColumnSide.HeaderText = "Side";
            this.ColumnSide.Name = "ColumnSide";
            this.ColumnSide.ReadOnly = true;
            // 
            // ColumnAccount
            // 
            this.ColumnAccount.DataPropertyName = "Account";
            this.ColumnAccount.HeaderText = "Account";
            this.ColumnAccount.Name = "ColumnAccount";
            this.ColumnAccount.ReadOnly = true;
            // 
            // ColumnCurrency
            // 
            this.ColumnCurrency.DataPropertyName = "Currency";
            this.ColumnCurrency.HeaderText = "Currency";
            this.ColumnCurrency.Name = "ColumnCurrency";
            this.ColumnCurrency.ReadOnly = true;
            // 
            // ColumnNearAmount
            // 
            this.ColumnNearAmount.DataPropertyName = "NearAmount";
            this.ColumnNearAmount.HeaderText = "Near Amount";
            this.ColumnNearAmount.Name = "ColumnNearAmount";
            this.ColumnNearAmount.ReadOnly = true;
            // 
            // ColumnFarAmount
            // 
            this.ColumnFarAmount.DataPropertyName = "FarAmount";
            this.ColumnFarAmount.HeaderText = "Far Amount";
            this.ColumnFarAmount.Name = "ColumnFarAmount";
            this.ColumnFarAmount.ReadOnly = true;
            // 
            // ColumnNearAllocations
            // 
            this.ColumnNearAllocations.HeaderText = "Near Allocations";
            this.ColumnNearAllocations.Name = "ColumnNearAllocations";
            this.ColumnNearAllocations.ReadOnly = true;
            this.ColumnNearAllocations.Subform = null;
            // 
            // ColumnFarAllocations
            // 
            this.ColumnFarAllocations.HeaderText = "Far Allocations";
            this.ColumnFarAllocations.Name = "ColumnFarAllocations";
            this.ColumnFarAllocations.ReadOnly = true;
            this.ColumnFarAllocations.Subform = null;
            // 
            // allocateOrderToolStripMenuItem
            // 
            this.allocateOrderToolStripMenuItem.Name = "allocateOrderToolStripMenuItem";
            this.allocateOrderToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.allocateOrderToolStripMenuItem.Text = "Allocate Order...";
            this.allocateOrderToolStripMenuItem.Click += new System.EventHandler(this.allocateOrderToolStripMenuItem_Click);
            // 
            // FXTradeSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1696, 948);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStripMainMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1701, 974);
            this.Name = "FXTradeSimulator";
            this.Text = "FX Trade Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FXTradeSimulatorFormClosing);
            this.Load += new System.EventHandler(this.FXTradeSimulator_Load);
            this.MenuStripMainMenu.ResumeLayout(false);
            this.MenuStripMainMenu.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PricingRequestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientOrderBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientOrders)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPricingRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStripMainMenu;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ApplicationStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem ConnectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConnectMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem ConnectMenuItem_Connect;
        private System.Windows.Forms.ToolStripMenuItem ConnectMenuItem_Disconnect;
        private System.Windows.Forms.ToolStripSeparator ConnectMenuItem_ConnectionSeparator;
        private System.Windows.Forms.ToolStripMenuItem ConnectMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem QuotesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuoteMenuItem_NewQuoteRequest;
        private System.Windows.Forms.ToolStripMenuItem OrdersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdersMenuItem_NewOrder;
        private System.Windows.Forms.ToolStripStatusLabel toolStripApplicationStatus;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuItem_ShowQuoteId;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMDStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTDStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripRFQStatus;
        private System.Windows.Forms.BindingSource PricingRequestBindingSource;
        private DataGridViewExtension dataGridClientOrders;
        private System.Windows.Forms.BindingSource ClientOrderBindingSource;
        private DataGridViewSubformColumn ColumnOrderDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderRequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FXPricingControl.FXPricingControl fxPricingControl11;
        private FXPricingControl.FXPricingControl fxPricingControl12;
        private FXPricingControl.FXPricingControl fxPricingControl8;
        private FXPricingControl.FXPricingControl fxPricingControl4;
        private FXPricingControl.FXPricingControl fxPricingControl1;
        private FXPricingControl.FXPricingControl fxPricingControl2;
        private FXPricingControl.FXPricingControl fxPricingControl3;
        private FXPricingControl.FXPricingControl fxPricingControl5;
        private FXPricingControl.FXPricingControl fxPricingControl6;
        private FXPricingControl.FXPricingControl fxPricingControl7;
        private FXPricingControl.FXPricingControl fxPricingControl9;
        private FXPricingControl.FXPricingControl fxPricingControl10;
        private FXPricingControl.FXPricingControl fxPricingControl13;
        private FXPricingControl.FXPricingControl fxPricingControl14;
        private FXPricingControl.FXPricingControl fxPricingControl15;
        private FXPricingControl.FXPricingControl fxPricingControl16;
        private DataGridViewSubformColumn ColumnFarAllocations;
        private DataGridViewSubformColumn ColumnNearAllocations;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFarAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNearAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSide;
        private DataGridViewDateTimeColumn ColumnFarSettle;
        private DataGridViewDateTimeColumn ColumnNearSettle;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarTenor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNearTenor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRequestId;
        private DataGridViewSubformColumn ColumnResponses;
        private DataGridViewExtension dataGridPricingRequests;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem newSimpleOrderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cancelOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMultiOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allocateOrderToolStripMenuItem;




    }
}

