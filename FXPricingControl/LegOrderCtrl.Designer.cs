namespace FXPricingControl
{
    partial class LegOrderCtrl
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
            this.label4 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dtExpirationTimeZone = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtExpirationTS = new System.Windows.Forms.DateTimePicker();
            this.dtActivationTimeZone = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtActivationTS = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dtSettleDate = new System.Windows.Forms.DateTimePicker();
            this.cmbTIF = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbSide = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.cmbSymbol = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtAllocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 123;
            this.label4.Text = "Active";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(95, 278);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(18, 17);
            this.chkActive.TabIndex = 122;
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // dtExpirationTimeZone
            // 
            this.dtExpirationTimeZone.FormattingEnabled = true;
            this.dtExpirationTimeZone.Location = new System.Drawing.Point(95, 400);
            this.dtExpirationTimeZone.Name = "dtExpirationTimeZone";
            this.dtExpirationTimeZone.Size = new System.Drawing.Size(149, 24);
            this.dtExpirationTimeZone.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 120;
            this.label7.Text = "Expiration";
            // 
            // dtExpirationTS
            // 
            this.dtExpirationTS.CustomFormat = "yyyyMMdd HH:mm:ss";
            this.dtExpirationTS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpirationTS.Location = new System.Drawing.Point(95, 371);
            this.dtExpirationTS.Margin = new System.Windows.Forms.Padding(4);
            this.dtExpirationTS.Name = "dtExpirationTS";
            this.dtExpirationTS.Size = new System.Drawing.Size(149, 22);
            this.dtExpirationTS.TabIndex = 119;
            // 
            // dtActivationTimeZone
            // 
            this.dtActivationTimeZone.Enabled = false;
            this.dtActivationTimeZone.FormattingEnabled = true;
            this.dtActivationTimeZone.Location = new System.Drawing.Point(95, 340);
            this.dtActivationTimeZone.Name = "dtActivationTimeZone";
            this.dtActivationTimeZone.Size = new System.Drawing.Size(149, 24);
            this.dtActivationTimeZone.TabIndex = 118;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 311);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 17);
            this.label15.TabIndex = 117;
            this.label15.Text = "Activation";
            // 
            // dtActivationTS
            // 
            this.dtActivationTS.CustomFormat = "yyyyMMdd HH:mm:ss";
            this.dtActivationTS.Enabled = false;
            this.dtActivationTS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtActivationTS.Location = new System.Drawing.Point(95, 311);
            this.dtActivationTS.Margin = new System.Windows.Forms.Padding(4);
            this.dtActivationTS.Name = "dtActivationTS";
            this.dtActivationTS.Size = new System.Drawing.Size(149, 22);
            this.dtActivationTS.TabIndex = 116;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 429);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 17);
            this.label16.TabIndex = 115;
            this.label16.Text = "Sett. Date";
            // 
            // dtSettleDate
            // 
            this.dtSettleDate.CustomFormat = "yyyyMMdd";
            this.dtSettleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSettleDate.Location = new System.Drawing.Point(95, 431);
            this.dtSettleDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtSettleDate.Name = "dtSettleDate";
            this.dtSettleDate.Size = new System.Drawing.Size(100, 22);
            this.dtSettleDate.TabIndex = 114;
            // 
            // cmbTIF
            // 
            this.cmbTIF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIF.FormattingEnabled = true;
            this.cmbTIF.Location = new System.Drawing.Point(95, 242);
            this.cmbTIF.Name = "cmbTIF";
            this.cmbTIF.Size = new System.Drawing.Size(136, 24);
            this.cmbTIF.TabIndex = 113;
            this.cmbTIF.SelectedIndexChanged += new System.EventHandler(this.cmbTIF_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(61, 240);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 17);
            this.label17.TabIndex = 112;
            this.label17.Text = "TIF";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 111;
            this.button1.Text = "20M";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 23);
            this.button2.TabIndex = 110;
            this.button2.Text = "10M";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 202);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 23);
            this.button3.TabIndex = 109;
            this.button3.Text = "5M";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(95, 47);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(136, 24);
            this.cmbCurrency.TabIndex = 108;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 17);
            this.label18.TabIndex = 107;
            this.label18.Text = "Currency";
            // 
            // cmbSide
            // 
            this.cmbSide.FormattingEnabled = true;
            this.cmbSide.Location = new System.Drawing.Point(95, 81);
            this.cmbSide.Name = "cmbSide";
            this.cmbSide.Size = new System.Drawing.Size(136, 24);
            this.cmbSide.TabIndex = 106;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(53, 81);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 17);
            this.label19.TabIndex = 105;
            this.label19.Text = "Side";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(95, 174);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(136, 22);
            this.txtQuantity.TabIndex = 104;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 171);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 17);
            this.label20.TabIndex = 103;
            this.label20.Text = "Quantity";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(95, 146);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(136, 22);
            this.txtPrice.TabIndex = 102;
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Location = new System.Drawing.Point(95, 116);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(136, 24);
            this.cmbOrderType.TabIndex = 101;
            // 
            // cmbSymbol
            // 
            this.cmbSymbol.FormattingEnabled = true;
            this.cmbSymbol.Location = new System.Drawing.Point(95, 17);
            this.cmbSymbol.Name = "cmbSymbol";
            this.cmbSymbol.Size = new System.Drawing.Size(136, 24);
            this.cmbSymbol.TabIndex = 100;
            this.cmbSymbol.SelectedIndexChanged += new System.EventHandler(this.cmbSymbol_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(49, 143);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 17);
            this.label21.TabIndex = 99;
            this.label21.Text = "Price";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 114);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 17);
            this.label22.TabIndex = 98;
            this.label22.Text = "Order Type";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(35, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 17);
            this.label23.TabIndex = 97;
            this.label23.Text = "Symbol";
            // 
            // txtAllocation
            // 
            this.txtAllocation.Location = new System.Drawing.Point(96, 460);
            this.txtAllocation.Name = "txtAllocation";
            this.txtAllocation.Size = new System.Drawing.Size(144, 22);
            this.txtAllocation.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 124;
            this.label1.Text = "Allocation";
            // 
            // LegOrderCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAllocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.dtExpirationTimeZone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtExpirationTS);
            this.Controls.Add(this.dtActivationTimeZone);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtActivationTS);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtSettleDate);
            this.Controls.Add(this.cmbTIF);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbSide);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cmbOrderType);
            this.Controls.Add(this.cmbSymbol);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Name = "LegOrderCtrl";
            this.Size = new System.Drawing.Size(266, 496);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ComboBox dtExpirationTimeZone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtExpirationTS;
        private System.Windows.Forms.ComboBox dtActivationTimeZone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtActivationTS;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtSettleDate;
        private System.Windows.Forms.ComboBox cmbTIF;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbSide;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.ComboBox cmbSymbol;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtAllocation;
        private System.Windows.Forms.Label label1;
    }
}
