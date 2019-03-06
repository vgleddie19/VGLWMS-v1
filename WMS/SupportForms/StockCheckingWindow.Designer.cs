namespace WMS
{
    partial class StockCheckingWindow
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
            this.btnStockCheck = new System.Windows.Forms.Button();
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
            this.headerGrid.Location = new System.Drawing.Point(22, 44);
            this.headerGrid.Margin = new System.Windows.Forms.Padding(2);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.ReadOnly = true;
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.Size = new System.Drawing.Size(577, 253);
            this.headerGrid.TabIndex = 23;
            this.headerGrid.TabStop = false;
            // 
            // btnStockCheck
            // 
            this.btnStockCheck.BackColor = System.Drawing.Color.Yellow;
            this.btnStockCheck.ForeColor = System.Drawing.Color.Black;
            this.btnStockCheck.Location = new System.Drawing.Point(22, 18);
            this.btnStockCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnStockCheck.Name = "btnStockCheck";
            this.btnStockCheck.Size = new System.Drawing.Size(81, 22);
            this.btnStockCheck.TabIndex = 30;
            this.btnStockCheck.TabStop = false;
            this.btnStockCheck.Text = "Stock Check";
            this.btnStockCheck.UseVisualStyleBackColor = false;
            this.btnStockCheck.Click += new System.EventHandler(this.btnStockCheck_Click);
            // 
            // StockCheckingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 327);
            this.Controls.Add(this.btnStockCheck);
            this.Controls.Add(this.headerGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StockCheckingWindow";
            this.Text = "StockCheckingWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockCheckingWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView headerGrid;
        private System.Windows.Forms.Button btnStockCheck;
    }
}