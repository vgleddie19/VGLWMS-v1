namespace WMS
{
    partial class ReleasesWindow
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.items_grid = new System.Windows.Forms.DataGridView();
            this.orders_grid = new System.Windows.Forms.DataGridView();
            this.txtTrip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.items_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orders_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(43, 589);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(534, 32);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Declare Incomplete";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtScan
            // 
            this.txtScan.Location = new System.Drawing.Point(120, 84);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(287, 26);
            this.txtScan.TabIndex = 48;
            this.txtScan.TextChanged += new System.EventHandler(this.txtScan_TextChanged);
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 47;
            this.label3.Text = "Scan Item:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 29);
            this.label2.TabIndex = 46;
            this.label2.Text = "ITEMS SCANNED";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 29);
            this.label5.TabIndex = 45;
            this.label5.Text = "ORDERS";
            // 
            // items_grid
            // 
            this.items_grid.AllowUserToAddRows = false;
            this.items_grid.AllowUserToDeleteRows = false;
            this.items_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.items_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.items_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.items_grid.Location = new System.Drawing.Point(26, 389);
            this.items_grid.Name = "items_grid";
            this.items_grid.ReadOnly = true;
            this.items_grid.RowTemplate.Height = 28;
            this.items_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.items_grid.Size = new System.Drawing.Size(1044, 179);
            this.items_grid.TabIndex = 44;
            // 
            // orders_grid
            // 
            this.orders_grid.AllowUserToAddRows = false;
            this.orders_grid.AllowUserToDeleteRows = false;
            this.orders_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orders_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orders_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orders_grid.Location = new System.Drawing.Point(26, 157);
            this.orders_grid.Name = "orders_grid";
            this.orders_grid.ReadOnly = true;
            this.orders_grid.RowTemplate.Height = 28;
            this.orders_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.orders_grid.Size = new System.Drawing.Size(1044, 174);
            this.orders_grid.TabIndex = 43;
            // 
            // txtTrip
            // 
            this.txtTrip.AutoSize = true;
            this.txtTrip.Location = new System.Drawing.Point(476, 19);
            this.txtTrip.Name = "txtTrip";
            this.txtTrip.Size = new System.Drawing.Size(101, 20);
            this.txtTrip.TabIndex = 42;
            this.txtTrip.Text = "<Code here>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Trip ID:";
            // 
            // ReleasesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 651);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.items_grid);
            this.Controls.Add(this.orders_grid);
            this.Controls.Add(this.txtTrip);
            this.Controls.Add(this.label1);
            this.Name = "ReleasesWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReleasesWindow";
            this.Load += new System.EventHandler(this.ReleasesWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.items_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orders_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView items_grid;
        public System.Windows.Forms.DataGridView orders_grid;
        public System.Windows.Forms.Label txtTrip;
        private System.Windows.Forms.Label label1;
    }
}