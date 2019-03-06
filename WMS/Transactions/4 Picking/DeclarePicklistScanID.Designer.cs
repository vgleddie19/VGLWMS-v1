namespace WMS
{
    partial class DeclarePicklistScanID
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
            this.txtPicklistCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPicklistCode
            // 
            this.txtPicklistCode.Location = new System.Drawing.Point(202, 38);
            this.txtPicklistCode.Name = "txtPicklistCode";
            this.txtPicklistCode.Size = new System.Drawing.Size(219, 26);
            this.txtPicklistCode.TabIndex = 21;
            this.txtPicklistCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPicklistCode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Scan Picklist Code:";
            // 
            // DeclarePicklistScanID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 102);
            this.Controls.Add(this.txtPicklistCode);
            this.Controls.Add(this.label2);
            this.Name = "DeclarePicklistScanID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Scan...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtPicklistCode;
        private System.Windows.Forms.Label label2;
    }
}