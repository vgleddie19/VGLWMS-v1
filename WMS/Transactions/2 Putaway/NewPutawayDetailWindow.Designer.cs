namespace WMS
{
    partial class NewPutawayDetailWindow
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
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(94, 12);
            this.txtContainer.Margin = new System.Windows.Forms.Padding(2);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(203, 20);
            this.txtContainer.TabIndex = 19;
            this.txtContainer.TextChanged += new System.EventHandler(this.txtContainer_TextChanged);
            this.txtContainer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContainer_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Scan Item:";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BackColor = System.Drawing.Color.Lime;
            this.btnPrintPreview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrintPreview.Location = new System.Drawing.Point(203, 41);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(94, 39);
            this.btnPrintPreview.TabIndex = 28;
            this.btnPrintPreview.Text = "Done";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // NewPutawayDetailWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnPrintPreview;
            this.ClientSize = new System.Drawing.Size(308, 91);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewPutawayDetailWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan for Putaway...";
            this.Load += new System.EventHandler(this.NewPutawayDetailWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrintPreview;
    }
}