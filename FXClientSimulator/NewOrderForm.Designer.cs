namespace FXClientSimulator {
    partial class NewOrderForm {
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
            this.cmbSymbol = new System.Windows.Forms.ComboBox();
            this.cmbTier = new System.Windows.Forms.ComboBox();
            this.tabAllocations = new System.Windows.Forms.TabControl();
            this.tabNearLeg = new System.Windows.Forms.TabPage();
            this.dtNearSettleDate = new System.Windows.Forms.DateTimePicker();
            this.cmbNearTenor = new System.Windows.Forms.ComboBox();
            this.cmbNearCcy = new System.Windows.Forms.ComboBox();
            this.txtNearAmount = new System.Windows.Forms.TextBox();
            this.btnRemoveNearAllocation = new System.Windows.Forms.Button();
            this.btnAddNearAllocation = new System.Windows.Forms.Button();
            this.lstNearAllocations = new System.Windows.Forms.ListBox();
            this.txtNearAllocation = new System.Windows.Forms.TextBox();
            this.cmbNearAccount = new System.Windows.Forms.ComboBox();
            this.tabFarLeg = new System.Windows.Forms.TabPage();
            this.dtFarSettleDate = new System.Windows.Forms.DateTimePicker();
            this.cmbFarTenor = new System.Windows.Forms.ComboBox();
            this.cmbFarCcy = new System.Windows.Forms.ComboBox();
            this.txtFarAmount = new System.Windows.Forms.TextBox();
            this.btnRemoveFarAllocation = new System.Windows.Forms.Button();
            this.btnAddFarAllocation = new System.Windows.Forms.Button();
            this.lstFarAllocations = new System.Windows.Forms.ListBox();
            this.txtFarAllocation = new System.Windows.Forms.TextBox();
            this.cmbFarAccount = new System.Windows.Forms.ComboBox();
            this.cmbInstrumentType = new System.Windows.Forms.ComboBox();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelBuy = new System.Windows.Forms.Panel();
            this.lblBidQuoteId = new System.Windows.Forms.Label();
            this.lblBidBps = new System.Windows.Forms.Label();
            this.lblBidPips = new System.Windows.Forms.Label();
            this.lblBid = new System.Windows.Forms.Label();
            this.panelSell = new System.Windows.Forms.Panel();
            this.lblAskQuoteId = new System.Windows.Forms.Label();
            this.lblAskBps = new System.Windows.Forms.Label();
            this.lblAskPips = new System.Windows.Forms.Label();
            this.lblAsk = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.tabAllocations.SuspendLayout();
            this.tabNearLeg.SuspendLayout();
            this.tabFarLeg.SuspendLayout();
            this.panelBuy.SuspendLayout();
            this.panelSell.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSymbol
            // 
            this.cmbSymbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSymbol.FormattingEnabled = true;
            this.cmbSymbol.Location = new System.Drawing.Point(16, 15);
            this.cmbSymbol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSymbol.Name = "cmbSymbol";
            this.cmbSymbol.Size = new System.Drawing.Size(160, 24);
            this.cmbSymbol.TabIndex = 0;
            this.cmbSymbol.Text = "Symbol";
            // 
            // cmbTier
            // 
            this.cmbTier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTier.FormattingEnabled = true;
            this.cmbTier.Location = new System.Drawing.Point(185, 15);
            this.cmbTier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTier.Name = "cmbTier";
            this.cmbTier.Size = new System.Drawing.Size(99, 24);
            this.cmbTier.TabIndex = 1;
            this.cmbTier.Text = "Tier";
            // 
            // tabAllocations
            // 
            this.tabAllocations.Controls.Add(this.tabNearLeg);
            this.tabAllocations.Controls.Add(this.tabFarLeg);
            this.tabAllocations.Location = new System.Drawing.Point(16, 49);
            this.tabAllocations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabAllocations.Name = "tabAllocations";
            this.tabAllocations.SelectedIndex = 0;
            this.tabAllocations.Size = new System.Drawing.Size(585, 188);
            this.tabAllocations.TabIndex = 4;
            // 
            // tabNearLeg
            // 
            this.tabNearLeg.Controls.Add(this.dtNearSettleDate);
            this.tabNearLeg.Controls.Add(this.cmbNearTenor);
            this.tabNearLeg.Controls.Add(this.cmbNearCcy);
            this.tabNearLeg.Controls.Add(this.txtNearAmount);
            this.tabNearLeg.Controls.Add(this.btnRemoveNearAllocation);
            this.tabNearLeg.Controls.Add(this.btnAddNearAllocation);
            this.tabNearLeg.Controls.Add(this.lstNearAllocations);
            this.tabNearLeg.Controls.Add(this.txtNearAllocation);
            this.tabNearLeg.Controls.Add(this.cmbNearAccount);
            this.tabNearLeg.Location = new System.Drawing.Point(4, 25);
            this.tabNearLeg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabNearLeg.Name = "tabNearLeg";
            this.tabNearLeg.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabNearLeg.Size = new System.Drawing.Size(577, 159);
            this.tabNearLeg.TabIndex = 0;
            this.tabNearLeg.Text = "Near Leg";
            this.tabNearLeg.UseVisualStyleBackColor = true;
            // 
            // dtNearSettleDate
            // 
            this.dtNearSettleDate.Location = new System.Drawing.Point(368, 9);
            this.dtNearSettleDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtNearSettleDate.Name = "dtNearSettleDate";
            this.dtNearSettleDate.Size = new System.Drawing.Size(196, 22);
            this.dtNearSettleDate.TabIndex = 8;
            // 
            // cmbNearTenor
            // 
            this.cmbNearTenor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNearTenor.FormattingEnabled = true;
            this.cmbNearTenor.Location = new System.Drawing.Point(273, 7);
            this.cmbNearTenor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbNearTenor.Name = "cmbNearTenor";
            this.cmbNearTenor.Size = new System.Drawing.Size(85, 24);
            this.cmbNearTenor.TabIndex = 7;
            // 
            // cmbNearCcy
            // 
            this.cmbNearCcy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNearCcy.FormattingEnabled = true;
            this.cmbNearCcy.Location = new System.Drawing.Point(164, 7);
            this.cmbNearCcy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbNearCcy.Name = "cmbNearCcy";
            this.cmbNearCcy.Size = new System.Drawing.Size(100, 24);
            this.cmbNearCcy.TabIndex = 6;
            this.cmbNearCcy.Text = "Currency";
            // 
            // txtNearAmount
            // 
            this.txtNearAmount.Location = new System.Drawing.Point(8, 7);
            this.txtNearAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNearAmount.Name = "txtNearAmount";
            this.txtNearAmount.Size = new System.Drawing.Size(147, 22);
            this.txtNearAmount.TabIndex = 5;
            this.txtNearAmount.Text = "Amount";
            this.txtNearAmount.TextChanged += new System.EventHandler(this.TxtNearAmountTextChanged);
            // 
            // btnRemoveNearAllocation
            // 
            this.btnRemoveNearAllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveNearAllocation.Location = new System.Drawing.Point(479, 95);
            this.btnRemoveNearAllocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveNearAllocation.Name = "btnRemoveNearAllocation";
            this.btnRemoveNearAllocation.Size = new System.Drawing.Size(87, 55);
            this.btnRemoveNearAllocation.TabIndex = 4;
            this.btnRemoveNearAllocation.Text = "-";
            this.btnRemoveNearAllocation.UseVisualStyleBackColor = true;
            // 
            // btnAddNearAllocation
            // 
            this.btnAddNearAllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNearAllocation.Location = new System.Drawing.Point(479, 37);
            this.btnAddNearAllocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddNearAllocation.Name = "btnAddNearAllocation";
            this.btnAddNearAllocation.Size = new System.Drawing.Size(87, 55);
            this.btnAddNearAllocation.TabIndex = 3;
            this.btnAddNearAllocation.Text = "+";
            this.btnAddNearAllocation.UseVisualStyleBackColor = true;
            // 
            // lstNearAllocations
            // 
            this.lstNearAllocations.FormattingEnabled = true;
            this.lstNearAllocations.ItemHeight = 16;
            this.lstNearAllocations.Location = new System.Drawing.Point(8, 65);
            this.lstNearAllocations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstNearAllocations.MultiColumn = true;
            this.lstNearAllocations.Name = "lstNearAllocations";
            this.lstNearAllocations.Size = new System.Drawing.Size(461, 84);
            this.lstNearAllocations.TabIndex = 2;
            // 
            // txtNearAllocation
            // 
            this.txtNearAllocation.Location = new System.Drawing.Point(272, 37);
            this.txtNearAllocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNearAllocation.Name = "txtNearAllocation";
            this.txtNearAllocation.Size = new System.Drawing.Size(197, 22);
            this.txtNearAllocation.TabIndex = 1;
            this.txtNearAllocation.Text = "Amount";
            // 
            // cmbNearAccount
            // 
            this.cmbNearAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNearAccount.FormattingEnabled = true;
            this.cmbNearAccount.Location = new System.Drawing.Point(8, 37);
            this.cmbNearAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbNearAccount.Name = "cmbNearAccount";
            this.cmbNearAccount.Size = new System.Drawing.Size(255, 24);
            this.cmbNearAccount.TabIndex = 0;
            this.cmbNearAccount.Text = "Account";
            // 
            // tabFarLeg
            // 
            this.tabFarLeg.Controls.Add(this.dtFarSettleDate);
            this.tabFarLeg.Controls.Add(this.cmbFarTenor);
            this.tabFarLeg.Controls.Add(this.cmbFarCcy);
            this.tabFarLeg.Controls.Add(this.txtFarAmount);
            this.tabFarLeg.Controls.Add(this.btnRemoveFarAllocation);
            this.tabFarLeg.Controls.Add(this.btnAddFarAllocation);
            this.tabFarLeg.Controls.Add(this.lstFarAllocations);
            this.tabFarLeg.Controls.Add(this.txtFarAllocation);
            this.tabFarLeg.Controls.Add(this.cmbFarAccount);
            this.tabFarLeg.Location = new System.Drawing.Point(4, 25);
            this.tabFarLeg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabFarLeg.Name = "tabFarLeg";
            this.tabFarLeg.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabFarLeg.Size = new System.Drawing.Size(577, 159);
            this.tabFarLeg.TabIndex = 1;
            this.tabFarLeg.Text = "Far Leg";
            this.tabFarLeg.UseVisualStyleBackColor = true;
            // 
            // dtFarSettleDate
            // 
            this.dtFarSettleDate.Location = new System.Drawing.Point(368, 9);
            this.dtFarSettleDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFarSettleDate.Name = "dtFarSettleDate";
            this.dtFarSettleDate.Size = new System.Drawing.Size(196, 22);
            this.dtFarSettleDate.TabIndex = 13;
            // 
            // cmbFarTenor
            // 
            this.cmbFarTenor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFarTenor.FormattingEnabled = true;
            this.cmbFarTenor.Location = new System.Drawing.Point(273, 7);
            this.cmbFarTenor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbFarTenor.Name = "cmbFarTenor";
            this.cmbFarTenor.Size = new System.Drawing.Size(85, 24);
            this.cmbFarTenor.TabIndex = 12;
            // 
            // cmbFarCcy
            // 
            this.cmbFarCcy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFarCcy.FormattingEnabled = true;
            this.cmbFarCcy.Location = new System.Drawing.Point(164, 7);
            this.cmbFarCcy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbFarCcy.Name = "cmbFarCcy";
            this.cmbFarCcy.Size = new System.Drawing.Size(100, 24);
            this.cmbFarCcy.TabIndex = 11;
            this.cmbFarCcy.Text = "Currency";
            // 
            // txtFarAmount
            // 
            this.txtFarAmount.Location = new System.Drawing.Point(8, 7);
            this.txtFarAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFarAmount.Name = "txtFarAmount";
            this.txtFarAmount.Size = new System.Drawing.Size(147, 22);
            this.txtFarAmount.TabIndex = 10;
            this.txtFarAmount.Text = "Amount";
            this.txtFarAmount.TextChanged += new System.EventHandler(this.TxtFarAmountTextChanged);
            // 
            // btnRemoveFarAllocation
            // 
            this.btnRemoveFarAllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFarAllocation.Location = new System.Drawing.Point(479, 95);
            this.btnRemoveFarAllocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveFarAllocation.Name = "btnRemoveFarAllocation";
            this.btnRemoveFarAllocation.Size = new System.Drawing.Size(87, 55);
            this.btnRemoveFarAllocation.TabIndex = 9;
            this.btnRemoveFarAllocation.Text = "-";
            this.btnRemoveFarAllocation.UseVisualStyleBackColor = true;
            // 
            // btnAddFarAllocation
            // 
            this.btnAddFarAllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFarAllocation.Location = new System.Drawing.Point(479, 37);
            this.btnAddFarAllocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddFarAllocation.Name = "btnAddFarAllocation";
            this.btnAddFarAllocation.Size = new System.Drawing.Size(87, 55);
            this.btnAddFarAllocation.TabIndex = 8;
            this.btnAddFarAllocation.Text = "+";
            this.btnAddFarAllocation.UseVisualStyleBackColor = true;
            // 
            // lstFarAllocations
            // 
            this.lstFarAllocations.FormattingEnabled = true;
            this.lstFarAllocations.ItemHeight = 16;
            this.lstFarAllocations.Location = new System.Drawing.Point(8, 65);
            this.lstFarAllocations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstFarAllocations.Name = "lstFarAllocations";
            this.lstFarAllocations.Size = new System.Drawing.Size(461, 84);
            this.lstFarAllocations.TabIndex = 7;
            // 
            // txtFarAllocation
            // 
            this.txtFarAllocation.Location = new System.Drawing.Point(272, 37);
            this.txtFarAllocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFarAllocation.Name = "txtFarAllocation";
            this.txtFarAllocation.Size = new System.Drawing.Size(197, 22);
            this.txtFarAllocation.TabIndex = 6;
            this.txtFarAllocation.Text = "Amount";
            // 
            // cmbFarAccount
            // 
            this.cmbFarAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFarAccount.FormattingEnabled = true;
            this.cmbFarAccount.Location = new System.Drawing.Point(8, 37);
            this.cmbFarAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbFarAccount.Name = "cmbFarAccount";
            this.cmbFarAccount.Size = new System.Drawing.Size(255, 24);
            this.cmbFarAccount.TabIndex = 5;
            // 
            // cmbInstrumentType
            // 
            this.cmbInstrumentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbInstrumentType.FormattingEnabled = true;
            this.cmbInstrumentType.Location = new System.Drawing.Point(293, 16);
            this.cmbInstrumentType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbInstrumentType.Name = "cmbInstrumentType";
            this.cmbInstrumentType.Size = new System.Drawing.Size(137, 24);
            this.cmbInstrumentType.TabIndex = 5;
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Location = new System.Drawing.Point(440, 16);
            this.cmbOrderType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(160, 24);
            this.cmbOrderType.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(499, 241);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 72);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExitClick);
            // 
            // panelBuy
            // 
            this.panelBuy.BackColor = System.Drawing.Color.Red;
            this.panelBuy.Controls.Add(this.lblBidQuoteId);
            this.panelBuy.Controls.Add(this.lblBidBps);
            this.panelBuy.Controls.Add(this.lblBidPips);
            this.panelBuy.Controls.Add(this.lblBid);
            this.panelBuy.Location = new System.Drawing.Point(16, 245);
            this.panelBuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBuy.Name = "panelBuy";
            this.panelBuy.Size = new System.Drawing.Size(140, 71);
            this.panelBuy.TabIndex = 13;
            this.panelBuy.DoubleClick += new System.EventHandler(this.SellOrderDoubleClick);
            // 
            // lblBidQuoteId
            // 
            this.lblBidQuoteId.AutoSize = true;
            this.lblBidQuoteId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidQuoteId.ForeColor = System.Drawing.Color.White;
            this.lblBidQuoteId.Location = new System.Drawing.Point(4, 4);
            this.lblBidQuoteId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBidQuoteId.Name = "lblBidQuoteId";
            this.lblBidQuoteId.Size = new System.Drawing.Size(45, 13);
            this.lblBidQuoteId.TabIndex = 16;
            this.lblBidQuoteId.Text = "QuoteId";
            this.lblBidQuoteId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBidQuoteId.Visible = false;
            this.lblBidQuoteId.DoubleClick += new System.EventHandler(this.SellOrderDoubleClick);
            // 
            // lblBidBps
            // 
            this.lblBidBps.AutoSize = true;
            this.lblBidBps.ForeColor = System.Drawing.Color.White;
            this.lblBidBps.Location = new System.Drawing.Point(100, 37);
            this.lblBidBps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBidBps.Name = "lblBidBps";
            this.lblBidBps.Size = new System.Drawing.Size(24, 17);
            this.lblBidBps.TabIndex = 11;
            this.lblBidBps.Text = "00";
            this.lblBidBps.DoubleClick += new System.EventHandler(this.SellOrderDoubleClick);
            // 
            // lblBidPips
            // 
            this.lblBidPips.AutoSize = true;
            this.lblBidPips.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidPips.ForeColor = System.Drawing.Color.White;
            this.lblBidPips.Location = new System.Drawing.Point(47, 20);
            this.lblBidPips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBidPips.Name = "lblBidPips";
            this.lblBidPips.Size = new System.Drawing.Size(55, 39);
            this.lblBidPips.TabIndex = 10;
            this.lblBidPips.Text = "00";
            this.lblBidPips.DoubleClick += new System.EventHandler(this.SellOrderDoubleClick);
            // 
            // lblBid
            // 
            this.lblBid.AutoSize = true;
            this.lblBid.ForeColor = System.Drawing.Color.White;
            this.lblBid.Location = new System.Drawing.Point(13, 37);
            this.lblBid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBid.Name = "lblBid";
            this.lblBid.Size = new System.Drawing.Size(36, 17);
            this.lblBid.TabIndex = 9;
            this.lblBid.Text = "0.00";
            this.lblBid.DoubleClick += new System.EventHandler(this.SellOrderDoubleClick);
            // 
            // panelSell
            // 
            this.panelSell.BackColor = System.Drawing.Color.Green;
            this.panelSell.Controls.Add(this.lblAskQuoteId);
            this.panelSell.Controls.Add(this.lblAskBps);
            this.panelSell.Controls.Add(this.lblAskPips);
            this.panelSell.Controls.Add(this.lblAsk);
            this.panelSell.Location = new System.Drawing.Point(180, 245);
            this.panelSell.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSell.Name = "panelSell";
            this.panelSell.Size = new System.Drawing.Size(140, 71);
            this.panelSell.TabIndex = 14;
            this.panelSell.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSell_Paint);
            this.panelSell.DoubleClick += new System.EventHandler(this.BuyOrderDoubleClick);
            // 
            // lblAskQuoteId
            // 
            this.lblAskQuoteId.AutoSize = true;
            this.lblAskQuoteId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskQuoteId.ForeColor = System.Drawing.Color.White;
            this.lblAskQuoteId.Location = new System.Drawing.Point(4, 4);
            this.lblAskQuoteId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAskQuoteId.Name = "lblAskQuoteId";
            this.lblAskQuoteId.Size = new System.Drawing.Size(45, 13);
            this.lblAskQuoteId.TabIndex = 17;
            this.lblAskQuoteId.Text = "QuoteId";
            this.lblAskQuoteId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAskQuoteId.Visible = false;
            this.lblAskQuoteId.DoubleClick += new System.EventHandler(this.BuyOrderDoubleClick);
            // 
            // lblAskBps
            // 
            this.lblAskBps.AutoSize = true;
            this.lblAskBps.ForeColor = System.Drawing.Color.White;
            this.lblAskBps.Location = new System.Drawing.Point(100, 37);
            this.lblAskBps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAskBps.Name = "lblAskBps";
            this.lblAskBps.Size = new System.Drawing.Size(24, 17);
            this.lblAskBps.TabIndex = 15;
            this.lblAskBps.Text = "00";
            this.lblAskBps.DoubleClick += new System.EventHandler(this.BuyOrderDoubleClick);
            // 
            // lblAskPips
            // 
            this.lblAskPips.AutoSize = true;
            this.lblAskPips.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskPips.ForeColor = System.Drawing.Color.White;
            this.lblAskPips.Location = new System.Drawing.Point(47, 20);
            this.lblAskPips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAskPips.Name = "lblAskPips";
            this.lblAskPips.Size = new System.Drawing.Size(55, 39);
            this.lblAskPips.TabIndex = 14;
            this.lblAskPips.Text = "00";
            this.lblAskPips.DoubleClick += new System.EventHandler(this.BuyOrderDoubleClick);
            // 
            // lblAsk
            // 
            this.lblAsk.AutoSize = true;
            this.lblAsk.ForeColor = System.Drawing.Color.White;
            this.lblAsk.Location = new System.Drawing.Point(13, 37);
            this.lblAsk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAsk.Name = "lblAsk";
            this.lblAsk.Size = new System.Drawing.Size(36, 17);
            this.lblAsk.TabIndex = 13;
            this.lblAsk.Text = "0.00";
            this.lblAsk.DoubleClick += new System.EventHandler(this.BuyOrderDoubleClick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(355, 241);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(102, 72);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 314);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.panelBuy);
            this.Controls.Add(this.panelSell);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbOrderType);
            this.Controls.Add(this.cmbInstrumentType);
            this.Controls.Add(this.tabAllocations);
            this.Controls.Add(this.cmbTier);
            this.Controls.Add(this.cmbSymbol);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(621, 359);
            this.MinimumSize = new System.Drawing.Size(621, 359);
            this.Name = "NewOrderForm";
            this.Text = "Create New Order";
            this.tabAllocations.ResumeLayout(false);
            this.tabNearLeg.ResumeLayout(false);
            this.tabNearLeg.PerformLayout();
            this.tabFarLeg.ResumeLayout(false);
            this.tabFarLeg.PerformLayout();
            this.panelBuy.ResumeLayout(false);
            this.panelBuy.PerformLayout();
            this.panelSell.ResumeLayout(false);
            this.panelSell.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSymbol;
        private System.Windows.Forms.ComboBox cmbTier;
        private System.Windows.Forms.TabControl tabAllocations;
        private System.Windows.Forms.TabPage tabNearLeg;
        private System.Windows.Forms.Button btnRemoveNearAllocation;
        private System.Windows.Forms.Button btnAddNearAllocation;
        private System.Windows.Forms.ListBox lstNearAllocations;
        private System.Windows.Forms.TextBox txtNearAllocation;
        private System.Windows.Forms.ComboBox cmbNearAccount;
        private System.Windows.Forms.TabPage tabFarLeg;
        private System.Windows.Forms.Button btnRemoveFarAllocation;
        private System.Windows.Forms.Button btnAddFarAllocation;
        private System.Windows.Forms.ListBox lstFarAllocations;
        private System.Windows.Forms.TextBox txtFarAllocation;
        private System.Windows.Forms.ComboBox cmbFarAccount;
        private System.Windows.Forms.DateTimePicker dtNearSettleDate;
        private System.Windows.Forms.ComboBox cmbNearTenor;
        private System.Windows.Forms.ComboBox cmbNearCcy;
        private System.Windows.Forms.TextBox txtNearAmount;
        private System.Windows.Forms.DateTimePicker dtFarSettleDate;
        private System.Windows.Forms.ComboBox cmbFarTenor;
        private System.Windows.Forms.ComboBox cmbFarCcy;
        private System.Windows.Forms.TextBox txtFarAmount;
        private System.Windows.Forms.ComboBox cmbInstrumentType;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelBuy;
        private System.Windows.Forms.Label lblBidQuoteId;
        private System.Windows.Forms.Label lblBidBps;
        private System.Windows.Forms.Label lblBidPips;
        private System.Windows.Forms.Label lblBid;
        private System.Windows.Forms.Panel panelSell;
        private System.Windows.Forms.Label lblAskQuoteId;
        private System.Windows.Forms.Label lblAskBps;
        private System.Windows.Forms.Label lblAskPips;
        private System.Windows.Forms.Label lblAsk;
        private System.Windows.Forms.Button btnSend;
    }
}