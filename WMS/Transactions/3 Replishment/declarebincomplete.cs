using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class declarebincomplete : Form
    {
        public string picklistid = null;
        public string casebreakid = null;
        public string putawayid = null;

        public string type = "pick";
        public declarebincomplete()
        {
            InitializeComponent();
        }

        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (type == "pick")
                {
                    var dt = DataSupport.RunDataSet("SELECT * FROM [Picklists] WHERE picklist_id = '" + txtbarcode.Text + "' ").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        picklistid = txtbarcode.Text;
                        DialogResult = DialogResult.OK;
                    }
                }
                else if(type == "casebreak")
                {
                    var dt = DataSupport.RunDataSet("SELECT * FROM [Picklists] WHERE picklist_id = '" + picklistid + "' and [casebreak_id] = '" + txtbarcode.Text + "'").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        casebreakid = txtbarcode.Text;
                        DialogResult = DialogResult.OK;
                    }
                }
                else if (type == "putaway")
                {
                    var dt = DataSupport.RunDataSet("SELECT * FROM [Picklists] WHERE picklist_id = '" + picklistid + "' and [casebreak_id] = '" + casebreakid  + "' and [putaway_id] = '" + txtbarcode.Text + "'").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }
    }
}
