namespace FXClientSimulator
{
    partial class NewMultiLegOrderForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbMultiLegOrderType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grpLeg1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.Button();
            this.grpLeg2 = new System.Windows.Forms.GroupBox();
            this.grpLeg3 = new System.Windows.Forms.GroupBox();
            this.chkAlertSMS = new System.Windows.Forms.CheckBox();
            this.chkAlertEmail = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dtActivationTimeZone = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtActivationTS = new System.Windows.Forms.DateTimePicker();
            this.dtExpirationTimeZone = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtExpirationTS = new System.Windows.Forms.DateTimePicker();
            this.cmbTIF = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.legOrderCtrl3 = new FXPricingControl.LegOrderCtrl();
            this.legOrderCtrl2 = new FXPricingControl.LegOrderCtrl();
            this.legOrderCtrl1 = new FXPricingControl.LegOrderCtrl();
            this.grpLeg1.SuspendLayout();
            this.grpLeg2.SuspendLayout();
            this.grpLeg3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMultiLegOrderType
            // 
            this.cmbMultiLegOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMultiLegOrderType.FormattingEnabled = true;
            this.cmbMultiLegOrderType.Location = new System.Drawing.Point(70, 12);
            this.cmbMultiLegOrderType.Name = "cmbMultiLegOrderType";
            this.cmbMultiLegOrderType.Size = new System.Drawing.Size(136, 24);
            this.cmbMultiLegOrderType.TabIndex = 26;
            this.cmbMultiLegOrderType.SelectedIndexChanged += new System.EventHandler(this.cmbOrderType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "Type";
            // 
            // grpLeg1
            // 
            this.grpLeg1.Controls.Add(this.legOrderCtrl1);
            this.grpLeg1.Location = new System.Drawing.Point(12, 122);
            this.grpLeg1.Name = "grpLeg1";
            this.grpLeg1.Size = new System.Drawing.Size(290, 536);
            this.grpLeg1.TabIndex = 27;
            this.grpLeg1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(656, 682);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 43);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtSend
            // 
            this.txtSend.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txtSend.Location = new System.Drawing.Point(778, 682);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(116, 43);
            this.txtSend.TabIndex = 28;
            this.txtSend.Text = "Send";
            this.txtSend.UseVisualStyleBackColor = true;
            this.txtSend.Click += new System.EventHandler(this.txtSend_Click);
            // 
            // grpLeg2
            // 
            this.grpLeg2.Controls.Add(this.legOrderCtrl2);
            this.grpLeg2.Location = new System.Drawing.Point(308, 122);
            this.grpLeg2.Name = "grpLeg2";
            this.grpLeg2.Size = new System.Drawing.Size(290, 536);
            this.grpLeg2.TabIndex = 28;
            this.grpLeg2.TabStop = false;
            // 
            // grpLeg3
            // 
            this.grpLeg3.Controls.Add(this.legOrderCtrl3);
            this.grpLeg3.Location = new System.Drawing.Point(604, 122);
            this.grpLeg3.Name = "grpLeg3";
            this.grpLeg3.Size = new System.Drawing.Size(290, 536);
            this.grpLeg3.TabIndex = 29;
            this.grpLeg3.TabStop = false;
            // 
            // chkAlertSMS
            // 
            this.chkAlertSMS.AutoSize = true;
            this.chkAlertSMS.Location = new System.Drawing.Point(114, 84);
            this.chkAlertSMS.Name = "chkAlertSMS";
            this.chkAlertSMS.Size = new System.Drawing.Size(59, 21);
            this.chkAlertSMS.TabIndex = 50;
            this.chkAlertSMS.Text = "SMS";
            this.chkAlertSMS.UseVisualStyleBackColor = true;
            // 
            // chkAlertEmail
            // 
            this.chkAlertEmail.AutoSize = true;
            this.chkAlertEmail.Location = new System.Drawing.Point(115, 57);
            this.chkAlertEmail.Name = "chkAlertEmail";
            this.chkAlertEmail.Size = new System.Drawing.Size(64, 21);
            this.chkAlertEmail.TabIndex = 49;
            this.chkAlertEmail.Text = "Email";
            this.chkAlertEmail.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "Alert";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(255, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 17);
            this.label14.TabIndex = 55;
            this.label14.Text = "Active";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(307, 20);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(18, 17);
            this.chkActive.TabIndex = 54;
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // dtActivationTimeZone
            // 
            this.dtActivationTimeZone.Enabled = false;
            this.dtActivationTimeZone.FormattingEnabled = true;
            this.dtActivationTimeZone.Location = new System.Drawing.Point(307, 82);
            this.dtActivationTimeZone.Name = "dtActivationTimeZone";
            this.dtActivationTimeZone.Size = new System.Drawing.Size(163, 24);
            this.dtActivationTimeZone.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(232, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 52;
            this.label13.Text = "Activation";
            // 
            // dtActivationTS
            // 
            this.dtActivationTS.CustomFormat = "yyyyMMdd HH:mm:ss";
            this.dtActivationTS.Enabled = false;
            this.dtActivationTS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtActivationTS.Location = new System.Drawing.Point(307, 53);
            this.dtActivationTS.Margin = new System.Windows.Forms.Padding(4);
            this.dtActivationTS.Name = "dtActivationTS";
            this.dtActivationTS.Size = new System.Drawing.Size(163, 22);
            this.dtActivationTS.TabIndex = 51;
            // 
            // dtExpirationTimeZone
            // 
            this.dtExpirationTimeZone.FormattingEnabled = true;
            this.dtExpirationTimeZone.Location = new System.Drawing.Point(552, 82);
            this.dtExpirationTimeZone.Name = "dtExpirationTimeZone";
            this.dtExpirationTimeZone.Size = new System.Drawing.Size(156, 24);
            this.dtExpirationTimeZone.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(477, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 57;
            this.label8.Text = "Expiration";
            // 
            // dtExpirationTS
            // 
            this.dtExpirationTS.CustomFormat = "yyyyMMdd HH:mm:ss";
            this.dtExpirationTS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpirationTS.Location = new System.Drawing.Point(552, 53);
            this.dtExpirationTS.Margin = new System.Windows.Forms.Padding(4);
            this.dtExpirationTS.Name = "dtExpirationTS";
            this.dtExpirationTS.Size = new System.Drawing.Size(156, 22);
            this.dtExpirationTS.TabIndex = 56;
            // 
            // cmbTIF
            // 
            this.cmbTIF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTIF.FormattingEnabled = true;
            this.cmbTIF.Location = new System.Drawing.Point(390, 22);
            this.cmbTIF.Name = "cmbTIF";
            this.cmbTIF.Size = new System.Drawing.Size(136, 24);
            this.cmbTIF.TabIndex = 60;
            this.cmbTIF.SelectedIndexChanged += new System.EventHandler(this.cmbTIF_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 59;
            this.label6.Text = "TIF";
            // 
            // legOrderCtrl3
            // 
            this.legOrderCtrl3.Enabled = false;
            this.legOrderCtrl3.Location = new System.Drawing.Point(6, 30);
            this.legOrderCtrl3.Name = "legOrderCtrl3";
            this.legOrderCtrl3.Side = "";
            this.legOrderCtrl3.Size = new System.Drawing.Size(266, 500);
            this.legOrderCtrl3.TabIndex = 1;
            // 
            // legOrderCtrl2
            // 
            this.legOrderCtrl2.Enabled = false;
            this.legOrderCtrl2.Location = new System.Drawing.Point(0, 30);
            this.legOrderCtrl2.Name = "legOrderCtrl2";
            this.legOrderCtrl2.Side = "";
            this.legOrderCtrl2.Size = new System.Drawing.Size(266, 500);
            this.legOrderCtrl2.TabIndex = 1;
            // 
            // legOrderCtrl1
            // 
            this.legOrderCtrl1.Enabled = false;
            this.legOrderCtrl1.Location = new System.Drawing.Point(6, 30);
            this.legOrderCtrl1.Name = "legOrderCtrl1";
            this.legOrderCtrl1.Side = "";
            this.legOrderCtrl1.Size = new System.Drawing.Size(266, 500);
            this.legOrderCtrl1.TabIndex = 0;
            // 
            // NewMultiLegOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(918, 744);
            this.Controls.Add(this.cmbTIF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtExpirationTimeZone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtExpirationTS);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.dtActivationTimeZone);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtActivationTS);
            this.Controls.Add(this.chkAlertSMS);
            this.Controls.Add(this.chkAlertEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpLeg3);
            this.Controls.Add(this.grpLeg2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.grpLeg1);
            this.Controls.Add(this.cmbMultiLegOrderType);
            this.Controls.Add(this.label11);
            this.Name = "NewMultiLegOrderForm";
            this.Text = "New multi-leg non-quoted order";
            this.Load += new System.EventHandler(this.NewMultiLegOrderForm_Load);
            this.grpLeg1.ResumeLayout(false);
            this.grpLeg2.ResumeLayout(false);
            this.grpLeg3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMultiLegOrderType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpLeg1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button txtSend;
        private System.Windows.Forms.GroupBox grpLeg2;
        private System.Windows.Forms.GroupBox grpLeg3;
        private FXPricingControl.LegOrderCtrl legOrderCtrl1;
        private FXPricingControl.LegOrderCtrl legOrderCtrl2;
        private FXPricingControl.LegOrderCtrl legOrderCtrl3;
        private System.Windows.Forms.CheckBox chkAlertSMS;
        private System.Windows.Forms.CheckBox chkAlertEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ComboBox dtActivationTimeZone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtActivationTS;
        private System.Windows.Forms.ComboBox dtExpirationTimeZone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtExpirationTS;
        private System.Windows.Forms.ComboBox cmbTIF;
        private System.Windows.Forms.Label label6;
    }
}