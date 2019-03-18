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
            this.headerGrid = new System.Windows.Forms.DataGridView();
            this.utabControl1 = new VGLHelper.CustomControls.utabControl();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.genproductpickgrid = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.genpickgrid = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.genpick = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btngenpick = new System.Windows.Forms.Button();
            this.btnrepbins = new System.Windows.Forms.Button();
            this.btnconpick = new System.Windows.Forms.Button();
            this.maintab = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.confirmpick = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_to_be_replenished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utabControl1)).BeginInit();
            this.utabControl1.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genproductpickgrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genpickgrid)).BeginInit();
            this.panel5.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGrid
            // 
            this.headerGrid.AllowUserToAddRows = false;
            this.headerGrid.AllowUserToDeleteRows = false;
            this.headerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.headerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.location,
            this.product,
            this.Uom,
            this.lot_no,
            this.Expiry,
            this.actual_qty,
            this.min_qty,
            this.qty_to_be_replenished,
            this.status});
            this.headerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGrid.Location = new System.Drawing.Point(0, 0);
            this.headerGrid.Margin = new System.Windows.Forms.Padding(2);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.ReadOnly = true;
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.Size = new System.Drawing.Size(1221, 713);
            this.headerGrid.StandardTab = true;
            this.headerGrid.TabIndex = 35;
            this.headerGrid.TabStop = false;
            // 
            // utabControl1
            // 
            this.utabControl1.AllowDrop = true;
            this.utabControl1.BorderColor = System.Drawing.Color.Empty;
            this.utabControl1.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.utabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.utabControl1.ControlBox.MenuBox.Name = "";
            this.utabControl1.ControlBox.Name = "";
            this.utabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.utabControl1.ControlBox.MenuBox,
            this.utabControl1.ControlBox.CloseBox});
            this.utabControl1.Controls.Add(this.superTabControlPanel1);
            this.utabControl1.Controls.Add(this.superTabControlPanel5);
            this.utabControl1.Controls.Add(this.superTabControlPanel3);
            this.utabControl1.Controls.Add(this.superTabControlPanel4);
            this.utabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.utabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utabControl1.FixedTabSize = new System.Drawing.Size(250, 50);
            this.utabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.utabControl1.InactiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(160)))));
            this.utabControl1.ItemPadding.Bottom = 10;
            this.utabControl1.ItemPadding.Left = 10;
            this.utabControl1.ItemPadding.Right = 10;
            this.utabControl1.ItemPadding.Top = 10;
            this.utabControl1.Location = new System.Drawing.Point(0, 0);
            this.utabControl1.Name = "utabControl1";
            this.utabControl1.ReorderTabsEnabled = true;
            this.utabControl1.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.utabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utabControl1.SelectedTabIndex = 0;
            this.utabControl1.ShowFocusRectangle = true;
            this.utabControl1.Size = new System.Drawing.Size(1221, 765);
            this.utabControl1.TabBackColor = System.Drawing.Color.White;
            this.utabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utabControl1.TabIndex = 41;
            this.utabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.maintab,
            this.genpick,
            this.confirmpick});
            this.utabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OfficeMobile2014;
            this.utabControl1.TabTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.utabControl1.Text = "utabControl1";
            this.utabControl1.TabItemClose += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs>(this.utabControl1_TabItemClose);
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.panel4);
            this.superTabControlPanel5.Controls.Add(this.panel3);
            this.superTabControlPanel5.Controls.Add(this.panel2);
            this.superTabControlPanel5.Controls.Add(this.panel5);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 52);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(1221, 713);
            this.superTabControlPanel5.TabIndex = 1;
            this.superTabControlPanel5.TabItem = this.genpick;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.genproductpickgrid);
            this.panel4.Location = new System.Drawing.Point(12, 351);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1197, 287);
            this.panel4.TabIndex = 38;
            // 
            // genproductpickgrid
            // 
            this.genproductpickgrid.AllowUserToDeleteRows = false;
            this.genproductpickgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.genproductpickgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.genproductpickgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genproductpickgrid.Location = new System.Drawing.Point(0, 0);
            this.genproductpickgrid.Margin = new System.Windows.Forms.Padding(2);
            this.genproductpickgrid.Name = "genproductpickgrid";
            this.genproductpickgrid.RowTemplate.Height = 28;
            this.genproductpickgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.genproductpickgrid.Size = new System.Drawing.Size(1197, 287);
            this.genproductpickgrid.StandardTab = true;
            this.genproductpickgrid.TabIndex = 37;
            this.genproductpickgrid.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 640);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1221, 73);
            this.panel3.TabIndex = 42;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(19, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 58);
            this.button1.TabIndex = 38;
            this.button1.Text = "Generate Pick List";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.genpickgrid);
            this.panel2.Location = new System.Drawing.Point(12, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1197, 287);
            this.panel2.TabIndex = 0;
            // 
            // genpickgrid
            // 
            this.genpickgrid.AllowUserToDeleteRows = false;
            this.genpickgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.genpickgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.genpickgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genpickgrid.Location = new System.Drawing.Point(0, 0);
            this.genpickgrid.Margin = new System.Windows.Forms.Padding(2);
            this.genpickgrid.Name = "genpickgrid";
            this.genpickgrid.RowTemplate.Height = 28;
            this.genpickgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.genpickgrid.Size = new System.Drawing.Size(1197, 287);
            this.genpickgrid.StandardTab = true;
            this.genpickgrid.TabIndex = 37;
            this.genpickgrid.TabStop = false;
            this.genpickgrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.genpickgrid_CellValueChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button2);
            this.panel5.Location = new System.Drawing.Point(12, 287);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1197, 73);
            this.panel5.TabIndex = 43;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(7, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 58);
            this.button2.TabIndex = 39;
            this.button2.Text = "Add to Pick List";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // genpick
            // 
            this.genpick.AttachedControl = this.superTabControlPanel5;
            this.genpick.GlobalItem = false;
            this.genpick.Name = "genpick";
            this.genpick.Text = "Generate PickList";
            this.genpick.Visible = false;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.panel1);
            this.superTabControlPanel1.Controls.Add(this.headerGrid);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 52);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1221, 713);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.maintab;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btngenpick);
            this.panel1.Controls.Add(this.btnrepbins);
            this.panel1.Controls.Add(this.btnconpick);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 640);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 73);
            this.panel1.TabIndex = 41;
            // 
            // btngenpick
            // 
            this.btngenpick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btngenpick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenpick.ForeColor = System.Drawing.Color.White;
            this.btngenpick.Location = new System.Drawing.Point(19, 8);
            this.btngenpick.Name = "btngenpick";
            this.btngenpick.Size = new System.Drawing.Size(180, 58);
            this.btngenpick.TabIndex = 38;
            this.btngenpick.Text = "Generate Pick List";
            this.btngenpick.UseVisualStyleBackColor = false;
            this.btngenpick.Click += new System.EventHandler(this.btngenpick_Click);
            // 
            // btnrepbins
            // 
            this.btnrepbins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnrepbins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrepbins.ForeColor = System.Drawing.Color.White;
            this.btnrepbins.Location = new System.Drawing.Point(400, 8);
            this.btnrepbins.Name = "btnrepbins";
            this.btnrepbins.Size = new System.Drawing.Size(188, 58);
            this.btnrepbins.TabIndex = 39;
            this.btnrepbins.Text = "Confirm Replenish Bins";
            this.btnrepbins.UseVisualStyleBackColor = false;
            // 
            // btnconpick
            // 
            this.btnconpick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnconpick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconpick.ForeColor = System.Drawing.Color.White;
            this.btnconpick.Location = new System.Drawing.Point(205, 8);
            this.btnconpick.Name = "btnconpick";
            this.btnconpick.Size = new System.Drawing.Size(189, 58);
            this.btnconpick.TabIndex = 36;
            this.btnconpick.Text = "Generate Confirm Pick List";
            this.btnconpick.UseVisualStyleBackColor = false;
            this.btnconpick.Click += new System.EventHandler(this.btnconpick_Click);
            // 
            // maintab
            // 
            this.maintab.AttachedControl = this.superTabControlPanel1;
            this.maintab.CloseButtonVisible = false;
            this.maintab.FixedTabSize = new System.Drawing.Size(250, 50);
            this.maintab.GlobalItem = false;
            this.maintab.ImagePadding.Bottom = 10;
            this.maintab.ImagePadding.Left = 20;
            this.maintab.ImagePadding.Top = 10;
            this.maintab.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.maintab.Name = "maintab";
            this.maintab.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintab.Symbol = "";
            this.maintab.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.maintab.SymbolSize = 25F;
            this.maintab.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintab.Text = "Main Panel";
            this.maintab.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 52);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(1221, 713);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.confirmpick;
            // 
            // confirmpick
            // 
            this.confirmpick.AttachedControl = this.superTabControlPanel3;
            this.confirmpick.GlobalItem = false;
            this.confirmpick.Name = "confirmpick";
            this.confirmpick.Text = "Confirm PickList";
            this.confirmpick.Visible = false;
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(1221, 765);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.confirmpick;
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1221, 52);
            this.superTabControlPanel2.TabIndex = 0;
            // 
            // location
            // 
            this.location.HeaderText = "BIN Location";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // product
            // 
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            // 
            // Uom
            // 
            this.Uom.HeaderText = "Uom";
            this.Uom.Name = "Uom";
            this.Uom.ReadOnly = true;
            // 
            // lot_no
            // 
            this.lot_no.HeaderText = "Lot No";
            this.lot_no.Name = "lot_no";
            this.lot_no.ReadOnly = true;
            // 
            // Expiry
            // 
            this.Expiry.HeaderText = "expiry";
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            // 
            // actual_qty
            // 
            this.actual_qty.HeaderText = "Actual Qty";
            this.actual_qty.Name = "actual_qty";
            this.actual_qty.ReadOnly = true;
            // 
            // min_qty
            // 
            this.min_qty.HeaderText = "Minimum Qty";
            this.min_qty.Name = "min_qty";
            this.min_qty.ReadOnly = true;
            // 
            // qty_to_be_replenished
            // 
            this.qty_to_be_replenished.HeaderText = "Qty To Be Replenished";
            this.qty_to_be_replenished.Name = "qty_to_be_replenished";
            this.qty_to_be_replenished.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // BinReplishmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 765);
            this.Controls.Add(this.utabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BinReplishmentWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bin Replishment";
            this.Load += new System.EventHandler(this.BinReplishmentWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utabControl1)).EndInit();
            this.utabControl1.ResumeLayout(false);
            this.superTabControlPanel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genproductpickgrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genpickgrid)).EndInit();
            this.panel5.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView headerGrid;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem maintab;
        public VGLHelper.CustomControls.utabControl utabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem confirmpick;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private DevComponents.DotNetBar.SuperTabItem genpick;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btngenpick;
        private System.Windows.Forms.Button btnrepbins;
        private System.Windows.Forms.Button btnconpick;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView genpickgrid;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.DataGridView genproductpickgrid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn min_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_to_be_replenished;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}