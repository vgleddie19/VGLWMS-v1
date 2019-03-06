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
    public partial class PrintReleaseDocument : Form
    {
        public String release_id = "";

        public PrintReleaseDocument()
        {
            InitializeComponent();
        }


        DataSet set = null;

        private void LoadData()
        {
            set = DataSupport.RunDataSet( String.Format(@"SELECT * FROM Releases WHERE release_id = '{0}';
SELECT (SELECT client FROM ReleaseOrders RO WHERE RO.order_id = RD.order_id)[Client]
			, (SELECT reference FROM ReleaseOrders RO WHERE RO.order_id = RD.order_id)[Order]
			, Product, Uom, lot_no[Lot No], Expiry, scanned_qty[Qty] 
			FROM ReleaseDetailItems RD WHERE release = '{0}';
SELECT * FROM ReleaseTrips WHERE trip_id =(SELECT trip FROM Releases WHERE release_id = '{0}');
", release_id ));

            foreach (DataRow row in set.Tables[1].Rows)
            {
                row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();
            }
        }

        private void PrintReleaseDocument_Load(object sender, EventArgs e)
        {
            LoadData();

            DataTable releaseDetails = set.Tables[1];

            btnPrintPreview.Select();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table'>");

            sb.Append("<thead>");
            sb.Append("<tr>");

            {
                foreach (DataColumn col in releaseDetails.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(col.ColumnName);
                    sb.Append("</th>");
                }
            }

            sb.Append("</tr>");
            sb.Append("</thead>");

            foreach (DataRow row in releaseDetails.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn col in releaseDetails.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row[col].ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.releasing_report
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[header_table]", sb.ToString())
                .Replace("[released_to_person]", set.Tables[2].Rows[0]["authorized_receiver"].ToString())
                .Replace("[released_to]", set.Tables[2].Rows[0]["tms_name"].ToString())
                .Replace("[trip_id]", set.Tables[2].Rows[0]["trip_id"].ToString())
                .Replace("[released_by]", RegistrationSupport.username)

                ;
        }
    }
}
