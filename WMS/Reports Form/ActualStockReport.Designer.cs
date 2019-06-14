namespace WMS
{
    partial class ActualStockReport
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
            this.btnDeclareExpiredStocks = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeclareExpiredStocks
            // 
            this.btnDeclareExpiredStocks.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDeclareExpiredStocks.Location = new System.Drawing.Point(5, 11);
            this.btnDeclareExpiredStocks.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeclareExpiredStocks.Name = "btnDeclareExpiredStocks";
            this.btnDeclareExpiredStocks.Size = new System.Drawing.Size(131, 49);
            this.btnDeclareExpiredStocks.TabIndex = 47;
            this.btnDeclareExpiredStocks.Text = "Print";
            this.btnDeclareExpiredStocks.UseVisualStyleBackColor = false;
            this.btnDeclareExpiredStocks.Click += new System.EventHandler(this.btnDeclareExpiredStocks_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(5, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 49);
            this.button1.TabIndex = 47;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = -1;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.ShowCloseButton = false;
            this.viewer.ShowCopyButton = false;
            this.viewer.ShowGotoPageButton = false;
            this.viewer.ShowGroupTreeButton = false;
            this.viewer.ShowLogo = false;
            this.viewer.ShowParameterPanelButton = false;
            this.viewer.ShowPrintButton = false;
            this.viewer.ShowRefreshButton = false;
            this.viewer.ShowTextSearchButton = false;
            this.viewer.Size = new System.Drawing.Size(982, 781);
            this.viewer.TabIndex = 48;
            this.viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnDeclareExpiredStocks);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(982, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 781);
            this.panel1.TabIndex = 49;
            // 
            // ActualStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 781);
            this.Controls.Add(this.viewer);
            this.Controls.Add(this.panel1);
            this.Name = "ActualStockReport";
            this.Text = "ActualStockReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ActualStockReport_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDeclareExpiredStocks;
        private System.Windows.Forms.Button button1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private System.Windows.Forms.Panel panel1;
    }
}