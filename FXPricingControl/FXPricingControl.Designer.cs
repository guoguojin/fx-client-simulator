namespace FXPricingControl
{
    partial class FXPricingControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbSymbol = new System.Windows.Forms.ComboBox();
            this.lblLow = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblBid = new System.Windows.Forms.Label();
            this.lblLowPrice = new System.Windows.Forms.Label();
            this.lblHighPrice = new System.Windows.Forms.Label();
            this.lblSpread = new System.Windows.Forms.Label();
            this.lblBidPips = new System.Windows.Forms.Label();
            this.lblBidBps = new System.Windows.Forms.Label();
            this.lblAsk = new System.Windows.Forms.Label();
            this.cmbQuantity = new System.Windows.Forms.ComboBox();
            this.panelBuy = new System.Windows.Forms.Panel();
            this.lblBidQuoteId = new System.Windows.Forms.Label();
            this.lblAskPips = new System.Windows.Forms.Label();
            this.lblAskBps = new System.Windows.Forms.Label();
            this.panelSell = new System.Windows.Forms.Panel();
            this.lblAskQuoteId = new System.Windows.Forms.Label();
            this.dtSettlement = new System.Windows.Forms.DateTimePicker();
            this.cmbTenor = new System.Windows.Forms.ComboBox();
            this.cmbTier = new System.Windows.Forms.ComboBox();
            this.cmbCcy = new System.Windows.Forms.ComboBox();
            this.contextPricingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newOrderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRFQContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBuy.SuspendLayout();
            this.panelSell.SuspendLayout();
            this.contextPricingMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSymbol
            // 
            this.cmbSymbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSymbol.FormattingEnabled = true;
            this.cmbSymbol.Location = new System.Drawing.Point(16, 4);
            this.cmbSymbol.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSymbol.Name = "cmbSymbol";
            this.cmbSymbol.Size = new System.Drawing.Size(183, 24);
            this.cmbSymbol.TabIndex = 1;
            this.cmbSymbol.Text = "Symbol";
            this.cmbSymbol.SelectedIndexChanged += new System.EventHandler(this.CmbSymbolSelectedIndexChanged);
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Location = new System.Drawing.Point(12, 94);
            this.lblLow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(33, 17);
            this.lblLow.TabIndex = 3;
            this.lblLow.Text = "Low";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(280, 94);
            this.lblHigh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(37, 17);
            this.lblHigh.TabIndex = 6;
            this.lblHigh.Text = "High";
            // 
            // lblBid
            // 
            this.lblBid.AutoSize = true;
            this.lblBid.ForeColor = System.Drawing.Color.White;
            this.lblBid.Location = new System.Drawing.Point(13, 27);
            this.lblBid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBid.Name = "lblBid";
            this.lblBid.Size = new System.Drawing.Size(36, 17);
            this.lblBid.TabIndex = 9;
            this.lblBid.Text = "0.00";
            this.lblBid.DoubleClick += new System.EventHandler(this.LblBidDoubleClick);
            // 
            // lblLowPrice
            // 
            this.lblLowPrice.AutoSize = true;
            this.lblLowPrice.Location = new System.Drawing.Point(56, 94);
            this.lblLowPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowPrice.Name = "lblLowPrice";
            this.lblLowPrice.Size = new System.Drawing.Size(60, 17);
            this.lblLowPrice.TabIndex = 4;
            this.lblLowPrice.Text = "0.00000";
            // 
            // lblHighPrice
            // 
            this.lblHighPrice.AutoSize = true;
            this.lblHighPrice.Location = new System.Drawing.Point(326, 94);
            this.lblHighPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHighPrice.Name = "lblHighPrice";
            this.lblHighPrice.Size = new System.Drawing.Size(60, 17);
            this.lblHighPrice.TabIndex = 7;
            this.lblHighPrice.Text = "0.00000";
            // 
            // lblSpread
            // 
            this.lblSpread.AutoSize = true;
            this.lblSpread.Location = new System.Drawing.Point(196, 94);
            this.lblSpread.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpread.Name = "lblSpread";
            this.lblSpread.Size = new System.Drawing.Size(44, 17);
            this.lblSpread.TabIndex = 5;
            this.lblSpread.Text = "0.000";
            // 
            // lblBidPips
            // 
            this.lblBidPips.AutoSize = true;
            this.lblBidPips.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidPips.ForeColor = System.Drawing.Color.White;
            this.lblBidPips.Location = new System.Drawing.Point(47, 10);
            this.lblBidPips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBidPips.Name = "lblBidPips";
            this.lblBidPips.Size = new System.Drawing.Size(55, 39);
            this.lblBidPips.TabIndex = 10;
            this.lblBidPips.Text = "00";
            this.lblBidPips.DoubleClick += new System.EventHandler(this.LblBidPipsDoubleClick);
            // 
            // lblBidBps
            // 
            this.lblBidBps.AutoSize = true;
            this.lblBidBps.ForeColor = System.Drawing.Color.White;
            this.lblBidBps.Location = new System.Drawing.Point(100, 27);
            this.lblBidBps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBidBps.Name = "lblBidBps";
            this.lblBidBps.Size = new System.Drawing.Size(24, 17);
            this.lblBidBps.TabIndex = 11;
            this.lblBidBps.Text = "00";
            this.lblBidBps.DoubleClick += new System.EventHandler(this.LblBidBpsDoubleClick);
            // 
            // lblAsk
            // 
            this.lblAsk.AutoSize = true;
            this.lblAsk.ForeColor = System.Drawing.Color.White;
            this.lblAsk.Location = new System.Drawing.Point(13, 27);
            this.lblAsk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAsk.Name = "lblAsk";
            this.lblAsk.Size = new System.Drawing.Size(36, 17);
            this.lblAsk.TabIndex = 13;
            this.lblAsk.Text = "0.00";
            this.lblAsk.DoubleClick += new System.EventHandler(this.LblAskDoubleClick);
            // 
            // cmbQuantity
            // 
            this.cmbQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQuantity.FormattingEnabled = true;
            this.cmbQuantity.Location = new System.Drawing.Point(16, 34);
            this.cmbQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbQuantity.Name = "cmbQuantity";
            this.cmbQuantity.Size = new System.Drawing.Size(183, 24);
            this.cmbQuantity.TabIndex = 2;
            this.cmbQuantity.Text = "1000000";
            this.cmbQuantity.SelectedIndexChanged += new System.EventHandler(this.CmbQuantitySelectedIndexChanged);
            this.cmbQuantity.TextUpdate += new System.EventHandler(this.CmbQuantityTextUpdate);
            // 
            // panelBuy
            // 
            this.panelBuy.BackColor = System.Drawing.Color.Red;
            this.panelBuy.Controls.Add(this.lblBidQuoteId);
            this.panelBuy.Controls.Add(this.lblBidBps);
            this.panelBuy.Controls.Add(this.lblBidPips);
            this.panelBuy.Controls.Add(this.lblBid);
            this.panelBuy.Location = new System.Drawing.Point(16, 113);
            this.panelBuy.Margin = new System.Windows.Forms.Padding(4);
            this.panelBuy.Name = "panelBuy";
            this.panelBuy.Size = new System.Drawing.Size(195, 55);
            this.panelBuy.TabIndex = 8;
            this.panelBuy.DoubleClick += new System.EventHandler(this.PanelBuyDoubleClick);
            // 
            // lblBidQuoteId
            // 
            this.lblBidQuoteId.AutoSize = true;
            this.lblBidQuoteId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidQuoteId.ForeColor = System.Drawing.Color.White;
            this.lblBidQuoteId.Location = new System.Drawing.Point(0, 1);
            this.lblBidQuoteId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBidQuoteId.Name = "lblBidQuoteId";
            this.lblBidQuoteId.Size = new System.Drawing.Size(45, 13);
            this.lblBidQuoteId.TabIndex = 16;
            this.lblBidQuoteId.Text = "QuoteId";
            this.lblBidQuoteId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBidQuoteId.Visible = false;
            // 
            // lblAskPips
            // 
            this.lblAskPips.AutoSize = true;
            this.lblAskPips.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskPips.ForeColor = System.Drawing.Color.White;
            this.lblAskPips.Location = new System.Drawing.Point(47, 10);
            this.lblAskPips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAskPips.Name = "lblAskPips";
            this.lblAskPips.Size = new System.Drawing.Size(55, 39);
            this.lblAskPips.TabIndex = 14;
            this.lblAskPips.Text = "00";
            this.lblAskPips.DoubleClick += new System.EventHandler(this.LblAskPipsDoubleClick);
            // 
            // lblAskBps
            // 
            this.lblAskBps.AutoSize = true;
            this.lblAskBps.ForeColor = System.Drawing.Color.White;
            this.lblAskBps.Location = new System.Drawing.Point(100, 27);
            this.lblAskBps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAskBps.Name = "lblAskBps";
            this.lblAskBps.Size = new System.Drawing.Size(24, 17);
            this.lblAskBps.TabIndex = 15;
            this.lblAskBps.Text = "00";
            this.lblAskBps.DoubleClick += new System.EventHandler(this.LblAskBpsDoubleClick);
            // 
            // panelSell
            // 
            this.panelSell.BackColor = System.Drawing.Color.Green;
            this.panelSell.Controls.Add(this.lblAskQuoteId);
            this.panelSell.Controls.Add(this.lblAskBps);
            this.panelSell.Controls.Add(this.lblAskPips);
            this.panelSell.Controls.Add(this.lblAsk);
            this.panelSell.Location = new System.Drawing.Point(229, 113);
            this.panelSell.Margin = new System.Windows.Forms.Padding(4);
            this.panelSell.Name = "panelSell";
            this.panelSell.Size = new System.Drawing.Size(195, 55);
            this.panelSell.TabIndex = 12;
            this.panelSell.DoubleClick += new System.EventHandler(this.PanelSellDoubleClick);
            // 
            // lblAskQuoteId
            // 
            this.lblAskQuoteId.AutoSize = true;
            this.lblAskQuoteId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskQuoteId.ForeColor = System.Drawing.Color.White;
            this.lblAskQuoteId.Location = new System.Drawing.Point(-1, 1);
            this.lblAskQuoteId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAskQuoteId.Name = "lblAskQuoteId";
            this.lblAskQuoteId.Size = new System.Drawing.Size(45, 13);
            this.lblAskQuoteId.TabIndex = 17;
            this.lblAskQuoteId.Text = "QuoteId";
            this.lblAskQuoteId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAskQuoteId.Visible = false;
            // 
            // dtSettlement
            // 
            this.dtSettlement.CustomFormat = "yyyyMMdd";
            this.dtSettlement.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSettlement.Location = new System.Drawing.Point(229, 66);
            this.dtSettlement.Margin = new System.Windows.Forms.Padding(4);
            this.dtSettlement.Name = "dtSettlement";
            this.dtSettlement.Size = new System.Drawing.Size(108, 22);
            this.dtSettlement.TabIndex = 18;
            // 
            // cmbTenor
            // 
            this.cmbTenor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTenor.FormattingEnabled = true;
            this.cmbTenor.Location = new System.Drawing.Point(16, 64);
            this.cmbTenor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTenor.Name = "cmbTenor";
            this.cmbTenor.Size = new System.Drawing.Size(183, 24);
            this.cmbTenor.TabIndex = 19;
            this.cmbTenor.Text = "Tenor";
            // 
            // cmbTier
            // 
            this.cmbTier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTier.FormattingEnabled = true;
            this.cmbTier.Location = new System.Drawing.Point(229, 4);
            this.cmbTier.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTier.Name = "cmbTier";
            this.cmbTier.Size = new System.Drawing.Size(108, 24);
            this.cmbTier.TabIndex = 22;
            this.cmbTier.Text = "Tier";
            this.cmbTier.SelectedIndexChanged += new System.EventHandler(this.CmbTierSelectedIndexChanged);
            // 
            // cmbCcy
            // 
            this.cmbCcy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCcy.FormattingEnabled = true;
            this.cmbCcy.Location = new System.Drawing.Point(229, 34);
            this.cmbCcy.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCcy.Name = "cmbCcy";
            this.cmbCcy.Size = new System.Drawing.Size(108, 24);
            this.cmbCcy.TabIndex = 25;
            this.cmbCcy.Text = "Currency";
            // 
            // contextPricingMenu
            // 
            this.contextPricingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newOrderContextMenuItem,
            this.newRFQContextMenuItem});
            this.contextPricingMenu.Name = "contextMenuStrip1";
            this.contextPricingMenu.Size = new System.Drawing.Size(151, 52);
            // 
            // newOrderContextMenuItem
            // 
            this.newOrderContextMenuItem.Name = "newOrderContextMenuItem";
            this.newOrderContextMenuItem.Size = new System.Drawing.Size(150, 24);
            this.newOrderContextMenuItem.Text = "New Order";
            this.newOrderContextMenuItem.Click += new System.EventHandler(this.NewOrderContextMenuItemClick);
            // 
            // newRFQContextMenuItem
            // 
            this.newRFQContextMenuItem.Name = "newRFQContextMenuItem";
            this.newRFQContextMenuItem.Size = new System.Drawing.Size(150, 24);
            this.newRFQContextMenuItem.Text = "New RFQ";
            this.newRFQContextMenuItem.Click += new System.EventHandler(this.NewRFQContextMenuItemClick);
            // 
            // FXPricingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ContextMenuStrip = this.contextPricingMenu;
            this.Controls.Add(this.cmbCcy);
            this.Controls.Add(this.cmbTier);
            this.Controls.Add(this.cmbTenor);
            this.Controls.Add(this.dtSettlement);
            this.Controls.Add(this.cmbQuantity);
            this.Controls.Add(this.lblSpread);
            this.Controls.Add(this.lblHighPrice);
            this.Controls.Add(this.lblLowPrice);
            this.Controls.Add(this.lblHigh);
            this.Controls.Add(this.lblLow);
            this.Controls.Add(this.cmbSymbol);
            this.Controls.Add(this.panelBuy);
            this.Controls.Add(this.panelSell);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FXPricingControl";
            this.Size = new System.Drawing.Size(436, 172);
            this.panelBuy.ResumeLayout(false);
            this.panelBuy.PerformLayout();
            this.panelSell.ResumeLayout(false);
            this.panelSell.PerformLayout();
            this.contextPricingMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSymbol;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblBid;
        private System.Windows.Forms.Label lblLowPrice;
        private System.Windows.Forms.Label lblHighPrice;
        private System.Windows.Forms.Label lblSpread;
        private System.Windows.Forms.Label lblBidPips;
        private System.Windows.Forms.Label lblBidBps;
        private System.Windows.Forms.Label lblAsk;
        private System.Windows.Forms.ComboBox cmbQuantity;
        private System.Windows.Forms.Panel panelBuy;
        private System.Windows.Forms.Label lblAskPips;
        private System.Windows.Forms.Label lblAskBps;
        private System.Windows.Forms.Panel panelSell;
        private System.Windows.Forms.Label lblBidQuoteId;
        private System.Windows.Forms.Label lblAskQuoteId;
        private System.Windows.Forms.DateTimePicker dtSettlement;
        private System.Windows.Forms.ComboBox cmbTenor;
        private System.Windows.Forms.ComboBox cmbTier;
        private System.Windows.Forms.ComboBox cmbCcy;
        private System.Windows.Forms.ContextMenuStrip contextPricingMenu;
        private System.Windows.Forms.ToolStripMenuItem newOrderContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRFQContextMenuItem;
    }
}
