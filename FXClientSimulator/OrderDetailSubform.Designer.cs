namespace FXClientSimulator {
    partial class OrderDetailSubform {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailSubform));
            this.tabOrderDetails = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.txtSummaryStatus = new System.Windows.Forms.TextBox();
            this.lblSummaryFarAllIn = new System.Windows.Forms.Label();
            this.txtSummaryFarAllIn = new System.Windows.Forms.TextBox();
            this.lblSummaryFarPoints = new System.Windows.Forms.Label();
            this.txtSummaryFarPoints = new System.Windows.Forms.TextBox();
            this.lblSummaryNearAllIn = new System.Windows.Forms.Label();
            this.txtSummaryNearAllIn = new System.Windows.Forms.TextBox();
            this.lblSummaryNearPoints = new System.Windows.Forms.Label();
            this.txtSummaryNearPoints = new System.Windows.Forms.TextBox();
            this.lblSide = new System.Windows.Forms.Label();
            this.txtSide = new System.Windows.Forms.TextBox();
            this.lblSpot = new System.Windows.Forms.Label();
            this.txtSummaryLastSpot = new System.Windows.Forms.TextBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.txtOrderType = new System.Windows.Forms.TextBox();
            this.lblInstrumentType = new System.Windows.Forms.Label();
            this.txtInstrumentType = new System.Windows.Forms.TextBox();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.tabNearLegDetails = new System.Windows.Forms.TabPage();
            this.lblNearAllIn = new System.Windows.Forms.Label();
            this.txtNearAllIn = new System.Windows.Forms.TextBox();
            this.lblNearPoints = new System.Windows.Forms.Label();
            this.txtNearPoints = new System.Windows.Forms.TextBox();
            this.lblNearSpot = new System.Windows.Forms.Label();
            this.txtNearSpot = new System.Windows.Forms.TextBox();
            this.lstNearAllocations = new System.Windows.Forms.ListBox();
            this.lblNearSettles = new System.Windows.Forms.Label();
            this.txtNearSettles = new System.Windows.Forms.TextBox();
            this.lblNearTenor = new System.Windows.Forms.Label();
            this.txtNearTenor = new System.Windows.Forms.TextBox();
            this.lblNearCurrency = new System.Windows.Forms.Label();
            this.txtNearCurrency = new System.Windows.Forms.TextBox();
            this.lblNearAmount = new System.Windows.Forms.Label();
            this.txtNearAmount = new System.Windows.Forms.TextBox();
            this.tabFarLegDetails = new System.Windows.Forms.TabPage();
            this.lblFarAllIn = new System.Windows.Forms.Label();
            this.txtFarAllIn = new System.Windows.Forms.TextBox();
            this.lblFarPoints = new System.Windows.Forms.Label();
            this.txtFarPoints = new System.Windows.Forms.TextBox();
            this.lblFarSpot = new System.Windows.Forms.Label();
            this.txtFarSpot = new System.Windows.Forms.TextBox();
            this.lstFarAllocations = new System.Windows.Forms.ListBox();
            this.lblFarSettles = new System.Windows.Forms.Label();
            this.txtFarSettles = new System.Windows.Forms.TextBox();
            this.lblFarTenor = new System.Windows.Forms.Label();
            this.txtFarTenor = new System.Windows.Forms.TextBox();
            this.lblFarCurrency = new System.Windows.Forms.Label();
            this.txtFarCurrency = new System.Windows.Forms.TextBox();
            this.lblFarAmount = new System.Windows.Forms.Label();
            this.txtFarAmount = new System.Windows.Forms.TextBox();
            this.dataGridViewExecutions = new Extensions.DataGridViewExtension();
            this.executionsNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.executionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnReportType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExecutionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFilledAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCumulative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFillPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAvgPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastSpot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTransactionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabOrderDetails.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabNearLegDetails.SuspendLayout();
            this.tabFarLegDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExecutions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.executionsNavigator)).BeginInit();
            this.executionsNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.executionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOrderDetails
            // 
            this.tabOrderDetails.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabOrderDetails.Controls.Add(this.tabDetails);
            this.tabOrderDetails.Controls.Add(this.tabNearLegDetails);
            this.tabOrderDetails.Controls.Add(this.tabFarLegDetails);
            this.tabOrderDetails.Location = new System.Drawing.Point(0, 3);
            this.tabOrderDetails.Name = "tabOrderDetails";
            this.tabOrderDetails.SelectedIndex = 0;
            this.tabOrderDetails.Size = new System.Drawing.Size(646, 138);
            this.tabOrderDetails.TabIndex = 0;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.lblOrderStatus);
            this.tabDetails.Controls.Add(this.txtSummaryStatus);
            this.tabDetails.Controls.Add(this.lblSummaryFarAllIn);
            this.tabDetails.Controls.Add(this.txtSummaryFarAllIn);
            this.tabDetails.Controls.Add(this.lblSummaryFarPoints);
            this.tabDetails.Controls.Add(this.txtSummaryFarPoints);
            this.tabDetails.Controls.Add(this.lblSummaryNearAllIn);
            this.tabDetails.Controls.Add(this.txtSummaryNearAllIn);
            this.tabDetails.Controls.Add(this.lblSummaryNearPoints);
            this.tabDetails.Controls.Add(this.txtSummaryNearPoints);
            this.tabDetails.Controls.Add(this.lblSide);
            this.tabDetails.Controls.Add(this.txtSide);
            this.tabDetails.Controls.Add(this.lblSpot);
            this.tabDetails.Controls.Add(this.txtSummaryLastSpot);
            this.tabDetails.Controls.Add(this.lblOrderType);
            this.tabDetails.Controls.Add(this.txtOrderType);
            this.tabDetails.Controls.Add(this.lblInstrumentType);
            this.tabDetails.Controls.Add(this.txtInstrumentType);
            this.tabDetails.Controls.Add(this.lblSymbol);
            this.tabDetails.Controls.Add(this.txtSymbol);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(638, 109);
            this.tabDetails.TabIndex = 2;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Location = new System.Drawing.Point(303, 86);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(37, 13);
            this.lblOrderStatus.TabIndex = 37;
            this.lblOrderStatus.Text = "Status";
            // 
            // txtSummaryStatus
            // 
            this.txtSummaryStatus.Location = new System.Drawing.Point(344, 83);
            this.txtSummaryStatus.Name = "txtSummaryStatus";
            this.txtSummaryStatus.Size = new System.Drawing.Size(288, 20);
            this.txtSummaryStatus.TabIndex = 36;
            // 
            // lblSummaryFarAllIn
            // 
            this.lblSummaryFarAllIn.AutoSize = true;
            this.lblSummaryFarAllIn.Location = new System.Drawing.Point(482, 60);
            this.lblSummaryFarAllIn.Name = "lblSummaryFarAllIn";
            this.lblSummaryFarAllIn.Size = new System.Drawing.Size(48, 13);
            this.lblSummaryFarAllIn.TabIndex = 35;
            this.lblSummaryFarAllIn.Text = "Far All-In";
            // 
            // txtSummaryFarAllIn
            // 
            this.txtSummaryFarAllIn.Location = new System.Drawing.Point(532, 57);
            this.txtSummaryFarAllIn.Name = "txtSummaryFarAllIn";
            this.txtSummaryFarAllIn.Size = new System.Drawing.Size(100, 20);
            this.txtSummaryFarAllIn.TabIndex = 34;
            // 
            // lblSummaryFarPoints
            // 
            this.lblSummaryFarPoints.AutoSize = true;
            this.lblSummaryFarPoints.Location = new System.Drawing.Point(286, 60);
            this.lblSummaryFarPoints.Name = "lblSummaryFarPoints";
            this.lblSummaryFarPoints.Size = new System.Drawing.Size(54, 13);
            this.lblSummaryFarPoints.TabIndex = 33;
            this.lblSummaryFarPoints.Text = "Far Points";
            // 
            // txtSummaryFarPoints
            // 
            this.txtSummaryFarPoints.Location = new System.Drawing.Point(344, 57);
            this.txtSummaryFarPoints.Name = "txtSummaryFarPoints";
            this.txtSummaryFarPoints.Size = new System.Drawing.Size(100, 20);
            this.txtSummaryFarPoints.TabIndex = 32;
            // 
            // lblSummaryNearAllIn
            // 
            this.lblSummaryNearAllIn.AutoSize = true;
            this.lblSummaryNearAllIn.Location = new System.Drawing.Point(474, 34);
            this.lblSummaryNearAllIn.Name = "lblSummaryNearAllIn";
            this.lblSummaryNearAllIn.Size = new System.Drawing.Size(56, 13);
            this.lblSummaryNearAllIn.TabIndex = 31;
            this.lblSummaryNearAllIn.Text = "Near All-In";
            // 
            // txtSummaryNearAllIn
            // 
            this.txtSummaryNearAllIn.Location = new System.Drawing.Point(532, 31);
            this.txtSummaryNearAllIn.Name = "txtSummaryNearAllIn";
            this.txtSummaryNearAllIn.Size = new System.Drawing.Size(100, 20);
            this.txtSummaryNearAllIn.TabIndex = 30;
            // 
            // lblSummaryNearPoints
            // 
            this.lblSummaryNearPoints.AutoSize = true;
            this.lblSummaryNearPoints.Location = new System.Drawing.Point(278, 34);
            this.lblSummaryNearPoints.Name = "lblSummaryNearPoints";
            this.lblSummaryNearPoints.Size = new System.Drawing.Size(62, 13);
            this.lblSummaryNearPoints.TabIndex = 29;
            this.lblSummaryNearPoints.Text = "Near Points";
            // 
            // txtSummaryNearPoints
            // 
            this.txtSummaryNearPoints.Location = new System.Drawing.Point(344, 31);
            this.txtSummaryNearPoints.Name = "txtSummaryNearPoints";
            this.txtSummaryNearPoints.Size = new System.Drawing.Size(100, 20);
            this.txtSummaryNearPoints.TabIndex = 28;
            // 
            // lblSide
            // 
            this.lblSide.AutoSize = true;
            this.lblSide.Location = new System.Drawing.Point(54, 34);
            this.lblSide.Name = "lblSide";
            this.lblSide.Size = new System.Drawing.Size(28, 13);
            this.lblSide.TabIndex = 27;
            this.lblSide.Text = "Side";
            // 
            // txtSide
            // 
            this.txtSide.Location = new System.Drawing.Point(88, 31);
            this.txtSide.Name = "txtSide";
            this.txtSide.Size = new System.Drawing.Size(169, 20);
            this.txtSide.TabIndex = 26;
            // 
            // lblSpot
            // 
            this.lblSpot.AutoSize = true;
            this.lblSpot.Location = new System.Drawing.Point(288, 8);
            this.lblSpot.Name = "lblSpot";
            this.lblSpot.Size = new System.Drawing.Size(52, 13);
            this.lblSpot.TabIndex = 25;
            this.lblSpot.Text = "Last Spot";
            // 
            // txtSummaryLastSpot
            // 
            this.txtSummaryLastSpot.Location = new System.Drawing.Point(344, 5);
            this.txtSummaryLastSpot.Name = "txtSummaryLastSpot";
            this.txtSummaryLastSpot.Size = new System.Drawing.Size(288, 20);
            this.txtSummaryLastSpot.TabIndex = 24;
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Location = new System.Drawing.Point(22, 86);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(60, 13);
            this.lblOrderType.TabIndex = 23;
            this.lblOrderType.Text = "Order Type";
            // 
            // txtOrderType
            // 
            this.txtOrderType.Location = new System.Drawing.Point(88, 83);
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.Size = new System.Drawing.Size(169, 20);
            this.txtOrderType.TabIndex = 22;
            // 
            // lblInstrumentType
            // 
            this.lblInstrumentType.AutoSize = true;
            this.lblInstrumentType.Location = new System.Drawing.Point(25, 60);
            this.lblInstrumentType.Name = "lblInstrumentType";
            this.lblInstrumentType.Size = new System.Drawing.Size(57, 13);
            this.lblInstrumentType.TabIndex = 21;
            this.lblInstrumentType.Text = "Instr. Type";
            // 
            // txtInstrumentType
            // 
            this.txtInstrumentType.Location = new System.Drawing.Point(88, 57);
            this.txtInstrumentType.Name = "txtInstrumentType";
            this.txtInstrumentType.Size = new System.Drawing.Size(169, 20);
            this.txtInstrumentType.TabIndex = 20;
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(41, 8);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(41, 13);
            this.lblSymbol.TabIndex = 19;
            this.lblSymbol.Text = "Symbol";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(88, 5);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(169, 20);
            this.txtSymbol.TabIndex = 18;
            // 
            // tabNearLegDetails
            // 
            this.tabNearLegDetails.Controls.Add(this.lblNearAllIn);
            this.tabNearLegDetails.Controls.Add(this.txtNearAllIn);
            this.tabNearLegDetails.Controls.Add(this.lblNearPoints);
            this.tabNearLegDetails.Controls.Add(this.txtNearPoints);
            this.tabNearLegDetails.Controls.Add(this.lblNearSpot);
            this.tabNearLegDetails.Controls.Add(this.txtNearSpot);
            this.tabNearLegDetails.Controls.Add(this.lstNearAllocations);
            this.tabNearLegDetails.Controls.Add(this.lblNearSettles);
            this.tabNearLegDetails.Controls.Add(this.txtNearSettles);
            this.tabNearLegDetails.Controls.Add(this.lblNearTenor);
            this.tabNearLegDetails.Controls.Add(this.txtNearTenor);
            this.tabNearLegDetails.Controls.Add(this.lblNearCurrency);
            this.tabNearLegDetails.Controls.Add(this.txtNearCurrency);
            this.tabNearLegDetails.Controls.Add(this.lblNearAmount);
            this.tabNearLegDetails.Controls.Add(this.txtNearAmount);
            this.tabNearLegDetails.Location = new System.Drawing.Point(4, 25);
            this.tabNearLegDetails.Name = "tabNearLegDetails";
            this.tabNearLegDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabNearLegDetails.Size = new System.Drawing.Size(638, 109);
            this.tabNearLegDetails.TabIndex = 0;
            this.tabNearLegDetails.Text = "Near Leg";
            this.tabNearLegDetails.UseVisualStyleBackColor = true;
            // 
            // lblNearAllIn
            // 
            this.lblNearAllIn.AutoSize = true;
            this.lblNearAllIn.Location = new System.Drawing.Point(20, 86);
            this.lblNearAllIn.Name = "lblNearAllIn";
            this.lblNearAllIn.Size = new System.Drawing.Size(30, 13);
            this.lblNearAllIn.TabIndex = 15;
            this.lblNearAllIn.Text = "All In";
            // 
            // txtNearAllIn
            // 
            this.txtNearAllIn.Location = new System.Drawing.Point(56, 83);
            this.txtNearAllIn.Name = "txtNearAllIn";
            this.txtNearAllIn.Size = new System.Drawing.Size(270, 20);
            this.txtNearAllIn.TabIndex = 14;
            // 
            // lblNearPoints
            // 
            this.lblNearPoints.AutoSize = true;
            this.lblNearPoints.Location = new System.Drawing.Point(185, 61);
            this.lblNearPoints.Name = "lblNearPoints";
            this.lblNearPoints.Size = new System.Drawing.Size(36, 13);
            this.lblNearPoints.TabIndex = 13;
            this.lblNearPoints.Text = "Points";
            // 
            // txtNearPoints
            // 
            this.txtNearPoints.Location = new System.Drawing.Point(226, 58);
            this.txtNearPoints.Name = "txtNearPoints";
            this.txtNearPoints.Size = new System.Drawing.Size(100, 20);
            this.txtNearPoints.TabIndex = 12;
            // 
            // lblNearSpot
            // 
            this.lblNearSpot.AutoSize = true;
            this.lblNearSpot.Location = new System.Drawing.Point(21, 62);
            this.lblNearSpot.Name = "lblNearSpot";
            this.lblNearSpot.Size = new System.Drawing.Size(29, 13);
            this.lblNearSpot.TabIndex = 11;
            this.lblNearSpot.Text = "Spot";
            // 
            // txtNearSpot
            // 
            this.txtNearSpot.Location = new System.Drawing.Point(56, 58);
            this.txtNearSpot.Name = "txtNearSpot";
            this.txtNearSpot.Size = new System.Drawing.Size(100, 20);
            this.txtNearSpot.TabIndex = 10;
            // 
            // lstNearAllocations
            // 
            this.lstNearAllocations.FormattingEnabled = true;
            this.lstNearAllocations.Location = new System.Drawing.Point(332, 6);
            this.lstNearAllocations.Name = "lstNearAllocations";
            this.lstNearAllocations.Size = new System.Drawing.Size(300, 95);
            this.lstNearAllocations.TabIndex = 9;
            // 
            // lblNearSettles
            // 
            this.lblNearSettles.AutoSize = true;
            this.lblNearSettles.Location = new System.Drawing.Point(182, 35);
            this.lblNearSettles.Name = "lblNearSettles";
            this.lblNearSettles.Size = new System.Drawing.Size(39, 13);
            this.lblNearSettles.TabIndex = 8;
            this.lblNearSettles.Text = "Settles";
            // 
            // txtNearSettles
            // 
            this.txtNearSettles.Location = new System.Drawing.Point(226, 32);
            this.txtNearSettles.Name = "txtNearSettles";
            this.txtNearSettles.Size = new System.Drawing.Size(100, 20);
            this.txtNearSettles.TabIndex = 7;
            // 
            // lblNearTenor
            // 
            this.lblNearTenor.AutoSize = true;
            this.lblNearTenor.Location = new System.Drawing.Point(15, 35);
            this.lblNearTenor.Name = "lblNearTenor";
            this.lblNearTenor.Size = new System.Drawing.Size(35, 13);
            this.lblNearTenor.TabIndex = 6;
            this.lblNearTenor.Text = "Tenor";
            // 
            // txtNearTenor
            // 
            this.txtNearTenor.Location = new System.Drawing.Point(56, 32);
            this.txtNearTenor.Name = "txtNearTenor";
            this.txtNearTenor.Size = new System.Drawing.Size(100, 20);
            this.txtNearTenor.TabIndex = 5;
            // 
            // lblNearCurrency
            // 
            this.lblNearCurrency.AutoSize = true;
            this.lblNearCurrency.Location = new System.Drawing.Point(172, 9);
            this.lblNearCurrency.Name = "lblNearCurrency";
            this.lblNearCurrency.Size = new System.Drawing.Size(49, 13);
            this.lblNearCurrency.TabIndex = 4;
            this.lblNearCurrency.Text = "Currency";
            // 
            // txtNearCurrency
            // 
            this.txtNearCurrency.Location = new System.Drawing.Point(226, 6);
            this.txtNearCurrency.Name = "txtNearCurrency";
            this.txtNearCurrency.Size = new System.Drawing.Size(100, 20);
            this.txtNearCurrency.TabIndex = 3;
            // 
            // lblNearAmount
            // 
            this.lblNearAmount.AutoSize = true;
            this.lblNearAmount.Location = new System.Drawing.Point(7, 9);
            this.lblNearAmount.Name = "lblNearAmount";
            this.lblNearAmount.Size = new System.Drawing.Size(43, 13);
            this.lblNearAmount.TabIndex = 2;
            this.lblNearAmount.Text = "Amount";
            // 
            // txtNearAmount
            // 
            this.txtNearAmount.Location = new System.Drawing.Point(56, 6);
            this.txtNearAmount.Name = "txtNearAmount";
            this.txtNearAmount.Size = new System.Drawing.Size(100, 20);
            this.txtNearAmount.TabIndex = 1;
            // 
            // tabFarLegDetails
            // 
            this.tabFarLegDetails.Controls.Add(this.lblFarAllIn);
            this.tabFarLegDetails.Controls.Add(this.txtFarAllIn);
            this.tabFarLegDetails.Controls.Add(this.lblFarPoints);
            this.tabFarLegDetails.Controls.Add(this.txtFarPoints);
            this.tabFarLegDetails.Controls.Add(this.lblFarSpot);
            this.tabFarLegDetails.Controls.Add(this.txtFarSpot);
            this.tabFarLegDetails.Controls.Add(this.lstFarAllocations);
            this.tabFarLegDetails.Controls.Add(this.lblFarSettles);
            this.tabFarLegDetails.Controls.Add(this.txtFarSettles);
            this.tabFarLegDetails.Controls.Add(this.lblFarTenor);
            this.tabFarLegDetails.Controls.Add(this.txtFarTenor);
            this.tabFarLegDetails.Controls.Add(this.lblFarCurrency);
            this.tabFarLegDetails.Controls.Add(this.txtFarCurrency);
            this.tabFarLegDetails.Controls.Add(this.lblFarAmount);
            this.tabFarLegDetails.Controls.Add(this.txtFarAmount);
            this.tabFarLegDetails.Location = new System.Drawing.Point(4, 25);
            this.tabFarLegDetails.Name = "tabFarLegDetails";
            this.tabFarLegDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabFarLegDetails.Size = new System.Drawing.Size(638, 109);
            this.tabFarLegDetails.TabIndex = 1;
            this.tabFarLegDetails.Text = "Far Leg";
            this.tabFarLegDetails.UseVisualStyleBackColor = true;
            // 
            // lblFarAllIn
            // 
            this.lblFarAllIn.AutoSize = true;
            this.lblFarAllIn.Location = new System.Drawing.Point(20, 86);
            this.lblFarAllIn.Name = "lblFarAllIn";
            this.lblFarAllIn.Size = new System.Drawing.Size(30, 13);
            this.lblFarAllIn.TabIndex = 30;
            this.lblFarAllIn.Text = "All In";
            // 
            // txtFarAllIn
            // 
            this.txtFarAllIn.Location = new System.Drawing.Point(56, 83);
            this.txtFarAllIn.Name = "txtFarAllIn";
            this.txtFarAllIn.Size = new System.Drawing.Size(270, 20);
            this.txtFarAllIn.TabIndex = 29;
            // 
            // lblFarPoints
            // 
            this.lblFarPoints.AutoSize = true;
            this.lblFarPoints.Location = new System.Drawing.Point(185, 61);
            this.lblFarPoints.Name = "lblFarPoints";
            this.lblFarPoints.Size = new System.Drawing.Size(36, 13);
            this.lblFarPoints.TabIndex = 28;
            this.lblFarPoints.Text = "Points";
            // 
            // txtFarPoints
            // 
            this.txtFarPoints.Location = new System.Drawing.Point(226, 58);
            this.txtFarPoints.Name = "txtFarPoints";
            this.txtFarPoints.Size = new System.Drawing.Size(100, 20);
            this.txtFarPoints.TabIndex = 27;
            // 
            // lblFarSpot
            // 
            this.lblFarSpot.AutoSize = true;
            this.lblFarSpot.Location = new System.Drawing.Point(21, 62);
            this.lblFarSpot.Name = "lblFarSpot";
            this.lblFarSpot.Size = new System.Drawing.Size(29, 13);
            this.lblFarSpot.TabIndex = 26;
            this.lblFarSpot.Text = "Spot";
            // 
            // txtFarSpot
            // 
            this.txtFarSpot.Location = new System.Drawing.Point(56, 58);
            this.txtFarSpot.Name = "txtFarSpot";
            this.txtFarSpot.Size = new System.Drawing.Size(100, 20);
            this.txtFarSpot.TabIndex = 25;
            // 
            // lstFarAllocations
            // 
            this.lstFarAllocations.FormattingEnabled = true;
            this.lstFarAllocations.Location = new System.Drawing.Point(332, 6);
            this.lstFarAllocations.Name = "lstFarAllocations";
            this.lstFarAllocations.Size = new System.Drawing.Size(300, 95);
            this.lstFarAllocations.TabIndex = 24;
            // 
            // lblFarSettles
            // 
            this.lblFarSettles.AutoSize = true;
            this.lblFarSettles.Location = new System.Drawing.Point(182, 35);
            this.lblFarSettles.Name = "lblFarSettles";
            this.lblFarSettles.Size = new System.Drawing.Size(39, 13);
            this.lblFarSettles.TabIndex = 23;
            this.lblFarSettles.Text = "Settles";
            // 
            // txtFarSettles
            // 
            this.txtFarSettles.Location = new System.Drawing.Point(226, 32);
            this.txtFarSettles.Name = "txtFarSettles";
            this.txtFarSettles.Size = new System.Drawing.Size(100, 20);
            this.txtFarSettles.TabIndex = 22;
            // 
            // lblFarTenor
            // 
            this.lblFarTenor.AutoSize = true;
            this.lblFarTenor.Location = new System.Drawing.Point(15, 35);
            this.lblFarTenor.Name = "lblFarTenor";
            this.lblFarTenor.Size = new System.Drawing.Size(35, 13);
            this.lblFarTenor.TabIndex = 21;
            this.lblFarTenor.Text = "Tenor";
            // 
            // txtFarTenor
            // 
            this.txtFarTenor.Location = new System.Drawing.Point(56, 32);
            this.txtFarTenor.Name = "txtFarTenor";
            this.txtFarTenor.Size = new System.Drawing.Size(100, 20);
            this.txtFarTenor.TabIndex = 20;
            // 
            // lblFarCurrency
            // 
            this.lblFarCurrency.AutoSize = true;
            this.lblFarCurrency.Location = new System.Drawing.Point(172, 9);
            this.lblFarCurrency.Name = "lblFarCurrency";
            this.lblFarCurrency.Size = new System.Drawing.Size(49, 13);
            this.lblFarCurrency.TabIndex = 19;
            this.lblFarCurrency.Text = "Currency";
            // 
            // txtFarCurrency
            // 
            this.txtFarCurrency.Location = new System.Drawing.Point(226, 6);
            this.txtFarCurrency.Name = "txtFarCurrency";
            this.txtFarCurrency.Size = new System.Drawing.Size(100, 20);
            this.txtFarCurrency.TabIndex = 18;
            // 
            // lblFarAmount
            // 
            this.lblFarAmount.AutoSize = true;
            this.lblFarAmount.Location = new System.Drawing.Point(7, 9);
            this.lblFarAmount.Name = "lblFarAmount";
            this.lblFarAmount.Size = new System.Drawing.Size(43, 13);
            this.lblFarAmount.TabIndex = 17;
            this.lblFarAmount.Text = "Amount";
            // 
            // txtFarAmount
            // 
            this.txtFarAmount.Location = new System.Drawing.Point(56, 6);
            this.txtFarAmount.Name = "txtFarAmount";
            this.txtFarAmount.Size = new System.Drawing.Size(100, 20);
            this.txtFarAmount.TabIndex = 16;
            // 
            // dataGridViewExecutions
            // 
            this.dataGridViewExecutions.AlternateRowColor = System.Drawing.Color.LightGray;
            this.dataGridViewExecutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExecutions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReportType,
            this.ColumnExecutionType,
            this.ColumnOrderAmount,
            this.ColumnFilledAmount,
            this.ColumnCumulative,
            this.ColumnRemaining,
            this.ColumnFillPrice,
            this.ColumnAvgPrice,
            this.ColumnLastSpot,
            this.ColumnTransactionTime,
            this.ColumnStatus});
            this.dataGridViewExecutions.Location = new System.Drawing.Point(0, 168);
            this.dataGridViewExecutions.Name = "dataGridViewExecutions";
            this.dataGridViewExecutions.Size = new System.Drawing.Size(642, 90);
            this.dataGridViewExecutions.TabIndex = 0;
            // 
            // executionsNavigator
            // 
            this.executionsNavigator.AddNewItem = null;
            this.executionsNavigator.CountItem = this.bindingNavigatorCountItem;
            this.executionsNavigator.DeleteItem = null;
            this.executionsNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.executionsNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.executionsNavigator.Location = new System.Drawing.Point(0, 140);
            this.executionsNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.executionsNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.executionsNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.executionsNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.executionsNavigator.Name = "executionsNavigator";
            this.executionsNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.executionsNavigator.Size = new System.Drawing.Size(207, 25);
            this.executionsNavigator.TabIndex = 1;
            this.executionsNavigator.Text = "bindingNavigator1";
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
            // ColumnReportType
            // 
            this.ColumnReportType.DataPropertyName = "ReportType";
            this.ColumnReportType.HeaderText = "Report Type";
            this.ColumnReportType.Name = "ColumnReportType";
            // 
            // ColumnExecutionType
            // 
            this.ColumnExecutionType.DataPropertyName = "ExecutionType";
            this.ColumnExecutionType.HeaderText = "Execution Type";
            this.ColumnExecutionType.Name = "ColumnExecutionType";
            // 
            // ColumnOrderAmount
            // 
            this.ColumnOrderAmount.DataPropertyName = "OrderAmount";
            this.ColumnOrderAmount.HeaderText = "Ordered";
            this.ColumnOrderAmount.Name = "ColumnOrderAmount";
            // 
            // ColumnFilledAmount
            // 
            this.ColumnFilledAmount.DataPropertyName = "FilledAmount";
            this.ColumnFilledAmount.HeaderText = "Filled";
            this.ColumnFilledAmount.Name = "ColumnFilledAmount";
            // 
            // ColumnCumulative
            // 
            this.ColumnCumulative.DataPropertyName = "CumulativeAmount";
            this.ColumnCumulative.HeaderText = "Cumulative";
            this.ColumnCumulative.Name = "ColumnCumulative";
            // 
            // ColumnRemaining
            // 
            this.ColumnRemaining.DataPropertyName = "RemainingAmount";
            this.ColumnRemaining.HeaderText = "Remaining";
            this.ColumnRemaining.Name = "ColumnRemaining";
            // 
            // ColumnFillPrice
            // 
            this.ColumnFillPrice.DataPropertyName = "FillPrice";
            this.ColumnFillPrice.HeaderText = "Fill Price";
            this.ColumnFillPrice.Name = "ColumnFillPrice";
            // 
            // ColumnAvgPrice
            // 
            this.ColumnAvgPrice.DataPropertyName = "AveragePrice";
            this.ColumnAvgPrice.HeaderText = "Avg. Price";
            this.ColumnAvgPrice.Name = "ColumnAvgPrice";
            // 
            // ColumnLastSpot
            // 
            this.ColumnLastSpot.DataPropertyName = "LastSpotRate";
            this.ColumnLastSpot.HeaderText = "Last Spot";
            this.ColumnLastSpot.Name = "ColumnLastSpot";
            // 
            // ColumnTransactionTime
            // 
            this.ColumnTransactionTime.DataPropertyName = "TransactionTime";
            this.ColumnTransactionTime.HeaderText = "Trans. Time";
            this.ColumnTransactionTime.Name = "ColumnTransactionTime";
            this.ColumnTransactionTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "Status";
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Name = "ColumnStatus";
            // 
            // OrderDetailSubform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.executionsNavigator);
            this.Controls.Add(this.tabOrderDetails);
            this.Controls.Add(this.dataGridViewExecutions);
            this.MaximumSize = new System.Drawing.Size(646, 258);
            this.MinimumSize = new System.Drawing.Size(646, 258);
            this.Name = "OrderDetailSubform";
            this.Size = new System.Drawing.Size(646, 258);
            this.tabOrderDetails.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabNearLegDetails.ResumeLayout(false);
            this.tabNearLegDetails.PerformLayout();
            this.tabFarLegDetails.ResumeLayout(false);
            this.tabFarLegDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExecutions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.executionsNavigator)).EndInit();
            this.executionsNavigator.ResumeLayout(false);
            this.executionsNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.executionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabOrderDetails;
        private System.Windows.Forms.TabPage tabNearLegDetails;
        private System.Windows.Forms.TabPage tabFarLegDetails;
        private Extensions.DataGridViewExtension dataGridViewExecutions;
        private System.Windows.Forms.BindingNavigator executionsNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ListBox lstNearAllocations;
        private System.Windows.Forms.Label lblNearSettles;
        private System.Windows.Forms.TextBox txtNearSettles;
        private System.Windows.Forms.Label lblNearTenor;
        private System.Windows.Forms.TextBox txtNearTenor;
        private System.Windows.Forms.Label lblNearCurrency;
        private System.Windows.Forms.TextBox txtNearCurrency;
        private System.Windows.Forms.Label lblNearAmount;
        private System.Windows.Forms.TextBox txtNearAmount;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.Label lblSide;
        private System.Windows.Forms.TextBox txtSide;
        private System.Windows.Forms.Label lblSpot;
        private System.Windows.Forms.TextBox txtSummaryLastSpot;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.TextBox txtOrderType;
        private System.Windows.Forms.Label lblInstrumentType;
        private System.Windows.Forms.TextBox txtInstrumentType;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label lblNearPoints;
        private System.Windows.Forms.TextBox txtNearPoints;
        private System.Windows.Forms.Label lblNearSpot;
        private System.Windows.Forms.TextBox txtNearSpot;
        private System.Windows.Forms.Label lblNearAllIn;
        private System.Windows.Forms.TextBox txtNearAllIn;
        private System.Windows.Forms.Label lblFarAllIn;
        private System.Windows.Forms.TextBox txtFarAllIn;
        private System.Windows.Forms.Label lblFarPoints;
        private System.Windows.Forms.TextBox txtFarPoints;
        private System.Windows.Forms.Label lblFarSpot;
        private System.Windows.Forms.TextBox txtFarSpot;
        private System.Windows.Forms.ListBox lstFarAllocations;
        private System.Windows.Forms.Label lblFarSettles;
        private System.Windows.Forms.TextBox txtFarSettles;
        private System.Windows.Forms.Label lblFarTenor;
        private System.Windows.Forms.TextBox txtFarTenor;
        private System.Windows.Forms.Label lblFarCurrency;
        private System.Windows.Forms.TextBox txtFarCurrency;
        private System.Windows.Forms.Label lblFarAmount;
        private System.Windows.Forms.TextBox txtFarAmount;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.TextBox txtSummaryStatus;
        private System.Windows.Forms.Label lblSummaryFarAllIn;
        private System.Windows.Forms.TextBox txtSummaryFarAllIn;
        private System.Windows.Forms.Label lblSummaryFarPoints;
        private System.Windows.Forms.TextBox txtSummaryFarPoints;
        private System.Windows.Forms.Label lblSummaryNearAllIn;
        private System.Windows.Forms.TextBox txtSummaryNearAllIn;
        private System.Windows.Forms.Label lblSummaryNearPoints;
        private System.Windows.Forms.TextBox txtSummaryNearPoints;
        private System.Windows.Forms.BindingSource executionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExecutionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFilledAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCumulative;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFillPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAvgPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastSpot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTransactionTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
    }
}
