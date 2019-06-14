namespace WMS
{
    partial class ProductMaster
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
            this.grd = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridcol_product = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcol_descp = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcol_category = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcol_client = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcol_id = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.grd.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.Name = "grd";
            // 
            // 
            // 
            this.grd.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.grd.PrimaryGrid.Columns.Add(this.gridcol_product);
            this.grd.PrimaryGrid.Columns.Add(this.gridcol_descp);
            this.grd.PrimaryGrid.Columns.Add(this.gridcol_category);
            this.grd.PrimaryGrid.Columns.Add(this.gridcol_client);
            this.grd.PrimaryGrid.Columns.Add(this.gridcol_id);
            this.grd.PrimaryGrid.EnableColumnFiltering = true;
            this.grd.PrimaryGrid.EnableFiltering = true;
            // 
            // 
            // 
            this.grd.PrimaryGrid.Filter.Visible = true;
            this.grd.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.grd.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.grd.PrimaryGrid.MultiSelect = false;
            this.grd.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.grd.PrimaryGrid.UseAlternateRowStyle = true;
            this.grd.Size = new System.Drawing.Size(902, 530);
            this.grd.TabIndex = 0;
            this.grd.Text = "superGridControl1";
            this.grd.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.grd_RowDoubleClick);
            // 
            // gridcol_product
            // 
            this.gridcol_product.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcol_product.HeaderText = "PRODUCT ID";
            this.gridcol_product.Name = "gridcol_product";
            this.gridcol_product.Width = 150;
            // 
            // gridcol_descp
            // 
            this.gridcol_descp.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcol_descp.HeaderText = "DESCRIPTION";
            this.gridcol_descp.Name = "gridcol_descp";
            this.gridcol_descp.Width = 400;
            // 
            // gridcol_category
            // 
            this.gridcol_category.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcol_category.HeaderText = "CATEGORY";
            this.gridcol_category.Name = "gridcol_category";
            this.gridcol_category.Width = 150;
            // 
            // gridcol_client
            // 
            this.gridcol_client.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcol_client.HeaderText = "CLIENT";
            this.gridcol_client.Name = "gridcol_client";
            // 
            // gridcol_id
            // 
            this.gridcol_id.Name = "gridcol_id";
            this.gridcol_id.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 530);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnPrintPreview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 530);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 69);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(774, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 55);
            this.button1.TabIndex = 27;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrintPreview.BackColor = System.Drawing.Color.Lime;
            this.btnPrintPreview.Location = new System.Drawing.Point(650, 5);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(120, 55);
            this.btnPrintPreview.TabIndex = 28;
            this.btnPrintPreview.Text = "Add New Product";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Visible = false;
            // 
            // ProductMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 599);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Master";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl grd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcol_product;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcol_descp;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcol_category;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcol_client;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPrintPreview;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcol_id;
    }
}