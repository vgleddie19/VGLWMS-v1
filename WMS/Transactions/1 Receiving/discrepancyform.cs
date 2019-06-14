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
    public partial class discrepancyform : Form
    {
        public DataTable discrepancy = null;
        DialogResult formdialog = new DialogResult();
        public discrepancyform()
        {
            InitializeComponent();
            formdialog = DialogResult.Cancel;
        }

        private void discrepancyform_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in discrepancy.Rows)
            {
                headerGrid.Rows.Add(row["Product"], row["desc"], row["uom"], row["qty"], row["uomactual"], row["qtyactual"], row["lot"], row["expiry"], row["prodremarks"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in discrepancy.Rows)
            {
                row["remarks"] = txtremarks.Text;
            }

            foreach (DataGridViewRow row in headerGrid.Rows)
            { 
                foreach (DataRow drow in discrepancy.Select(String.Format("product = '{0}' AND lot = '{1}' AND expiry = '{2}' AND uom = '{3}' AND qty = '{4}'", row.Cells["product_id"].Value, row.Cells["lot"].Value, row.Cells["expiry"].Value, row.Cells["uom"].Value, row.Cells["quantity"].Value)))
                {
                    drow["prodremarks"] = row.Cells["remarks"].Value;
                }
            }
            


            formdialog = DialogResult.OK;
            this.Close();
        }

        private void discrepancyform_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = formdialog;
        }
    }
}
