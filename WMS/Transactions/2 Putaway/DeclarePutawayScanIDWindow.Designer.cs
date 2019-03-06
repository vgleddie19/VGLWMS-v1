namespace WMS
{
    partial class DeclarePutawayScanIDWindow
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
            this.txtPutawayCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPutawayCode
            // 
            this.txtPutawayCode.Location = new System.Drawing.Point(213, 39);
            this.txtPutawayCode.Name = "txtPutawayCode";
            this.txtPutawayCode.Size = new System.Drawing.Size(219, 26);
            this.txtPutawayCode.TabIndex = 19;
            this.txtPutawayCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPutawayCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Scan Putaway Code:";
            // 
            // DeclarePutawayScanIDWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 116);
            this.Controls.Add(this.txtPutawayCode);
            this.Controls.Add(this.label2);
            this.Name = "DeclarePutawayScanIDWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Scan PA Document...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtPutawayCode;
        private System.Windows.Forms.Label label2;
    }
}