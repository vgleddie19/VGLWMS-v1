using System.Drawing;
using System.Windows.Forms;

namespace VGLHelper
{
    public class RendererColorTable : ProfessionalColorTable
    {
        private const string PRIMARY_COLOR = "#1976d2";
        private const string PRIMARY_COLOR_LIGHT = "#63a4ff";
        private const string PRIMARY_COLOR_DARK = "#004ba0";

        private const string SECONDARY_COLOR = "#00838f";
        private const string SECONDARY_COLOR_LIGHT = "#4fb3bf";
        private const string SECONDARY_COLOR_DARK = "#005662";

        public override Color ToolStripDropDownBackground
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR); }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR_DARK); }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR_DARK); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR_DARK); }
        }

        public override Color MenuBorder
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR); }
        }

        public override Color MenuItemBorder
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR); }
        }

        public override Color MenuItemSelected
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR_LIGHT); }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR); }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return ColorTranslator.FromHtml(PRIMARY_COLOR); }
        }
    }
}