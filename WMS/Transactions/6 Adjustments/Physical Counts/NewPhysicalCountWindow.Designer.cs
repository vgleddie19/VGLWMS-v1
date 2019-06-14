namespace WMS
{
    partial class NewPhysicalCountWindow
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
            this.header_grid = new System.Windows.Forms.DataGridView();
            this.inc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_counted_on = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateCountSheet = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCycle = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCountedBy = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycle)).BeginInit();
            this.SuspendLayout();
            // 
            // header_grid
            // 
            this.header_grid.AllowUserToAddRows = false;
            this.header_grid.AllowUserToDeleteRows = false;
            this.header_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.header_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.header_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inc,
            this.location,
            this.last_counted_on,
            this.last_cycle});
            this.header_grid.Location = new System.Drawing.Point(8, 61);
            this.header_grid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.header_grid.Name = "header_grid";
            this.header_grid.RowTemplate.Height = 28;
            this.header_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.header_grid.Size = new System.Drawing.Size(1036, 520);
            this.header_grid.TabIndex = 1;
            // 
            // inc
            // 
            this.inc.HeaderText = "?";
            this.inc.Name = "inc";
            this.inc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.inc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // location
            // 
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // last_counted_on
            // 
            this.last_counted_on.HeaderText = "Last Counted On";
            this.last_counted_on.Name = "last_counted_on";
            this.last_counted_on.ReadOnly = true;
            // 
            // last_cycle
            // 
            this.last_cycle.HeaderText = "Last Cycle";
            this.last_cycle.Name = "last_cycle";
            this.last_cycle.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Locations to Count or";
            // 
            // btnGenerateCountSheet
            // 
            this.btnGenerateCountSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateCountSheet.BackColor = System.Drawing.Color.Cyan;
            this.btnGenerateCountSheet.Location = new System.Drawing.Point(8, 585);
            this.btnGenerateCountSheet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerateCountSheet.Name = "btnGenerateCountSheet";
            this.btnGenerateCountSheet.Size = new System.Drawing.Size(1036, 32);
            this.btnGenerateCountSheet.TabIndex = 3;
            this.btnGenerateCountSheet.Text = "Generate Count Sheet";
            this.btnGenerateCountSheet.UseVisualStyleBackColor = false;
            this.btnGenerateCountSheet.Click += new System.EventHandler(this.btnGenerateCountSheet_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = true;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(147, 38);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(61, 13);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select All";
            this.btnSelect.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cycle:";
            // 
            // txtCycle
            // 
            this.txtCycle.DecimalPlaces = 2;
            this.txtCycle.Location = new System.Drawing.Point(47, 16);
            this.txtCycle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCycle.Name = "txtCycle";
            this.txtCycle.Size = new System.Drawing.Size(53, 20);
            this.txtCycle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Year:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(143, 16);
            this.txtYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(52, 20);
            this.txtYear.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Counted by:";
            // 
            // txtCountedBy
            // 
            this.txtCountedBy.Location = new System.Drawing.Point(271, 18);
            this.txtCountedBy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCountedBy.MaxLength = 4;
            this.txtCountedBy.Name = "txtCountedBy";
            this.txtCountedBy.Size = new System.Drawing.Size(127, 20);
            this.txtCountedBy.TabIndex = 10;
            // 
            // NewPhysicalCountWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 618);
            this.Controls.Add(this.txtCountedBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCycle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnGenerateCountSheet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.header_grid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NewPhysicalCountWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Physical Count Sheet";
            this.Load += new System.EventHandler(this.NewPhysicalCountWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCycle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView header_grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateCountSheet;
        private System.Windows.Forms.Label btnSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inc;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_counted_on;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_cycle;
        public System.Windows.Forms.NumericUpDown txtCycle;
        public System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCountedBy;
    }
}