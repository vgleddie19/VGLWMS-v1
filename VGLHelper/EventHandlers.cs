using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VGLHelper
{
    public class EventHandlers
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void Title_MouseMove(object sender, MouseEventArgs e)
        {
            var Handle = sender as Label;

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle.Parent.Parent.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public static void xButton_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var button = sender as Button;

            Rectangle _xButtonBounds = button.ClientRectangle; //new Rectangle(-10, -10, 50, 50);

            using (var xPen = new Pen(Color.White))
            {
                xPen.Width = 2F;
                g.DrawLine(
                            xPen,
                            _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.33),
                            _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.33),
                            _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.66),
                            _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.66)
                       );

                g.DrawLine(
                    xPen,
                    _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.66),
                    _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.33),
                    _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.33),
                    _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.66));
            }
        }

        public static void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = sender as DataGridView;
            var sortIconColor = Color.White;
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                //Draw Background
                e.PaintBackground(e.CellBounds, false);

                //Draw Text Default
                //e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);

                //Draw Text Custom
                TextRenderer.DrawText(e.Graphics, string.Format("{0}", e.FormattedValue),
                    e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                //Draw Sort Icon
                if (grid.SortedColumn?.Index == e.ColumnIndex)
                {
                    var sortIcon = grid.SortOrder == SortOrder.Ascending ? "▲" : "▼";

                    //Or draw an icon here.
                    TextRenderer.DrawText(e.Graphics, sortIcon,
                        e.CellStyle.Font, e.CellBounds, sortIconColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                }

                //Prevent Default Paint
                e.Handled = true;
            }
        }

        public static void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tc = sender as TabControl;
            Graphics g = e.Graphics;
            Brush _textBrush;
            Pen pen = new Pen(Color.Black);
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;

            // Get the item from the collection.
            var tp = tc.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tc.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);

                //g.FillPolygon(_textBrush, pt);
                g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(Etcetera.PRIMARY_COLOR)), e.Bounds);
                //g.DrawString(_tabPage.Text, new Font(e.Font, FontStyle.Bold), _textBrush, _tabBounds, new StringFormat(_stringFlags));
                TabRenderer.DrawTabItem(g, e.Bounds, tp.Text, tp.Font, System.Windows.Forms.VisualStyles.TabItemState.Selected);
                TabRenderer.DrawTabPage(g, tp.Bounds);
                //TextRenderer.DrawText(g, _tabPage.Text, new Font(e.Font, FontStyle.Bold), _tabBounds, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            else
            {
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#16a085")), e.Bounds);
                //g.DrawString(_tabPage.Text, e.Font, _textBrush, _tabBounds, new StringFormat(_stringFlags));
                TextRenderer.DrawText(g, tp.Text, e.Font, _tabBounds, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }

            // Draw string. Center the text.

            //g.DrawString(_tabPage.Text, e.Font, _textBrush, _tabBounds, new StringFormat(_stringFlags));

            _textBrush.Dispose();
        }
    }
}