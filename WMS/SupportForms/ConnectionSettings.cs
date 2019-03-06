using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.ModifyRegistry;

namespace WMS
{
    public partial class ConnectionSettings : Form
    {
       public Dictionary<String, Dictionary<String, String>> dbConnectionSettings = new Dictionary<String, Dictionary<String, String>>();

        public ConnectionSettings()
        {
            InitializeComponent();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Program Launcher Settings|*.prs";
            openFileDialog1.Title = "Open an Program Launcher Settings";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                programsGrid.Rows.Clear();
                System.IO.FileStream fs2 = new System.IO.FileStream(openFileDialog1.FileName.ToString(), FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs2);
                String data = reader.ReadToEnd();
                String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                reader.Close();
                foreach (String program in programs)
                {
                    String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                    programsGrid.Rows.Add(records);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Program Launcher Settings|*.prs";
            saveFileDialog1.Title = "Save an settings";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs1 = new System.IO.FileStream(saveFileDialog1.FileName.ToString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                String program = "";
                foreach (DataGridViewRow dRow in programsGrid.Rows)
                {
                    if (dRow.Index == programsGrid.Rows.Count - 1)
                        break;
                    String name = dRow.Cells["gridcolname"].Value.ToString();
                    String server = dRow.Cells["gridcolserver"].Value.ToString();
                    String user = dRow.Cells["gridcoluser"].Value.ToString();
                    String password = dRow.Cells["gridcolpassword"].Value.ToString();
                    String dbname = dRow.Cells["gridcoldbname"].Value.ToString();
                    program += String.Format("{0}<limiter>{1}<limiter>{2}<limiter>{3}<limiter>{4}<limiter1>", name, server,  user, password, dbname);
                }

                StreamWriter writer = new StreamWriter(fs1);
                writer.Write(program);
                writer.Close();
                fs1.Dispose();
                MessageBox.Show("Settings Successfully Export");
            }
        }

        private void ConnectionSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                RegistrySupport registry = new RegistrySupport();
                String data = registry.Read(Settings.PROGRAM_GRID_KEY);
                String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String program in programs)
                {
                    String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                    programsGrid.Rows.Add(records);
                }
            }
            catch (Exception)
            {

            }
        }

        private void SaveData()
        {
            String data = "";
            foreach (DataGridViewRow row in programsGrid.Rows)
            {
                // Ignore last row
                if (row.Index == programsGrid.Rows.Count - 1)
                    break;
                String name = row.Cells["gridcolname"].Value.ToString();
                String server = row.Cells["gridcolserver"].Value.ToString();
                String user = row.Cells["gridcoluser"].Value.ToString();
                String password = row.Cells["gridcolpassword"].Value.ToString();
                String dbname = row.Cells["gridcoldbname"].Value.ToString();
                data += String.Format("{0}<limiter>{1}<limiter>{2}<limiter>{3}<limiter>{4}<limiter1>", name, server, user, password, dbname);
            }
            RegistrySupport registry = new RegistrySupport();
            if (registry.Write(Settings.PROGRAM_GRID_KEY, data))
            {
                MessageBox.Show("Settings Saved");
                this.Close();
            }
        }

        //private void programsGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    if (programsGrid.CurrentRow.Tag != null)
        //        e.Control.Text = programsGrid.CurrentRow.Tag.ToString();
        //}

        private void programsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            programsGrid.Rows[e.RowIndex].Tag = e.Value;
            if (programsGrid.Columns[e.ColumnIndex].Name == "gridcolpassword" && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (programsGrid.Rows.Count != 1)
            {
                SaveData();
            }
        }

        private void ConnectionSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.SetConnectionDetails();
            dbConnectionSettings = Utils.DBConnection;
        }
    }
}
