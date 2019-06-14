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
            this.btnDeclareIncomplete.Enabled = false;
            this.btnDeclareIncomplete.Location = new System.Drawing.Point(123, 57);
            this.btnDeclareIncomplete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeclareIncomplete.Name = "btnDeclareIncomplete";
            this.btnDeclareIncomplete.Size = new System.Drawing.Size(92, 69);
            this.btnDeclareIncomplete.TabIndex = 18;
            this.btnDeclareIncomplete.Text = "Declare Incomplete";
            this.btnDeclareIncomplete.UseVisualStyleBackColor = false;
            this.btnDeclareIncomplete.Click += new System.EventHandler(this.btnDeclareIncomplete_Click);
            // 
            // btnDeclareComplete
            // 
            this.btnDeclareComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeclareComplete.BackColor = System.Drawing.Color.Lime;
            this.btnDeclareComplete.Location = new System.Drawing.Point(21, 57);
            this.btnDeclareComplete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeclareComplete.Name = "btnDeclareComplete";
            this.btnDeclareComplete.Size = new System.Drawing.Size(92, 69);
            this.btnDeclareComplete.TabIndex = 17;
            this.btnDeclareComplete.Text = "Declare Complete";
            this.btnDeclareComplete.UseVisualStyleBackColor = false;
            this.btnDeclareComplete.Click += new System.EventHandler(this.btnDeclareComplete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Container:";
            this.label1.Visible = false;
            // 
            // txtContainer
            // 
            this.txtContainer.AutoSize = true;
            this.txtContainer.Location = new System.Drawing.Point(103, 30);
            this.txtContainer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(70, 13);
            this.txtContainer.TabIndex = 20;
            this.txtContainer.Text = "<Code Here>";
            this.txtContainer.Visible = false;
            // 
            // txtPutawayID
            // 
            this.txtPutawayID.AutoSize = true;
            this.txtPutawayID.Location = new System.Drawing.Point(103, 6);
            this.txtPutawayID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPutawayID.Name = "txtPutawayID";
            this.txtPutawayID.Size = new System.Drawing.Size(70, 13);
            this.txtPutawayID.TabIndex = 22;
            this.txtPutawayID.Text = "<Code Here>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Putaway ID:";
            // 
            // DeclareCompleteOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 159);
            this.Controls.Add(this.txtPutawayID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeclareIncomplete);
            this.Controls.Add(this.btnDeclareComplete);
            this.Margin = new System.Windows.Forms.Padding(2);
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