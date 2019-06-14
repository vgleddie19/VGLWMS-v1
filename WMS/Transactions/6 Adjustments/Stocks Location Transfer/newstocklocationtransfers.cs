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
    public partial class newstocklocationtransfers : Form
    {
        public newstocklocationtransfers()
        {
            InitializeComponent();
            var dt = FAQ.GetLocations();
            txtLocation.Items.Clear();
            foreach (DataRow row in dt.Rows)
                if (row["TYPE"].ToString() != "PROCESSING")
                    txtLocation.Items.Add(row["location_id"].ToString());
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            stockstransferdetails dialog = new stockstransferdetails();
            dialog.products_to_transfer = FAQ.whatAreTheStocksToTransfer(txtLocation.Text);
            dialog.parent = this;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }

        private void txtLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
