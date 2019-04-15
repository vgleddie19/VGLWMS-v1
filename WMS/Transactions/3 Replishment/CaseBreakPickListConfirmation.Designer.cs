﻿namespace WMS
{
    partial class CaseBreakPickListConfirmation
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            this.btnCancel.Location = new System.Drawing.Point(1357, 518);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 73);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Back";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.BackColor = System.Drawing.Color.Lime;
            this.btnPrintPreview.Location = new System.Drawing.Point(1261, 522);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(92, 69);
            this.btnPrintPreview.TabIndex = 21;
            this.btnPrintPreview.Text = "Save";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // webBrowser3
            // 
            this.webBrowser3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.webBrowser3.Location = new System.Drawing.Point(11, 315);
            this.webBrowser3.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(13, 13);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.Size = new System.Drawing.Size(714, 276);
            this.webBrowser3.TabIndex = 29;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser2.Location = new System.Drawing.Point(740, 22);
            this.webBrowser2.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(13, 13);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(712, 276);
            this.webBrowser2.TabIndex = 30;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(13, 22);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(13, 13);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(712, 276);
            this.webBrowser1.TabIndex = 31;
            // 
            // CaseBreakPickListConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 627);
            this.Controls.Add(this.webBrowser3);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrintPreview);
            this.Name = "CaseBreakPickListConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaseBreak - PickList Confirmation";
            this.Load += new System.EventHandler(this.CaseBreakPickListConfirmation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.WebBrowser webBrowser3;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}