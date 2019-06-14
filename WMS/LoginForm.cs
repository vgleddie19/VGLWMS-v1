using Framework;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class LoginForm : Form
    {
        Dictionary<String, Dictionary<String, String>> dbConnectionSettings = new Dictionary<String, Dictionary<String, String>>();

        public LoginForm()
        {
            InitializeComponent();
            lblversion.Text = "version  " + Application.ProductVersion;
            if (Properties.Settings.Default.isremember)
            {
                chkRemember.Checked = true;
                txtUsername.Text = Properties.Settings.Default.username;            }
            else
                chkRemember.Checked = false;

            Utils.SetConnectionDetails();
            dbConnectionSettings = Utils.DBConnection;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (dbConnectionSettings.Count == 0)
            {
                MessageBox.Show(String.Format("Administrator Settings not Initialize! \nReport this to the programmer!"), "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!dbConnectionSettings.ContainsKey("WMS"))
            {
                MessageBox.Show(String.Format("WMS Database Connection not Initialize properly! \nReport this to the programmer!"), "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DataSupport ds = new DataSupport(String.Format(@"Initial Catalog={0};Data Source= {1};User Id = {2}; Password = {3}", Utils.DBConnection["WMS"]["DBNAME"], Utils.DBConnection["WMS"]["SERVER"], Utils.DBConnection["WMS"]["USERNAME"], Utils.DBConnection["WMS"]["PASSWORD"]));
            
            if (!dbConnectionSettings.ContainsKey("OMS"))
            {
                MessageBox.Show(String.Format("OMS Database Connection not Initialize properly! \nReport this to the programmer!"), "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (RegistrationSupport.IsCorrectUsernameAndPassword(txtUsername.Text, txtPassword.Text))
            {
                Properties.Settings.Default.username = String.Empty;
                Properties.Settings.Default.isremember = false;
                if (chkRemember.Checked)
                {
                    Properties.Settings.Default.username = txtUsername.Text;
                    Properties.Settings.Default.isremember = true;
                }
                Properties.Settings.Default.Save();

                RegistrationSupport.username = txtUsername.Text;
                MainMenu dialog = new MainMenu();
                this.Visible = false;
                dialog.Text = "WAREHOUSE MANAGEMENT SYSTEM - MAIN MENU";
                dialog.Icon = this.Icon;
                dialog.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isremember)
                txtPassword.Focus();
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isremember)
                txtPassword.Focus();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                AuthenticationForm af = new AuthenticationForm();
                if (DialogResult.OK == af.ShowDialog())
                {
                    if (SecuritySupport.Encrypt(af.txtpassword.Text) == SecuritySupport.Encrypt("tqbfjotld"))
                    {
                        ConnectionSettings cs = new ConnectionSettings();
                        cs.ShowDialog();
                        dbConnectionSettings = cs.dbConnectionSettings;
                    }
                }
            }

        }
    }
}
