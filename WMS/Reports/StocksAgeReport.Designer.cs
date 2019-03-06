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
            this.header_grid.Location = new System.Drawing.Point(24, 51);
            this.header_grid.Name = "header_grid";
            this.header_grid.ReadOnly = true;
            this.header_grid.RowTemplate.Height = 28;
            this.header_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.header_grid.Size = new System.Drawing.Size(1082, 510);
            this.header_grid.TabIndex = 45;
            // 
            // btnDeclareExpiredStocks
            // 
            this.btnDeclareExpiredStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeclareExpiredStocks.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDeclareExpiredStocks.Location = new System.Drawing.Point(24, 577);
            this.btnDeclareExpiredStocks.Name = "btnDeclareExpiredStocks";
            this.btnDeclareExpiredStocks.Size = new System.Drawing.Size(286, 76);
            this.btnDeclareExpiredStocks.TabIndex = 46;
            this.btnDeclareExpiredStocks.Text = "Declare Stocks \"Near Expiry\" and Unavailable for Orders";
            this.btnDeclareExpiredStocks.UseVisualStyleBackColor = false;
            this.btnDeclareExpiredStocks.Click += new System.EventHandler(this.btnDeclareExpiredStocks_Click);
            // 
            // btnDispose
            // 
            this.btnDispose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDispose.BackColor = System.Drawing.Color.Lime;
            this.btnDispose.Location = new System.Drawing.Point(331, 577);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(286, 76);
            this.btnDispose.TabIndex = 47;
            this.btnDispose.Text = "Generate Picklist - Expired Stocks";
            this.btnDispose.UseVisualStyleBackColor = false;
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelease.BackColor = System.Drawing.Color.Yellow;
            this.btnRelease.Location = new System.Drawing.Point(623, 577);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(286, 76);
            this.btnRelease.TabIndex = 48;
            this.btnRelease.Text = "Release Picklists - Expired Stocks";
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // StocksAgeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 676);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDispose);
            this.Controls.Add(this.btnDeclareExpiredStocks);
            this.Controls.Add(this.header_grid);
            this.Name = "StocksAgeReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stocks Age Report";
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