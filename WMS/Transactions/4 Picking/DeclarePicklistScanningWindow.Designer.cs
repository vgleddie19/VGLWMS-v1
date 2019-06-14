namespace WMS
{
    partial class DeclarePicklistScanningWindow
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
            this.txtPicklist = new System.Windows.Forms.Label();
            this.scanned_grid = new System.Windows.Forms.DataGridView();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.original_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picklist_details_grid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scanned_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picklist_details_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Picklist ID:";
            // 
            // txtPicklist
            // 
            this.txtPicklist.AutoSize = true;
            this.txtPicklist.Location = new System.Drawing.Point(308, 6);
            this.txtPicklist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPicklist.Name = "txtPicklist";
            this.txtPicklist.Size = new System.Drawing.Size(68, 13);
            this.txtPicklist.TabIndex = 1;
            this.txtPicklist.Text = "<Code here>";
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
            this.product,
            this.qty,
            this.uom,
            this.lot_no,
            this.expiry,
            this.location,
            this.original_location});
            this.scanned_grid.Location = new System.Drawing.Point(8, 246);
            this.scanned_grid.Margin = new System.Windows.Forms.Padding(2);
            this.scanned_grid.Name = "scanned_grid";
            this.scanned_grid.ReadOnly = true;
            this.scanned_grid.RowTemplate.Height = 28;
            this.scanned_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scanned_grid.Size = new System.Drawing.Size(614, 116);
            this.scanned_grid.TabIndex = 35;
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
            // original_location
            // 
            this.original_location.HeaderText = "Picked From";
            this.original_location.Name = "original_location";
            this.original_location.ReadOnly = true;
            // 
            // picklist_details_grid
            // 
            this.picklist_details_grid.AllowUserToAddRows = false;
            this.picklist_details_grid.AllowUserToDeleteRows = false;
            this.picklist_details_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picklist_details_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.picklist_details_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.picklist_details_grid.Location = new System.Drawing.Point(8, 96);
            this.picklist_details_grid.Margin = new System.Windows.Forms.Padding(2);
            this.picklist_details_grid.Name = "picklist_details_grid";
            this.picklist_details_grid.ReadOnly = true;
            this.picklist_details_grid.RowTemplate.Height = 28;
            this.picklist_details_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.picklist_details_grid.Size = new System.Drawing.Size(614, 113);
            this.picklist_details_grid.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "ITEMS IN PICKLIST";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 226);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "ITEMS SCANNED";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Scan Item:";
            // 
            // txtScan
            // 
            this.txtScan.Location = new System.Drawing.Point(71, 48);
            this.txtScan.Margin = new System.Windows.Forms.Padding(2);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(193, 20);
            this.txtScan.TabIndex = 39;
            this.txtScan.TextChanged += new System.EventHandler(this.txtScan_TextChanged);
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(8, 376);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 21);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Declare Incomplete";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DeclarePicklistScanningWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 414);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.scanned_grid);
            this.Controls.Add(this.picklist_details_grid);
            this.Controls.Add(this.txtPicklist);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DeclarePicklistScanningWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Declare Picklist...";
            this.Load += new System.EventHandler(this.DeclarePicklistScanningWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scanned_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picklist_details_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label txtPicklist;
        public System.Windows.Forms.DataGridView scanned_grid;
        public System.Windows.Forms.DataGridView picklist_details_grid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn original_location;
    }
}