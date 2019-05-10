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
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding1 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            this.headerGrid = new System.Windows.Forms.DataGridView();
            this.btnStockCheck = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grd = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
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
            this.headerGrid.Location = new System.Drawing.Point(228, 11);
            this.headerGrid.Margin = new System.Windows.Forms.Padding(2);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.ReadOnly = true;
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.Size = new System.Drawing.Size(10, 10);
            this.headerGrid.TabIndex = 23;
            this.headerGrid.TabStop = false;
            this.headerGrid.Visible = false;
            // 
            // btnStockCheck
            // 
            this.btnStockCheck.BackColor = System.Drawing.Color.Yellow;
            this.btnStockCheck.ForeColor = System.Drawing.Color.Black;
            this.btnStockCheck.Location = new System.Drawing.Point(8, 11);
            this.btnStockCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnStockCheck.Name = "btnStockCheck";
            this.btnStockCheck.Size = new System.Drawing.Size(99, 45);
            this.btnStockCheck.TabIndex = 30;
            this.btnStockCheck.TabStop = false;
            this.btnStockCheck.Text = "Stock Check";
            this.btnStockCheck.UseVisualStyleBackColor = false;
            this.btnStockCheck.Click += new System.EventHandler(this.btnStockCheck_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(111, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 45);
            this.button1.TabIndex = 30;
            this.button1.TabStop = false;
            this.button1.Text = "Closed";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grd
            // 
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.grd.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.grd.Location = new System.Drawing.Point(9, 61);
            this.grd.Name = "grd";
            this.grd.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            // 
            // 
            // 
            this.grd.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            // 
            // 
            // 
            this.grd.PrimaryGrid.ColumnHeader.MinRowHeight = 100;
            this.grd.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.grd.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.grd.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.grd.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.grd.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            padding1.Bottom = 10;
            padding1.Top = 10;
            this.grd.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Padding = padding1;
            this.grd.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.grd.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.grd.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.grd.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.grd.PrimaryGrid.EnableColumnFiltering = true;
            this.grd.PrimaryGrid.EnableFiltering = true;
            this.grd.PrimaryGrid.EnableRowFiltering = true;
            // 
            // 
            // 
            this.grd.PrimaryGrid.Filter.ShowPanelFilterExpr = true;
            this.grd.PrimaryGrid.Filter.Visible = true;
            this.grd.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.grd.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.grd.PrimaryGrid.GridLines = DevComponents.DotNetBar.SuperGrid.GridLines.Vertical;
            this.grd.PrimaryGrid.MultiSelect = false;
            this.grd.PrimaryGrid.RowDoubleClickBehavior = DevComponents.DotNetBar.SuperGrid.RowDoubleClickBehavior.ExpandCollapse;
            this.grd.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.grd.PrimaryGrid.ShowTreeButtons = true;
            this.grd.PrimaryGrid.ShowTreeLines = true;
            // 
            // 
            // 
            this.grd.PrimaryGrid.Title.Text = "";
            this.grd.PrimaryGrid.Title.Visible = false;
            this.grd.PrimaryGrid.UseAlternateColumnStyle = true;
            this.grd.Size = new System.Drawing.Size(872, 443);
            this.grd.TabIndex = 31;
            this.grd.Text = "0.";
            // 
            // StockCheckingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 514);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        public DevComponents.DotNetBar.SuperGrid.SuperGridControl grd;
    }
}