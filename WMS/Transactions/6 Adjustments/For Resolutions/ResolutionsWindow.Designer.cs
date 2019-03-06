namespace WMS
{
    partial class ResolutionsWindow
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDetected = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVarianceType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUnresolvedQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.header_grid = new System.Windows.Forms.DataGridView();
            this.btnResolve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Document:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detected On:";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(583, 17);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(149, 26);
            this.txtSource.TabIndex = 2;
            // 
            // txtDetected
            // 
            this.txtDetected.Location = new System.Drawing.Point(583, 49);
            this.txtDetected.Name = "txtDetected";
            this.txtDetected.ReadOnly = true;
            this.txtDetected.Size = new System.Drawing.Size(149, 26);
            this.txtDetected.TabIndex = 3;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(99, 14);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.ReadOnly = true;
            this.txtProduct.Size = new System.Drawing.Size(149, 26);
            this.txtProduct.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Product:";
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(99, 48);
            this.txtUom.Name = "txtUom";
            this.txtUom.ReadOnly = true;
            this.txtUom.Size = new System.Drawing.Size(104, 26);
            this.txtUom.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Uom:";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(99, 80);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.ReadOnly = true;
            this.txtLotNo.Size = new System.Drawing.Size(149, 26);
            this.txtLotNo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lot No:";
            // 
            // txtExpiry
            // 
            this.txtExpiry.Location = new System.Drawing.Point(99, 112);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.ReadOnly = true;
            this.txtExpiry.Size = new System.Drawing.Size(149, 26);
            this.txtExpiry.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Expiry:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(99, 144);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(149, 26);
            this.txtLocation.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Location:";
            // 
            // txtVarianceType
            // 
            this.txtVarianceType.Location = new System.Drawing.Point(583, 101);
            this.txtVarianceType.Name = "txtVarianceType";
            this.txtVarianceType.ReadOnly = true;
            this.txtVarianceType.Size = new System.Drawing.Size(149, 26);
            this.txtVarianceType.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Variance Type:";
            // 
            // txtUnresolvedQty
            // 
            this.txtUnresolvedQty.BackColor = System.Drawing.Color.Red;
            this.txtUnresolvedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnresolvedQty.ForeColor = System.Drawing.Color.White;
            this.txtUnresolvedQty.Location = new System.Drawing.Point(583, 133);
            this.txtUnresolvedQty.Name = "txtUnresolvedQty";
            this.txtUnresolvedQty.ReadOnly = true;
            this.txtUnresolvedQty.Size = new System.Drawing.Size(93, 35);
            this.txtUnresolvedQty.TabIndex = 17;
            this.txtUnresolvedQty.Text = "10";
            this.txtUnresolvedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(457, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Unresolved Qty:";
            // 
            // header_grid
            // 
            this.header_grid.AllowUserToAddRows = false;
            this.header_grid.AllowUserToDeleteRows = false;
            this.header_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.header_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.header_grid.Location = new System.Drawing.Point(29, 225);
            this.header_grid.Name = "header_grid";
            this.header_grid.ReadOnly = true;
            this.header_grid.RowTemplate.Height = 28;
            this.header_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.header_grid.Size = new System.Drawing.Size(703, 261);
            this.header_grid.TabIndex = 18;
            // 
            // btnResolve
            // 
            this.btnResolve.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnResolve.Location = new System.Drawing.Point(23, 189);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(225, 30);
            this.btnResolve.TabIndex = 19;
            this.btnResolve.Text = "Add Resolution";
            this.btnResolve.UseVisualStyleBackColor = false;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // ResolutionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 498);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.header_grid);
            this.Controls.Add(this.txtUnresolvedQty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVarianceType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtExpiry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDetected);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ResolutionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resolutions For...";
            this.Load += new System.EventHandler(this.ResolutionsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).EndInit();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DataGridView header_grid;
        private System.Windows.Forms.Button btnResolve;
        public System.Windows.Forms.TextBox txtSource;
        public System.Windows.Forms.TextBox txtDetected;
        public System.Windows.Forms.TextBox txtProduct;
        public System.Windows.Forms.TextBox txtUom;
        public System.Windows.Forms.TextBox txtLotNo;
        public System.Windows.Forms.TextBox txtExpiry;
        public System.Windows.Forms.TextBox txtLocation;
        public System.Windows.Forms.TextBox txtVarianceType;
        public System.Windows.Forms.TextBox txtUnresolvedQty;
    }
}