namespace WMS
{
    partial class BinReplishmentWindow
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
            this.headerGrid = new System.Windows.Forms.DataGridView();
            this.bin_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_to_be_replenished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGrid
            // 
            this.headerGrid.AllowUserToAddRows = false;
            this.headerGrid.AllowUserToDeleteRows = false;
            this.headerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.headerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bin_id,
            this.product,
            this.Uom,
            this.lot_no,
            this.Expiry,
            this.actual_qty,
            this.min_qty,
            this.qty_to_be_replenished,
            this.status});
            this.headerGrid.Location = new System.Drawing.Point(12, 68);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.ReadOnly = true;
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.Size = new System.Drawing.Size(1241, 468);
            this.headerGrid.TabIndex = 23;
            this.headerGrid.TabStop = false;
            // 
            // bin_id
            // 
            this.bin_id.HeaderText = "Bin ID";
            this.bin_id.Name = "bin_id";
            this.bin_id.ReadOnly = true;
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
            // Expiry
            // 
            this.Expiry.HeaderText = "expiry";
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            // 
            // actual_qty
            // 
            this.actual_qty.HeaderText = "Actual Qty";
            this.actual_qty.Name = "actual_qty";
            this.actual_qty.ReadOnly = true;
            // 
            // min_qty
            // 
            this.min_qty.HeaderText = "Minimum Qty";
            this.min_qty.Name = "min_qty";
            this.min_qty.ReadOnly = true;
            // 
            // qty_to_be_replenished
            // 
            this.qty_to_be_replenished.HeaderText = "Qty To Be Replenished";
            this.qty_to_be_replenished.Name = "qty_to_be_replenished";
            this.qty_to_be_replenished.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Lime;
            this.btnAdd.Location = new System.Drawing.Point(9, 564);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(292, 32);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Generate Bin Replenishment List";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(309, 564);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 32);
            this.button1.TabIndex = 29;
            this.button1.Text = "Replenish Bins";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // BinReplishmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 609);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.headerGrid);
            this.Name = "BinReplishmentWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bin Replishment";
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView headerGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bin_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn min_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_to_be_replenished;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button1;
    }
}