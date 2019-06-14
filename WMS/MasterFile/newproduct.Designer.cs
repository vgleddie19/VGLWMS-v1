namespace WMS
{
    partial class newproduct
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboclient = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdesc3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdesc2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colUOM = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colpricetype = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtdesc1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeclare = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboclient);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtdesc3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtdesc2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCategory);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.txtdesc1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 413);
            this.panel1.TabIndex = 0;
            // 
            // cboclient
            // 
            this.cboclient.DisplayMember = "Text";
            this.cboclient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboclient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboclient.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboclient.FormattingEnabled = true;
            this.cboclient.ItemHeight = 25;
            this.cboclient.Location = new System.Drawing.Point(390, 129);
            this.cboclient.Name = "cboclient";
            this.cboclient.Size = new System.Drawing.Size(263, 31);
            this.cboclient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboclient.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(387, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 43;
            this.label6.Text = "Client";
            // 
            // txtdesc3
            // 
            this.txtdesc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdesc3.Location = new System.Drawing.Point(94, 131);
            this.txtdesc3.Name = "txtdesc3";
            this.txtdesc3.Size = new System.Drawing.Size(263, 20);
            this.txtdesc3.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(93, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "Description 3:";
            // 
            // txtdesc2
            // 
            this.txtdesc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdesc2.Location = new System.Drawing.Point(390, 78);
            this.txtdesc2.Name = "txtdesc2";
            this.txtdesc2.Size = new System.Drawing.Size(263, 20);
            this.txtdesc2.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(389, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Description 2 :";
            // 
            // txtCategory
            // 
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Location = new System.Drawing.Point(295, 31);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(178, 20);
            this.txtCategory.TabIndex = 35;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUOM,
            this.colpricetype,
            this.colQty,
            this.colbarcode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(97, 166);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(556, 207);
            this.dataGridView1.TabIndex = 36;
            // 
            // colUOM
            // 
            this.colUOM.DataPropertyName = "uom";
            this.colUOM.DisplayMember = "Text";
            this.colUOM.DropDownHeight = 106;
            this.colUOM.DropDownWidth = 121;
            this.colUOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colUOM.HeaderText = "UOM";
            this.colUOM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colUOM.IntegralHeight = false;
            this.colUOM.ItemHeight = 15;
            this.colUOM.Items.AddRange(new object[] {
            "PC",
            "CS",
            "PK",
            "CARD",
            "BOT",
            "SET",
            "CAN"});
            this.colUOM.Name = "colUOM";
            this.colUOM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // colpricetype
            // 
            this.colpricetype.HeaderText = "pricetype";
            this.colpricetype.Name = "colpricetype";
            this.colpricetype.Visible = false;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "qty";
            this.colQty.HeaderText = "Qty Express in Pcs";
            this.colQty.Name = "colQty";
            this.colQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colbarcode
            // 
            this.colbarcode.DataPropertyName = "colbarcode";
            this.colbarcode.HeaderText = "BarCode";
            this.colbarcode.Name = "colbarcode";
            this.colbarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // txtdesc1
            // 
            this.txtdesc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdesc1.Location = new System.Drawing.Point(96, 78);
            this.txtdesc1.Name = "txtdesc1";
            this.txtdesc1.Size = new System.Drawing.Size(263, 20);
            this.txtdesc1.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(95, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 32;
            this.label2.Text = "Description 1 :";
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(98, 31);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(178, 20);
            this.txtCode.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(95, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "Product Code :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(292, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Category :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDeclare);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 78);
            this.panel2.TabIndex = 1;
            // 
            // btnDeclare
            // 
            this.btnDeclare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeclare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(163)))));
            this.btnDeclare.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeclare.ForeColor = System.Drawing.Color.White;
            this.btnDeclare.Location = new System.Drawing.Point(632, 21);
            this.btnDeclare.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeclare.Name = "btnDeclare";
            this.btnDeclare.Size = new System.Drawing.Size(109, 46);
            this.btnDeclare.TabIndex = 37;
            this.btnDeclare.Text = "Save";
            this.btnDeclare.UseVisualStyleBackColor = false;
            this.btnDeclare.Click += new System.EventHandler(this.btnDeclare_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.BackColor = System.Drawing.Color.Firebrick;
            this.button5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(519, 21);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(109, 46);
            this.button5.TabIndex = 38;
            this.button5.Text = "Close";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // newproduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "newproduct";
            this.Text = "newproduct";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox txtdesc3;
        public System.Windows.Forms.TextBox txtdesc2;
        public System.Windows.Forms.TextBox txtCategory;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox txtdesc1;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnDeclare;
        public System.Windows.Forms.Button button5;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cboclient;
        public System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colUOM;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn colpricetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbarcode;
    }
}