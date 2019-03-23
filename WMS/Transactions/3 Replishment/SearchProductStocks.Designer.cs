namespace WMS
{
    partial class SearchProductStocks
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
            this.grid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridcolchk = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolloc = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolprod = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcoluom = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcollot = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolexpiry = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolqty = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.grid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.grid.Location = new System.Drawing.Point(8, 8);
            this.grid.Name = "grid";
            // 
            // 
            // 
            this.grid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.grid.PrimaryGrid.Columns.Add(this.gridcolchk);
            this.grid.PrimaryGrid.Columns.Add(this.gridcolloc);
            this.grid.PrimaryGrid.Columns.Add(this.gridcolprod);
            this.grid.PrimaryGrid.Columns.Add(this.gridcoluom);
            this.grid.PrimaryGrid.Columns.Add(this.gridcollot);
            this.grid.PrimaryGrid.Columns.Add(this.gridcolexpiry);
            this.grid.PrimaryGrid.Columns.Add(this.gridcolqty);
            this.grid.PrimaryGrid.EnableColumnFiltering = true;
            this.grid.PrimaryGrid.EnableFiltering = true;
            // 
            // 
            // 
            this.grid.PrimaryGrid.Filter.RowHeight = 30;
            this.grid.PrimaryGrid.Filter.Visible = true;
            this.grid.Size = new System.Drawing.Size(826, 334);
            this.grid.TabIndex = 9;
            this.grid.Text = "superGridControl1";
            this.grid.CellValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs>(this.grid_CellValueChanged);
            // 
            // gridcolchk
            // 
            this.gridcolchk.DefaultNewRowCellValue = false;
            this.gridcolchk.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridcolchk.HeaderText = " ";
            this.gridcolchk.Name = "gridcolchk";
            this.gridcolchk.Width = 30;
            // 
            // gridcolloc
            // 
            this.gridcolloc.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolloc.HeaderText = "Location";
            this.gridcolloc.Name = "gridcolloc";
            // 
            // gridcolprod
            // 
            this.gridcolprod.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolprod.HeaderText = "Product";
            this.gridcolprod.Name = "gridcolprod";
            this.gridcolprod.Width = 250;
            // 
            // gridcoluom
            // 
            this.gridcoluom.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcoluom.HeaderText = "Unit Of Measure";
            this.gridcoluom.Name = "gridcoluom";
            this.gridcoluom.Width = 120;
            // 
            // gridcollot
            // 
            this.gridcollot.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcollot.HeaderText = "Lot Number";
            this.gridcollot.Name = "gridcollot";
            // 
            // gridcolexpiry
            // 
            this.gridcolexpiry.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolexpiry.HeaderText = "Date Expire";
            this.gridcolexpiry.Name = "gridcolexpiry";
            this.gridcolexpiry.Width = 90;
            // 
            // gridcolqty
            // 
            this.gridcolqty.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolqty.HeaderText = "Availiable Qty.";
            this.gridcolqty.Name = "gridcolqty";
            this.gridcolqty.Width = 80;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(77)))), ((int)(((byte)(75)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(8, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 39);
            this.button2.TabIndex = 45;
            this.button2.Text = "&Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(8, 348);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 53);
            this.panel1.TabIndex = 0;
            // 
            // SearchProductStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 402);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchProductStocks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Product Stocks";
            this.Load += new System.EventHandler(this.SearchProductStocks_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl grid;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolloc;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolprod;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcoluom;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcollot;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolexpiry;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolqty;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolchk;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
    }
}