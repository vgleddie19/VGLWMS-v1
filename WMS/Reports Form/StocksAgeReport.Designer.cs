namespace WMS
{
    partial class StocksAgeReport
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
            this.header_grid = new System.Windows.Forms.DataGridView();
            this.btnDeclareExpiredStocks = new System.Windows.Forms.Button();
            this.btnDispose = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // header_grid
            // 
            this.header_grid.AllowUserToAddRows = false;
            this.header_grid.AllowUserToDeleteRows = false;
            this.header_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.header_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.header_grid.Location = new System.Drawing.Point(16, 33);
            this.header_grid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.header_grid.Name = "header_grid";
            this.header_grid.ReadOnly = true;
            this.header_grid.RowTemplate.Height = 28;
            this.header_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.header_grid.Size = new System.Drawing.Size(721, 331);
            this.header_grid.TabIndex = 45;
            // 
            // btnDeclareExpiredStocks
            // 
            this.btnDeclareExpiredStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeclareExpiredStocks.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDeclareExpiredStocks.Location = new System.Drawing.Point(16, 375);
            this.btnDeclareExpiredStocks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeclareExpiredStocks.Name = "btnDeclareExpiredStocks";
            this.btnDeclareExpiredStocks.Size = new System.Drawing.Size(191, 49);
            this.btnDeclareExpiredStocks.TabIndex = 46;
            this.btnDeclareExpiredStocks.Text = "Declare Stocks \"Near Expiry\" and Unavailable for Orders";
            this.btnDeclareExpiredStocks.UseVisualStyleBackColor = false;
            this.btnDeclareExpiredStocks.Click += new System.EventHandler(this.btnDeclareExpiredStocks_Click);
            // 
            // btnDispose
            // 
            this.btnDispose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDispose.BackColor = System.Drawing.Color.Lime;
            this.btnDispose.Location = new System.Drawing.Point(221, 375);
            this.btnDispose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(191, 49);
            this.btnDispose.TabIndex = 47;
            this.btnDispose.Text = "Generate Picklist - Expired Stocks";
            this.btnDispose.UseVisualStyleBackColor = false;
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelease.BackColor = System.Drawing.Color.Yellow;
            this.btnRelease.Location = new System.Drawing.Point(415, 375);
            this.btnRelease.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(191, 49);
            this.btnRelease.TabIndex = 48;
            this.btnRelease.Text = "Release Picklists - Expired Stocks";
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // StocksAgeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 439);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDispose);
            this.Controls.Add(this.btnDeclareExpiredStocks);
            this.Controls.Add(this.header_grid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StocksAgeReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stocks Age Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StocksAgeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView header_grid;
        private System.Windows.Forms.Button btnDeclareExpiredStocks;
        private System.Windows.Forms.Button btnDispose;
        private System.Windows.Forms.Button btnRelease;
    }
}