namespace WMS
{
    partial class newstocklocationtransfers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLocation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grd = new System.Windows.Forms.DataGridView();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.product = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.description = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Quantity = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.uom = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.lot = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.expiry = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.locationorigin = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.origin_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.translocation = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.transfer_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtLocation);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.grd);
            this.panel1.Controls.Add(this.btnPrintPreview);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 426);
            this.panel1.TabIndex = 0;
            // 
            // txtLocation
            // 
            this.txtLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLocation.FormattingEnabled = true;
            this.txtLocation.Location = new System.Drawing.Point(92, 14);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(147, 21);
            this.txtLocation.TabIndex = 33;
            this.txtLocation.SelectedIndexChanged += new System.EventHandler(this.txtLocation_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Location:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(768, 355);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 56);
            this.button1.TabIndex = 38;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(162, 39);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 22);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SkyBlue;
            this.btnAdd.Location = new System.Drawing.Point(92, 39);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 22);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "Transfer";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.description,
            this.Quantity,
            this.uom,
            this.lot,
            this.expiry,
            this.locationorigin,
            this.origin_qty,
            this.translocation,
            this.transfer_qty});
            this.grd.Location = new System.Drawing.Point(23, 67);
            this.grd.Margin = new System.Windows.Forms.Padding(2);
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RowTemplate.Height = 28;
            this.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd.Size = new System.Drawing.Size(1005, 284);
            this.grd.TabIndex = 36;
            this.grd.TabStop = false;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BackColor = System.Drawing.Color.Lime;
            this.btnPrintPreview.Location = new System.Drawing.Point(900, 355);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(128, 56);
            this.btnPrintPreview.TabIndex = 39;
            this.btnPrintPreview.Text = "Proceed to Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // product
            // 
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            this.product.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // uom
            // 
            this.uom.HeaderText = "UOM";
            this.uom.Name = "uom";
            this.uom.ReadOnly = true;
            this.uom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.uom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lot
            // 
            this.lot.HeaderText = "Lot #";
            this.lot.Name = "lot";
            this.lot.ReadOnly = true;
            this.lot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // expiry
            // 
            this.expiry.HeaderText = "Expiry";
            this.expiry.Name = "expiry";
            this.expiry.ReadOnly = true;
            this.expiry.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.expiry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // locationorigin
            // 
            this.locationorigin.HeaderText = "Location Origin";
            this.locationorigin.Name = "locationorigin";
            this.locationorigin.ReadOnly = true;
            this.locationorigin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.locationorigin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // origin_qty
            // 
            this.origin_qty.HeaderText = "Qty to Break";
            this.origin_qty.Name = "origin_qty";
            this.origin_qty.ReadOnly = true;
            // 
            // translocation
            // 
            this.translocation.HeaderText = "Location Destination";
            this.translocation.Name = "translocation";
            this.translocation.ReadOnly = true;
            this.translocation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.translocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // transfer_qty
            // 
            this.transfer_qty.HeaderText = "Expected Qty";
            this.transfer_qty.Name = "transfer_qty";
            this.transfer_qty.ReadOnly = true;
            // 
            // newstocklocationtransfers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 445);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "newstocklocationtransfers";
            this.Text = "New Stocks Transfer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView grd;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox txtLocation;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnPrintPreview;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn product;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn description;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Quantity;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn uom;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn lot;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn expiry;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn locationorigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn origin_qty;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn translocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn transfer_qty;
    }
}