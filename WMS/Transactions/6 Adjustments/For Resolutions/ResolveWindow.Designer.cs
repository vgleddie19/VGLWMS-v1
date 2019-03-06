namespace WMS
{
    partial class ResolveWindow
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
            this.txtUnresolvedQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtyToResolve = new System.Windows.Forms.TextBox();
            this.txtResolvedBy = new System.Windows.Forms.TextBox();
            this.txtChargeTo = new System.Windows.Forms.TextBox();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUnresolvedQty
            // 
            this.txtUnresolvedQty.BackColor = System.Drawing.Color.Red;
            this.txtUnresolvedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnresolvedQty.ForeColor = System.Drawing.Color.White;
            this.txtUnresolvedQty.Location = new System.Drawing.Point(142, 12);
            this.txtUnresolvedQty.Name = "txtUnresolvedQty";
            this.txtUnresolvedQty.ReadOnly = true;
            this.txtUnresolvedQty.Size = new System.Drawing.Size(93, 35);
            this.txtUnresolvedQty.TabIndex = 19;
            this.txtUnresolvedQty.Text = "10";
            this.txtUnresolvedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Unresolved Qty:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Qty to Resolve:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Charge To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Explanation:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Resolved By:";
            // 
            // txtQtyToResolve
            // 
            this.txtQtyToResolve.Location = new System.Drawing.Point(142, 66);
            this.txtQtyToResolve.Name = "txtQtyToResolve";
            this.txtQtyToResolve.Size = new System.Drawing.Size(93, 26);
            this.txtQtyToResolve.TabIndex = 25;
            // 
            // txtResolvedBy
            // 
            this.txtResolvedBy.Location = new System.Drawing.Point(142, 116);
            this.txtResolvedBy.Name = "txtResolvedBy";
            this.txtResolvedBy.Size = new System.Drawing.Size(195, 26);
            this.txtResolvedBy.TabIndex = 26;
            // 
            // txtChargeTo
            // 
            this.txtChargeTo.Location = new System.Drawing.Point(142, 159);
            this.txtChargeTo.Name = "txtChargeTo";
            this.txtChargeTo.Size = new System.Drawing.Size(195, 26);
            this.txtChargeTo.TabIndex = 27;
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(142, 205);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(195, 181);
            this.txtExplanation.TabIndex = 28;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BackColor = System.Drawing.Color.Lime;
            this.btnPrintPreview.Location = new System.Drawing.Point(140, 404);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(189, 68);
            this.btnPrintPreview.TabIndex = 30;
            this.btnPrintPreview.Text = "Proceed to Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // ResolveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 522);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.txtChargeTo);
            this.Controls.Add(this.txtResolvedBy);
            this.Controls.Add(this.txtQtyToResolve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUnresolvedQty);
            this.Controls.Add(this.label9);
            this.Name = "ResolveWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resolve...";
            this.Load += new System.EventHandler(this.ResolveWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrintPreview;
        public System.Windows.Forms.TextBox txtUnresolvedQty;
        public System.Windows.Forms.TextBox txtQtyToResolve;
        public System.Windows.Forms.TextBox txtResolvedBy;
        public System.Windows.Forms.TextBox txtChargeTo;
        public System.Windows.Forms.TextBox txtExplanation;
    }
}