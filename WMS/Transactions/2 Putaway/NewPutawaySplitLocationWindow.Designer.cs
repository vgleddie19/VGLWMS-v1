namespace WMS
{
    partial class NewPutawaySplitLocationWindow
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Qty:";
            // 
            // btnSplit
            // 
            this.btnSplit.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSplit.Location = new System.Drawing.Point(234, 97);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 34);
            this.btnSplit.TabIndex = 35;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = false;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(91, 15);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(91, 26);
            this.txtQty.TabIndex = 36;
            // 
            // txtLocation
            // 
            this.txtLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLocation.FormattingEnabled = true;
            this.txtLocation.Location = new System.Drawing.Point(90, 49);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(219, 28);
            this.txtLocation.TabIndex = 37;
            // 
            // NewPutawaySplitLocationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 155);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "NewPutawaySplitLocationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Split...";
            this.Load += new System.EventHandler(this.NewPutawaySplitLocationWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSplit;
        public System.Windows.Forms.TextBox txtQty;
        public System.Windows.Forms.ComboBox txtLocation;
    }
}