using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework;

namespace WMS
{
    public partial class NewReceiptsWindow : Form
    {
        public String oms_shipment_id = "";

        public NewReceiptsWindow()
        {
            InitializeComponent();
            DataTable  dt = FAQ.GetEmployees("SELECT * FROM EMPLOYEES");
            cboReceivedBy.DataSource = dt;
            cboReceivedBy.DropDownStyle = ComboBoxStyle.DropDown;
            cboReceivedBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboReceivedBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboReceivedBy.DisplayMember = "name";
            cboReceivedBy.ValueMember = "employee_id";
            if (dt.Rows.Count > 0)
                cboReceivedBy.SelectedIndex = 0;
        }


        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (cboReceivedBy.Text == "")
            {
                MessageBox.Show("Received By can't be blank");
                return;
            }

            NewReceiptConfirmationWindow dialog = new NewReceiptConfirmationWindow();
            dialog.parent = this;
            if (dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
            if (dialog.btnCancel.Visible == false)
                DialogResult = DialogResult.OK;
        }

        private void NewReceiptWindow_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewReceiptsDetailWindow dialog = new NewReceiptsDetailWindow();
            dialog.parent = this;
            dialog.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var row = headerGrid.SelectedRows[0];
            headerGrid.Rows.Remove(row);
        }

        private void NewReceiptsWindow_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = FAQ.GetOMSIncoming();

            SelectGridWindow dialog = new SelectGridWindow();
            dialog.dataGridView1.DataSource = dt;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Load Header
                var header_row = dialog.dataGridView1.SelectedRows[0];

                txtReceivedFrom.Text = header_row.Cells["client"].Value.ToString();
                txtReferenceDocument.Text = header_row.Cells["document_reference"].Value.ToString();


                // Load Details
                {
                    DataTable detail_dt = FAQ.GetOMSIncomingDetails(dialog.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                    foreach (DataRow row in detail_dt.Rows)
                    {
                        headerGrid.Rows.Add(row["Product"], row["Product"], row["expected_qty"], row["Uom"], row["lot_no"], row["expiry"], "");
                    }
                }

                oms_shipment_id = dialog.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
        }
    }
}
