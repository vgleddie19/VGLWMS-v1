namespace WMS
{
    partial class OrderHoldingWindow
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
            this.products_grid = new System.Windows.Forms.DataGridView();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_ordered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_picked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_lacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.orders_grid = new System.Windows.Forms.DataGridView();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_invoice_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail_qty_ordered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnHoldOrder = new System.Windows.Forms.Button();
            this.btnActivateSelectedOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.products_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orders_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // products_grid
            // 
            this.products_grid.AllowUserToAddRows = false;
            this.products_grid.AllowUserToDeleteRows = false;
            this.products_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.products_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.products_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.products_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.uom,
            this.expiry,
            this.lot_no,
            this.qty_ordered,
            this.qty_picked,
            this.qty_lacking});
            this.products_grid.Location = new System.Drawing.Point(12, 77);
            this.products_grid.MultiSelect = false;
            this.products_grid.Name = "products_grid";
            this.products_grid.ReadOnly = true;
            this.products_grid.RowTemplate.Height = 28;
            this.products_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.products_grid.Size = new System.Drawing.Size(1035, 194);
            this.products_grid.TabIndex = 35;
            this.products_grid.SelectionChanged += new System.EventHandler(this.products_grid_SelectionChanged);
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
            // expiry
            // 
            this.expiry.HeaderText = "Expiry";
            this.expiry.Name = "expiry";
            this.expiry.ReadOnly = true;
            // 
            // lot_no
            // 
            this.lot_no.HeaderText = "Lot No";
            this.lot_no.Name = "lot_no";
            this.lot_no.ReadOnly = true;
            // 
            // qty_ordered
            // 
            this.qty_ordered.HeaderText = "Qty Ordered";
            this.qty_ordered.Name = "qty_ordered";
            this.qty_ordered.ReadOnly = true;
            // 
            // qty_picked
            // 
            this.qty_picked.HeaderText = "Qty Picked";
            this.qty_picked.Name = "qty_picked";
            this.qty_picked.ReadOnly = true;
            // 
            // qty_lacking
            // 
            this.qty_lacking.HeaderText = "Qty Lacking";
            this.qty_lacking.Name = "qty_lacking";
            this.qty_lacking.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 29);
            this.label5.TabIndex = 37;
            this.label5.Text = "Products Compromised";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 29);
            this.label1.TabIndex = 38;
            this.label1.Text = "Orders To Hold";
            // 
            // orders_grid
            // 
            this.orders_grid.AllowUserToAddRows = false;
            this.orders_grid.AllowUserToDeleteRows = false;
            this.orders_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orders_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orders_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orders_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_id,
            this.total_invoice_amount,
            this.client,
            this.customer,
            this.detail_qty_ordered,
            this.status});
            this.orders_grid.Location = new System.Drawing.Point(10, 368);
            this.orders_grid.Name = "orders_grid";
            this.orders_grid.ReadOnly = true;
            this.orders_grid.RowTemplate.Height = 28;
            this.orders_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orders_grid.Size = new System.Drawing.Size(1036, 213);
            this.orders_grid.TabIndex = 39;
            // 
            // order_id
            // 
            this.order_id.HeaderText = "Order ID";
            this.order_id.Name = "order_id";
            this.order_id.ReadOnly = true;
            // 
            // total_invoice_amount
            // 
            this.total_invoice_amount.HeaderText = "Total Invoice Amount";
            this.total_invoice_amount.Name = "total_invoice_amount";
            this.total_invoice_amount.ReadOnly = true;
            // 
            // client
            // 
            this.client.HeaderText = "Client";
            this.client.Name = "client";
            this.client.ReadOnly = true;
            // 
            // customer
            // 
            this.customer.HeaderText = "Customer";
            this.customer.Name = "customer";
            this.customer.ReadOnly = true;
            // 
            // detail_qty_ordered
            // 
            this.detail_qty_ordered.HeaderText = "Qty Ordered";
            this.detail_qty_ordered.Name = "detail_qty_ordered";
            this.detail_qty_ordered.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(12, 599);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(216, 32);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Proceed To Print Preview";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHoldOrder
            // 
            this.btnHoldOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHoldOrder.BackColor = System.Drawing.Color.Pink;
            this.btnHoldOrder.Location = new System.Drawing.Point(10, 324);
            this.btnHoldOrder.Name = "btnHoldOrder";
            this.btnHoldOrder.Size = new System.Drawing.Size(197, 32);
            this.btnHoldOrder.TabIndex = 43;
            this.btnHoldOrder.Text = "Hold Selected Order";
            this.btnHoldOrder.UseVisualStyleBackColor = false;
            this.btnHoldOrder.Click += new System.EventHandler(this.btnHoldOrder_Click);
            // 
            // btnActivateSelectedOrder
            // 
            this.btnActivateSelectedOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActivateSelectedOrder.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnActivateSelectedOrder.ForeColor = System.Drawing.Color.White;
            this.btnActivateSelectedOrder.Location = new System.Drawing.Point(213, 324);
            this.btnActivateSelectedOrder.Name = "btnActivateSelectedOrder";
            this.btnActivateSelectedOrder.Size = new System.Drawing.Size(197, 32);
            this.btnActivateSelectedOrder.TabIndex = 44;
            this.btnActivateSelectedOrder.Text = "Activate Selected Order";
            this.btnActivateSelectedOrder.UseVisualStyleBackColor = false;
            this.btnActivateSelectedOrder.Click += new System.EventHandler(this.btnActivateSelectedOrder_Click);
            // 
            // OrderHoldingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 691);
            this.Controls.Add(this.btnActivateSelectedOrder);
            this.Controls.Add(this.btnHoldOrder);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.orders_grid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.products_grid);
            this.Name = "OrderHoldingWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hold Orders...";
            this.Load += new System.EventHandler(this.OrderHoldingWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.products_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orders_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView products_grid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView orders_grid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_invoice_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn client;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn detail_qty_ordered;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_ordered;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_picked;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_lacking;
        private System.Windows.Forms.Button btnHoldOrder;
        private System.Windows.Forms.Button btnActivateSelectedOrder;
    }
}