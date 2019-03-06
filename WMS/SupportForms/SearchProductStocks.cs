using DevComponents.DotNetBar.SuperGrid;
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
    public partial class SearchProductStocks : Form
    {
        #region Initialize Form
        public SearchProductStocks()
        {
            InitializeComponent();
        }

        private void SearchProductStocks_Load(object sender, EventArgs e)
        {
            InitGridColumns(grid.PrimaryGrid);
        }
        #endregion

        #region Search procedure
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void cbosearchby_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Initialize Grid
        private void InitGridColumns(GridPanel panel)
        {
            panel.Columns.Clear();
            panel.Rows.Clear();
            GridColumn col = new GridColumn();
            col.HeaderText = "Product ID";
            col.Name = "product_id";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Description";
            col.Name = "description";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);
        }
        private void LoadData()
        {
            StringBuilder search = new StringBuilder();
            //if (cbosearchby.SelectedIndex == 0)
            //    search.AppendFormat("SELECT * FROM LocationProductsLedger WHERE product = '{0}' order by product,location", txtsearch.Text);
            //else if (cbosearchby.SelectedIndex == 0)
            //    search.AppendFormat("SELECT * FROM LocationProductsLedger WHERE product = '{0}' order by product,location", txtsearch.Text);

            foreach (DataRow dRow_locprod in DataSupport.RunDataSet(search.ToString()).Tables[0].Rows)
            {

            }
        }
            #endregion
        }
}
