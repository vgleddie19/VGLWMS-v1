namespace WMS
{
    partial class MakeReleaseOrderWindow
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnStockCheck = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 57);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(561, 299);
            this.textBox1.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(78, 362);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 30);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "OMS - Order";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnStockCheck
            // 
            this.btnStockCheck.Location = new System.Drawing.Point(204, 362);
            this.btnStockCheck.Name = "btnStockCheck";
            this.btnStockCheck.Size = new System.Drawing.Size(120, 52);
            this.btnStockCheck.TabIndex = 3;
            this.btnStockCheck.Text = "to OMS - Stock Check";
            this.btnStockCheck.UseVisualStyleBackColor = true;
            this.btnStockCheck.Click += new System.EventHandler(this.btnStockCheck_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(330, 362);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(153, 52);
            this.btnSchedule.TabIndex = 4;
            this.btnSchedule.Text = "TMS - Declare Trip";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 438);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(405, 26);
            this.textBox2.TabIndex = 5;
            // 
            // MakeReleaseOrderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 508);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.btnStockCheck);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.textBox1);
            this.Name = "MakeReleaseOrderWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulate API";
            this.Load += new System.EventHandler(this.MakeReleaseOrderWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnStockCheck;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.TextBox textBox2;
    }
}