using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WMS.Utilities
{
    public static class UISetter
    {
        private const string PRIMARY_COLOR = "#3f51b5";
        private const string SECONDARY_COLOR = "#27ae60";

        public static void DoubleBuffered(this object obj, bool setting)
        {
            Type objType = obj.GetType();
            PropertyInfo pi = objType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(obj, setting, null);
        }

        public static void SetLabelAppearance(params Label[] labels)
        {
            foreach (Label label in labels)
            {
                label.Height = 40;
                label.Font = new Font("ROBOTO", 16);
                label.BackColor = ColorTranslator.FromHtml(PRIMARY_COLOR);
                label.ForeColor = Color.White;
                label.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        public static void SetButtonAppearance(bool usepredefinecolor,params Button[] buttons)
        {
            foreach (Button button in buttons)
            {
                if (usepredefinecolor)
                    button.BackColor = ColorTranslator.FromHtml("#16a085");
                button.Font = new Font("Roboto", 12);
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
        }

        public static void SetButtonAppearance(this Button button, bool usepredefinecolor)
        {
            if (usepredefinecolor)
                button.BackColor = ColorTranslator.FromHtml("#16a085");
            button.Font = new Font("Roboto", 12);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        public static void SetGridAppearance(params DataGridView[] dataGridViews)
        {
            foreach (DataGridView datagridview in dataGridViews)
            {
                datagridview.BorderStyle = BorderStyle.None;
                datagridview.BackColor = SystemColors.Control;
                datagridview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                datagridview.DefaultCellStyle.Font = new Font("Courier New", 12);
                datagridview.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
                datagridview.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(SECONDARY_COLOR);
                datagridview.DefaultCellStyle.SelectionForeColor = Color.White;
                datagridview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                datagridview.RowsDefaultCellStyle.Padding = new Padding(5, 1, 5, 1);
                datagridview.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                datagridview.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 12, FontStyle.Bold);
                datagridview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                datagridview.RowTemplate.Height = 30;
                datagridview.BackgroundColor = SystemColors.Control;
                datagridview.RowPostPaint += DataGridView_RowPostPaint;
                datagridview.DoubleBuffered(true);
                datagridview.ClearSelection();
            }
        }

        public static void SetGridAppearance(this DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.BackColor = SystemColors.Control;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.Font = new Font("Courier New", 10);
            dataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(SECONDARY_COLOR);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowsDefaultCellStyle.Padding = new Padding(5, 1, 5, 1);
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 12, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowTemplate.Height = 50;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.DoubleBuffered(true);
            dataGridView.ClearSelection();
        }

        private static void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView grd = sender as DataGridView;            
            if (e.IsLastVisibleRow)
                grd.Rows[0].Selected = false;
        }

        public static void SetComboBox(this ComboBox cbo, DataTable dt, string DisplayMember, string ValueMember, AutoCompleteSource AutoSource = AutoCompleteSource.ListItems,
                                            AutoCompleteMode AutoMode = AutoCompleteMode.SuggestAppend, ComboBoxStyle DropStyle = ComboBoxStyle.DropDownList)
        {
            cbo.DisplayMember = DisplayMember;
            cbo.ValueMember = ValueMember;
            cbo.AutoCompleteSource = AutoSource;
            cbo.AutoCompleteMode = AutoMode;
            cbo.DropDownStyle = DropStyle;
            cbo.DataSource = dt;
            cbo.SelectedIndex = -1;
        }

        public static void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tc = sender as TabControl;
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tc.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tc.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#3f51b5")), e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#16a085")), e.Bounds);
            }

            // Use our own font.
            Font _tabFont = new Font("Roboto", (float)18.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
    }
}