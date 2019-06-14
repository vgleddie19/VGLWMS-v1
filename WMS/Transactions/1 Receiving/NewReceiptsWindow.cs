using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Framework;

namespace WMS
{
    public partial class NewReceiptsWindow : Form
    {
        public String oms_shipment_id = "";
        Dictionary<String, DataRow> clients = new Dictionary<string, DataRow>();
        Dictionary<String, DataRow> customers = new Dictionary<string, DataRow>();
        Dictionary<String, int> uomqty = new Dictionary<string, int>();
        DataTable oms_productrec = null;
        bool formload = false;

        #region Form Initialization
        public NewReceiptsWindow()
        {
            InitializeComponent();
            DataTable  dt = FAQ.GetEmployees("SELECT * FROM EMPLOYEES");
            cboreceivedby.DataSource = dt;
            cboreceivedby.DropDownStyle = ComboBoxStyle.DropDown;
            cboreceivedby.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboreceivedby.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboreceivedby.DisplayMember = "completename";
            cboreceivedby.ValueMember = "employee_id";
            if (dt.Rows.Count > 0)
                cboreceivedby.SelectedIndex = 0;

            cboreceivedfrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumericUpper_KeyPress);
            cboreceivedby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumericUpper_KeyPress);
        }

        private void NewReceiptsWindow_Load(object sender, EventArgs e)
        {
            DataSupport oms_dh = new DataSupport("Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"]);
            var dt1 = oms_dh.ExecuteDataSet("SELECT * FROM base_client where clientcode != 'ALL'").Tables[0];
            cboreceivedfrom.DataSource = dt1;
            cboreceivedfrom.DisplayMember = "clientname";
            cboreceivedfrom.ValueMember = "clientcode";
            cboreceivedfrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboreceivedfrom.SelectedIndex = 0;
            clients = Utils.BuildIndex_DataTable(dt1, "clientcode");
            lblclientadd.Text = clients[cboreceivedfrom.SelectedValue.ToString()]["clientaddress"].ToString();

            customers = Utils.BuildIndex_DataTable(oms_dh.ExecuteDataSet("SELECT * FROM TransportCustomers").Tables[0], "custcode");

            formload = true;
        }
        #endregion

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (txtrrno.Text.Length <= 0)
            {
                MessageBox.Show("Missing Receiving Report Number");
                return;
            }

            if (txtrefno.Text.Length <= 0)
            {
                MessageBox.Show("Missing Reference Number");
                return;
            }

            if (headerGrid.Rows.Count <= 0)
            {
                MessageBox.Show("Grid can't be blank");
                return;
            }

            if (cboreceivedby.Text == "")
            {
                MessageBox.Show("Received By can't be blank");
                return;
            }

            NewReceiptConfirmationWindow dialog = new NewReceiptConfirmationWindow();
            dialog.WindowState = FormWindowState.Maximized;
            dialog.parent = this;
            dialog.oms_productrec = oms_productrec;
            if (dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewReceiptsDetailWindow dialog = new NewReceiptsDetailWindow();
            dialog.parent = this;
            dialog.clientcode = (rbCustomer.Checked) ? "" : cboreceivedfrom.SelectedValue.ToString();
            dialog.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (headerGrid.Rows.Count == 0)
                return;
            var row = headerGrid.SelectedRows[0];
            headerGrid.Rows.Remove(row);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = FAQ.GetOMSIncoming();

            SelectGridWindow dialog = new SelectGridWindow();
            dialog.WindowState = FormWindowState.Maximized;
            dialog.dataGridView1.DataSource = dt;
            dialog.dataGridView1.Columns["sourcetype"].Visible = false;
            oms_productrec = null;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Load Header
                headerGrid.Rows.Clear();

                var header_row = dialog.dataGridView1.SelectedRows[0];

                if (header_row.Cells["sourcetype"].Value.ToString() == "CLIENT")
                    rbclient.Checked = true;
                else
                    rbCustomer.Checked = true;

                cboreceivedfrom.Text = header_row.Cells["Source Name"].Value.ToString();
                txtrefno.Text = header_row.Cells["Document Reference #"].Value.ToString();
                txtshippername.Text = header_row.Cells["shippername"].Value.ToString();
                txtvanno.Text = header_row.Cells["vanno"].Value.ToString();

                // Load Details
                {
                    DataTable detail_dt = FAQ.GetOMSIncomingDetails(dialog.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                    List<String> _listuom = new List<string>();
                    foreach (DataRow row in detail_dt.Rows)
                    {
                        _listuom.Add(row["Uom"].ToString());
                        headerGrid.Rows.Add(row["Product"].ToString(), row["description"], row["expected_qty"], null, row["lot_no"], row["expiry"], row["remarks"], row["_lineno"]);
                        //headerGrid.Rows.Add(null, row["description"], row["expected_qty"],null, row["lot_no"], row["expiry"], row["remarks"], row["_lineno"]);
                    }
                    foreach (DataGridViewRow item in headerGrid.Rows)
                    {
                        string code = item.Cells[product_id.Name].Value.ToString();
                        var dts = Connection.GetOMSConnection.ExecuteDataSet("Select distinct uom from itemprice where prodcode = '" + code + "'").Tables[0];
                        DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
                        dgvcc = (DataGridViewComboBoxCell)headerGrid.Rows[item.Index].Cells[uom.Name];
                        dgvcc.DataSource = dts;
                        dgvcc.DisplayMember = "uom";
                        dgvcc.ValueMember = "uom";
                        dgvcc.Value = _listuom[item.Index];
                    }


                    oms_productrec = detail_dt;
                }

                //headerGrid
                oms_shipment_id = dialog.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            formload = false;
            if(headerGrid.Rows.Count >= 1)
            {
                string source = (rbclient.Checked) ? "Client" : "Customer";
                if (MessageBox.Show(String.Format("Warning: You will lost all the product you inputed in your datagrid. Are you sure you want to change {0}?",source), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    headerGrid.Rows.Clear();
                }
            }


            if (rbCustomer.Checked)
            {
                DataSupport oms_dh = new DataSupport("Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"]);
                var dt = oms_dh.ExecuteDataSet("SELECT * FROM TransportCustomers").Tables[0];
                cboreceivedfrom.DataSource = dt;
                cboreceivedfrom.DisplayMember = "customer";
                cboreceivedfrom.ValueMember = "custcode";
                cboreceivedfrom.DropDownStyle = ComboBoxStyle.DropDownList;
                cboreceivedfrom.SelectedIndex = 0;
                cboreceivedfrom.DropDownStyle = ComboBoxStyle.DropDown;
                cboreceivedfrom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboreceivedfrom.AutoCompleteSource = AutoCompleteSource.ListItems;
                lblclientadd.Text = customers[cboreceivedfrom.SelectedValue.ToString()]["address"].ToString();
            }
            else
            {
                DataSupport oms_dh = new DataSupport("Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"]);
                var dt = oms_dh.ExecuteDataSet("SELECT * FROM base_client where clientcode != 'ALL'").Tables[0];
                cboreceivedfrom.DataSource = dt;
                cboreceivedfrom.DisplayMember = "clientname";
                cboreceivedfrom.ValueMember = "clientcode";
                cboreceivedfrom.DropDownStyle = ComboBoxStyle.DropDownList;
                cboreceivedfrom.SelectedIndex = 0;
                lblclientadd.Text = clients[cboreceivedfrom.SelectedValue.ToString()]["clientaddress"].ToString();
            }
            formload = true;
        }

        private void cboreceivedfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formload)
                return;
            if (rbclient.Checked)
            {
                var dt = DataSupport.RunDataSet("SELECT DISTINCT product_id FROM Products where [default_owner] = '" + cboreceivedfrom.SelectedValue + "'").Tables[0];
                product_id.DataSource = dt;
                lblclientadd.Text = clients[cboreceivedfrom.SelectedValue.ToString()]["clientaddress"].ToString();
            }
            else
            {
                var dt = DataSupport.RunDataSet("SELECT DISTINCT product_id FROM Products").Tables[0];
                product_id.DataSource = dt;
                lblclientadd.Text = customers[cboreceivedfrom.SelectedValue.ToString()]["address"].ToString();
            }
            product_id.DisplayMember = "product_id";
            product_id.ValueMember = "product_id";
            product_id.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void rbclient_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void headerGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (headerGrid.Rows.Count >= 1)
            {
                if (e.ColumnIndex == headerGrid.Columns[product_id.Name].Index)
                {
                    string code = headerGrid.Rows[e.RowIndex].Cells[product_id.Name].Value.ToString();
                    var dt = DataSupport.RunDataSet("Select distinct uom from itemprice where prodcode = '" + code + "'").Tables[0];
                    DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
                    dgvcc = (DataGridViewComboBoxCell)headerGrid.Rows[e.RowIndex].Cells[uom.Name];
                    dgvcc.DataSource = dt;
                    dgvcc.DisplayMember = "uom";
                    dgvcc.ValueMember = "uom";

                }
            }
        }
    }
}
