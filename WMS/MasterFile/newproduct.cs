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
    public partial class newproduct : Form
    {
        public string _entrytype = "new";
        public string id = null;
        DataSupport oms_dh = null;
        public newproduct()
        {
            InitializeComponent();
            DataGridViewCellStyle style =
            dataGridView1.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.SteelBlue;
            style.ForeColor = Color.White;
            style.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            oms_dh = new DataSupport("Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"]);
            cboclient.DataSource =  oms_dh.ExecuteDataSet("SELECT * FROM base_client").Tables[0];
            //cboclient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cboclient.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboclient.DisplayMember = "clientname";
            cboclient.ValueMember = "clientcode";
        }

        private void btnDeclare_Click(object sender, EventArgs e)
        {
            if (_entrytype == "new")
            {
                savedwms();
                saved();
                clear();
            }
            else
            {
                updatewms();
                update();
            }
        }
        private void clear()
        {
            txtCode.Clear();
            txtdesc1.Clear();
            txtdesc2.Clear();
            txtdesc3.Clear();
            txtCategory.Clear();
            dataGridView1.Rows.Clear();
        }
        private void saved()
        {
            StringBuilder sql = new StringBuilder();
            Dictionary<String, Object> header = new Dictionary<String, Object>();
            header.Add("product_id", txtCode.Text);
            header.Add("description", txtdesc1.Text);
            header.Add("description1", txtdesc2.Text);
            header.Add("description2", txtdesc3.Text);
            header.Add("category", txtCategory.Text);
            header.Add("pcs_per_case", "0");
            sql.Append(DataSupport.GetInsert("products", header));

            if ((bool)oms_dh.ExecuteScalar(sql.ToString()))
            {
                id = oms_dh.ExecuteDataSet("Select max(id) from Products").Tables[0].Rows[0][0].ToString();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (dataGridView1.Rows.IndexOf(row) == dataGridView1.Rows.Count )
                        break;
                    Dictionary<String, Object> details = new Dictionary<String, Object>();
                    details.Add("productID", id);
                    details.Add("prodCode", txtCode.Text);
                    if (string.IsNullOrEmpty(row.Cells[colUOM.Name].Value as string))
                    { details.Add("uom", ""); }
                    else
                    { details.Add("uom", row.Cells[colUOM.Name].Value.ToString()); }
                    if (string.IsNullOrEmpty(row.Cells[colUOM.Name].Value as string))
                    { details.Add("qty", ""); }
                    else
                    { details.Add("qty", row.Cells[colQty.Name].Value.ToString()); }
                    sql.Append(DataSupport.GetUpdate("itemPrice", details, new List<string> { "productid", "uom" }));
                }
                oms_dh.ExecuteNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
            }
        }

        private void update()
        {
            StringBuilder sql = new StringBuilder();
            var primary = new List<string>();
            Dictionary<String, Object> header = new Dictionary<String, Object>();
            header.Add("id", id);
            header.Add("product_id", txtCode.Text);
            header.Add("description", txtdesc1.Text);
            header.Add("description1", txtdesc2.Text);
            header.Add("description2", txtdesc3.Text);
            header.Add("category", txtCategory.Text);
            header.Add("default_owner", cboclient.SelectedValue);
            sql.Append(DataSupport.GetUpdate("products", header, new List<string> { "id" }));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (dataGridView1.Rows.IndexOf(row) == dataGridView1.Rows.Count)
                    break;
                var primarys = new List<string>();
                Dictionary<String, Object> details = new Dictionary<String, Object>();
                details.Add("productid", id);
                details.Add("prodcode", txtCode.Text);
                if (string.IsNullOrEmpty(row.Cells[colUOM.Name].Value as string))
                {
                    details.Add("uom", "");
                }
                else
                {
                    details.Add("uom", row.Cells[colUOM.Name].Value.ToString());
                }
                if (string.IsNullOrEmpty(row.Cells[colUOM.Name].Value as string))
                {
                    details.Add("qty", "0");
                }
                else
                {
                    details.Add("qty", row.Cells[colQty.Name].Value.ToString());
                }
                sql.Append(DataSupport.GetUpdate("itemPrice", details, new List<string> { "productid", "uom" }));
            }
            oms_dh.ExecuteNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
            MessageBox.Show("saved");
            DialogResult = DialogResult.OK;
        }
        private void savedwms()
        {
            StringBuilder sql = new StringBuilder();
            Dictionary<String, Object> header = new Dictionary<String, Object>();
            header.Add("id", id);
            header.Add("product_id", txtCode.Text);
            header.Add("description", txtdesc1.Text);
            header.Add("description1", txtdesc2.Text);
            header.Add("description2", txtdesc3.Text);
            header.Add("category", txtCategory.Text);
            header.Add("pcs_per_case", "0");
            header.Add("default_owner", cboclient.SelectedValue);
            sql.Append(DataSupport.GetInsert("products", header));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var primary = new List<string>();
                if (dataGridView1.Rows.IndexOf(row) == dataGridView1.Rows.Count)
                    break;
                Dictionary<String, Object> details = new Dictionary<String, Object>();
                details.Add("product", txtCode.Text);
                if (string.IsNullOrEmpty(row.Cells[colUOM.Name].Value as string))
                { details.Add("uom", ""); }
                else
                { details.Add("uom", row.Cells[colUOM.Name].Value.ToString()); }
                if (string.IsNullOrEmpty(row.Cells[colUOM.Name].Value as string))
                { details.Add("qty", "0"); }
                else
                { details.Add("qty", row.Cells[colQty.Name].Value.ToString()); }

                sql.Append(DataSupport.GetUpsert("ProductUOMs", details, new List<String> { "product", "uom" }));
            }
            DataSupport.RunNonQuery(sql.ToString());
        }
        private void updatewms()
        {
            try
            {

                StringBuilder sql = new StringBuilder();
                {
                    var primary = new List<string>();
                    Dictionary<String, Object> header = new Dictionary<String, Object>();
                    header.Add("id", id);
                    header.Add("product_id", txtCode.Text);
                    header.Add("description", txtdesc1.Text);
                    header.Add("description1", txtdesc2.Text);
                    header.Add("description2", txtdesc3.Text);
                    header.Add("category", txtCategory.Text);                    
                    sql.Append(DataSupport.GetUpdate("products", header,new List<String> { "id" }));
                }
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var primarys = new List<string>();
                        if (dataGridView1.Rows.IndexOf(row) == dataGridView1.Rows.Count)
                            break;
                        Dictionary<String, Object> headers = new Dictionary<String, Object>();
                        headers.Add("product", txtCode.Text);
                        headers.Add("id", id);
                        headers.Add("uom", row.Cells[colUOM.Name].Value);
                        headers.Add("qty", row.Cells[colQty.Name].Value);
                        headers.Add("barcode", row.Cells[colbarcode.Name].Value);
                        sql.Append(DataSupport.GetUpsert("ProductUOMs", headers, new List<String> { "id", "uom" }));
                    }
                }
                DataSupport.RunNonQuery(sql.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
