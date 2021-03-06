﻿namespace WMS
{
    partial class OrdersForResolutionsWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnResolve = new System.Windows.Forms.Button();
            this.header_grid = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResolve
            // 
            this.btnResolve.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnResolve.Location = new System.Drawing.Point(12, 32);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(167, 30);
            this.btnResolve.TabIndex = 4;
            this.btnResolve.Text = "Release Anyway";
            this.btnResolve.UseVisualStyleBackColor = false;
            this.btnResolve.Click += new System.EventHandler(this.btnReleaseAnyway_Click);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.header_grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.header_grid.Location = new System.Drawing.Point(12, 68);
            this.header_grid.Name = "header_grid";
            this.header_grid.ReadOnly = true;
            this.header_grid.RowTemplate.Height = 28;
            this.header_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.header_grid.Size = new System.Drawing.Size(938, 577);
            this.header_grid.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(185, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OrdersForResolutionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 657);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.header_grid);
            this.Name = "OrdersForResolutionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resolve the issues...";
            this.Load += new System.EventHandler(this.OrdersForResolutionsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.header_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResolve;
        public System.Windows.Forms.DataGridView header_grid;
        private System.Windows.Forms.Button btnCancel;
    }
}