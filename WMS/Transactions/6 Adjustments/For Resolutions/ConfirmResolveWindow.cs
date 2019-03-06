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
    public partial class ConfirmResolveWindow : Form
    {
        public ResolveWindow parent = null;
        public ConfirmResolveWindow()
        {
            InitializeComponent();
        }

        private void ConfirmResolveWindow_Load(object sender, EventArgs e)
        {

            ResolutionsWindow grandparent = parent.parent;

            btnPrintPreview.Select();

           


            webBrowser1.DocumentText = Properties.Resources.resolution_report
                .Replace("[variance]", grandparent.txtVarianceType.Text)
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[source]", grandparent.txtSource.Text)
                .Replace("[detected]", grandparent.txtDetected.Text)
                .Replace("[product]", grandparent.txtProduct.Text)
                .Replace("[uom]", grandparent.txtUom.Text)
                .Replace("[lot_no]", grandparent.txtLotNo.Text)
                .Replace("[expiry]", grandparent.txtExpiry.Text)
                .Replace("[location]", grandparent.txtLocation.Text)
                .Replace("[qty_resolved]", parent.txtQtyToResolve.Text)
                .Replace("[charge_to]", parent.txtChargeTo.Text)
                .Replace("[explanation]", parent.txtExplanation.Text)
                .Replace("[resolved_by]", parent.txtResolvedBy.Text)

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
            ResolutionsWindow grandparent = parent.parent;
            String trans_source = grandparent.product_row.Cells["Trans"].Value.ToString();
            String trans_id = grandparent.product_row.Cells["Id"].Value.ToString();
            String line = grandparent.product_row.Cells["Line"].Value.ToString();


            int explanation_no = int.Parse( DataSupport.RunDataSet("SELECT COUNT(*)[count] FROM Resolutions WHERE trans_source = '"+trans_source+"' AND trans_id = '"+trans_id+"' AND line='"+line+"'").Tables[0].Rows[0][0].ToString());

            // Save Transaction
            String sql = DataSupport.GetInsert("Resolutions", Utils.ToDict(
                "trans_source", trans_source
               , "trans_id", trans_id
               , "line", line
               , "explanation_no", explanation_no
               , "explanation", parent.txtExplanation.Text
               , "charge_to", parent.txtChargeTo.Text
               , "qty_resolved", parent.txtQtyToResolve.Text
               , "resolved_by", parent.txtResolvedBy.Text
               , "resolved_on", DateTime.Now
                ));

          



            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", trans_id + "-" + line + "-RS-" + explanation_no);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
        }


    }
}
