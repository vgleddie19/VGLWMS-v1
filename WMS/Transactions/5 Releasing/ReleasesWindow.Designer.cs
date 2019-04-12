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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.items_grid = new System.Windows.Forms.DataGridView();
            this.orders_grid = new System.Windows.Forms.DataGridView();
            this.txtTrip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtreleaseto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.items_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orders_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(17, 458);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(263, 39);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Declare Incomplete";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtScan
            // 
            this.txtScan.Location = new System.Drawing.Point(87, 95);
            this.txtScan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(193, 20);
            this.txtScan.TabIndex = 48;
            this.txtScan.TextChanged += new System.EventHandler(this.txtScan_TextChanged);
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Scan Item:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 316);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "ITEMS SCANNED";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.items_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.items_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.items_grid.Location = new System.Drawing.Point(17, 338);
            this.items_grid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.items_grid.Name = "items_grid";
            this.items_grid.ReadOnly = true;
            this.items_grid.RowTemplate.Height = 28;
            this.items_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.items_grid.Size = new System.Drawing.Size(696, 116);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orders_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.orders_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orders_grid.Location = new System.Drawing.Point(17, 137);
            this.orders_grid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.orders_grid.Name = "orders_grid";
            this.orders_grid.ReadOnly = true;
            this.orders_grid.RowTemplate.Height = 28;
            this.orders_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.orders_grid.Size = new System.Drawing.Size(696, 163);
            this.orders_grid.TabIndex = 43;
            // 
            // txtTrip
            // 
            this.txtTrip.AutoSize = true;
            this.txtTrip.Location = new System.Drawing.Point(317, 12);
            this.txtTrip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTrip.Name = "txtTrip";
            this.txtTrip.Size = new System.Drawing.Size(68, 13);
            this.txtTrip.TabIndex = 42;
            this.txtTrip.Text = "<Code here>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Trip ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Release To:";
            // 
            // txtreleaseto
            // 
            this.txtreleaseto.Location = new System.Drawing.Point(87, 71);
            this.txtreleaseto.Margin = new System.Windows.Forms.Padding(2);
            this.txtreleaseto.Name = "txtreleaseto";
            this.txtreleaseto.Size = new System.Drawing.Size(193, 20);
            this.txtreleaseto.TabIndex = 48;
            this.txtreleaseto.TextChanged += new System.EventHandler(this.txtScan_TextChanged);
            this.txtreleaseto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // ReleasesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 508);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtreleaseto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.items_grid);
            this.Controls.Add(this.orders_grid);
            this.Controls.Add(this.txtTrip);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtreleaseto;
    }
}