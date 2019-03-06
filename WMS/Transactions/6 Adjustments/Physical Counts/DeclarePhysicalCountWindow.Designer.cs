namespace WMS
{
    partial class DeclarePhysicalCountWindow
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
            this.header_grid = new System.Windows.Forms.DataGridView();
            this.btnDeclareUnexpectedProduct = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).BeginInit();
            this.SuspendLayout();
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
            this.header_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.location,
            this.product,
            this.uom,
            this.lot_no,
            this.Expiry,
            this.actual_qty,
            this.expected});
            this.header_grid.Location = new System.Drawing.Point(23, 77);
            this.header_grid.Name = "header_grid";
            this.header_grid.RowTemplate.Height = 28;
            this.header_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.header_grid.Size = new System.Drawing.Size(923, 504);
            this.header_grid.TabIndex = 2;
            // 
            // btnDeclareUnexpectedProduct
            // 
            this.btnDeclareUnexpectedProduct.BackColor = System.Drawing.Color.Cyan;
            this.btnDeclareUnexpectedProduct.Location = new System.Drawing.Point(23, 36);
            this.btnDeclareUnexpectedProduct.Name = "btnDeclareUnexpectedProduct";
            this.btnDeclareUnexpectedProduct.Size = new System.Drawing.Size(222, 35);
            this.btnDeclareUnexpectedProduct.TabIndex = 3;
            this.btnDeclareUnexpectedProduct.Text = "Declare Unexpected Product";
            this.btnDeclareUnexpectedProduct.UseVisualStyleBackColor = false;
            this.btnDeclareUnexpectedProduct.Click += new System.EventHandler(this.btnDeclareUnexpectedProduct_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(23, 587);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(207, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Proceed to Print Preview";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // location
            // 
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // product
            // 
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
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
            // 
            // Expiry
            // 
            this.Expiry.HeaderText = "Expiry";
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            // 
            // actual_qty
            // 
            this.actual_qty.HeaderText = "Actual Qty";
            this.actual_qty.Name = "actual_qty";
            // 
            // expected
            // 
            this.expected.HeaderText = "Expected";
            this.expected.Name = "expected";
            this.expected.ReadOnly = true;
            // 
            // DeclarePhysicalCountWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 641);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeclareUnexpectedProduct);
            this.Controls.Add(this.header_grid);
            this.Name = "DeclarePhysicalCountWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeclarePhysicalCountWindow";
            this.Load += new System.EventHandler(this.DeclarePhysicalCountWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView header_grid;
        private System.Windows.Forms.Button btnDeclareUnexpectedProduct;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn expected;
    }
}