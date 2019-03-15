using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VGLHelper.CustomControls
{
    public class vglTabControl : TabControl
    {
        private int borderSize;

        public vglTabControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw
                | ControlStyles.OptimizedDoubleBuffer,
                true);
            AllowDrop = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(150, 50);
        }

        /// <summary>
        ///     Format of the title of the TabPage
        /// </summary>
        private readonly StringFormat CenterStringFormat = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
        };

        /// <summary>
        ///     The color of the active tab header
        /// </summary>
        private Color selectedTabColor = ColorTranslator.FromHtml(Etcetera.PRIMARY_COLOR);

        [DefaultValue(typeof(Color), "White")]
        public Color SelectedTabColor
        {
            get { return selectedTabColor; }
            set
            {
                selectedTabColor = value;
                Invalidate();
            }
        }

        private Color inactiveTabColor = ColorTranslator.FromHtml(Etcetera.PRIMARY_COLOR_DARK);

        /// <summary>
        /// Color of the inactive tab
        /// </summary>
        [Category("TabColor")]
        public Color InactiveTabColor
        {
            get { return inactiveTabColor; }
            set
            {
                inactiveTabColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Border of the tab control
        /// </summary>
        [Category("Border"), DefaultValue(0), Description("Add border to the tabcontrol")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        private Color tabTextColor = Color.White;

        [DefaultValue(typeof(Color), "White"), Description("Add border to the tabcontrol")]
        public Color TabTextColor
        {
            get { return tabTextColor; }
            set
            {
                tabTextColor = value;
                Invalidate();
            }
        }

        private Color tabBackColor = Color.White;

        public Color TabBackColor
        {
            get { return tabBackColor; }
            set { tabBackColor = value; Invalidate(); }
        }

        private Color borderColor;

        /// <summary>
        ///     The color of the border of the control
        /// </summary>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        ///     The color of the background of the Tab
        /// </summary>
        private Color backTabColor = Color.FromArgb(255, 255, 0);

        /// <summary>
        ///     Color of the closing button
        /// </summary>
        private Color closingButtonColor = Color.WhiteSmoke;

        /// <summary>
        ///     The color of the tab header
        /// </summary>
        ///
        private Color headerColor = Color.FromArgb(70, 70, 70);

        /// <summary>
        ///     The color of the horizontal line which is under the headers of the tab pages
        /// </summary>
        private Color horizLineColor = Color.FromArgb(0, 122, 204);

        /// <summary>
        ///     A random page will be used to store a tab that will be deplaced in the run-time
        /// </summary>
        private TabPage predraggedTab;

        /// <summary>
        ///     The color of the text
        /// </summary>
        //private Color textColor = Color.FromArgb(255, 255, 255);

        /// <summary>
        /// Selected tab text color
        /// </summary>
        private Color selectedTextColor = Color.FromArgb(255, 255, 255);

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            var Drawer = e.Graphics;

            //Drawer.SmoothingMode = SmoothingMode.HighQuality;
            Drawer.SmoothingMode = SmoothingMode.HighSpeed;
            Drawer.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Drawer.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Drawer.Clear(headerColor);
            //try
            //{
            //    SelectedTab.BackColor = backTabColor;
            //}
            //catch
            //{
            //    // ignored
            //}

            try
            {
                SelectedTab.BorderStyle = BorderStyle.None;
            }
            catch
            {
                // ignored
            }
            // Draws the background of the tab control
            using (var b = new SolidBrush(TabBackColor))
            {
                Drawer.FillRectangle(b, new Rectangle(0, 10, Width, Height));
                Drawer.FillRectangle(b, new Rectangle(0, 0, Width, 10));
            }

            for (var i = 0; i <= TabCount - 1; i++)
            {
                var Header = new Rectangle(
                    new Point(GetTabRect(i).Location.X + 3, GetTabRect(i).Location.Y),
                    new Size(GetTabRect(i).Width, GetTabRect(i).Height));
                var HeaderSize = new Rectangle(Header.Location, new Size(Header.Width, Header.Height));

                if (i == SelectedIndex)
                {
                    // Draws the back of the header
                    Drawer.FillRectangle(new SolidBrush(headerColor), HeaderSize.X, HeaderSize.Y + 5, HeaderSize.Width - 3, HeaderSize.Height);

                    // Draws the back of the color when it is selected
                    using (var b = new SolidBrush(SelectedTabColor))
                    {
                        //Drawer.FillRectangle(b, new Rectangle(Header.X - 5, Header.Y - 3, Header.Width, Header.Height + 5));

                        //Drawer.FillRectangle(new SolidBrush(headerColor), HeaderSize.X - 5, HeaderSize.Y - 2, HeaderSize.Width - 10, HeaderSize.Height);
                        //Drawer.FillRectangle(new SolidBrush(headerColor), Header.X - 4f, Header.Y - 3f, Header.Width - 2.5f, Header.Height + 5f);
                        Drawer.FillRectangle(b, Header.X, Header.Y, Header.Width - 10f, Header.Height);
                        //Drawer.DrawLine(new Pen(Color.Black, 3), new Point(HeaderSize.X - 3, HeaderSize.Y - 2), new Point(HeaderSize.X - 3, HeaderSize.Height));

                        //Draws the title of the page
                        //b.Color = TabTextColor;
                        //Drawer.DrawString(
                        //    TabPages[i].Text,
                        //    Font,
                        //    b,
                        //    HeaderSize,
                        //    CenterStringFormat);

                        TextRenderer.DrawText(Drawer, TabPages[i].Text, new Font(TabPages[i].Font, FontStyle.Bold), HeaderSize, TabTextColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                    }
                }
                else
                {
                    // Simply draws the header when it is not selected
                    using (var b = new SolidBrush(TabTextColor))
                    {
                        b.Color = InactiveTabColor;
                        Drawer.FillRectangle(b, HeaderSize.X, HeaderSize.Y + 5, HeaderSize.Width - 10F, HeaderSize.Height);
                        //Drawer.DrawString(TabPages[i].Text, Font, b, HeaderSize, CenterStringFormat);
                        b.Color = TabTextColor;
                        TextRenderer.DrawText(Drawer, TabPages[i].Text, TabPages[i].Font, HeaderSize, TabTextColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                    }
                }
            }

            // Draws the horizontal line

            //Drawer.DrawLine(new Pen(horizLineColor, 5), new Point(0, Bounds.Height), new Point(Width, 42));
            if (TabPages.Count > 0)
            {
                //Pen p = new Pen(SelectedTabColor, 5);
                //Drawer.DrawLine(p, -10, ItemSize.Height + 2, Width - 1, ItemSize.Height + 2);
            }

            // Draws the border of the TabControl

            if (BorderSize > 0)
                Drawer.DrawRectangle(new Pen(BorderColor, BorderSize), new Rectangle(0, 0, Width, Height));

            //Tab Control Border
            using (var b = new SolidBrush(SelectedTabColor))
            {
                Drawer.FillRectangle(b, new Rectangle(0, ItemSize.Height - 5, Width, Height));
            }

            //Drawer.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //
            //p.Dispose();
        }
    }
}