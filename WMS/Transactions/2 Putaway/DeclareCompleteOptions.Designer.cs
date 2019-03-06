namespace WMS
{
    partial class DeclareCompleteOptions
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
            this.btnDeclareIncomplete = new System.Windows.Forms.Button();
            this.btnDeclareComplete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContainer = new System.Windows.Forms.Label();
            this.txtPutawayID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeclareIncomplete
            // 
            this.btnDeclareIncomplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeclareIncomplete.BackColor = System.Drawing.Color.Orange;
            this.btnDeclareIncomplete.Location = new System.Drawing.Point(185, 87);
            this.btnDeclareIncomplete.Name = "btnDeclareIncomplete";
            this.btnDeclareIncomplete.Size = new System.Drawing.Size(138, 106);
            this.btnDeclareIncomplete.TabIndex = 18;
            this.btnDeclareIncomplete.Text = "Declare Incomplete";
            this.btnDeclareIncomplete.UseVisualStyleBackColor = false;
            this.btnDeclareIncomplete.Click += new System.EventHandler(this.btnDeclareIncomplete_Click);
            // 
            // btnDeclareComplete
            // 
            this.btnDeclareComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeclareComplete.BackColor = System.Drawing.Color.Lime;
            this.btnDeclareComplete.Location = new System.Drawing.Point(32, 87);
            this.btnDeclareComplete.Name = "btnDeclareComplete";
            this.btnDeclareComplete.Size = new System.Drawing.Size(138, 106);
            this.btnDeclareComplete.TabIndex = 17;
            this.btnDeclareComplete.Text = "Declare Complete";
            this.btnDeclareComplete.UseVisualStyleBackColor = false;
            this.btnDeclareComplete.Click += new System.EventHandler(this.btnDeclareComplete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Container:";
            // 
            // txtContainer
            // 
            this.txtContainer.AutoSize = true;
            this.txtContainer.Location = new System.Drawing.Point(155, 46);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(104, 20);
            this.txtContainer.TabIndex = 20;
            this.txtContainer.Text = "<Code Here>";
            // 
            // txtPutawayID
            // 
            this.txtPutawayID.AutoSize = true;
            this.txtPutawayID.Location = new System.Drawing.Point(155, 9);
            this.txtPutawayID.Name = "txtPutawayID";
            this.txtPutawayID.Size = new System.Drawing.Size(104, 20);
            this.txtPutawayID.TabIndex = 22;
            this.txtPutawayID.Text = "<Code Here>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Putaway ID:";
            // 
            // DeclareCompleteOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 244);
            this.Controls.Add(this.txtPutawayID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeclareIncomplete);
            this.Controls.Add(this.btnDeclareComplete);
            this.Name = "DeclareCompleteOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Choose...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnDeclareIncomplete;
        private System.Windows.Forms.Button btnDeclareComplete;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label txtContainer;
        public System.Windows.Forms.Label txtPutawayID;
        private System.Windows.Forms.Label label3;
    }
}