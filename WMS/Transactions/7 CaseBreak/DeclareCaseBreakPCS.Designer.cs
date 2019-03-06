namespace WMS
{
    partial class DeclareCaseBreakPCS
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
            this.scanned_grid = new System.Windows.Forms.DataGridView();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUOM = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scanned_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // scanned_grid
            // 
            this.scanned_grid.AllowUserToAddRows = false;
            this.scanned_grid.AllowUserToDeleteRows = false;
            this.scanned_grid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scanned_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.scanned_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scanned_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.qty,
            this.uom,
            this.lot_no,
            this.expiry,
            this.location});
            this.scanned_grid.Location = new System.Drawing.Point(29, 111);
            this.scanned_grid.Margin = new System.Windows.Forms.Padding(2);
            this.scanned_grid.Name = "scanned_grid";
            this.scanned_grid.ReadOnly = true;
            this.scanned_grid.RowTemplate.Height = 28;
            this.scanned_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scanned_grid.Size = new System.Drawing.Size(717, 211);
            this.scanned_grid.TabIndex = 79;
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(334, 14);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(68, 13);
            this.lblProduct.TabIndex = 78;
            this.lblProduct.Text = "<Code here>";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Product:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(29, 337);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 21);
            this.btnSave.TabIndex = 83;
            this.btnSave.Text = "Declare Incomplete";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtScan
            // 
            this.txtScan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtScan.Location = new System.Drawing.Point(97, 56);
            this.txtScan.Margin = new System.Windows.Forms.Padding(2);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(193, 20);
            this.txtScan.TabIndex = 82;
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Scan Item:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 80;
            this.label2.Text = "ITEMS SCANNED";
            // 
            // product
            // 
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.HeaderText = "Quantity";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // uom
            // 
            this.uom.HeaderText = "Uom";
            this.uom.Name = "uom";
            this.uom.ReadOnly = true;
            // 
            // lot_no
            // 
            this.lot_no.HeaderText = "Lot No";
            this.lot_no.Name = "lot_no";
            this.lot_no.ReadOnly = true;
            // 
            // expiry
            // 
            this.expiry.HeaderText = "Expiry";
            this.expiry.Name = "expiry";
            this.expiry.ReadOnly = true;
            // 
            // location
            // 
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // lblUOM
            // 
            this.lblUOM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUOM.AutoSize = true;
            this.lblUOM.Location = new System.Drawing.Point(492, 14);
            this.lblUOM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(68, 13);
            this.lblUOM.TabIndex = 85;
            this.lblUOM.Text = "<Code here>";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(433, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "UOM:";
            // 
            // DeclareCaseBreakPCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 373);
            this.Controls.Add(this.lblUOM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.scanned_grid);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "DeclareCaseBreakPCS";
            this.Text = "DeclareCaseBreakPCS";
            this.Load += new System.EventHandler(this.DeclareCaseBreakPCS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scanned_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView scanned_grid;
        public System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        public System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label label5;
    }
}