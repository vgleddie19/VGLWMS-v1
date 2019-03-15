using System.Drawing;
using System.Windows.Forms;
using VGLHelper;

namespace VGLHelper
{
    public class RendererToolStrip : ToolStripProfessionalRenderer
    {
        public RendererToolStrip() : base(new RendererColorTable())
        {
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            var tsMenuItem = e.Item as ToolStripMenuItem;
            if (tsMenuItem != null)
                e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }
    }
}