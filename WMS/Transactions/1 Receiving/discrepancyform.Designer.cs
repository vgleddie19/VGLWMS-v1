namespace WMS
{
    partial class discrepancyform
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.headerGrid = new System.Windows.Forms.DataGridView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.product_id = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.product = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.uom = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Quantity = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.actualuom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualqty = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.lot = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.expiry = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.headerGrid);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1056, 424);
            this.panel6.TabIndex = 10;
            // 
            // headerGrid
            // 
            this.headerGrid.AllowUserToAddRows = false;
            this.headerGrid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headerGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.headerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.headerGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.headerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.product,
            this.uom,
            this.Quantity,
            this.actualuom,
            this.actualqty,
            this.lot,
            this.expiry,
            this.remarks});
            this.headerGrid.Location = new System.Drawing.Point(17, 163);
            this.headerGrid.Margin = new System.Windows.Forms.Padding(2);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.ShowRowErrors = false;
            this.headerGrid.Size = new System.Drawing.Size(1023, 255);
            this.headerGrid.TabIndex = 8;
            // 
            // panel9
            // 
            this.panel9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.txtremarks);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Location = new System.Drawing.Point(17, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(416, 155);
            this.panel9.TabIndex = 8;
            this.panel9.TabStop = true;
            // 
            // txtremarks
            // 
            this.txtremarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtremarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtremarks.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremarks.Location = new System.Drawing.Point(6, 20);
            this.txtremarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(397, 127);
            this.txtremarks.TabIndex = 5;
            this.txtremarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Remarks:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnPrintPreview);
            this.panel7.Controls.Add(this.button1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 424);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1056, 60);
            this.panel7.TabIndex = 11;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintPreview.BackColor = System.Drawing.Color.Lime;
            this.btnPrintPreview.Location = new System.Drawing.Point(932, 1);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(120, 55);
            this.btnPrintPreview.TabIndex = 10;
            this.btnPrintPreview.Text = "Proceed to Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(808, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 55);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // product_id
            // 
            this.product_id.HeaderText = "ID";
            this.product_id.Name = "product_id";
            this.product_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.product_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // product
            // 
            this.product.HeaderText = "Product Description";
            this.product.Name = "product";
            this.product.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.product.Width = 200;
            // 
            // uom
            // 
            this.uom.HeaderText = "Ref. Doc. UOM";
            this.uom.Name = "uom";
            this.uom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.uom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.uom.Width = 80;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Ref. Doc. Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Quantity.Width = 80;
            // 
            // actualuom
            // 
            this.actualuom.HeaderText = "Actual UOM";
            this.actualuom.Name = "actualuom";
            this.actualuom.Width = 80;
            // 
            // actualqty
            // 
            this.actualqty.HeaderText = "Actual Quantity";
            this.actualqty.Name = "actualqty";
            this.actualqty.Width = 80;
            // 
            // lot
            // 
            this.lot.HeaderText = "Lot #";
            this.lot.Name = "lot";
            this.lot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // expiry
            // 
            this.expiry.HeaderText = "Expiry";
            this.expiry.Name = "expiry";
            this.expiry.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.expiry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.expiry.Width = 80;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.Width = 150;
            // 
            // discrepancyform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 484);
            this.ControlBox = false;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "discrepancyform";
            this.Text = "discrepancyform";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.discrepancyform_FormClosed);
            this.Load += new System.EventHandler(this.discrepancyform_Load);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.DataGridView headerGrid;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn product_id;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn product;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn uom;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualuom;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn actualqty;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lot;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        public System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.TextBox txtremarks;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.Button btnPrintPreview;
        public System.Windows.Forms.Button button1;
    }
}