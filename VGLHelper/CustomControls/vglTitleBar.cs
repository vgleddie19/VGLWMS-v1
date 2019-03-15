using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VGLHelper.CustomControls
{
    public class vglTitleBar : Panel
    {
        private string _text;
        private StringAlignment vertical, horizontal;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public vglTitleBar() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        [Category("Alignment")]
        public StringAlignment VerticalAlign
        {
            get { return vertical; }
            set { vertical = value; Invalidate(); }
        }

        [Category("Alignment")]
        public StringAlignment HorizontalAlign
        {
            get { return horizontal; }
            set { horizontal = value; Invalidate(); }
        }

        public string TitleText
        {
            get { return _text; }
            set { _text = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            var g = e.Graphics;

            using (var brush = new SolidBrush(Color.White))
            {
                brush.Color = BackColor;
                g.FillRectangle(brush, g.ClipBounds);

                brush.Color = ForeColor;
                g.DrawString(TitleText, Font, brush, g.ClipBounds, new StringFormat { LineAlignment = HorizontalAlign, Alignment = VerticalAlign });
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Parent.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                Invalidate();
            }
        }
    }
}