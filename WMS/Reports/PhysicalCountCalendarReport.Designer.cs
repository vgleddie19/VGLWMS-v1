namespace WMS
{
    partial class PhysicalCountCalendarReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCycleDays = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.header_grid = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Days Per Cycle:";
            // 
            // txtCycleDays
            // 
            this.txtCycleDays.Location = new System.Drawing.Point(148, 27);
            this.txtCycleDays.Name = "txtCycleDays";
            this.txtCycleDays.Size = new System.Drawing.Size(85, 26);
            this.txtCycleDays.TabIndex = 1;
            this.txtCycleDays.Text = "4";
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.LightGreen;
            this.btnExecute.Location = new System.Drawing.Point(242, 16);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(98, 43);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // header_grid
            // 
            this.header_grid.AllowUserToAddRows = false;
            this.header_grid.AllowUserToDeleteRows = false;
            this.header_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.header_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.header_grid.Location = new System.Drawing.Point(38, 75);
            this.header_grid.Name = "header_grid";
            this.header_grid.ReadOnly = true;
            this.header_grid.RowTemplate.Height = 28;
            this.header_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.header_grid.Size = new System.Drawing.Size(1616, 437);
            this.header_grid.TabIndex = 44;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGreen;
            this.btnPrint.Location = new System.Drawing.Point(346, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(98, 43);
            this.btnPrint.TabIndex = 45;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // PhysicalCountCalendarReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 581);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.header_grid);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtCycleDays);
            this.Controls.Add(this.label1);
            this.Name = "PhysicalCountCalendarReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Physical Count Calendar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCycleDays;
        private System.Windows.Forms.Button btnExecute;
        public System.Windows.Forms.DataGridView header_grid;
        private System.Windows.Forms.Button btnPrint;
    }
}