namespace WMS
{
    partial class NewBadStockDetailWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.ComboBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtUom = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtBadStockStorage = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Uom:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Qty:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Expiry:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lot No:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "What makes it a bad stock?";
            // 
            // txtLocation
            // 
            this.txtLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLocation.FormattingEnabled = true;
            this.txtLocation.Location = new System.Drawing.Point(158, 21);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(144, 28);
            this.txtLocation.TabIndex = 7;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(158, 103);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.ReadOnly = true;
            this.txtProduct.Size = new System.Drawing.Size(144, 26);
            this.txtProduct.TabIndex = 8;
            this.txtProduct.TabStop = false;
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(158, 171);
            this.txtUom.Name = "txtUom";
            this.txtUom.ReadOnly = true;
            this.txtUom.Size = new System.Drawing.Size(144, 26);
            this.txtUom.TabIndex = 9;
            this.txtUom.TabStop = false;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(158, 273);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(144, 26);
            this.txtQty.TabIndex = 10;
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(158, 205);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.ReadOnly = true;
            this.txtLotNo.Size = new System.Drawing.Size(144, 26);
            this.txtLotNo.TabIndex = 11;
            this.txtLotNo.TabStop = false;
            // 
            // txtExpiry
            // 
            this.txtExpiry.Location = new System.Drawing.Point(158, 239);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.ReadOnly = true;
            this.txtExpiry.Size = new System.Drawing.Size(144, 26);
            this.txtExpiry.TabIndex = 12;
            this.txtExpiry.TabStop = false;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(59, 400);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(439, 151);
            this.txtReason.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cyan;
            this.btnAdd.Location = new System.Drawing.Point(59, 572);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 34);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.Lime;
            this.btnAddProduct.Location = new System.Drawing.Point(158, 55);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(254, 36);
            this.btnAddProduct.TabIndex = 15;
            this.btnAddProduct.Text = "Add Product From Location";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(158, 137);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(363, 26);
            this.txtDescription.TabIndex = 16;
            this.txtDescription.TabStop = false;
            // 
            // txtBadStockStorage
            // 
            this.txtBadStockStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBadStockStorage.FormattingEnabled = true;
            this.txtBadStockStorage.Location = new System.Drawing.Point(158, 314);
            this.txtBadStockStorage.Name = "txtBadStockStorage";
            this.txtBadStockStorage.Size = new System.Drawing.Size(144, 28);
            this.txtBadStockStorage.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "Bad Stock Storage:";
            // 
            // NewBadStockDetailWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 632);
            this.Controls.Add(this.txtBadStockStorage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.txtExpiry);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtUom);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewBadStockDetailWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Bad Stock Detail...";
            this.Load += new System.EventHandler(this.NewBadStockDetailWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddProduct;
        public System.Windows.Forms.ComboBox txtLocation;
        public System.Windows.Forms.TextBox txtProduct;
        public System.Windows.Forms.TextBox txtUom;
        public System.Windows.Forms.TextBox txtQty;
        public System.Windows.Forms.TextBox txtLotNo;
        public System.Windows.Forms.TextBox txtExpiry;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtReason;
        public System.Windows.Forms.ComboBox txtBadStockStorage;
        private System.Windows.Forms.Label label8;
    }
}