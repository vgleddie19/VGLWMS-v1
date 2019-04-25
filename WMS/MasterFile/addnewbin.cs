using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.Utilities;

namespace WMS
{
    public partial class addnewbin : Form
    {
        public String entrytype = null;
        public String bin_id = null;
        Boolean formload = false;
        Dictionary<String, DataRow> products = null;
        Dictionary<String, DataRow> locations = null;
        public addnewbin()
        {
            InitializeComponent();
            this.txtbin_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumericUpper_KeyPress);

            //if (entrytype != "update")
            //{
            DataTable dt = DataSupport.RunDataSet(@"SELECT * FROM PRODUCTS ORDER BY product_id").Tables[0];
            products = Utils.BuildIndex_DataTable(dt, "product_id");
            locations = Utils.BuildIndex("SELECT * FROM Locations ORDER BY location_id", "location_id");
            UISetter.SetComboBox(cboproduct, dt, "description", "product_id", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDown);
            dt = DataSupport.RunDataSet(String.Format("SELECT * FROM PRODUCTuoms WHERE product = '{0}'", dt.Rows[0]["product_id"])).Tables[0];
            if (dt.Rows.Count != 0)
                UISetter.SetComboBox(cbouom, dt, "uom", "uom", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDownList);
            dt = DataSupport.RunDataSet(String.Format("SELECT * FROM LocationProductsLedger WHERE product = '{0}' and uom = '{1}'", cboproduct.Text, cbouom.Text)).Tables[0];
            if (dt.Rows.Count != 0)
                UISetter.SetComboBox(cbolot, dt, "lot_no", "lot_no", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDown);
        }

        private void addnewbin_Load(object sender, EventArgs e)
        {
            if(entrytype =="update")
            {
                LoadData();
                txtbin_id.Enabled = false;
            }
            formload = true;
        }

        private void LoadData()
        {
            foreach (DataRow drow in DataSupport.RunDataSet(@"SELECT [location],[product],[uom],[min_qty][min],[max_qty][max] FROM [BinProducts] WHERE location = '" + bin_id  + "'").Tables[0].Rows)
            {
                txtbin_id.Text = drow["location"].ToString();
                cboproduct.SelectedValue = drow["product"].ToString();
                cbouom.Text = drow["uom"].ToString();
                txtmin_qty.Text = drow["min"].ToString();
                txtmax_qty.Text = drow["max"].ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder validate = new StringBuilder();
            {
                if (entrytype == "new")
                {
                    if (locations.ContainsKey(txtbin_id.Text.Trim()))
                        validate.Append("Bin ID already exist\n");
                }
                if (txtbin_id.Text.Trim().Length == 0)
                    validate.Append("Missing Bin ID\n");
                if (!products.ContainsKey(cboproduct.SelectedValue.ToString()))
                    validate.Append("product not found\n");
                if (cbouom.Text.Trim().Length == 0)
                    validate.Append("Missing UOM");
                if (cbolot.Text.Trim().Length == 0)
                    validate.Append("Missing Lot Number");
                if (cboexpiry.Text.Trim().Length == 0)
                    validate.Append("Missing Expiry");                
            }
            if (validate.Length != 0)
            {
                MessageBox.Show(validate.ToString());
                return;
            }
            if (entrytype == "update")
            {
                sql.Append(DataSupport.GetUpdate("[BinProducts]", Utils.ToDict(
                "location", txtbin_id.Text
               , "product", cboproduct.SelectedValue
               , "uom", cbouom.Text
               , "min_qty", txtmin_qty.Text
               , "max_qty", txtmax_qty.Text
                ), new List<string> { "location" }));
                if (FAQ.isbinproductledgerexist(txtbin_id.Text,cboproduct.Text,cbouom.Text,cbolot.Text,cboexpiry.Text))
                {
                    sql.Append(DataSupport.GetUpdate("[BinProductLedger]", Utils.ToDict(
                                "location", txtbin_id.Text
                               , "product", cboproduct.SelectedValue
                               , "uom", cbouom.Text
                               , "lot_no", cbolot.Text
                               , "expiry", cboexpiry.Text
                               , "status", "ACTIVE"
                                ), new List<string> { "location","product","uom","lotno","expiry"}));
                }
                else
                {
                    sql.Append(DataSupport.GetInsert("[BinProductLedger]", Utils.ToDict(
                                "location", txtbin_id.Text
                               , "product", cboproduct.SelectedValue
                               , "uom", cbouom.Text
                               , "lot_no", cbolot.Text
                               , "expiry", cboexpiry.Text
                               , "actualqty", 0
                               , "min_qty", txtmin_qty.Text
                               , "max_qty", txtmax_qty.Text
                               , "qty_to_replenished", txtmax_qty.Text
                               , "status", "ACTIVE"
                                )));
                }
            }
            else
            {
                sql.Append(DataSupport.GetInsert("[Locations]", Utils.ToDict(
                "location_id", txtbin_id.Text
               , "description", txtbin_id.Text
               , "type", "BIN"
               , "status", "ACTIVE"
                )));

                sql.Append(DataSupport.GetInsert("[BinProducts]", Utils.ToDict(
                                "location", txtbin_id.Text
                               , "product", cboproduct.SelectedValue
                               , "uom", cbouom.Text
                               , "lot_no", cbolot.Text
                               , "expiry", cboexpiry.Text
                               , "min_qty", txtmin_qty.Text
                               , "max_qty", txtmax_qty.Text
                                )));
                sql.Append(DataSupport.GetInsert("[BinProductLedger]", Utils.ToDict(
                                "location", txtbin_id.Text
                               , "product", cboproduct.SelectedValue
                               , "uom", cbouom.Text
                               , "lot_no", cbolot.Text
                               , "expiry", cboexpiry.Text
                               , "actualqty", 0
                               , "min_qty", txtmin_qty.Text
                               , "max_qty", txtmax_qty.Text
                               , "qty_to_replenished", txtmax_qty.Text
                               , "status", "ACTIVE"
                                )));
            }
            try
            {
                DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
                MessageBox.Show("Success");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formload)
                return;
            DataTable dt = DataSupport.RunDataSet(String.Format("SELECT DISTINCT uom FROM PRODUCTuoms WHERE product = '{0}'", cboproduct.SelectedValue)).Tables[0];
            if (dt.Rows.Count != 0)
                UISetter.SetComboBox(cbouom, dt, "uom", "uom", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDownList);
        }

        private void cbouom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formload)
                return;
            
            DataTable dt = DataSupport.RunDataSet(String.Format("SELECT DISTINCT lot_no FROM LocationProductsLedger WHERE product = '{0}' and uom = '{1}'", cboproduct.SelectedValue, cbouom.Text)).Tables[0];
            if (dt.Rows.Count != 0)
                UISetter.SetComboBox(cbolot, dt, "lot_no", "lot_no", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDownList);
        }

        private void cbolot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formload)
                return;
            DataTable dt = DataSupport.RunDataSet(String.Format("SELECT DISTINCT convert(varchar, expiry, 101)[expiry] FROM LocationProductsLedger WHERE product = '{0}' and uom = '{1}' AND lot_no = '{2}'", cboproduct.SelectedValue, cbouom.Text,cbolot.Text)).Tables[0];
            if (dt.Rows.Count != 0)
                UISetter.SetComboBox(cboexpiry, dt, "expiry", "expiry", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDown);
        }

        private void cboexpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formload)
                return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
