namespace WMS
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmax_qty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboproduct = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbouom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbolot = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboexpiry = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button1 = new System.Windows.Forms.Button();
            this.lblShowProduct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtmin_qty
            // 
            this.txtmin_qty.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmin_qty.Location = new System.Drawing.Point(163, 177);
            this.txtmin_qty.Name = "txtmin_qty";
            this.txtmin_qty.Size = new System.Drawing.Size(132, 22);
            this.txtmin_qty.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Minimum Quantity:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnAdd.Location = new System.Drawing.Point(34, 231);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 68);
            this.btnAdd.TabIndex = 7;
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
            this.txtbin_id.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "UOM:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "Maximum Quantity:";
            // 
            // txtmax_qty
            // 
            this.txtmax_qty.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmax_qty.Location = new System.Drawing.Point(163, 203);
            this.txtmax_qty.Name = "txtmax_qty";
            this.txtmax_qty.Size = new System.Drawing.Size(132, 22);
            this.txtmax_qty.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(100, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "Lot No:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(102, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 49;
            this.label7.Text = "Expiry:";
            // 
            // cboproduct
            // 
            this.cboproduct.DisplayMember = "Text";
            this.cboproduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboproduct.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboproduct.FormattingEnabled = true;
            this.cboproduct.ItemHeight = 17;
            this.cboproduct.Location = new System.Drawing.Point(163, 36);
            this.cboproduct.Name = "cboproduct";
            this.cboproduct.Size = new System.Drawing.Size(321, 23);
            this.cboproduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboproduct.TabIndex = 1;
            this.cboproduct.SelectedIndexChanged += new System.EventHandler(this.cboproduct_SelectedIndexChanged);
            // 
            // cbouom
            // 
            this.cbouom.DisplayMember = "Text";
            this.cbouom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbouom.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbouom.FormattingEnabled = true;
            this.cbouom.ItemHeight = 17;
            this.cbouom.Location = new System.Drawing.Point(163, 90);
            this.cbouom.Name = "cbouom";
            this.cbouom.Size = new System.Drawing.Size(137, 23);
            this.cbouom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbouom.TabIndex = 2;
            this.cbouom.SelectedIndexChanged += new System.EventHandler(this.cbouom_SelectedIndexChanged);
            // 
            // cbolot
            // 
            this.cbolot.DisplayMember = "Text";
            this.cbolot.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbolot.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbolot.FormattingEnabled = true;
            this.cbolot.ItemHeight = 17;
            this.cbolot.Location = new System.Drawing.Point(163, 118);
            this.cbolot.Name = "cbolot";
            this.cbolot.Size = new System.Drawing.Size(137, 23);
            this.cbolot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbolot.TabIndex = 3;
            this.cbolot.SelectedIndexChanged += new System.EventHandler(this.cbolot_SelectedIndexChanged);
            // 
            // cboexpiry
            // 
            this.cboexpiry.DisplayMember = "Text";
            this.cboexpiry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboexpiry.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboexpiry.FormattingEnabled = true;
            this.cboexpiry.ItemHeight = 17;
            this.cboexpiry.Location = new System.Drawing.Point(163, 148);
            this.cboexpiry.Name = "cboexpiry";
            this.cboexpiry.Size = new System.Drawing.Size(137, 23);
            this.cboexpiry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboexpiry.TabIndex = 4;
            this.cboexpiry.SelectedIndexChanged += new System.EventHandler(this.cboexpiry_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(138, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 68);
            this.button1.TabIndex = 7;
            this.button1.Text = "Closed";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblShowProduct
            // 
            this.lblShowProduct.AutoSize = true;
            this.lblShowProduct.Font = new System.Drawing.Font("Arial Narrow", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowProduct.Location = new System.Drawing.Point(160, 69);
            this.lblShowProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowProduct.Name = "lblShowProduct";
            this.lblShowProduct.Size = new System.Drawing.Size(59, 17);
            this.lblShowProduct.TabIndex = 50;
            this.lblShowProduct.Text = "Show IDs";
            this.lblShowProduct.Click += new System.EventHandler(this.lblShowProduct_Click);
            // 
            // addnewbin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 310);
            this.Controls.Add(this.lblShowProduct);
            this.Controls.Add(this.cboexpiry);
            this.Controls.Add(this.cbolot);
            this.Controls.Add(this.cbouom);
            this.Controls.Add(this.cboproduct);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmax_qty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmin_qty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmax_qty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboproduct;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbouom;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbolot;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboexpiry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblShowProduct;
    }
}