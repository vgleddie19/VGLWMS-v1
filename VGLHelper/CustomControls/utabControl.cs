using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;

namespace VGLHelper.CustomControls
{
    public class utabControl : SuperTabControl
    {
        private int borderSize;
        public utabControl()
        {
            AllowDrop = true;            
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

        private Color tabTextColor = Color.Navy;

        [DefaultValue(typeof(Color), "Navy"), Description("Add border to the tabcontrol")]
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
        ///     The color of the text
        /// </summary>
        private Color textColor = Color.FromArgb(255, 255, 255);

        /// <summary>
        /// Selected tab text color
        /// </summary>
        private Color selectedTextColor = Color.FromArgb(255, 255, 255);





    }
}
