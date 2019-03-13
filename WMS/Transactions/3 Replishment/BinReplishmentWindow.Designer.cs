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
            this.btngenpick = new System.Windows.Forms.Button();
            this.btnrepbins = new System.Windows.Forms.Button();
            this.btngencasebreak = new System.Windows.Forms.Button();
            this.btnconpick = new System.Windows.Forms.Button();
            this.location_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_to_be_replenished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.location_id,
            this.product,
            this.Uom,
            this.lot_no,
            this.Expiry,
            this.actual_qty,
            this.min_qty,
            this.qty_to_be_replenished,
            this.status});
            this.headerGrid.Location = new System.Drawing.Point(11, 11);
            this.headerGrid.Margin = new System.Windows.Forms.Padding(2);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.ReadOnly = true;
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.Size = new System.Drawing.Size(827, 304);
            this.headerGrid.TabIndex = 23;
            this.headerGrid.TabStop = false;
            // 
            // btngenpick
            // 
            this.btngenpick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btngenpick.Location = new System.Drawing.Point(12, 330);
            this.btngenpick.Name = "btngenpick";
            this.btngenpick.Size = new System.Drawing.Size(117, 58);
            this.btngenpick.TabIndex = 28;
            this.btngenpick.Text = "Generate Pick List";
            this.btngenpick.UseVisualStyleBackColor = false;
            this.btngenpick.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnrepbins
            // 
            this.btnrepbins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnrepbins.Location = new System.Drawing.Point(393, 330);
            this.btnrepbins.Name = "btnrepbins";
            this.btnrepbins.Size = new System.Drawing.Size(125, 54);
            this.btnrepbins.TabIndex = 29;
            this.btnrepbins.Text = "Replenish Bins";
            this.btnrepbins.UseVisualStyleBackColor = false;
            // 
            // btngencasebreak
            // 
            this.btngencasebreak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btngencasebreak.Location = new System.Drawing.Point(267, 330);
            this.btngencasebreak.Name = "btngencasebreak";
            this.btngencasebreak.Size = new System.Drawing.Size(120, 58);
            this.btngencasebreak.TabIndex = 28;
            this.btngencasebreak.Text = "Generate Case Break";
            this.btngencasebreak.UseVisualStyleBackColor = false;
            this.btngencasebreak.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnconpick
            // 
            this.btnconpick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnconpick.Location = new System.Drawing.Point(135, 330);
            this.btnconpick.Name = "btnconpick";
            this.btnconpick.Size = new System.Drawing.Size(126, 54);
            this.btnconpick.TabIndex = 28;
            this.btnconpick.Text = "Generate Confirm Pick List";
            this.btnconpick.UseVisualStyleBackColor = false;
            this.btnconpick.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // location_id
            // 
            this.location_id.HeaderText = "BIN Location";
            this.location_id.Name = "location_id";
            this.location_id.ReadOnly = true;
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
            // BinReplishmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 396);
            this.Controls.Add(this.btnrepbins);
            this.Controls.Add(this.btnconpick);
            this.Controls.Add(this.btngencasebreak);
            this.Controls.Add(this.btngenpick);
            this.Controls.Add(this.headerGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BinReplishmentWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bin Replishment";
            this.Load += new System.EventHandler(this.BinReplishmentWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView headerGrid;
        private System.Windows.Forms.Button btngenpick;
        private System.Windows.Forms.Button btnrepbins;
        private System.Windows.Forms.Button btngencasebreak;
        private System.Windows.Forms.Button btnconpick;
        private System.Windows.Forms.DataGridViewTextBoxColumn location_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn min_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_to_be_replenished;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}