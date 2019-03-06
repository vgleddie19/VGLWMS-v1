namespace WMS
{
    partial class CancelledPalletPutawayWindow
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
            this.items_grid = new System.Windows.Forms.DataGridView();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putaway_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChangeLocation = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.items_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // items_grid
            // 
            this.items_grid.AllowUserToAddRows = false;
            this.items_grid.AllowUserToDeleteRows = false;
            this.items_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.items_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.items_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.items_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.uom,
            this.lot_no,
            this.Expiry,
            this.qty,
            this.putaway_to});
            this.items_grid.Location = new System.Drawing.Point(12, 77);
            this.items_grid.Name = "items_grid";
            this.items_grid.ReadOnly = true;
            this.items_grid.RowTemplate.Height = 28;
            this.items_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.items_grid.Size = new System.Drawing.Size(866, 466);
            this.items_grid.TabIndex = 45;
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
            this.lot_no.HeaderText = "Lot no";
            this.lot_no.Name = "lot_no";
            this.lot_no.ReadOnly = true;
            // 
            // Expiry
            // 
            this.Expiry.HeaderText = "Expiry";
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // putaway_to
            // 
            this.putaway_to.HeaderText = "Putaway To";
            this.putaway_to.Name = "putaway_to";
            this.putaway_to.ReadOnly = true;
            // 
            // btnChangeLocation
            // 
            this.btnChangeLocation.BackColor = System.Drawing.Color.Aqua;
            this.btnChangeLocation.Location = new System.Drawing.Point(14, 23);
            this.btnChangeLocation.Name = "btnChangeLocation";
            this.btnChangeLocation.Size = new System.Drawing.Size(322, 38);
            this.btnChangeLocation.TabIndex = 46;
            this.btnChangeLocation.Text = "Add / Change Location";
            this.btnChangeLocation.UseVisualStyleBackColor = false;
            this.btnChangeLocation.Click += new System.EventHandler(this.btnChangeLocation_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintPreview.BackColor = System.Drawing.Color.GreenYellow;
            this.btnPrintPreview.Location = new System.Drawing.Point(12, 549);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(265, 49);
            this.btnPrintPreview.TabIndex = 48;
            this.btnPrintPreview.Text = "Proceed to Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // CancelledPalletPutawayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 610);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.btnChangeLocation);
            this.Controls.Add(this.items_grid);
            this.Name = "CancelledPalletPutawayWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Putaway the Cancelled Pallet...";
            this.Load += new System.EventHandler(this.CancelledPalletPutawayWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.items_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView items_grid;
        private System.Windows.Forms.Button btnChangeLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn putaway_to;
        private System.Windows.Forms.Button btnPrintPreview;
    }
}