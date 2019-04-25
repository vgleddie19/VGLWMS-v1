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
    public partial class DeclarePicklistScanID : Form
    {
        public DeclarePicklistScanID()
        {
            InitializeComponent();
        }

        private void txtPicklistCode_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!FAQ.DoesPicklistExist(txtPicklistCode.Text))
                {
                    MessageBox.Show("Barcode Not Recognized");
                    return;
                }

                bool isbinok = true;
                foreach (DataRow row in Framework.DataSupport.RunDataSet("SELECT Product, qty, Uom, lot_no [Lot No], Expiry , Location  FROM PicklistDetails WHERE picklist = '" + txtPicklistCode.Text + "'").Tables[0].Rows)
                {
                    isbinok = LedgerSupport.CheckBin(row["product"].ToString(), row["uom"].ToString(), row["qty"].ToString());
                    if (!isbinok)
                        break;
                }
                if (!isbinok)
                {
                    MessageBox.Show("Replenish the bin first before proceeding to stocks check!", "Unable to stock check");
                    return;
                }

                DeclarePicklistScanningWindow dialog = new DeclarePicklistScanningWindow();
                dialog.txtPicklist.Text = txtPicklistCode.Text;
                dialog.ShowDialog();
                this.Close();
            }
        }
    }
}
