namespace WMS
{
    partial class MissingOrBadGridWindow
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
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.what_happened = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.product,
            this.uom,
            this.lot_no,
            this.expiry,
            this.location,
            this.qty,
            this.what_happened,
            this.remarks});
            this.header_grid.Location = new System.Drawing.Point(12, 37);
            this.header_grid.Name = "header_grid";
            this.header_grid.RowTemplate.Height = 28;
            this.header_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.header_grid.Size = new System.Drawing.Size(1254, 465);
            this.header_grid.TabIndex = 35;
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
            // qty
            // 
            this.qty.HeaderText = "Quantity";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // what_happened
            // 
            this.what_happened.HeaderText = "What Happened?";
            this.what_happened.Items.AddRange(new object[] {
            "MISSING",
            "BAD STOCKS"});
            this.what_happened.Name = "what_happened";
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(12, 529);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(216, 32);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Proceed";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MissingOrBadGridWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 590);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.header_grid);
            this.Name = "MissingOrBadGridWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please specify...";
            this.Load += new System.EventHandler(this.MissingOrBadGridWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView header_grid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewComboBoxColumn what_happened;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
    }
}