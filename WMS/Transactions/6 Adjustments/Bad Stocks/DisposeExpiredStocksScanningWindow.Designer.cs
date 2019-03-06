namespace WMS
{
    partial class DisposeExpiredStocksScanningWindow
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
            this.txtPicklistID = new System.Windows.Forms.Label();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scanned_grid = new System.Windows.Forms.DataGridView();
            this.for_scanning_grid = new System.Windows.Forms.DataGridView();
            this.txtReleaseTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReleaseToPerson = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTripReference = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.scanned_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.for_scanning_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPicklistID
            // 
            this.txtPicklistID.AutoSize = true;
            this.txtPicklistID.Location = new System.Drawing.Point(52, 13);
            this.txtPicklistID.Name = "txtPicklistID";
            this.txtPicklistID.Size = new System.Drawing.Size(51, 20);
            this.txtPicklistID.TabIndex = 0;
            this.txtPicklistID.Text = "label1";
            // 
            // txtScan
            // 
            this.txtScan.Location = new System.Drawing.Point(129, 106);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(287, 26);
            this.txtScan.TabIndex = 54;
            this.txtScan.TextChanged += new System.EventHandler(this.txtScan_TextChanged);
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 53;
            this.label3.Text = "Scan Item:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 29);
            this.label2.TabIndex = 52;
            this.label2.Text = "ITEMS SCANNED";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(294, 29);
            this.label5.TabIndex = 51;
            this.label5.Text = "ITEMS FOR SCANNING";
            // 
            // scanned_grid
            // 
            this.scanned_grid.AllowUserToAddRows = false;
            this.scanned_grid.AllowUserToDeleteRows = false;
            this.scanned_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scanned_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.scanned_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scanned_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.client,
            this.product,
            this.Uom,
            this.lot_no,
            this.expiry,
            this.qty});
            this.scanned_grid.Location = new System.Drawing.Point(35, 424);
            this.scanned_grid.Name = "scanned_grid";
            this.scanned_grid.ReadOnly = true;
            this.scanned_grid.RowTemplate.Height = 28;
            this.scanned_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scanned_grid.Size = new System.Drawing.Size(1024, 179);
            this.scanned_grid.TabIndex = 50;
            // 
            // for_scanning_grid
            // 
            this.for_scanning_grid.AllowUserToAddRows = false;
            this.for_scanning_grid.AllowUserToDeleteRows = false;
            this.for_scanning_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.for_scanning_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.for_scanning_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.for_scanning_grid.Location = new System.Drawing.Point(35, 179);
            this.for_scanning_grid.Name = "for_scanning_grid";
            this.for_scanning_grid.ReadOnly = true;
            this.for_scanning_grid.RowTemplate.Height = 28;
            this.for_scanning_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.for_scanning_grid.Size = new System.Drawing.Size(1024, 187);
            this.for_scanning_grid.TabIndex = 49;
            // 
            // txtReleaseTo
            // 
            this.txtReleaseTo.Location = new System.Drawing.Point(129, 62);
            this.txtReleaseTo.Name = "txtReleaseTo";
            this.txtReleaseTo.Size = new System.Drawing.Size(200, 26);
            this.txtReleaseTo.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Release To:";
            // 
            // txtReleaseToPerson
            // 
            this.txtReleaseToPerson.Location = new System.Drawing.Point(516, 62);
            this.txtReleaseToPerson.Name = "txtReleaseToPerson";
            this.txtReleaseToPerson.Size = new System.Drawing.Size(200, 26);
            this.txtReleaseToPerson.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "Release To Person:";
            // 
            // txtTripReference
            // 
            this.txtTripReference.Location = new System.Drawing.Point(845, 62);
            this.txtTripReference.Name = "txtTripReference";
            this.txtTripReference.Size = new System.Drawing.Size(200, 26);
            this.txtTripReference.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(721, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 59;
            this.label6.Text = "Trip Reference:";
            // 
            // client
            // 
            this.client.HeaderText = "Client";
            this.client.Name = "client";
            this.client.ReadOnly = true;
            // 
            // product
            // 
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            // 
            // Uom
            // 
            this.Uom.HeaderText = "Uom";
            this.Uom.Name = "Uom";
            this.Uom.ReadOnly = true;
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
            // qty
            // 
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // DisposeExpiredStocksScanningWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 632);
            this.Controls.Add(this.txtTripReference);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReleaseToPerson);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReleaseTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.scanned_grid);
            this.Controls.Add(this.for_scanning_grid);
            this.Controls.Add(this.txtPicklistID);
            this.Name = "DisposeExpiredStocksScanningWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan Disposals...";
            this.Load += new System.EventHandler(this.DisposeExpiredStocksScanningWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scanned_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.for_scanning_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label txtPicklistID;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView scanned_grid;
        public System.Windows.Forms.DataGridView for_scanning_grid;
        private System.Windows.Forms.TextBox txtReleaseTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReleaseToPerson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTripReference;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn client;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
    }
}