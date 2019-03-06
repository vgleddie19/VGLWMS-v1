namespace WMS
{
    partial class DeclarePutawayScanContainerWindow
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
            this.SuspendLayout();
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(193, 34);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(219, 26);
            this.txtContainer.TabIndex = 21;
            this.txtContainer.TextChanged += new System.EventHandler(this.txtContainer_TextChanged);
            this.txtContainer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPutawayCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Scan Container:";
            // 
            // DeclarePutawayScanContainerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 96);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.label2);
            this.Name = "DeclarePutawayScanContainerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Scan Container Barcode...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtContainer;
        private System.Windows.Forms.Label label2;
    }
}