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
    public partial class NewPutawaySplitLocationWindow : Form
    {
        public NewPutawaySplitLocationWindow()
        {
            InitializeComponent();
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.OK;
        }

        private void NewPutawaySplitLocationWindow_Load(object sender, EventArgs e)
        {

            var dt = FAQ.GetLocations();
            txtLocation.Items.Clear();
            foreach (DataRow row in dt.Rows)
                if (row["location_id"].ToString() != "STAGING-IN")
                    txtLocation.Items.Add(row["location_id"].ToString());
        }
    }
}
