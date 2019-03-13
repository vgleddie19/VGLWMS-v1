namespace WMS
{
    partial class MenuWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuWindow));
            this.btnAddReceipt = new System.Windows.Forms.Button();
            this.btnNewPutaway = new System.Windows.Forms.Button();
            this.btnConfirmPutaway = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnPicklist = new System.Windows.Forms.Button();
            this.btnConfirmPicklist = new System.Windows.Forms.Button();
            this.btnForResolution = new System.Windows.Forms.Button();
            this.btnReleasing = new System.Windows.Forms.Button();
            this.btnPhysicalCount = new System.Windows.Forms.Button();
            this.btnDeclarePhysicalCou = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNewBinReplishment = new System.Windows.Forms.Button();
            this.btnConfirmCaseBreak = new System.Windows.Forms.Button();
            this.btnStockCheck = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPutawayCancelledPallet = new System.Windows.Forms.Button();
            this.btnForOrderResolutions = new System.Windows.Forms.Button();
            this.btnBadStockDeclarations = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LocationInventoryTab = new System.Windows.Forms.TabPage();
            this.grid = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnLoad = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.LocationInventoryTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddReceipt
            // 
            this.btnAddReceipt.BackColor = System.Drawing.Color.Chartreuse;
            this.btnAddReceipt.Location = new System.Drawing.Point(11, 23);
            this.btnAddReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddReceipt.Name = "btnAddReceipt";
            this.btnAddReceipt.Size = new System.Drawing.Size(114, 33);
            this.btnAddReceipt.TabIndex = 0;
            this.btnAddReceipt.Text = "New Receipt";
            this.btnAddReceipt.UseVisualStyleBackColor = false;
            this.btnAddReceipt.Click += new System.EventHandler(this.btnAddReceipt_Click);
            // 
            // btnNewPutaway
            // 
            this.btnNewPutaway.BackColor = System.Drawing.Color.LightGreen;
            this.btnNewPutaway.Location = new System.Drawing.Point(11, 60);
            this.btnNewPutaway.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewPutaway.Name = "btnNewPutaway";
            this.btnNewPutaway.Size = new System.Drawing.Size(114, 33);
            this.btnNewPutaway.TabIndex = 1;
            this.btnNewPutaway.Text = "New Putaway";
            this.btnNewPutaway.UseVisualStyleBackColor = false;
            this.btnNewPutaway.Click += new System.EventHandler(this.btnNewPutaway_Click);
            // 
            // btnConfirmPutaway
            // 
            this.btnConfirmPutaway.BackColor = System.Drawing.Color.PaleGreen;
            this.btnConfirmPutaway.Location = new System.Drawing.Point(11, 97);
            this.btnConfirmPutaway.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmPutaway.Name = "btnConfirmPutaway";
            this.btnConfirmPutaway.Size = new System.Drawing.Size(114, 33);
            this.btnConfirmPutaway.TabIndex = 2;
            this.btnConfirmPutaway.Text = "Confirm Putaway";
            this.btnConfirmPutaway.UseVisualStyleBackColor = false;
            this.btnConfirmPutaway.Click += new System.EventHandler(this.btnConfirmPutaway_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.BackColor = System.Drawing.Color.OliveDrab;
            this.btnNewOrder.ForeColor = System.Drawing.Color.White;
            this.btnNewOrder.Location = new System.Drawing.Point(136, 23);
            this.btnNewOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(139, 33);
            this.btnNewOrder.TabIndex = 3;
            this.btnNewOrder.Text = "New Order from OMS";
            this.btnNewOrder.UseVisualStyleBackColor = false;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnPicklist
            // 
            this.btnPicklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPicklist.ForeColor = System.Drawing.Color.White;
            this.btnPicklist.Location = new System.Drawing.Point(292, 23);
            this.btnPicklist.Margin = new System.Windows.Forms.Padding(2);
            this.btnPicklist.Name = "btnPicklist";
            this.btnPicklist.Size = new System.Drawing.Size(139, 33);
            this.btnPicklist.TabIndex = 4;
            this.btnPicklist.Text = "New Picklist";
            this.btnPicklist.UseVisualStyleBackColor = false;
            this.btnPicklist.Click += new System.EventHandler(this.btnPicklist_Click);
            // 
            // btnConfirmPicklist
            // 
            this.btnConfirmPicklist.BackColor = System.Drawing.Color.Red;
            this.btnConfirmPicklist.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPicklist.Location = new System.Drawing.Point(292, 60);
            this.btnConfirmPicklist.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmPicklist.Name = "btnConfirmPicklist";
            this.btnConfirmPicklist.Size = new System.Drawing.Size(139, 33);
            this.btnConfirmPicklist.TabIndex = 5;
            this.btnConfirmPicklist.Text = "Confirm Picklist";
            this.btnConfirmPicklist.UseVisualStyleBackColor = false;
            this.btnConfirmPicklist.Click += new System.EventHandler(this.btnConfirmPicklist_Click);
            // 
            // btnForResolution
            // 
            this.btnForResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnForResolution.ForeColor = System.Drawing.Color.White;
            this.btnForResolution.Location = new System.Drawing.Point(139, 25);
            this.btnForResolution.Margin = new System.Windows.Forms.Padding(2);
            this.btnForResolution.Name = "btnForResolution";
            this.btnForResolution.Size = new System.Drawing.Size(139, 33);
            this.btnForResolution.TabIndex = 6;
            this.btnForResolution.Text = "For Resolutions - Stocks";
            this.btnForResolution.UseVisualStyleBackColor = false;
            this.btnForResolution.Click += new System.EventHandler(this.btnForResolution_Click);
            // 
            // btnReleasing
            // 
            this.btnReleasing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReleasing.ForeColor = System.Drawing.Color.White;
            this.btnReleasing.Location = new System.Drawing.Point(292, 97);
            this.btnReleasing.Margin = new System.Windows.Forms.Padding(2);
            this.btnReleasing.Name = "btnReleasing";
            this.btnReleasing.Size = new System.Drawing.Size(139, 33);
            this.btnReleasing.TabIndex = 7;
            this.btnReleasing.Text = "Release Stocks";
            this.btnReleasing.UseVisualStyleBackColor = false;
            this.btnReleasing.Click += new System.EventHandler(this.btnReleasing_Click);
            // 
            // btnPhysicalCount
            // 
            this.btnPhysicalCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPhysicalCount.Location = new System.Drawing.Point(22, 25);
            this.btnPhysicalCount.Margin = new System.Windows.Forms.Padding(2);
            this.btnPhysicalCount.Name = "btnPhysicalCount";
            this.btnPhysicalCount.Size = new System.Drawing.Size(107, 33);
            this.btnPhysicalCount.TabIndex = 8;
            this.btnPhysicalCount.Text = "Physical Count";
            this.btnPhysicalCount.UseVisualStyleBackColor = false;
            this.btnPhysicalCount.Click += new System.EventHandler(this.btnPhysicalCount_Click);
            // 
            // btnDeclarePhysicalCou
            // 
            this.btnDeclarePhysicalCou.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDeclarePhysicalCou.Location = new System.Drawing.Point(22, 69);
            this.btnDeclarePhysicalCou.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeclarePhysicalCou.Name = "btnDeclarePhysicalCou";
            this.btnDeclarePhysicalCou.Size = new System.Drawing.Size(107, 45);
            this.btnDeclarePhysicalCou.TabIndex = 11;
            this.btnDeclarePhysicalCou.Text = "Declare Physical Count";
            this.btnDeclarePhysicalCou.UseVisualStyleBackColor = false;
            this.btnDeclarePhysicalCou.Click += new System.EventHandler(this.btnDeclarePhysicalCou_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnNewBinReplishment);
            this.groupBox1.Controls.Add(this.btnConfirmCaseBreak);
            this.groupBox1.Controls.Add(this.btnStockCheck);
            this.groupBox1.Controls.Add(this.btnConfirmPutaway);
            this.groupBox1.Controls.Add(this.btnAddReceipt);
            this.groupBox1.Controls.Add(this.btnNewPutaway);
            this.groupBox1.Controls.Add(this.btnNewOrder);
            this.groupBox1.Controls.Add(this.btnPicklist);
            this.groupBox1.Controls.Add(this.btnReleasing);
            this.groupBox1.Controls.Add(this.btnConfirmPicklist);
            this.groupBox1.Location = new System.Drawing.Point(8, 439);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(456, 217);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regular Operations";
            // 
            // btnNewBinReplishment
            // 
            this.btnNewBinReplishment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNewBinReplishment.ForeColor = System.Drawing.Color.White;
            this.btnNewBinReplishment.Location = new System.Drawing.Point(11, 134);
            this.btnNewBinReplishment.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewBinReplishment.Name = "btnNewBinReplishment";
            this.btnNewBinReplishment.Size = new System.Drawing.Size(114, 38);
            this.btnNewBinReplishment.TabIndex = 9;
            this.btnNewBinReplishment.Text = "New Bin Replenishment";
            this.btnNewBinReplishment.UseVisualStyleBackColor = false;
            this.btnNewBinReplishment.Click += new System.EventHandler(this.btnNewCaseBreak_Click);
            // 
            // btnConfirmCaseBreak
            // 
            this.btnConfirmCaseBreak.BackColor = System.Drawing.Color.Red;
            this.btnConfirmCaseBreak.ForeColor = System.Drawing.Color.White;
            this.btnConfirmCaseBreak.Location = new System.Drawing.Point(11, 171);
            this.btnConfirmCaseBreak.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmCaseBreak.Name = "btnConfirmCaseBreak";
            this.btnConfirmCaseBreak.Size = new System.Drawing.Size(114, 40);
            this.btnConfirmCaseBreak.TabIndex = 10;
            this.btnConfirmCaseBreak.Text = "Confirm Case Break";
            this.btnConfirmCaseBreak.UseVisualStyleBackColor = false;
            this.btnConfirmCaseBreak.Click += new System.EventHandler(this.btnConfirmCaseBreak_Click);
            // 
            // btnStockCheck
            // 
            this.btnStockCheck.BackColor = System.Drawing.Color.OliveDrab;
            this.btnStockCheck.ForeColor = System.Drawing.Color.White;
            this.btnStockCheck.Location = new System.Drawing.Point(136, 60);
            this.btnStockCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnStockCheck.Name = "btnStockCheck";
            this.btnStockCheck.Size = new System.Drawing.Size(139, 33);
            this.btnStockCheck.TabIndex = 8;
            this.btnStockCheck.Text = "Stock Check OMS";
            this.btnStockCheck.UseVisualStyleBackColor = false;
            this.btnStockCheck.Click += new System.EventHandler(this.btnStockCheck_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnPutawayCancelledPallet);
            this.groupBox2.Controls.Add(this.btnForOrderResolutions);
            this.groupBox2.Controls.Add(this.btnBadStockDeclarations);
            this.groupBox2.Controls.Add(this.btnDeclarePhysicalCou);
            this.groupBox2.Controls.Add(this.btnForResolution);
            this.groupBox2.Controls.Add(this.btnPhysicalCount);
            this.groupBox2.Location = new System.Drawing.Point(468, 439);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(482, 217);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inventory Audits";
            // 
            // btnPutawayCancelledPallet
            // 
            this.btnPutawayCancelledPallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPutawayCancelledPallet.ForeColor = System.Drawing.Color.White;
            this.btnPutawayCancelledPallet.Location = new System.Drawing.Point(288, 69);
            this.btnPutawayCancelledPallet.Margin = new System.Windows.Forms.Padding(2);
            this.btnPutawayCancelledPallet.Name = "btnPutawayCancelledPallet";
            this.btnPutawayCancelledPallet.Size = new System.Drawing.Size(172, 45);
            this.btnPutawayCancelledPallet.TabIndex = 14;
            this.btnPutawayCancelledPallet.Text = "Putaway Cancelled Pallet";
            this.btnPutawayCancelledPallet.UseVisualStyleBackColor = false;
            this.btnPutawayCancelledPallet.Click += new System.EventHandler(this.btnPutawayCancelledPallet_Click);
            // 
            // btnForOrderResolutions
            // 
            this.btnForOrderResolutions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnForOrderResolutions.ForeColor = System.Drawing.Color.White;
            this.btnForOrderResolutions.Location = new System.Drawing.Point(139, 69);
            this.btnForOrderResolutions.Margin = new System.Windows.Forms.Padding(2);
            this.btnForOrderResolutions.Name = "btnForOrderResolutions";
            this.btnForOrderResolutions.Size = new System.Drawing.Size(139, 45);
            this.btnForOrderResolutions.TabIndex = 13;
            this.btnForOrderResolutions.Text = "For Resolutions - Orders";
            this.btnForOrderResolutions.UseVisualStyleBackColor = false;
            this.btnForOrderResolutions.Click += new System.EventHandler(this.btnForOrderResolutions_Click);
            // 
            // btnBadStockDeclarations
            // 
            this.btnBadStockDeclarations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBadStockDeclarations.ForeColor = System.Drawing.Color.White;
            this.btnBadStockDeclarations.Location = new System.Drawing.Point(288, 25);
            this.btnBadStockDeclarations.Margin = new System.Windows.Forms.Padding(2);
            this.btnBadStockDeclarations.Name = "btnBadStockDeclarations";
            this.btnBadStockDeclarations.Size = new System.Drawing.Size(172, 33);
            this.btnBadStockDeclarations.TabIndex = 12;
            this.btnBadStockDeclarations.Text = "Bad Stock Declarations";
            this.btnBadStockDeclarations.UseVisualStyleBackColor = false;
            this.btnBadStockDeclarations.Click += new System.EventHandler(this.btnBadStockDeclarations_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.LocationInventoryTab);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(8, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1131, 421);
            this.tabControl1.TabIndex = 14;
            // 
            // LocationInventoryTab
            // 
            this.LocationInventoryTab.Controls.Add(this.grid);
            this.LocationInventoryTab.Controls.Add(this.btnLoad);
            this.LocationInventoryTab.Controls.Add(this.comboBox1);
            this.LocationInventoryTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationInventoryTab.ImageKey = "shelf.png";
            this.LocationInventoryTab.Location = new System.Drawing.Point(4, 47);
            this.LocationInventoryTab.Margin = new System.Windows.Forms.Padding(2);
            this.LocationInventoryTab.Name = "LocationInventoryTab";
            this.LocationInventoryTab.Size = new System.Drawing.Size(1123, 370);
            this.LocationInventoryTab.TabIndex = 0;
            this.LocationInventoryTab.Text = "My Inventory";
            this.LocationInventoryTab.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.grid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.grid.Location = new System.Drawing.Point(9, 44);
            this.grid.Name = "grid";
            // 
            // 
            // 
            this.grid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.grid.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.grid.PrimaryGrid.ShowTreeButtons = true;
            this.grid.PrimaryGrid.ShowTreeLines = true;
            this.grid.PrimaryGrid.UseAlternateColumnStyle = true;
            this.grid.PrimaryGrid.UseAlternateRowStyle = true;
            this.grid.Size = new System.Drawing.Size(1105, 326);
            this.grid.TabIndex = 4;
            this.grid.Text = "superGridControl1";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Cyan;
            this.btnLoad.Location = new System.Drawing.Point(228, 16);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(71, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Items per Location",
            "Detailed Items per Location"});
            this.comboBox1.Location = new System.Drawing.Point(9, 18);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "shelf.png");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(954, 439);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Reports";
            // 
            // cmbReports
            // 
            this.cmbReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Items.AddRange(new object[] {
            "PHYSICAL COUNT CALENDAR",
            "STOCKS AGE REPORT"});
            this.cmbReports.Location = new System.Drawing.Point(957, 454);
            this.cmbReports.Margin = new System.Windows.Forms.Padding(2);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(188, 21);
            this.cmbReports.TabIndex = 16;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnViewReport.Location = new System.Drawing.Point(957, 477);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(187, 33);
            this.btnViewReport.TabIndex = 15;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // MenuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 676);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.cmbReports);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuWindow_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.LocationInventoryTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddReceipt;
        private System.Windows.Forms.Button btnNewPutaway;
        private System.Windows.Forms.Button btnConfirmPutaway;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnPicklist;
        private System.Windows.Forms.Button btnConfirmPicklist;
        private System.Windows.Forms.Button btnForResolution;
        private System.Windows.Forms.Button btnReleasing;
        private System.Windows.Forms.Button btnPhysicalCount;
        private System.Windows.Forms.Button btnDeclarePhysicalCou;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LocationInventoryTab;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnBadStockDeclarations;
        private System.Windows.Forms.Button btnForOrderResolutions;
        private System.Windows.Forms.Button btnPutawayCancelledPallet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnStockCheck;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl grid;
        private System.Windows.Forms.Button btnNewBinReplishment;
        private System.Windows.Forms.Button btnConfirmCaseBreak;
    }
}