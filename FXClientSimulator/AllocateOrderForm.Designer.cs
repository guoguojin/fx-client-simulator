namespace FXClientSimulator
{
    partial class AllocateOrderForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.Button();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSettleDate = new System.Windows.Forms.TextBox();
            this.txtTradeDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAllocID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listAllocations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbAllocSide = new System.Windows.Forms.ComboBox();
            this.btnRemoveNearAllocation = new System.Windows.Forms.Button();
            this.btnAddNearAllocation = new System.Windows.Forms.Button();
            this.txtAllocation = new System.Windows.Forms.TextBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.txtAllocAvgPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSide = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.txrOrderAmount = new System.Windows.Forms.TextBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.listOrders = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(390, 599);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 43);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtSend
            // 
            this.txtSend.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txtSend.Location = new System.Drawing.Point(512, 599);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(116, 43);
            this.txtSend.TabIndex = 3;
            this.txtSend.Text = "Send";
            this.txtSend.UseVisualStyleBackColor = true;
            this.txtSend.Click += new System.EventHandler(this.txtSend_Click);
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(120, 12);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(86, 22);
            this.txtSymbol.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Currency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Symbol";
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(120, 41);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(86, 22);
            this.txtCurrency.TabIndex = 35;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 69);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(86, 22);
            this.txtQuantity.TabIndex = 37;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "Quantity";
            // 
            // txtSettleDate
            // 
            this.txtSettleDate.Location = new System.Drawing.Point(329, 70);
            this.txtSettleDate.Name = "txtSettleDate";
            this.txtSettleDate.Size = new System.Drawing.Size(86, 22);
            this.txtSettleDate.TabIndex = 43;
            // 
            // txtTradeDate
            // 
            this.txtTradeDate.Location = new System.Drawing.Point(329, 41);
            this.txtTradeDate.Name = "txtTradeDate";
            this.txtTradeDate.Size = new System.Drawing.Size(86, 22);
            this.txtTradeDate.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "Settle Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 40;
            this.label7.Text = "Trade Date";
            // 
            // txtAllocID
            // 
            this.txtAllocID.Location = new System.Drawing.Point(120, 98);
            this.txtAllocID.Name = "txtAllocID";
            this.txtAllocID.Size = new System.Drawing.Size(375, 22);
            this.txtAllocID.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Alloc ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listAllocations);
            this.groupBox1.Controls.Add(this.cmbAllocSide);
            this.groupBox1.Controls.Add(this.btnRemoveNearAllocation);
            this.groupBox1.Controls.Add(this.btnAddNearAllocation);
            this.groupBox1.Controls.Add(this.txtAllocation);
            this.groupBox1.Controls.Add(this.cmbAccount);
            this.groupBox1.Location = new System.Drawing.Point(36, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 234);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allocations";
            // 
            // listAllocations
            // 
            this.listAllocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listAllocations.FullRowSelect = true;
            this.listAllocations.Location = new System.Drawing.Point(16, 61);
            this.listAllocations.MultiSelect = false;
            this.listAllocations.Name = "listAllocations";
            this.listAllocations.Size = new System.Drawing.Size(479, 123);
            this.listAllocations.TabIndex = 52;
            this.listAllocations.UseCompatibleStateImageBehavior = false;
            this.listAllocations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Account";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 200;
            // 
            // cmbAllocSide
            // 
            this.cmbAllocSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllocSide.FormattingEnabled = true;
            this.cmbAllocSide.Items.AddRange(new object[] {
            "BUY",
            "SELL"});
            this.cmbAllocSide.Location = new System.Drawing.Point(423, 28);
            this.cmbAllocSide.Name = "cmbAllocSide";
            this.cmbAllocSide.Size = new System.Drawing.Size(72, 24);
            this.cmbAllocSide.TabIndex = 51;
            // 
            // btnRemoveNearAllocation
            // 
            this.btnRemoveNearAllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveNearAllocation.Location = new System.Drawing.Point(505, 88);
            this.btnRemoveNearAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveNearAllocation.Name = "btnRemoveNearAllocation";
            this.btnRemoveNearAllocation.Size = new System.Drawing.Size(87, 55);
            this.btnRemoveNearAllocation.TabIndex = 9;
            this.btnRemoveNearAllocation.Text = "-";
            this.btnRemoveNearAllocation.UseVisualStyleBackColor = true;
            this.btnRemoveNearAllocation.Click += new System.EventHandler(this.btnRemoveNearAllocation_Click);
            // 
            // btnAddNearAllocation
            // 
            this.btnAddNearAllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNearAllocation.Location = new System.Drawing.Point(505, 30);
            this.btnAddNearAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNearAllocation.Name = "btnAddNearAllocation";
            this.btnAddNearAllocation.Size = new System.Drawing.Size(87, 55);
            this.btnAddNearAllocation.TabIndex = 8;
            this.btnAddNearAllocation.Text = "+";
            this.btnAddNearAllocation.UseVisualStyleBackColor = true;
            this.btnAddNearAllocation.Click += new System.EventHandler(this.btnAddNearAllocation_Click);
            // 
            // txtAllocation
            // 
            this.txtAllocation.Location = new System.Drawing.Point(219, 30);
            this.txtAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtAllocation.Name = "txtAllocation";
            this.txtAllocation.Size = new System.Drawing.Size(197, 22);
            this.txtAllocation.TabIndex = 6;
            this.txtAllocation.Text = "Allocation Amount";
            this.txtAllocation.TextChanged += new System.EventHandler(this.txtAllocation_TextChanged);
            // 
            // cmbAccount
            // 
            this.cmbAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(16, 30);
            this.cmbAccount.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(195, 24);
            this.cmbAccount.TabIndex = 5;
            this.cmbAccount.Text = "Account";
            // 
            // txtAllocAvgPrice
            // 
            this.txtAllocAvgPrice.Location = new System.Drawing.Point(329, 127);
            this.txtAllocAvgPrice.Name = "txtAllocAvgPrice";
            this.txtAllocAvgPrice.Size = new System.Drawing.Size(86, 22);
            this.txtAllocAvgPrice.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(249, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 17);
            this.label11.TabIndex = 49;
            this.label11.Text = "Avg Price";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(120, 127);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(86, 22);
            this.txtTotalQty.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "Total Qty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 17);
            this.label9.TabIndex = 47;
            this.label9.Text = "Side";
            // 
            // cmbSide
            // 
            this.cmbSide.FormattingEnabled = true;
            this.cmbSide.Location = new System.Drawing.Point(329, 13);
            this.cmbSide.Name = "cmbSide";
            this.cmbSide.Size = new System.Drawing.Size(86, 24);
            this.cmbSide.TabIndex = 48;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteOrder);
            this.groupBox2.Controls.Add(this.txrOrderAmount);
            this.groupBox2.Controls.Add(this.btnAddOrder);
            this.groupBox2.Controls.Add(this.cmbOrder);
            this.groupBox2.Controls.Add(this.listOrders);
            this.groupBox2.Location = new System.Drawing.Point(36, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 180);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Orders";
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrder.Location = new System.Drawing.Point(505, 80);
            this.btnDeleteOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(87, 55);
            this.btnDeleteOrder.TabIndex = 53;
            this.btnDeleteOrder.Text = "-";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // txrOrderAmount
            // 
            this.txrOrderAmount.Location = new System.Drawing.Point(370, 22);
            this.txrOrderAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txrOrderAmount.Name = "txrOrderAmount";
            this.txrOrderAmount.Size = new System.Drawing.Size(125, 22);
            this.txrOrderAmount.TabIndex = 55;
            this.txrOrderAmount.Text = "Order Amount";
            this.txrOrderAmount.TextChanged += new System.EventHandler(this.txrOrderAmount_TextChanged);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.Location = new System.Drawing.Point(505, 22);
            this.btnAddOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(87, 55);
            this.btnAddOrder.TabIndex = 52;
            this.btnAddOrder.Text = "+";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // cmbOrder
            // 
            this.cmbOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Location = new System.Drawing.Point(16, 22);
            this.cmbOrder.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(346, 24);
            this.cmbOrder.TabIndex = 54;
            this.cmbOrder.Text = "OrderId";
            this.cmbOrder.TextChanged += new System.EventHandler(this.cmbOrder_TextChanged);
            // 
            // listOrders
            // 
            this.listOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listOrders.FullRowSelect = true;
            this.listOrders.Location = new System.Drawing.Point(16, 57);
            this.listOrders.MultiSelect = false;
            this.listOrders.Name = "listOrders";
            this.listOrders.Size = new System.Drawing.Size(479, 117);
            this.listOrders.TabIndex = 53;
            this.listOrders.UseCompatibleStateImageBehavior = false;
            this.listOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            this.columnHeader3.Width = 350;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantity";
            this.columnHeader4.Width = 125;
            // 
            // AllocateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(675, 662);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmbSide);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAllocAvgPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.txtAllocID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSettleDate);
            this.Controls.Add(this.txtTradeDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSend);
            this.Name = "AllocateOrderForm";
            this.Text = "Allocate Order";
            this.Load += new System.EventHandler(this.AllocateOrderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button txtSend;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSettleDate;
        private System.Windows.Forms.TextBox txtTradeDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAllocID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveNearAllocation;
        private System.Windows.Forms.Button btnAddNearAllocation;
        private System.Windows.Forms.TextBox txtAllocation;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSide;
        private System.Windows.Forms.TextBox txtAllocAvgPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView listAllocations;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox cmbAllocSide;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.TextBox txrOrderAmount;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.ComboBox cmbOrder;
        private System.Windows.Forms.ListView listOrders;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}