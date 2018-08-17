namespace FXClientSimulator {
    partial class EditConnectionForm {
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
            System.Windows.Forms.Label lblTargetIdRFQ;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabConnections = new System.Windows.Forms.TabControl();
            this.tabMarketData = new System.Windows.Forms.TabPage();
            this.txtTargetIdMD = new System.Windows.Forms.TextBox();
            this.lblTargetIdMD = new System.Windows.Forms.Label();
            this.txtSenderIdMD = new System.Windows.Forms.TextBox();
            this.lblSenderIdMD = new System.Windows.Forms.Label();
            this.txtFixPortMD = new System.Windows.Forms.TextBox();
            this.lblFixPortMD = new System.Windows.Forms.Label();
            this.txtFixHostMD = new System.Windows.Forms.TextBox();
            this.lblFixHostMD = new System.Windows.Forms.Label();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.txtTargetIdTD = new System.Windows.Forms.TextBox();
            this.lblTargetIdTD = new System.Windows.Forms.Label();
            this.txtSenderIdTD = new System.Windows.Forms.TextBox();
            this.lblSenderIdTD = new System.Windows.Forms.Label();
            this.txtFixPortTD = new System.Windows.Forms.TextBox();
            this.lblFixPortTD = new System.Windows.Forms.Label();
            this.txtFixHostTD = new System.Windows.Forms.TextBox();
            this.lblFixHostTD = new System.Windows.Forms.Label();
            this.tabRFQ = new System.Windows.Forms.TabPage();
            this.txtTargetIdRFQ = new System.Windows.Forms.TextBox();
            this.txtSenderIdRFQ = new System.Windows.Forms.TextBox();
            this.lblSenderIdRFQ = new System.Windows.Forms.Label();
            this.txtFixPortRFQ = new System.Windows.Forms.TextBox();
            this.lblFixPortRFQ = new System.Windows.Forms.Label();
            this.txtFixHostRFQ = new System.Windows.Forms.TextBox();
            this.lblFixHostRFQ = new System.Windows.Forms.Label();
            this.chkAutoConnect = new System.Windows.Forms.CheckBox();
            this.txtOnBehalfOf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            lblTargetIdRFQ = new System.Windows.Forms.Label();
            this.tabConnections.SuspendLayout();
            this.tabMarketData.SuspendLayout();
            this.tabOrders.SuspendLayout();
            this.tabRFQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTargetIdRFQ
            // 
            lblTargetIdRFQ.AutoSize = true;
            lblTargetIdRFQ.Location = new System.Drawing.Point(12, 111);
            lblTargetIdRFQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTargetIdRFQ.Name = "lblTargetIdRFQ";
            lblTargetIdRFQ.Size = new System.Drawing.Size(65, 17);
            lblTargetIdRFQ.TabIndex = 22;
            lblTargetIdRFQ.Text = "Target Id";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(6, 251);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(204, 251);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // tabConnections
            // 
            this.tabConnections.Controls.Add(this.tabMarketData);
            this.tabConnections.Controls.Add(this.tabOrders);
            this.tabConnections.Controls.Add(this.tabRFQ);
            this.tabConnections.Location = new System.Drawing.Point(0, 0);
            this.tabConnections.Margin = new System.Windows.Forms.Padding(4);
            this.tabConnections.Name = "tabConnections";
            this.tabConnections.SelectedIndex = 0;
            this.tabConnections.Size = new System.Drawing.Size(308, 175);
            this.tabConnections.TabIndex = 10;
            // 
            // tabMarketData
            // 
            this.tabMarketData.Controls.Add(this.txtTargetIdMD);
            this.tabMarketData.Controls.Add(this.lblTargetIdMD);
            this.tabMarketData.Controls.Add(this.txtSenderIdMD);
            this.tabMarketData.Controls.Add(this.lblSenderIdMD);
            this.tabMarketData.Controls.Add(this.txtFixPortMD);
            this.tabMarketData.Controls.Add(this.lblFixPortMD);
            this.tabMarketData.Controls.Add(this.txtFixHostMD);
            this.tabMarketData.Controls.Add(this.lblFixHostMD);
            this.tabMarketData.Location = new System.Drawing.Point(4, 25);
            this.tabMarketData.Margin = new System.Windows.Forms.Padding(4);
            this.tabMarketData.Name = "tabMarketData";
            this.tabMarketData.Padding = new System.Windows.Forms.Padding(4);
            this.tabMarketData.Size = new System.Drawing.Size(300, 146);
            this.tabMarketData.TabIndex = 0;
            this.tabMarketData.Text = "Market Data";
            this.tabMarketData.UseVisualStyleBackColor = true;
            // 
            // txtTargetIdMD
            // 
            this.txtTargetIdMD.Location = new System.Drawing.Point(101, 107);
            this.txtTargetIdMD.Margin = new System.Windows.Forms.Padding(4);
            this.txtTargetIdMD.Name = "txtTargetIdMD";
            this.txtTargetIdMD.Size = new System.Drawing.Size(183, 22);
            this.txtTargetIdMD.TabIndex = 15;
            this.txtTargetIdMD.Click += new System.EventHandler(this.TxtTargetIdMDClick);
            this.txtTargetIdMD.Enter += new System.EventHandler(this.TxtTargetIdMDEnter);
            this.txtTargetIdMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTargetIdMDKeyPress);
            this.txtTargetIdMD.Leave += new System.EventHandler(this.TxtTargetIdMDLeave);
            // 
            // lblTargetIdMD
            // 
            this.lblTargetIdMD.AutoSize = true;
            this.lblTargetIdMD.Location = new System.Drawing.Point(12, 111);
            this.lblTargetIdMD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetIdMD.Name = "lblTargetIdMD";
            this.lblTargetIdMD.Size = new System.Drawing.Size(65, 17);
            this.lblTargetIdMD.TabIndex = 14;
            this.lblTargetIdMD.Text = "Target Id";
            // 
            // txtSenderIdMD
            // 
            this.txtSenderIdMD.Location = new System.Drawing.Point(101, 75);
            this.txtSenderIdMD.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenderIdMD.Name = "txtSenderIdMD";
            this.txtSenderIdMD.Size = new System.Drawing.Size(183, 22);
            this.txtSenderIdMD.TabIndex = 13;
            this.txtSenderIdMD.Click += new System.EventHandler(this.TxtSenderIdMDClick);
            this.txtSenderIdMD.Enter += new System.EventHandler(this.TxtSenderIdMDEnter);
            this.txtSenderIdMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSenderIdMDKeyPress);
            this.txtSenderIdMD.Leave += new System.EventHandler(this.TxtSenderIdMDLeave);
            // 
            // lblSenderIdMD
            // 
            this.lblSenderIdMD.AutoSize = true;
            this.lblSenderIdMD.Location = new System.Drawing.Point(12, 79);
            this.lblSenderIdMD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenderIdMD.Name = "lblSenderIdMD";
            this.lblSenderIdMD.Size = new System.Drawing.Size(69, 17);
            this.lblSenderIdMD.TabIndex = 12;
            this.lblSenderIdMD.Text = "Sender Id";
            // 
            // txtFixPortMD
            // 
            this.txtFixPortMD.Location = new System.Drawing.Point(101, 43);
            this.txtFixPortMD.Margin = new System.Windows.Forms.Padding(4);
            this.txtFixPortMD.Name = "txtFixPortMD";
            this.txtFixPortMD.Size = new System.Drawing.Size(183, 22);
            this.txtFixPortMD.TabIndex = 11;
            this.txtFixPortMD.Click += new System.EventHandler(this.TxtFixPortMDClick);
            this.txtFixPortMD.Enter += new System.EventHandler(this.TxtFixPortMDEnter);
            this.txtFixPortMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFixPortMDKeyPress);
            this.txtFixPortMD.Leave += new System.EventHandler(this.TxtFixPortMDLeave);
            // 
            // lblFixPortMD
            // 
            this.lblFixPortMD.AutoSize = true;
            this.lblFixPortMD.Location = new System.Drawing.Point(12, 48);
            this.lblFixPortMD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixPortMD.Name = "lblFixPortMD";
            this.lblFixPortMD.Size = new System.Drawing.Size(55, 17);
            this.lblFixPortMD.TabIndex = 10;
            this.lblFixPortMD.Text = "Fix Port";
            // 
            // txtFixHostMD
            // 
            this.txtFixHostMD.Location = new System.Drawing.Point(101, 11);
            this.txtFixHostMD.Margin = new System.Windows.Forms.Padding(4);
            this.txtFixHostMD.Name = "txtFixHostMD";
            this.txtFixHostMD.Size = new System.Drawing.Size(183, 22);
            this.txtFixHostMD.TabIndex = 9;
            this.txtFixHostMD.Click += new System.EventHandler(this.TxtFixHostMDClick);
            this.txtFixHostMD.Enter += new System.EventHandler(this.TxtFixHostMDEnter);
            this.txtFixHostMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFixHostMDKeyPress);
            this.txtFixHostMD.Leave += new System.EventHandler(this.TxtFixHostMDLeave);
            // 
            // lblFixHostMD
            // 
            this.lblFixHostMD.AutoSize = true;
            this.lblFixHostMD.Location = new System.Drawing.Point(12, 15);
            this.lblFixHostMD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixHostMD.Name = "lblFixHostMD";
            this.lblFixHostMD.Size = new System.Drawing.Size(58, 17);
            this.lblFixHostMD.TabIndex = 8;
            this.lblFixHostMD.Text = "Fix Host";
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.txtTargetIdTD);
            this.tabOrders.Controls.Add(this.lblTargetIdTD);
            this.tabOrders.Controls.Add(this.txtSenderIdTD);
            this.tabOrders.Controls.Add(this.lblSenderIdTD);
            this.tabOrders.Controls.Add(this.txtFixPortTD);
            this.tabOrders.Controls.Add(this.lblFixPortTD);
            this.tabOrders.Controls.Add(this.txtFixHostTD);
            this.tabOrders.Controls.Add(this.lblFixHostTD);
            this.tabOrders.Location = new System.Drawing.Point(4, 25);
            this.tabOrders.Margin = new System.Windows.Forms.Padding(4);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(4);
            this.tabOrders.Size = new System.Drawing.Size(300, 146);
            this.tabOrders.TabIndex = 1;
            this.tabOrders.Text = "Orders";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // txtTargetIdTD
            // 
            this.txtTargetIdTD.Location = new System.Drawing.Point(101, 107);
            this.txtTargetIdTD.Margin = new System.Windows.Forms.Padding(4);
            this.txtTargetIdTD.Name = "txtTargetIdTD";
            this.txtTargetIdTD.Size = new System.Drawing.Size(183, 22);
            this.txtTargetIdTD.TabIndex = 23;
            this.txtTargetIdTD.Click += new System.EventHandler(this.TxtTargetIdTDClick);
            this.txtTargetIdTD.Enter += new System.EventHandler(this.TxtTargetIdTDEnter);
            this.txtTargetIdTD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTargetIdTDKeyPress);
            this.txtTargetIdTD.Leave += new System.EventHandler(this.TxtTargetIdTDLeave);
            // 
            // lblTargetIdTD
            // 
            this.lblTargetIdTD.AutoSize = true;
            this.lblTargetIdTD.Location = new System.Drawing.Point(12, 111);
            this.lblTargetIdTD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetIdTD.Name = "lblTargetIdTD";
            this.lblTargetIdTD.Size = new System.Drawing.Size(65, 17);
            this.lblTargetIdTD.TabIndex = 22;
            this.lblTargetIdTD.Text = "Target Id";
            // 
            // txtSenderIdTD
            // 
            this.txtSenderIdTD.Location = new System.Drawing.Point(101, 75);
            this.txtSenderIdTD.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenderIdTD.Name = "txtSenderIdTD";
            this.txtSenderIdTD.Size = new System.Drawing.Size(183, 22);
            this.txtSenderIdTD.TabIndex = 21;
            this.txtSenderIdTD.Click += new System.EventHandler(this.TxtSenderIdTDClick);
            this.txtSenderIdTD.Enter += new System.EventHandler(this.TxtSenderIdTDEnter);
            this.txtSenderIdTD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSenderIdTDKeyPress);
            this.txtSenderIdTD.Leave += new System.EventHandler(this.TxtSenderIdTDLeave);
            // 
            // lblSenderIdTD
            // 
            this.lblSenderIdTD.AutoSize = true;
            this.lblSenderIdTD.Location = new System.Drawing.Point(12, 79);
            this.lblSenderIdTD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenderIdTD.Name = "lblSenderIdTD";
            this.lblSenderIdTD.Size = new System.Drawing.Size(69, 17);
            this.lblSenderIdTD.TabIndex = 20;
            this.lblSenderIdTD.Text = "Sender Id";
            // 
            // txtFixPortTD
            // 
            this.txtFixPortTD.Location = new System.Drawing.Point(101, 43);
            this.txtFixPortTD.Margin = new System.Windows.Forms.Padding(4);
            this.txtFixPortTD.Name = "txtFixPortTD";
            this.txtFixPortTD.Size = new System.Drawing.Size(183, 22);
            this.txtFixPortTD.TabIndex = 19;
            this.txtFixPortTD.Click += new System.EventHandler(this.TxtFixPortTDClick);
            this.txtFixPortTD.Enter += new System.EventHandler(this.TxtFixPortTDEnter);
            this.txtFixPortTD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFixPortTDKeyPress);
            this.txtFixPortTD.Leave += new System.EventHandler(this.TxtFixPortTDLeave);
            // 
            // lblFixPortTD
            // 
            this.lblFixPortTD.AutoSize = true;
            this.lblFixPortTD.Location = new System.Drawing.Point(12, 48);
            this.lblFixPortTD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixPortTD.Name = "lblFixPortTD";
            this.lblFixPortTD.Size = new System.Drawing.Size(55, 17);
            this.lblFixPortTD.TabIndex = 18;
            this.lblFixPortTD.Text = "Fix Port";
            // 
            // txtFixHostTD
            // 
            this.txtFixHostTD.Location = new System.Drawing.Point(101, 11);
            this.txtFixHostTD.Margin = new System.Windows.Forms.Padding(4);
            this.txtFixHostTD.Name = "txtFixHostTD";
            this.txtFixHostTD.Size = new System.Drawing.Size(183, 22);
            this.txtFixHostTD.TabIndex = 17;
            this.txtFixHostTD.Click += new System.EventHandler(this.TxtFixHostTDClick);
            this.txtFixHostTD.Enter += new System.EventHandler(this.TxtFixHostTDEnter);
            this.txtFixHostTD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFixHostTDKeyPress);
            this.txtFixHostTD.Leave += new System.EventHandler(this.TxtFixHostTDLeave);
            // 
            // lblFixHostTD
            // 
            this.lblFixHostTD.AutoSize = true;
            this.lblFixHostTD.Location = new System.Drawing.Point(12, 15);
            this.lblFixHostTD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixHostTD.Name = "lblFixHostTD";
            this.lblFixHostTD.Size = new System.Drawing.Size(58, 17);
            this.lblFixHostTD.TabIndex = 16;
            this.lblFixHostTD.Text = "Fix Host";
            // 
            // tabRFQ
            // 
            this.tabRFQ.Controls.Add(this.txtTargetIdRFQ);
            this.tabRFQ.Controls.Add(lblTargetIdRFQ);
            this.tabRFQ.Controls.Add(this.txtSenderIdRFQ);
            this.tabRFQ.Controls.Add(this.lblSenderIdRFQ);
            this.tabRFQ.Controls.Add(this.txtFixPortRFQ);
            this.tabRFQ.Controls.Add(this.lblFixPortRFQ);
            this.tabRFQ.Controls.Add(this.txtFixHostRFQ);
            this.tabRFQ.Controls.Add(this.lblFixHostRFQ);
            this.tabRFQ.Location = new System.Drawing.Point(4, 25);
            this.tabRFQ.Margin = new System.Windows.Forms.Padding(4);
            this.tabRFQ.Name = "tabRFQ";
            this.tabRFQ.Padding = new System.Windows.Forms.Padding(4);
            this.tabRFQ.Size = new System.Drawing.Size(300, 146);
            this.tabRFQ.TabIndex = 2;
            this.tabRFQ.Text = "RFQ";
            this.tabRFQ.UseVisualStyleBackColor = true;
            // 
            // txtTargetIdRFQ
            // 
            this.txtTargetIdRFQ.Location = new System.Drawing.Point(101, 107);
            this.txtTargetIdRFQ.Margin = new System.Windows.Forms.Padding(4);
            this.txtTargetIdRFQ.Name = "txtTargetIdRFQ";
            this.txtTargetIdRFQ.Size = new System.Drawing.Size(183, 22);
            this.txtTargetIdRFQ.TabIndex = 23;
            this.txtTargetIdRFQ.Click += new System.EventHandler(this.TxtTargetIdRFQClick);
            this.txtTargetIdRFQ.Enter += new System.EventHandler(this.TxtTargetIdRFQEnter);
            this.txtTargetIdRFQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTargetIdRFQKeyPress);
            this.txtTargetIdRFQ.Leave += new System.EventHandler(this.TxtTargetIdRFQLeave);
            // 
            // txtSenderIdRFQ
            // 
            this.txtSenderIdRFQ.Location = new System.Drawing.Point(101, 75);
            this.txtSenderIdRFQ.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenderIdRFQ.Name = "txtSenderIdRFQ";
            this.txtSenderIdRFQ.Size = new System.Drawing.Size(183, 22);
            this.txtSenderIdRFQ.TabIndex = 21;
            this.txtSenderIdRFQ.Click += new System.EventHandler(this.TxtSenderIdRFQClick);
            this.txtSenderIdRFQ.Enter += new System.EventHandler(this.TxtSenderIdRFQEnter);
            this.txtSenderIdRFQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSenderIdRFQKeyPress);
            this.txtSenderIdRFQ.Leave += new System.EventHandler(this.TxtSenderIdRFQLeave);
            // 
            // lblSenderIdRFQ
            // 
            this.lblSenderIdRFQ.AutoSize = true;
            this.lblSenderIdRFQ.Location = new System.Drawing.Point(12, 79);
            this.lblSenderIdRFQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenderIdRFQ.Name = "lblSenderIdRFQ";
            this.lblSenderIdRFQ.Size = new System.Drawing.Size(69, 17);
            this.lblSenderIdRFQ.TabIndex = 20;
            this.lblSenderIdRFQ.Text = "Sender Id";
            // 
            // txtFixPortRFQ
            // 
            this.txtFixPortRFQ.Location = new System.Drawing.Point(101, 43);
            this.txtFixPortRFQ.Margin = new System.Windows.Forms.Padding(4);
            this.txtFixPortRFQ.Name = "txtFixPortRFQ";
            this.txtFixPortRFQ.Size = new System.Drawing.Size(183, 22);
            this.txtFixPortRFQ.TabIndex = 19;
            this.txtFixPortRFQ.Click += new System.EventHandler(this.TxtFixPortRFQClick);
            this.txtFixPortRFQ.Enter += new System.EventHandler(this.TxtFixPortRFQEnter);
            this.txtFixPortRFQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFixPortRFQKeyPress);
            this.txtFixPortRFQ.Leave += new System.EventHandler(this.TxtFixPortRFQLeave);
            // 
            // lblFixPortRFQ
            // 
            this.lblFixPortRFQ.AutoSize = true;
            this.lblFixPortRFQ.Location = new System.Drawing.Point(12, 48);
            this.lblFixPortRFQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixPortRFQ.Name = "lblFixPortRFQ";
            this.lblFixPortRFQ.Size = new System.Drawing.Size(55, 17);
            this.lblFixPortRFQ.TabIndex = 18;
            this.lblFixPortRFQ.Text = "Fix Port";
            // 
            // txtFixHostRFQ
            // 
            this.txtFixHostRFQ.Location = new System.Drawing.Point(101, 11);
            this.txtFixHostRFQ.Margin = new System.Windows.Forms.Padding(4);
            this.txtFixHostRFQ.Name = "txtFixHostRFQ";
            this.txtFixHostRFQ.Size = new System.Drawing.Size(183, 22);
            this.txtFixHostRFQ.TabIndex = 17;
            this.txtFixHostRFQ.Click += new System.EventHandler(this.TxtFixHostRFQClick);
            this.txtFixHostRFQ.Enter += new System.EventHandler(this.TxtFixHostRFQEnter);
            this.txtFixHostRFQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFixHostRFQKeyPress);
            this.txtFixHostRFQ.Leave += new System.EventHandler(this.TxtFixHostRFQLeave);
            // 
            // lblFixHostRFQ
            // 
            this.lblFixHostRFQ.AutoSize = true;
            this.lblFixHostRFQ.Location = new System.Drawing.Point(12, 15);
            this.lblFixHostRFQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixHostRFQ.Name = "lblFixHostRFQ";
            this.lblFixHostRFQ.Size = new System.Drawing.Size(58, 17);
            this.lblFixHostRFQ.TabIndex = 16;
            this.lblFixHostRFQ.Text = "Fix Host";
            // 
            // chkAutoConnect
            // 
            this.chkAutoConnect.AutoSize = true;
            this.chkAutoConnect.Location = new System.Drawing.Point(6, 182);
            this.chkAutoConnect.Name = "chkAutoConnect";
            this.chkAutoConnect.Size = new System.Drawing.Size(235, 21);
            this.chkAutoConnect.TabIndex = 11;
            this.chkAutoConnect.Text = "Automatically connect on startup";
            this.chkAutoConnect.UseVisualStyleBackColor = true;
            // 
            // txtOnBehalfOf
            // 
            this.txtOnBehalfOf.Location = new System.Drawing.Point(105, 210);
            this.txtOnBehalfOf.Margin = new System.Windows.Forms.Padding(4);
            this.txtOnBehalfOf.Name = "txtOnBehalfOf";
            this.txtOnBehalfOf.Size = new System.Drawing.Size(199, 22);
            this.txtOnBehalfOf.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 214);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "On behalf of";
            // 
            // EditConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 292);
            this.Controls.Add(this.txtOnBehalfOf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAutoConnect);
            this.Controls.Add(this.tabConnections);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(327, 217);
            this.Name = "EditConnectionForm";
            this.Text = "Edit Connections";
            this.Load += new System.EventHandler(this.EditConnectionFormLoad);
            this.tabConnections.ResumeLayout(false);
            this.tabMarketData.ResumeLayout(false);
            this.tabMarketData.PerformLayout();
            this.tabOrders.ResumeLayout(false);
            this.tabOrders.PerformLayout();
            this.tabRFQ.ResumeLayout(false);
            this.tabRFQ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabConnections;
        private System.Windows.Forms.TabPage tabMarketData;
        private System.Windows.Forms.TextBox txtTargetIdMD;
        private System.Windows.Forms.Label lblTargetIdMD;
        private System.Windows.Forms.TextBox txtSenderIdMD;
        private System.Windows.Forms.Label lblSenderIdMD;
        private System.Windows.Forms.TextBox txtFixPortMD;
        private System.Windows.Forms.Label lblFixPortMD;
        private System.Windows.Forms.TextBox txtFixHostMD;
        private System.Windows.Forms.Label lblFixHostMD;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TextBox txtTargetIdTD;
        private System.Windows.Forms.Label lblTargetIdTD;
        private System.Windows.Forms.TextBox txtSenderIdTD;
        private System.Windows.Forms.Label lblSenderIdTD;
        private System.Windows.Forms.TextBox txtFixPortTD;
        private System.Windows.Forms.Label lblFixPortTD;
        private System.Windows.Forms.TextBox txtFixHostTD;
        private System.Windows.Forms.Label lblFixHostTD;
        private System.Windows.Forms.TabPage tabRFQ;
        private System.Windows.Forms.TextBox txtTargetIdRFQ;
        private System.Windows.Forms.TextBox txtSenderIdRFQ;
        private System.Windows.Forms.Label lblSenderIdRFQ;
        private System.Windows.Forms.TextBox txtFixPortRFQ;
        private System.Windows.Forms.Label lblFixPortRFQ;
        private System.Windows.Forms.TextBox txtFixHostRFQ;
        private System.Windows.Forms.Label lblFixHostRFQ;
        private System.Windows.Forms.CheckBox chkAutoConnect;
        private System.Windows.Forms.TextBox txtOnBehalfOf;
        private System.Windows.Forms.Label label1;
    }
}