namespace WMS
{
    partial class NewReceiptsDetailWindow
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
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExpiry = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShowProduct = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtUOM = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtProducts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(73, 171);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(315, 20);
            this.txtRemarks.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Remarks:";
            // 
            // txtExpiry
            // 
            this.txtExpiry.Location = new System.Drawing.Point(73, 144);
            this.txtExpiry.Margin = new System.Windows.Forms.Padding(2);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(135, 20);
            this.txtExpiry.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Expiry:";
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(73, 119);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(75, 20);
            this.txtLot.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Lot No:";
            // 
            // lblShowProduct
            // 
            this.lblShowProduct.AutoSize = true;
            this.lblShowProduct.Font = new System.Drawing.Font("Arial Narrow", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowProduct.Location = new System.Drawing.Point(73, 42);
            this.lblShowProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowProduct.Name = "lblShowProduct";
            this.lblShowProduct.Size = new System.Drawing.Size(59, 17);
            this.lblShowProduct.TabIndex = 28;
            this.lblShowProduct.Text = "Show IDs";
            this.lblShowProduct.Click += new System.EventHandler(this.lblShowProduct_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cyan;
            this.btnAdd.Location = new System.Drawing.Point(73, 201);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 33);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtUOM
            // 
            this.txtUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtUOM.FormattingEnabled = true;
            this.txtUOM.Location = new System.Drawing.Point(73, 93);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(134, 21);
            this.txtUOM.TabIndex = 20;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(73, 65);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(75, 20);
            this.txtQty.TabIndex = 19;
            // 
            // txtProducts
            // 
            this.txtProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProducts.FormattingEnabled = true;
            this.txtProducts.Location = new System.Drawing.Point(73, 18);
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(314, 21);
            this.txtProducts.TabIndex = 18;
            this.txtProducts.SelectedIndexChanged += new System.EventHandler(this.txtProducts_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "UOM:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Qty:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Product:";
            // 
            // NewReceiptsDetailWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 242);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtExpiry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblShowProduct);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtUOM);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtProducts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewReceiptsDetailWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Detail...";
            this.Load += new System.EventHandler(this.AddReceiptDetailsWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddReceiptDetailsWindow_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker txtExpiry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblShowProduct;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox txtUOM;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.ComboBox txtProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}