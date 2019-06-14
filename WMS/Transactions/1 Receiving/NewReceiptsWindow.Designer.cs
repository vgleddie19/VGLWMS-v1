namespace WMS
{
    partial class NewReceiptsWindow
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
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.headerGrid = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.cboreceivedfrom = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtrefno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtprefdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblclientadd = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboreceivedby = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpreceivedon = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.rbclient = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtrrno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtvanno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.txtshippername = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.product_id = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lineno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).BeginInit();
            this.panel16.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintPreview.BackColor = System.Drawing.Color.Lime;
            this.btnPrintPreview.Location = new System.Drawing.Point(872, 6);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(120, 55);
            this.btnPrintPreview.TabIndex = 15;
            this.btnPrintPreview.Text = "Proceed to Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(105, 291);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 38);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete Product";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.BackColor = System.Drawing.Color.SkyBlue;
            this.btnAdd.Location = new System.Drawing.Point(12, 291);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 37);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add Product";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // headerGrid
            // 
            this.headerGrid.AllowUserToAddRows = false;
            this.headerGrid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headerGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.headerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.headerGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.headerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.headerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.product,
            this.Quantity,
            this.uom,
            this.lot,
            this.expiry,
            this.remarks,
            this._lineno});
            this.headerGrid.Location = new System.Drawing.Point(11, 332);
            this.headerGrid.Margin = new System.Windows.Forms.Padding(2);
            this.headerGrid.Name = "headerGrid";
            this.headerGrid.RowTemplate.Height = 28;
            this.headerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerGrid.ShowRowErrors = false;
            this.headerGrid.Size = new System.Drawing.Size(981, 273);
            this.headerGrid.TabIndex = 13;
            this.headerGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.headerGrid_CellValueChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoad.BackColor = System.Drawing.Color.Yellow;
            this.btnLoad.ForeColor = System.Drawing.Color.Black;
            this.btnLoad.Location = new System.Drawing.Point(12, 11);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(98, 37);
            this.btnLoad.TabIndex = 29;
            this.btnLoad.Text = "Load Data From OMS";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(748, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 55);
            this.button1.TabIndex = 16;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel16
            // 
            this.panel16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel16.BackColor = System.Drawing.Color.White;
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.cboreceivedfrom);
            this.panel16.Controls.Add(this.label12);
            this.panel16.Location = new System.Drawing.Point(12, 196);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(416, 35);
            this.panel16.TabIndex = 4;
            this.panel16.TabStop = true;
            // 
            // cboreceivedfrom
            // 
            this.cboreceivedfrom.AutoCompleteCustomSource.AddRange(new string[] {
            "Replenishment",
            "Return from Trade",
            "Return from Delivery",
            "Stock Transfer"});
            this.cboreceivedfrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboreceivedfrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboreceivedfrom.Font = new System.Drawing.Font("Calibri", 13F);
            this.cboreceivedfrom.FormattingEnabled = true;
            this.cboreceivedfrom.Items.AddRange(new object[] {
            "Replenishment",
            "Return from Trade",
            "Return from Delivery",
            "Stock Transfer"});
            this.cboreceivedfrom.Location = new System.Drawing.Point(97, 2);
            this.cboreceivedfrom.Margin = new System.Windows.Forms.Padding(2);
            this.cboreceivedfrom.Name = "cboreceivedfrom";
            this.cboreceivedfrom.Size = new System.Drawing.Size(313, 29);
            this.cboreceivedfrom.TabIndex = 9;
            this.cboreceivedfrom.SelectedIndexChanged += new System.EventHandler(this.cboreceivedfrom_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Received From :";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtrefno);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(11, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 34);
            this.panel2.TabIndex = 2;
            this.panel2.TabStop = true;
            // 
            // txtrefno
            // 
            this.txtrefno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtrefno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtrefno.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrefno.Location = new System.Drawing.Point(114, 3);
            this.txtrefno.Margin = new System.Windows.Forms.Padding(2);
            this.txtrefno.Name = "txtrefno";
            this.txtrefno.Size = new System.Drawing.Size(292, 25);
            this.txtrefno.TabIndex = 5;
            this.txtrefno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reference Doc. Number :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dtprefdate);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(11, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 35);
            this.panel3.TabIndex = 3;
            this.panel3.TabStop = true;
            // 
            // dtprefdate
            // 
            this.dtprefdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtprefdate.Location = new System.Drawing.Point(102, 8);
            this.dtprefdate.Margin = new System.Windows.Forms.Padding(2);
            this.dtprefdate.Name = "dtprefdate";
            this.dtprefdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtprefdate.Size = new System.Drawing.Size(100, 20);
            this.dtprefdate.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "Reference Doc. Date :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lblclientadd);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Location = new System.Drawing.Point(12, 236);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(417, 52);
            this.panel8.TabIndex = 5;
            this.panel8.TabStop = true;
            // 
            // lblclientadd
            // 
            this.lblclientadd.BackColor = System.Drawing.Color.Gainsboro;
            this.lblclientadd.Font = new System.Drawing.Font("Calibri", 12F);
            this.lblclientadd.Location = new System.Drawing.Point(106, 0);
            this.lblclientadd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblclientadd.Name = "lblclientadd";
            this.lblclientadd.Size = new System.Drawing.Size(309, 49);
            this.lblclientadd.TabIndex = 7;
            this.lblclientadd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 36);
            this.label9.TabIndex = 4;
            this.label9.Text = "Received From Address :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboreceivedby);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(452, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 35);
            this.panel1.TabIndex = 8;
            this.panel1.TabStop = true;
            // 
            // cboreceivedby
            // 
            this.cboreceivedby.AutoCompleteCustomSource.AddRange(new string[] {
            "Replenishment",
            "Return from Trade",
            "Return from Delivery",
            "Stock Transfer"});
            this.cboreceivedby.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboreceivedby.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboreceivedby.Font = new System.Drawing.Font("Calibri", 13F);
            this.cboreceivedby.FormattingEnabled = true;
            this.cboreceivedby.Items.AddRange(new object[] {
            "Replenishment",
            "Return from Trade",
            "Return from Delivery",
            "Stock Transfer"});
            this.cboreceivedby.Location = new System.Drawing.Point(91, 2);
            this.cboreceivedby.Margin = new System.Windows.Forms.Padding(2);
            this.cboreceivedby.Name = "cboreceivedby";
            this.cboreceivedby.Size = new System.Drawing.Size(322, 29);
            this.cboreceivedby.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Received By :";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dtpreceivedon);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(452, 181);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 35);
            this.panel4.TabIndex = 9;
            this.panel4.TabStop = true;
            // 
            // dtpreceivedon
            // 
            this.dtpreceivedon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpreceivedon.Location = new System.Drawing.Point(102, 8);
            this.dtpreceivedon.Margin = new System.Windows.Forms.Padding(2);
            this.dtpreceivedon.Name = "dtpreceivedon";
            this.dtpreceivedon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpreceivedon.Size = new System.Drawing.Size(100, 20);
            this.dtpreceivedon.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Received On :";
            // 
            // rbclient
            // 
            this.rbclient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbclient.AutoSize = true;
            this.rbclient.Checked = true;
            this.rbclient.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbclient.Location = new System.Drawing.Point(12, 174);
            this.rbclient.Name = "rbclient";
            this.rbclient.Size = new System.Drawing.Size(149, 26);
            this.rbclient.TabIndex = 35;
            this.rbclient.TabStop = true;
            this.rbclient.Text = "Client List";
            this.rbclient.UseVisualStyleBackColor = true;
            this.rbclient.CheckedChanged += new System.EventHandler(this.rbclient_CheckedChanged);
            // 
            // rbCustomer
            // 
            this.rbCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomer.Location = new System.Drawing.Point(167, 174);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(171, 26);
            this.rbCustomer.TabIndex = 36;
            this.rbCustomer.TabStop = true;
            this.rbCustomer.Text = "Customer List";
            this.rbCustomer.UseVisualStyleBackColor = true;
            this.rbCustomer.CheckedChanged += new System.EventHandler(this.rbCustomer_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.txtrrno);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(11, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(416, 35);
            this.panel5.TabIndex = 1;
            this.panel5.TabStop = true;
            // 
            // txtrrno
            // 
            this.txtrrno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtrrno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtrrno.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrrno.Location = new System.Drawing.Point(114, 3);
            this.txtrrno.Margin = new System.Windows.Forms.Padding(2);
            this.txtrrno.Name = "txtrrno";
            this.txtrrno.Size = new System.Drawing.Size(292, 25);
            this.txtrrno.TabIndex = 5;
            this.txtrrno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Receiving Report Number:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel12);
            this.panel6.Controls.Add(this.panel15);
            this.panel6.Controls.Add(this.btnLoad);
            this.panel6.Controls.Add(this.headerGrid);
            this.panel6.Controls.Add(this.btnAdd);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.btnDelete);
            this.panel6.Controls.Add(this.panel16);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Controls.Add(this.rbclient);
            this.panel6.Controls.Add(this.rbCustomer);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1003, 610);
            this.panel6.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.txtvanno);
            this.panel12.Controls.Add(this.label7);
            this.panel12.Location = new System.Drawing.Point(452, 97);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(416, 38);
            this.panel12.TabIndex = 7;
            // 
            // txtvanno
            // 
            this.txtvanno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtvanno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtvanno.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvanno.Location = new System.Drawing.Point(90, 10);
            this.txtvanno.Margin = new System.Windows.Forms.Padding(2);
            this.txtvanno.Name = "txtvanno";
            this.txtvanno.Size = new System.Drawing.Size(313, 15);
            this.txtvanno.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Van Number :";
            // 
            // panel15
            // 
            this.panel15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel15.BackColor = System.Drawing.Color.White;
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.txtshippername);
            this.panel15.Controls.Add(this.label15);
            this.panel15.Location = new System.Drawing.Point(452, 53);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(416, 38);
            this.panel15.TabIndex = 6;
            // 
            // txtshippername
            // 
            this.txtshippername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtshippername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtshippername.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtshippername.Location = new System.Drawing.Point(114, 10);
            this.txtshippername.Margin = new System.Windows.Forms.Padding(2);
            this.txtshippername.Name = "txtshippername";
            this.txtshippername.Size = new System.Drawing.Size(291, 15);
            this.txtshippername.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 9);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 15);
            this.label15.TabIndex = 1;
            this.label15.Text = "Carrier Name :";
            // 
            // panel9
            // 
            this.panel9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.txtremarks);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Location = new System.Drawing.Point(452, 222);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(416, 66);
            this.panel9.TabIndex = 10;
            this.panel9.TabStop = true;
            // 
            // txtremarks
            // 
            this.txtremarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtremarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtremarks.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremarks.Location = new System.Drawing.Point(6, 20);
            this.txtremarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(397, 36);
            this.txtremarks.TabIndex = 5;
            this.txtremarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Remarks:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnPrintPreview);
            this.panel7.Controls.Add(this.button1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 610);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1003, 66);
            this.panel7.TabIndex = 14;
            // 
            // product_id
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.product_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.product_id.DropDownHeight = 106;
            this.product_id.DropDownWidth = 121;
            this.product_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.product_id.HeaderText = "Product Code";
            this.product_id.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.product_id.ItemHeight = 15;
            this.product_id.Name = "product_id";
            this.product_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.product_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // product
            // 
            this.product.HeaderText = "Product Description";
            this.product.Name = "product";
            this.product.Width = 250;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 80;
            // 
            // uom
            // 
            this.uom.HeaderText = "UOM";
            this.uom.Name = "uom";
            this.uom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.uom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.uom.Width = 80;
            // 
            // lot
            // 
            this.lot.HeaderText = "Lot #";
            this.lot.Name = "lot";
            // 
            // expiry
            // 
            this.expiry.HeaderText = "Expiry";
            this.expiry.Name = "expiry";
            this.expiry.Width = 80;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.Width = 200;
            // 
            // _lineno
            // 
            this._lineno.HeaderText = "line";
            this._lineno.Name = "_lineno";
            this._lineno.Visible = false;
            // 
            // NewReceiptsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 676);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewReceiptsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receive Stocks...";
            this.Load += new System.EventHandler(this.NewReceiptsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGrid)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView headerGrid;
        public System.Windows.Forms.ComboBox cboreceivedfrom;
        public System.Windows.Forms.TextBox txtrefno;
        public System.Windows.Forms.DateTimePicker dtprefdate;
        public System.Windows.Forms.ComboBox cboreceivedby;
        public System.Windows.Forms.DateTimePicker dtpreceivedon;
        public System.Windows.Forms.RadioButton rbclient;
        public System.Windows.Forms.RadioButton rbCustomer;
        public System.Windows.Forms.Label lblclientadd;
        public System.Windows.Forms.TextBox txtrrno;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.Button btnPrintPreview;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Panel panel16;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.TextBox txtremarks;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Panel panel12;
        public System.Windows.Forms.TextBox txtvanno;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Panel panel15;
        public System.Windows.Forms.TextBox txtshippername;
        public System.Windows.Forms.Label label15;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn _lineno;
    }
}