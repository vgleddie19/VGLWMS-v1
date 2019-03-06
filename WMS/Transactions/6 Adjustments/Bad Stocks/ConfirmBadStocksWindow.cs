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
    public partial class ConfirmBadStocksWindow : Form
    {
        public NewBadStockWindow parent = new NewBadStockWindow();


        public ConfirmBadStocksWindow()
        {
            InitializeComponent();
        }

        private void ConfirmBadStocksWindow_Load(object sender, EventArgs e)
        {
            btnPrintPreview.Select();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table'>");

            sb.Append("<thead>");
            sb.Append("<tr>");

            {
                foreach (DataGridViewColumn col in parent.header_grid.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(col.HeaderText);
                    sb.Append("</th>");
                }
            }

            sb.Append("</tr>");
            sb.Append("</thead>");

            foreach (DataGridViewRow row in parent.header_grid.Rows)
            {
                sb.Append("<tr>");
                foreach (DataGridViewColumn col in parent.header_grid.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row.Cells[col.Name].Value.ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.bad_stock_declaration_form
                .Replace("[declared_by]", parent.txtDeclaredBy.Text)
                .Replace("[declared_on]", DateTime.Now.ToString())
                .Replace("[items_grid]", sb.ToString())

                ;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Text != "Print")
                SaveData();
            else
            {
                webBrowser1.ShowPrintPreviewDialog();
            }
        }


        private void SaveData()
        {

            String now = DateTime.Now.ToString();

            String sql = "";

            String bs_id = DataSupport.GetNextMenuCodeInt("BS");

            // Save Transaction
             sql += DataSupport.GetInsert("BadStockDeclarations", Utils.ToDict(
                "declaration_id", bs_id
               , "declared_by", parent.txtDeclaredBy.Text
               , "declared_on", now
               , "status", "OK"
                ));

            foreach (DataGridViewRow row in parent.header_grid.Rows)
            {
                sql += DataSupport.GetInsert("BadStockDeclarationDetails", Utils.ToDict(
                   "declaration", bs_id
                  , "line", parent.header_grid.Rows.IndexOf(row) + 1
                  , "product", row.Cells["product"].Value.ToString()
                  , "uom", row.Cells["uom"].Value.ToString()
                  , "lot_no", row.Cells["lot_no"].Value.ToString()
                  , "expiry", row.Cells["expiry"].Value.ToString()
                  , "location", row.Cells["location"].Value.ToString()
                  , "qty", row.Cells["qty"].Value.ToString()
                  , "reason", row.Cells["reason"].Value.ToString()
                  , "bad_stock_storage", row.Cells["bad_stock_storage"].Value.ToString()
                   ));
            }

            foreach (DataGridViewRow row in parent.header_grid.Rows)
            {
                // Update Transaction Ledger
                {
                    // Out with the good storage location
                    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                    outsDT.Rows.Add(row.Cells["location"].Value.ToString(), now, "OUT", "BAD STOCK DEC", bs_id);

                    sql += LedgerSupport.UpdateLocationLedger(outsDT);


                    // In with the bad storage location
                    DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                    insDT.Rows.Add(row.Cells["bad_stock_storage"].Value.ToString(), now, "IN", "BAD STOCK DEC", bs_id);
                    sql += LedgerSupport.UpdateLocationLedger(insDT);

                }

                // Update Location Products Ledger
                {
                    // Out with the good storage location
                    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
                    outsDT.Rows.Add(row.Cells["location"].Value.ToString(), row.Cells["product"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value);
                    sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);


                    // In with the bad storage location
                    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();
                    insDT.Rows.Add(row.Cells["bad_stock_storage"].Value.ToString(), row.Cells["product"].Value, row.Cells["qty"].Value, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value);
                    sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

                }
                

                // Update For Resolution
                sql += DataSupport.GetInsert("ForResolutions", Utils.ToDict(
                      "trans_source", "BAD_STOCK_DEC"
                    , "trans_id", bs_id
                    , "detected_on", now
                    , "product", row.Cells["product"].Value
                    , "uom", row.Cells["uom"].Value
                    , "lot_no", row.Cells["lot_no"].Value
                    , "expiry", row.Cells["expiry"].Value
                    , "location", row.Cells["bad_stock_storage"].Value.ToString()
                    , "variance_type", "BAD STOCK"
                    , "variance_qty", row.Cells["qty"].Value
                    , "status", "FOR RESOLUTION"
                    , "line", parent.header_grid.Rows.IndexOf(row) + 1
                    ));

            }

            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", bs_id);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
        }


    }
}
