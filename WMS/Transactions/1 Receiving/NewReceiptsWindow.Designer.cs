namespace WMS
{
    partial class NewReceiptsWindow
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReceivedOn = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.headerGrid = new System.Windows.Forms.DataGridView();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReferenceDocument = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReceivedFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cboReceivedBy = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(278, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Reference:";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintPreview.BackColor = System.Drawing.Color.Lime;
            this.btnPrintPreview.Location = new System.Drawing.Point(17, 394);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(180, 22);
            this.btnPrintPreview.TabIndex = 26;
            this.btnPrintPreview.Text = "Proceed to Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(269, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Received By:";
            // 
            // txtReceivedOn
            // 
            this.txtReceivedOn.Location = new System.Drawing.Point(108, 45);
            this.txtReceivedOn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReceivedOn.Name = "txtReceivedOn";
            this.txtReceivedOn.Size = new System.Drawing.Size(147, 20);
            this.txtReceivedOn.TabIndex = 24;
            this.txtReceivedOn.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(74, 75);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 22);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SkyBlue;
            this.btnAdd.Location = new System.Drawing.Point(20, 75);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 22);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.product_id,
            this.product,
            this.Quantity,
            this.uom,
            this.lot,
            this.expiry,
            this.remarks});
            this.headerGrid.Location = new System.Drawing.Point(19, 101);
            this.headerGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.ReadOnly = true;
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.Size = new System.Drawing.Size(677, 289);
            this.headerGrid.TabIndex = 22;
            this.headerGrid.TabStop = false;
            // 
            // product_id
            // 
            this.product_id.HeaderText = "ID";
            this.product_id.Name = "product_id";
            this.product_id.ReadOnly = true;
            // 
            // product
            // 
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // uom
            // 
            this.uom.HeaderText = "UOM";
            this.uom.Name = "uom";
            this.uom.ReadOnly = true;
            // 
            // lot
            // 
            this.lot.HeaderText = "Lot #";
            this.lot.Name = "lot";
            this.lot.ReadOnly = true;
            // 
            // expiry
            // 
            this.expiry.HeaderText = "Expiry";
            this.expiry.Name = "expiry";
            this.expiry.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // txtReferenceDocument
            // 
            this.txtReferenceDocument.Location = new System.Drawing.Point(350, 45);
            this.txtReferenceDocument.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReferenceDocument.Name = "txtReferenceDocument";
            this.txtReferenceDocument.Size = new System.Drawing.Size(147, 20);
            this.txtReferenceDocument.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Received On:";
            // 
            // txtReceivedFrom
            // 
            this.txtReceivedFrom.Location = new System.Drawing.Point(108, 23);
            this.txtReceivedFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReceivedFrom.Name = "txtReceivedFrom";
            this.txtReceivedFrom.Size = new System.Drawing.Size(147, 20);
            this.txtReceivedFrom.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Received From:";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Yellow;
            this.btnLoad.ForeColor = System.Drawing.Color.Black;
            this.btnLoad.Location = new System.Drawing.Point(128, 75);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(50, 22);
            this.btnLoad.TabIndex = 29;
            this.btnLoad.TabStop = false;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cboReceivedBy
            // 
            this.cboReceivedBy.DisplayMember = "Text";
            this.cboReceivedBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboReceivedBy.FormattingEnabled = true;
            this.cboReceivedBy.ItemHeight = 14;
            this.cboReceivedBy.Location = new System.Drawing.Point(350, 20);
            this.cboReceivedBy.Name = "cboReceivedBy";
            this.cboReceivedBy.Size = new System.Drawing.Size(193, 20);
            this.cboReceivedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboReceivedBy.TabIndex = 30;
            // 
            // NewReceiptsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 424);
            this.Controls.Add(this.cboReceivedBy);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtReceivedOn);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.headerGrid);
            this.Controls.Add(this.txtReferenceDocument);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtReceivedFrom);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NewReceiptsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receive Stocks...";
            this.Load += new System.EventHandler(this.NewReceiptsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker txtReceivedOn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.DataGridView headerGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        public System.Windows.Forms.TextBox txtReferenceDocument;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtReceivedFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoad;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cboReceivedBy;
    }
}