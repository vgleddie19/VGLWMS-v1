namespace WMS
{
    partial class reportform
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
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding2 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            this.pnlIncomingExtra = new System.Windows.Forms.Panel();
            this.grd_incoming = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.recextra_rrno = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.recextra_shippingid = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.recextra_receivedfrom = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.recextra_receivedon = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.recextra_refno = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.recextra_refdate = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.recextra_action = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlIncomingExtra.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlIncomingExtra
            // 
            this.pnlIncomingExtra.Controls.Add(this.grd_incoming);
            this.pnlIncomingExtra.Controls.Add(this.panel1);
            this.pnlIncomingExtra.Location = new System.Drawing.Point(12, 12);
            this.pnlIncomingExtra.Name = "pnlIncomingExtra";
            this.pnlIncomingExtra.Size = new System.Drawing.Size(988, 534);
            this.pnlIncomingExtra.TabIndex = 1;
            // 
            // grd_incoming
            // 
            this.grd_incoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_incoming.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.grd_incoming.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.grd_incoming.Location = new System.Drawing.Point(0, 0);
            this.grd_incoming.Name = "grd_incoming";
            // 
            // 
            // 
            this.grd_incoming.PrimaryGrid.Columns.Add(this.recextra_rrno);
            this.grd_incoming.PrimaryGrid.Columns.Add(this.recextra_shippingid);
            this.grd_incoming.PrimaryGrid.Columns.Add(this.recextra_receivedfrom);
            this.grd_incoming.PrimaryGrid.Columns.Add(this.recextra_receivedon);
            this.grd_incoming.PrimaryGrid.Columns.Add(this.recextra_refno);
            this.grd_incoming.PrimaryGrid.Columns.Add(this.recextra_refdate);
            this.grd_incoming.PrimaryGrid.Columns.Add(this.recextra_action);
            this.grd_incoming.PrimaryGrid.DefaultRowHeight = 40;
            padding1.Bottom = 3;
            padding1.Top = 3;
            this.grd_incoming.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Padding = padding1;
            padding2.Bottom = 10;
            padding2.Top = 10;
            this.grd_incoming.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Padding = padding2;
            this.grd_incoming.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.grd_incoming.PrimaryGrid.EnableColumnFiltering = true;
            this.grd_incoming.PrimaryGrid.EnableFiltering = true;
            this.grd_incoming.PrimaryGrid.EnableRowFiltering = true;
            this.grd_incoming.PrimaryGrid.EnsureVisibleAfterSort = true;
            this.grd_incoming.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Square;
            // 
            // 
            // 
            this.grd_incoming.PrimaryGrid.Filter.Visible = true;
            this.grd_incoming.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.grd_incoming.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.grd_incoming.PrimaryGrid.MultiSelect = false;
            this.grd_incoming.PrimaryGrid.NullString = " ";
            this.grd_incoming.PrimaryGrid.RowDoubleClickBehavior = DevComponents.DotNetBar.SuperGrid.RowDoubleClickBehavior.ExpandCollapse;
            this.grd_incoming.PrimaryGrid.RowHeaderWidth = 20;
            this.grd_incoming.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.grd_incoming.PrimaryGrid.ShowTreeButtons = true;
            this.grd_incoming.PrimaryGrid.ShowTreeLines = true;
            this.grd_incoming.PrimaryGrid.SortLevel = ((DevComponents.DotNetBar.SuperGrid.SortLevel)((DevComponents.DotNetBar.SuperGrid.SortLevel.Root | DevComponents.DotNetBar.SuperGrid.SortLevel.Expanded)));
            this.grd_incoming.PrimaryGrid.UseAlternateColumnStyle = true;
            this.grd_incoming.PrimaryGrid.UseAlternateRowStyle = true;
            this.grd_incoming.Size = new System.Drawing.Size(988, 477);
            this.grd_incoming.TabIndex = 6;
            this.grd_incoming.Text = "superGridControl1";
            this.grd_incoming.CellValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs>(this.grd_incoming_CellValueChanged);
            // 
            // recextra_rrno
            // 
            this.recextra_rrno.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.recextra_rrno.HeaderText = "RECEIVING NUMBER";
            this.recextra_rrno.Name = "recextra_rrno";
            // 
            // recextra_shippingid
            // 
            this.recextra_shippingid.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.recextra_shippingid.HeaderText = "TRANSACTION ID";
            this.recextra_shippingid.Name = "recextra_shippingid";
            this.recextra_shippingid.Width = 130;
            // 
            // recextra_receivedfrom
            // 
            this.recextra_receivedfrom.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.recextra_receivedfrom.HeaderText = "RECEIVED FROM";
            this.recextra_receivedfrom.Name = "recextra_receivedfrom";
            this.recextra_receivedfrom.Width = 300;
            // 
            // recextra_receivedon
            // 
            this.recextra_receivedon.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.recextra_receivedon.HeaderText = "RECEIVED ON";
            this.recextra_receivedon.Name = "recextra_receivedon";
            // 
            // recextra_refno
            // 
            this.recextra_refno.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.recextra_refno.HeaderText = "REFERENCE DOC. NUMBER";
            this.recextra_refno.Name = "recextra_refno";
            // 
            // recextra_refdate
            // 
            this.recextra_refdate.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.recextra_refdate.HeaderText = "REFERENCE DOC. DATE";
            this.recextra_refdate.Name = "recextra_refdate";
            // 
            // recextra_action
            // 
            this.recextra_action.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.recextra_action.HeaderText = " ";
            this.recextra_action.Name = "recextra_action";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 477);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 57);
            this.panel1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(844, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 46);
            this.button1.TabIndex = 16;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 557);
            this.ControlBox = false;
            this.Controls.Add(this.pnlIncomingExtra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "reportform";
            this.Text = "reportform";
            this.Load += new System.EventHandler(this.reportform_Load);
            this.pnlIncomingExtra.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIncomingExtra;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl grd_incoming;
        private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_rrno;
        private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_shippingid;
        private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_receivedfrom;
        private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_receivedon;
        private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_refno;
        private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_refdate;
        private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_action;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button button1;
    }
}