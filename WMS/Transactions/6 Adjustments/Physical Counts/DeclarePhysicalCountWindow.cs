using Framework;
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
    public partial class DeclarePhysicalCountWindow : Form
    {

        public String phcount_id;

        public DataRow phcount_header_row;

        public DeclarePhysicalCountWindow()
        {
            InitializeComponent();
        }

        private void DeclarePhysicalCountWindow_Load(object sender, EventArgs e)
        {
            DataTable dt = DataSupport.RunDataSet(@"SELECT pc.*,p.description[desc] FROM PhysicalCountDetailItems pc join products p on pc.product = p.product_id WHERE phcount = '" + phcount_id + "' AND pc.product !='EMPTY'").Tables[0];
            foreach (DataRow row in dt.Rows)
                header_grid.Rows.Add(row["location"], row["product"], row["desc"], row["uom"], row["lot_no"], DateTime.Parse( row["expiry"].ToString()).ToShortDateString(),"", "YES");
            phcount_header_row = DataSupport.RunDataSet("SELECT * FROM PhysicalCounts WHERE phcount_id='" + phcount_id + "'; ").Tables[0].Rows[0];
        }

        private void btnDeclareUnexpectedProduct_Click(object sender, EventArgs e)
        {
            // First dialog = scan item
            DeclareUnexpectedProductWindow dialog = new DeclareUnexpectedProductWindow();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                DataTable dt = DataSupport.RunDataSet("SELECT lot_no[Lot No], expiry[Expiry] FROM LocationProductsLedger WHERE product = '" + dialog.product + "' AND uom ='" + dialog.uom + "'; ").Tables[0];
                foreach (DataRow row in dt.Rows)
                    row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();

                if (dt.Rows.Count == 0)
                {
                    ManualDetailsPhysicalCount(dialog.product, dialog.descp, dialog.uom);
                }
                else
                {
                    // Second Dialog = select lot no and expiry
                    SelectGridWindow select_dialog = new SelectGridWindow();
                    select_dialog.dataGridView1.DataSource = dt;

                    if (select_dialog.ShowDialog() == DialogResult.OK)
                    {
                        // Third Dialog = select location
                        SelectGridWindow select_location_dialog = new SelectGridWindow();
                        select_location_dialog.Text = "WHERE DID YOU FIND IT?";
                        select_location_dialog.dataGridView1.DataSource = FAQ.GetLocationsFromPhysicalCount(phcount_id);
                        if (select_location_dialog.ShowDialog() == DialogResult.OK)
                        {

                            var location = select_location_dialog.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            var selected_row = select_dialog.dataGridView1.SelectedRows[0];

                            Boolean is_in_grid = false;
                            foreach (DataGridViewRow row in header_grid.Rows)
                            {
                                if (row.Cells["location"].Value.ToString() == location
                                 && row.Cells["product"].Value.ToString() == dialog.product
                                 && row.Cells["uom"].Value.ToString() == dialog.uom
                                 && row.Cells["lot_no"].Value.ToString() == selected_row.Cells["Lot No"].Value.ToString()
                                 && row.Cells["expiry"].Value.ToString() == selected_row.Cells["Expiry"].Value.ToString()
                                    )
                                {

                                    if (row.Cells["actual_qty"].Value.ToString() == "")
                                    {
                                        row.DefaultCellStyle.BackColor = Color.Yellow;

                                        MessageBox.Show("Sorry, this is not an unexpected product! Please see product highlighted in yellow");
                                        return;
                                    }

                                    row.Cells["actual_qty"].Value = int.Parse(row.Cells["actual_qty"].Value.ToString()) + 1;
                                    is_in_grid = true;
                                }
                            }

                            if (!is_in_grid)
                            {
                                var row_index = header_grid.Rows.Add(location, dialog.product, dialog.descp, dialog.uom, selected_row.Cells["Lot No"].Value.ToString(), selected_row.Cells["Expiry"].Value.ToString(), 1);
                                header_grid.Rows[row_index].Cells["actual_qty"].ReadOnly = true;
                                header_grid.Rows[row_index].Cells["actual_qty"].Style.BackColor = Color.LightGray;
                                header_grid.Rows[row_index].Cells["expected"].Value = "NO";
                            }
                        }
                    }
                    else if (select_dialog.ShowDialog() == DialogResult.Yes)
                    {
                        ManualDetailsPhysicalCount(dialog.product, dialog.descp, dialog.uom);
                    }
                }
            }
        }

        private void ManualDetailsPhysicalCount(String product,String descp,String uom)
        {
            manualaddedPhysicalCount mpc = new manualaddedPhysicalCount();
            if (mpc.ShowDialog() == DialogResult.OK)
            {
                // Third Dialog = select location
                SelectGridWindow select_location_dialog = new SelectGridWindow();
                select_location_dialog.Text = "WHERE DID YOU FIND IT?";
                select_location_dialog.dataGridView1.DataSource = FAQ.GetLocationsFromPhysicalCount(phcount_id);
                if (select_location_dialog.ShowDialog() == DialogResult.OK)
                {
                    var location = select_location_dialog.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    Boolean is_in_grid = false;
                    foreach (DataGridViewRow row in header_grid.Rows)
                    {
                        if (row.Cells["location"].Value.ToString() == location
                         && row.Cells["product"].Value.ToString() == product
                         && row.Cells["uom"].Value.ToString() == uom
                         && row.Cells["lot_no"].Value.ToString() == mpc.txtLot.Text
                         && row.Cells["expiry"].Value.ToString() == mpc.txtExpiry.Value.ToShortDateString()
                            )
                        {

                            if (row.Cells["actual_qty"].Value.ToString() == "")
                            {
                                row.DefaultCellStyle.BackColor = Color.Yellow;

                                MessageBox.Show("Sorry, this is not an unexpected product! Please see product highlighted in yellow");
                                return;
                            }

                            row.Cells["actual_qty"].Value = int.Parse(row.Cells["actual_qty"].Value.ToString()) + 1;
                            is_in_grid = true;
                        }
                    }

                    if (!is_in_grid)
                    {
                        var row_index = header_grid.Rows.Add(location, product, descp, uom, mpc.txtLot.Text, mpc.txtExpiry.Value.ToShortDateString(), 1);
                        header_grid.Rows[row_index].Cells["actual_qty"].ReadOnly = true;
                        header_grid.Rows[row_index].Cells["actual_qty"].Style.BackColor = Color.LightGray;
                        header_grid.Rows[row_index].Cells["expected"].Value = "NO";
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Boolean actual_quantity_missing = false;
            foreach (DataGridViewRow row in header_grid.Rows)
            {
                row.Cells["actual_qty"].Style.BackColor = Color.White;
                try
                { int.Parse(row.Cells["actual_qty"].Value.ToString()); }
                catch (Exception)
                {
                    row.Cells["actual_qty"].Style.BackColor = Color.Cyan;
                    actual_quantity_missing = true;
                }
                    
            }

            if (actual_quantity_missing)
            {
                MessageBox.Show("Actual Quantity Missing");
                return;
            }

            DeclarePhysicalCountConfirmationWindow dialog = new DeclarePhysicalCountConfirmationWindow();
            dialog.parent = this;
            if (dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeclarePhysicalCountWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                foreach (DataGridViewRow dRow in header_grid.SelectedRows)
                {
                    dRow.Cells[actual_qty.Name].ReadOnly = false;
                    dRow.Cells["actual_qty"].Style.BackColor = Color.White;
                }
            }
        }
    }
}
