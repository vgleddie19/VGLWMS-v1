﻿namespace WMS
{
    partial class addnewbin
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
            this.txtmin_qty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtbin_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProducts = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUOM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmax_qty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtmin_qty
            // 
            this.txtmin_qty.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmin_qty.Location = new System.Drawing.Point(163, 93);
            this.txtmin_qty.Name = "txtmin_qty";
            this.txtmin_qty.Size = new System.Drawing.Size(132, 22);
            this.txtmin_qty.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Minimum Quantity:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cyan;
            this.btnAdd.Location = new System.Drawing.Point(383, 74);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 68);
            this.btnAdd.TabIndex = 41;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtbin_id
            // 
            this.txtbin_id.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbin_id.Location = new System.Drawing.Point(163, 9);
            this.txtbin_id.Name = "txtbin_id";
            this.txtbin_id.Size = new System.Drawing.Size(134, 22);
            this.txtbin_id.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Bin ID:";
            // 
            // txtProducts
            // 
            this.txtProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProducts.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducts.FormattingEnabled = true;
            this.txtProducts.Location = new System.Drawing.Point(163, 35);
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(315, 24);
            this.txtProducts.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Product:";
            // 
            // txtUOM
            // 
            this.txtUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtUOM.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUOM.FormattingEnabled = true;
            this.txtUOM.Location = new System.Drawing.Point(163, 62);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(134, 24);
            this.txtUOM.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "UOM:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "Maximum Quantity:";
            // 
            // txtmax_qty
            // 
            this.txtmax_qty.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmax_qty.Location = new System.Drawing.Point(163, 119);
            this.txtmax_qty.Name = "txtmax_qty";
            this.txtmax_qty.Size = new System.Drawing.Size(132, 22);
            this.txtmax_qty.TabIndex = 35;
            // 
            // addnewbin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 158);
            this.Controls.Add(this.txtUOM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProducts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmax_qty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmin_qty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtbin_id);
            this.Controls.Add(this.label1);
            this.Name = "addnewbin";
            this.Text = "addnewbin";
            this.Load += new System.EventHandler(this.addnewbin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtmin_qty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtbin_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtProducts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtUOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmax_qty;
    }
}