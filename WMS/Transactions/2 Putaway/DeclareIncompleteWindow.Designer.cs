namespace WMS
{
    partial class DeclareIncompleteWindow
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
            this.txtScan = new System.Windows.Forms.TextBox();
            this.txtPutawayID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContainer = new System.Windows.Forms.Label();
            this.putaway_details_grid = new System.Windows.Forms.DataGridView();
            this.returns_grid = new System.Windows.Forms.DataGridView();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.putaway_details_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returns_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan Remaining Items:";
            // 
            // txtScan
            // 
            this.txtScan.AcceptsReturn = true;
            this.txtScan.Location = new System.Drawing.Point(210, 81);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(316, 26);
            this.txtScan.TabIndex = 1;
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // txtPutawayID
            // 
            this.txtPutawayID.AutoSize = true;
            this.txtPutawayID.Location = new System.Drawing.Point(206, 9);
            this.txtPutawayID.Name = "txtPutawayID";
            this.txtPutawayID.Size = new System.Drawing.Size(104, 20);
            this.txtPutawayID.TabIndex = 26;
            this.txtPutawayID.Text = "<Code Here>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Putaway ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Container:";
            // 
            // txtContainer
            // 
            this.txtContainer.AutoSize = true;
            this.txtContainer.Location = new System.Drawing.Point(215, 46);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(104, 20);
            this.txtContainer.TabIndex = 27;
            this.txtContainer.Text = "<Code Here>";
            // 
            // putaway_details_grid
            // 
            this.putaway_details_grid.AllowUserToAddRows = false;
            this.putaway_details_grid.AllowUserToDeleteRows = false;
            this.putaway_details_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.putaway_details_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.putaway_details_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.putaway_details_grid.Location = new System.Drawing.Point(35, 167);
            this.putaway_details_grid.Name = "putaway_details_grid";
            this.putaway_details_grid.ReadOnly = true;
            this.putaway_details_grid.RowTemplate.Height = 28;
            this.putaway_details_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.putaway_details_grid.Size = new System.Drawing.Size(826, 183);
            this.putaway_details_grid.TabIndex = 28;
            // 
            // returns_grid
            // 
            this.returns_grid.AllowUserToAddRows = false;
            this.returns_grid.AllowUserToDeleteRows = false;
            this.returns_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returns_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.returns_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.returns_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.uom,
            this.lot_no,
            this.expiry,
            this.qty});
            this.returns_grid.Location = new System.Drawing.Point(35, 409);
            this.returns_grid.Name = "returns_grid";
            this.returns_grid.ReadOnly = true;
            this.returns_grid.RowTemplate.Height = 28;
            this.returns_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.returns_grid.Size = new System.Drawing.Size(826, 226);
            this.returns_grid.TabIndex = 29;
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
            // qty
            // 
            this.qty.HeaderText = "Quantity";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 29);
            this.label4.TabIndex = 30;
            this.label4.Text = "DECLARED RETURNS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(465, 29);
            this.label5.TabIndex = 31;
            this.label5.Text = "PREVIOUSLY DECLARED PUTAWAYS";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(35, 652);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 32);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DeclareIncompleteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 696);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.returns_grid);
            this.Controls.Add(this.putaway_details_grid);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.txtPutawayID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label1);
            this.Name = "DeclareIncompleteWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Declare as Incomplete";
            this.Load += new System.EventHandler(this.DeclareIncompleteWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.putaway_details_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returns_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtScan;
        public System.Windows.Forms.Label txtPutawayID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label txtContainer;
        public System.Windows.Forms.DataGridView putaway_details_grid;
        public System.Windows.Forms.DataGridView returns_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
    }
}