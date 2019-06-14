namespace WMS
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.GroupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtUsername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chkRemember = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.LabelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblversion = new System.Windows.Forms.Label();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.GroupPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::WMS.Properties.Resources.wms_badge;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(191, 199);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 211;
            this.pictureBox2.TabStop = false;
            // 
            // GroupPanel1
            // 
            this.GroupPanel1.BackColor = System.Drawing.Color.Bisque;
            this.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GroupPanel1.Controls.Add(this.panel2);
            this.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.GroupPanel1.Font = new System.Drawing.Font("Broadway", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupPanel1.IsShadowEnabled = true;
            this.GroupPanel1.Location = new System.Drawing.Point(12, 14);
            this.GroupPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GroupPanel1.Name = "GroupPanel1";
            this.GroupPanel1.Size = new System.Drawing.Size(432, 310);
            // 
            // 
            // 
            this.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.GroupPanel1.Style.BackColorGradientAngle = 90;
            this.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GroupPanel1.Style.BorderBottomWidth = 1;
            this.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GroupPanel1.Style.BorderLeftWidth = 1;
            this.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GroupPanel1.Style.BorderRightWidth = 1;
            this.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GroupPanel1.Style.BorderTopWidth = 1;
            this.GroupPanel1.Style.CornerDiameter = 4;
            this.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GroupPanel1.TabIndex = 1;
            this.GroupPanel1.Text = "Log In";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.LabelX1);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.chkRemember);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.LabelX2);
            this.panel2.Controls.Add(this.lblversion);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(4, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 199);
            this.panel2.TabIndex = 1;
            // 
            // LabelX1
            // 
            this.LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LabelX1.Location = new System.Drawing.Point(178, 32);
            this.LabelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(22, 28);
            this.LabelX1.Symbol = "";
            this.LabelX1.TabIndex = 205;
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.Border.Class = "TextBoxBorder";
            this.txtUsername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUsername.DisabledBackColor = System.Drawing.Color.Black;
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highlighter1.SetHighlightOnFocus(this.txtUsername, true);
            this.txtUsername.Location = new System.Drawing.Point(202, 32);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PreventEnterBeep = true;
            this.txtUsername.Size = new System.Drawing.Size(209, 26);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsername.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtUsername.WatermarkText = "Username";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.DisabledBackColor = System.Drawing.Color.Black;
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highlighter1.SetHighlightOnFocus(this.txtPassword, true);
            this.txtPassword.Location = new System.Drawing.Point(202, 62);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PreventEnterBeep = true;
            this.txtPassword.Size = new System.Drawing.Size(209, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtPassword.WatermarkText = "Password";
            // 
            // chkRemember
            // 
            this.chkRemember.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkRemember.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkRemember.Checked = true;
            this.chkRemember.CheckSignSize = new System.Drawing.Size(15, 15);
            this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemember.CheckValue = "Y";
            this.chkRemember.FocusCuesEnabled = false;
            this.chkRemember.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highlighter1.SetHighlightOnFocus(this.chkRemember, true);
            this.chkRemember.Location = new System.Drawing.Point(202, 96);
            this.chkRemember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(178, 27);
            this.chkRemember.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.chkRemember.TabIndex = 4;
            this.chkRemember.TabStop = false;
            this.chkRemember.Text = "Remember Username";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.FocusCuesEnabled = false;
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highlighter1.SetHighlightOnFocus(this.btnLogin, true);
            this.btnLogin.Location = new System.Drawing.Point(311, 131);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 36);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnLogin.Symbol = "";
            this.btnLogin.SymbolColor = System.Drawing.Color.Green;
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FocusCuesEnabled = false;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highlighter1.SetHighlightOnFocus(this.btnClose, true);
            this.btnClose.Location = new System.Drawing.Point(219, 131);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 36);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnClose.Symbol = "";
            this.btnClose.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Exit";
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // LabelX2
            // 
            this.LabelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LabelX2.Location = new System.Drawing.Point(178, 63);
            this.LabelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelX2.Name = "LabelX2";
            this.LabelX2.Size = new System.Drawing.Size(22, 28);
            this.LabelX2.Symbol = "";
            this.LabelX2.TabIndex = 206;
            // 
            // lblversion
            // 
            this.lblversion.BackColor = System.Drawing.Color.Transparent;
            this.lblversion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblversion.Location = new System.Drawing.Point(202, 32);
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(209, 23);
            this.lblversion.TabIndex = 210;
            this.lblversion.Text = "Label1";
            this.lblversion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Bisque;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(457, 341);
            this.Controls.Add(this.GroupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Bisque;
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.GroupPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        internal DevComponents.DotNetBar.Controls.GroupPanel GroupPanel1;
        private System.Windows.Forms.Panel panel2;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtUsername;
        public DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        internal DevComponents.DotNetBar.Controls.CheckBoxX chkRemember;
        internal DevComponents.DotNetBar.ButtonX btnLogin;
        internal DevComponents.DotNetBar.ButtonX btnClose;
        internal DevComponents.DotNetBar.LabelX LabelX2;
        internal System.Windows.Forms.Label lblversion;
    }
}