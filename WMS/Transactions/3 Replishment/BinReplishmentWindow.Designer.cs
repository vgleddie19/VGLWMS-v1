namespace WMS
{
    partial class BinReplishmentWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabcontrol = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gencasebreakgrid = new System.Windows.Forms.DataGridView();
            this.gridcolcasebreak_loc = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcolcasebreak_prod = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcolcasebreak_uom = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcolcasebreak_lot = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcolcasebreak_expiry = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcolcasebreak_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.genpickgrid = new System.Windows.Forms.DataGridView();
            this.gridcolloc = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcolprod = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcoluom = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcollot = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcolexpiry = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.gridcolqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btngendocs = new System.Windows.Forms.Button();
            this.tabgenpick = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.headerGrid = new System.Windows.Forms.DataGridView();
            this.tabdashboard = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.gridreplenish = new System.Windows.Forms.DataGridView();
            this.tablistreplenish = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.gridcasebreak = new System.Windows.Forms.DataGridView();
            this.tablistcasebreak = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.grdpick = new System.Windows.Forms.DataGridView();
            this.tablistpick = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabcontrol)).BeginInit();
            this.tabcontrol.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gencasebreakgrid)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genpickgrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).BeginInit();
            this.superTabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridreplenish)).BeginInit();
            this.superTabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridcasebreak)).BeginInit();
            this.superTabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpick)).BeginInit();
            this.SuspendLayout();
            // 
            // tabcontrol
            // 
            this.tabcontrol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabcontrol.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabcontrol.ControlBox.MenuBox.Name = "";
            this.tabcontrol.ControlBox.Name = "";
            this.tabcontrol.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabcontrol.ControlBox.MenuBox,
            this.tabcontrol.ControlBox.CloseBox});
            this.tabcontrol.Controls.Add(this.superTabControlPanel1);
            this.tabcontrol.Controls.Add(this.superTabControlPanel2);
            this.tabcontrol.Controls.Add(this.superTabControlPanel5);
            this.tabcontrol.Controls.Add(this.superTabControlPanel4);
            this.tabcontrol.Controls.Add(this.superTabControlPanel3);
            this.tabcontrol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabcontrol.FixedTabSize = new System.Drawing.Size(110, 80);
            this.tabcontrol.Location = new System.Drawing.Point(12, 12);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.ReorderTabsEnabled = true;
            this.tabcontrol.SelectedTabFont = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabcontrol.SelectedTabIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(1060, 694);
            this.tabcontrol.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.tabcontrol.TabFont = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabcontrol.TabIndex = 0;
            this.tabcontrol.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabdashboard,
            this.tablistpick,
            this.tablistcasebreak,
            this.tablistreplenish,
            this.tabgenpick});
            this.tabcontrol.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OfficeMobile2014;
            this.tabcontrol.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.tabcontrol.TabItemClose += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs>(this.utabControl1_TabItemClose);
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.panel4);
            this.superTabControlPanel2.Controls.Add(this.panel2);
            this.superTabControlPanel2.Controls.Add(this.panel3);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(948, 694);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabgenpick;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(12, 317);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(923, 311);
            this.panel4.TabIndex = 48;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gencasebreakgrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 265);
            this.panel1.TabIndex = 51;
            // 
            // gencasebreakgrid
            // 
            this.gencasebreakgrid.AllowUserToAddRows = false;
            this.gencasebreakgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gencasebreakgrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gencasebreakgrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gencasebreakgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gencasebreakgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridcolcasebreak_loc,
            this.gridcolcasebreak_prod,
            this.gridcolcasebreak_uom,
            this.gridcolcasebreak_lot,
            this.gridcolcasebreak_expiry,
            this.gridcolcasebreak_qty});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gencasebreakgrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.gencasebreakgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gencasebreakgrid.Location = new System.Drawing.Point(0, 0);
            this.gencasebreakgrid.Margin = new System.Windows.Forms.Padding(2);
            this.gencasebreakgrid.Name = "gencasebreakgrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gencasebreakgrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gencasebreakgrid.RowHeadersWidth = 40;
            this.gencasebreakgrid.RowTemplate.Height = 150;
            this.gencasebreakgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gencasebreakgrid.Size = new System.Drawing.Size(923, 265);
            this.gencasebreakgrid.StandardTab = true;
            this.gencasebreakgrid.TabIndex = 37;
            this.gencasebreakgrid.TabStop = false;
            // 
            // gridcolcasebreak_loc
            // 
            this.gridcolcasebreak_loc.HeaderText = "Location";
            this.gridcolcasebreak_loc.Name = "gridcolcasebreak_loc";
            this.gridcolcasebreak_loc.WordWrap = true;
            // 
            // gridcolcasebreak_prod
            // 
            this.gridcolcasebreak_prod.HeaderText = "Product";
            this.gridcolcasebreak_prod.Name = "gridcolcasebreak_prod";
            this.gridcolcasebreak_prod.TextAlignment = System.Drawing.StringAlignment.Center;
            this.gridcolcasebreak_prod.WordWrap = true;
            // 
            // gridcolcasebreak_uom
            // 
            this.gridcolcasebreak_uom.HeaderText = "UOM";
            this.gridcolcasebreak_uom.Name = "gridcolcasebreak_uom";
            this.gridcolcasebreak_uom.TextAlignment = System.Drawing.StringAlignment.Center;
            this.gridcolcasebreak_uom.WordWrap = true;
            // 
            // gridcolcasebreak_lot
            // 
            this.gridcolcasebreak_lot.HeaderText = "Lot Number";
            this.gridcolcasebreak_lot.Name = "gridcolcasebreak_lot";
            this.gridcolcasebreak_lot.TextAlignment = System.Drawing.StringAlignment.Center;
            this.gridcolcasebreak_lot.WordWrap = true;
            // 
            // gridcolcasebreak_expiry
            // 
            this.gridcolcasebreak_expiry.HeaderText = "Date Expire";
            this.gridcolcasebreak_expiry.Name = "gridcolcasebreak_expiry";
            this.gridcolcasebreak_expiry.TextAlignment = System.Drawing.StringAlignment.Center;
            this.gridcolcasebreak_expiry.WordWrap = true;
            // 
            // gridcolcasebreak_qty
            // 
            this.gridcolcasebreak_qty.HeaderText = "Quantity Pick";
            this.gridcolcasebreak_qty.Name = "gridcolcasebreak_qty";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(923, 46);
            this.label1.TabIndex = 50;
            this.label1.Text = "Case Break";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.genpickgrid);
            this.panel2.Location = new System.Drawing.Point(12, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(923, 292);
            this.panel2.TabIndex = 46;
            // 
            // genpickgrid
            // 
            this.genpickgrid.AllowUserToAddRows = false;
            this.genpickgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.genpickgrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.genpickgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.genpickgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridcolloc,
            this.gridcolprod,
            this.gridcoluom,
            this.gridcollot,
            this.gridcolexpiry,
            this.gridcolqty});
            this.genpickgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genpickgrid.Location = new System.Drawing.Point(0, 0);
            this.genpickgrid.Margin = new System.Windows.Forms.Padding(2);
            this.genpickgrid.Name = "genpickgrid";
            this.genpickgrid.RowHeadersWidth = 40;
            this.genpickgrid.RowTemplate.Height = 150;
            this.genpickgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.genpickgrid.Size = new System.Drawing.Size(923, 292);
            this.genpickgrid.StandardTab = true;
            this.genpickgrid.TabIndex = 37;
            this.genpickgrid.TabStop = false;
            // 
            // gridcolloc
            // 
            this.gridcolloc.HeaderText = "Location";
            this.gridcolloc.Name = "gridcolloc";
            this.gridcolloc.TextAlignment = System.Drawing.StringAlignment.Center;
            this.gridcolloc.WordWrap = true;
            // 
            // gridcolprod
            // 
            this.gridcolprod.HeaderText = "Product";
            this.gridcolprod.Name = "gridcolprod";
            this.gridcolprod.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // gridcoluom
            // 
            this.gridcoluom.HeaderText = "UOM";
            this.gridcoluom.Name = "gridcoluom";
            this.gridcoluom.TextAlignment = System.Drawing.StringAlignment.Center;
            this.gridcoluom.WordWrap = true;
            // 
            // gridcollot
            // 
            this.gridcollot.HeaderText = "Lot Number";
            this.gridcollot.Name = "gridcollot";
            this.gridcollot.TextAlignment = System.Drawing.StringAlignment.Center;
            this.gridcollot.WordWrap = true;
            // 
            // gridcolexpiry
            // 
            this.gridcolexpiry.HeaderText = "Date Expire";
            this.gridcolexpiry.Name = "gridcolexpiry";
            this.gridcolexpiry.TextAlignment = System.Drawing.StringAlignment.Center;
            this.gridcolexpiry.WordWrap = true;
            // 
            // gridcolqty
            // 
            this.gridcolqty.HeaderText = "Quantity Pick";
            this.gridcolqty.Name = "gridcolqty";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btngendocs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 636);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(948, 58);
            this.panel3.TabIndex = 43;
            // 
            // btngendocs
            // 
            this.btngendocs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btngendocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngendocs.ForeColor = System.Drawing.Color.White;
            this.btngendocs.Location = new System.Drawing.Point(811, 10);
            this.btngendocs.Name = "btngendocs";
            this.btngendocs.Size = new System.Drawing.Size(124, 48);
            this.btngendocs.TabIndex = 38;
            this.btngendocs.Text = "Generate Documents";
            this.btngendocs.UseVisualStyleBackColor = false;
            this.btngendocs.Click += new System.EventHandler(this.btngendocs_Click);
            // 
            // tabgenpick
            // 
            this.tabgenpick.AttachedControl = this.superTabControlPanel2;
            this.tabgenpick.GlobalItem = false;
            this.tabgenpick.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.tabgenpick.Name = "tabgenpick";
            this.tabgenpick.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac;
            this.tabgenpick.Text = "Generate\nDocuments";
            this.tabgenpick.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.tabgenpick.Visible = false;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.headerGrid);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(948, 694);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabdashboard;
            // 
            // headerGrid
            // 
            this.headerGrid.AllowUserToAddRows = false;
            this.headerGrid.AllowUserToDeleteRows = false;
            this.headerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.headerGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.headerGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.headerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.headerGrid.ColumnHeadersHeight = 80;
            this.headerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGrid.Location = new System.Drawing.Point(0, 0);
            this.headerGrid.Margin = new System.Windows.Forms.Padding(2);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.Size = new System.Drawing.Size(948, 694);
            this.headerGrid.StandardTab = true;
            this.headerGrid.TabIndex = 36;
            this.headerGrid.TabStop = false;
            this.headerGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.headerGrid_CellClick);
            this.headerGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.headerGrid_CellValueChanged);
            // 
            // tabdashboard
            // 
            this.tabdashboard.AttachedControl = this.superTabControlPanel1;
            this.tabdashboard.GlobalItem = false;
            this.tabdashboard.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.tabdashboard.Name = "tabdashboard";
            this.tabdashboard.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Coral;
            this.tabdashboard.Text = "Dashboard";
            this.tabdashboard.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.gridreplenish);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(948, 694);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.tablistreplenish;
            // 
            // gridreplenish
            // 
            this.gridreplenish.AllowUserToAddRows = false;
            this.gridreplenish.AllowUserToDeleteRows = false;
            this.gridreplenish.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridreplenish.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(185)))), ((int)(((byte)(177)))));
            this.gridreplenish.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridreplenish.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gridreplenish.ColumnHeadersHeight = 80;
            this.gridreplenish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridreplenish.Location = new System.Drawing.Point(0, 0);
            this.gridreplenish.Margin = new System.Windows.Forms.Padding(2);
            this.gridreplenish.Name = "gridreplenish";
            this.gridreplenish.ReadOnly = true;
            this.gridreplenish.RowTemplate.Height = 28;
            this.gridreplenish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridreplenish.Size = new System.Drawing.Size(948, 694);
            this.gridreplenish.StandardTab = true;
            this.gridreplenish.TabIndex = 37;
            this.gridreplenish.TabStop = false;
            // 
            // tablistreplenish
            // 
            this.tablistreplenish.AttachedControl = this.superTabControlPanel5;
            this.tablistreplenish.GlobalItem = false;
            this.tablistreplenish.Name = "tablistreplenish";
            this.tablistreplenish.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue;
            this.tablistreplenish.Text = "List\nof\nReplenish";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.gridcasebreak);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(948, 694);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.tablistcasebreak;
            // 
            // gridcasebreak
            // 
            this.gridcasebreak.AllowUserToAddRows = false;
            this.gridcasebreak.AllowUserToDeleteRows = false;
            this.gridcasebreak.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridcasebreak.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(185)))), ((int)(((byte)(177)))));
            this.gridcasebreak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridcasebreak.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gridcasebreak.ColumnHeadersHeight = 80;
            this.gridcasebreak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridcasebreak.Location = new System.Drawing.Point(0, 0);
            this.gridcasebreak.Margin = new System.Windows.Forms.Padding(2);
            this.gridcasebreak.Name = "gridcasebreak";
            this.gridcasebreak.ReadOnly = true;
            this.gridcasebreak.RowTemplate.Height = 28;
            this.gridcasebreak.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridcasebreak.Size = new System.Drawing.Size(948, 694);
            this.gridcasebreak.StandardTab = true;
            this.gridcasebreak.TabIndex = 37;
            this.gridcasebreak.TabStop = false;
            // 
            // tablistcasebreak
            // 
            this.tablistcasebreak.AttachedControl = this.superTabControlPanel4;
            this.tablistcasebreak.GlobalItem = false;
            this.tablistcasebreak.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.tablistcasebreak.Name = "tablistcasebreak";
            this.tablistcasebreak.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Teal;
            this.tablistcasebreak.Text = "List\nof\nCaseBreak";
            this.tablistcasebreak.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.grdpick);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(112, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(948, 694);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tablistpick;
            // 
            // grdpick
            // 
            this.grdpick.AllowUserToAddRows = false;
            this.grdpick.AllowUserToDeleteRows = false;
            this.grdpick.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdpick.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(185)))), ((int)(((byte)(177)))));
            this.grdpick.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdpick.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grdpick.ColumnHeadersHeight = 80;
            this.grdpick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdpick.Location = new System.Drawing.Point(0, 0);
            this.grdpick.Margin = new System.Windows.Forms.Padding(2);
            this.grdpick.Name = "grdpick";
            this.grdpick.ReadOnly = true;
            this.grdpick.RowTemplate.Height = 28;
            this.grdpick.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdpick.Size = new System.Drawing.Size(948, 694);
            this.grdpick.StandardTab = true;
            this.grdpick.TabIndex = 37;
            this.grdpick.TabStop = false;
            // 
            // tablistpick
            // 
            this.tablistpick.AttachedControl = this.superTabControlPanel3;
            this.tablistpick.GlobalItem = false;
            this.tablistpick.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.tablistpick.Name = "tablistpick";
            this.tablistpick.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Apple;
            this.tablistpick.StartsNewTabLine = true;
            this.tablistpick.Text = "List\nof\nPicklist";
            this.tablistpick.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // BinReplishmentWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1084, 718);
            this.Controls.Add(this.tabcontrol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BinReplishmentWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bin Replishment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BinReplishmentWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabcontrol)).EndInit();
            this.tabcontrol.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gencasebreakgrid)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genpickgrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).EndInit();
            this.superTabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridreplenish)).EndInit();
            this.superTabControlPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridcasebreak)).EndInit();
            this.superTabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdpick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabdashboard;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem tablistcasebreak;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tablistpick;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tabgenpick;
        public System.Windows.Forms.DataGridView headerGrid;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.DataGridView gencasebreakgrid;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView genpickgrid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btngendocs;
        public DevComponents.DotNetBar.SuperTabControl tabcontrol;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private DevComponents.DotNetBar.SuperTabItem tablistreplenish;
        public System.Windows.Forms.DataGridView gridreplenish;
        public System.Windows.Forms.DataGridView gridcasebreak;
        public System.Windows.Forms.DataGridView grdpick;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcolcasebreak_loc;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcolcasebreak_prod;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcolcasebreak_uom;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcolcasebreak_lot;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcolcasebreak_expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolcasebreak_qty;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcolloc;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcolprod;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcoluom;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcollot;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn gridcolexpiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolqty;
    }
}