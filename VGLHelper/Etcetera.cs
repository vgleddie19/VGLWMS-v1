using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VGLHelper
{
    public class Etcetera
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        public const string PRIMARY_COLOR = "#1976d2";
        public const string PRIMARY_COLOR_LIGHT = "#63a4ff";
        public const string PRIMARY_COLOR_DARK = "#004ba0";

        public const string SECONDARY_COLOR = "#00838f";
        public const string SECONDARY_COLOR_LIGHT = "#4fb3bf";
        public const string SECONDARY_COLOR_DARK = "#005662";

        public const string ACCENT = "#ffffff";

        private static readonly PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        public enum FontStyles
        {
            ROBOTO_REGULAR_12,
            ROBOTO_REGULAR_10,
            CENTURY_GOTHIC_15,
            CENTURY_GOTHIC_12,
            SEGOE_UI_REGULAR_12,
            SEGOE_UI_BOLD_12
        }

        private static FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }

        public static Font GetFont(FontStyles value)
        {
            try
            {
                var path = Application.StartupPath + @"\Fonts\";
                switch (value)
                {
                    case FontStyles.ROBOTO_REGULAR_12:
                        return new Font(LoadFont(File.ReadAllBytes(path + "Roboto-Regular.ttf")), 12f);

                    case FontStyles.CENTURY_GOTHIC_15:
                        return new Font(LoadFont(File.ReadAllBytes(path + "CenturyGothicRegular.ttf")), 15f);

                    case FontStyles.CENTURY_GOTHIC_12:
                        return new Font(LoadFont(File.ReadAllBytes(path + "CenturyGothicRegular.ttf")), 12f);

                    case FontStyles.ROBOTO_REGULAR_10:
                        return new Font(LoadFont(File.ReadAllBytes(path + "Roboto_Regular.ttf")), 10f);

                    case FontStyles.SEGOE_UI_REGULAR_12:
                        return new Font(LoadFont(File.ReadAllBytes(path + "segoeui.ttf")), 12f);

                    case FontStyles.SEGOE_UI_BOLD_12:
                        return new Font(LoadFont(File.ReadAllBytes(path + "segoeuib.ttf")), 15f);
                    //case Fonts.CENTURY_GOTHIC_15:
                    //    return new Font(LoadFont(Resources.CenturyGothicRegular), 15f);

                    //case Fonts.ROBOTO_REGULAR_10:
                    //    return new Font(LoadFont(Resources.Roboto_Regular), 10f);

                    //case Fonts.SEGOE_UI_REGULAR_12:
                    //    return new Font(LoadFont(Resources.segoeui), 12f);

                    //case Fonts.SEGOE_UI_BOLD_12:
                    //    return new Font(LoadFont(Resources.segoeuib), 15f);

                    default:
                        return new Font("Microsoft Sans Serif", 12);
                }
            }
            catch (Exception ex)
            {
                return new Font("Microsoft Sans Serif", 12);
            }
        }

        public static void modify_coltype(DataGridView _dgv,String coltype, DataGridViewAutoSizeColumnMode _AutoSizeMode, int _colwidth,
                                                  String _colname,String _headerame, int _displayindex)
        {
            DataGridView result = new DataGridView();
            DataGridViewColumn col = new DataGridViewColumn();
            switch (coltype.ToLower())
            {
                case "button":
                    var btn = new DataGridViewButtonColumn // Modify column type
                    {
                        AutoSizeMode = _AutoSizeMode,
                        Width = _colwidth,
                        DataPropertyName = _dgv.Columns[_colname].Name,
                        HeaderText = _headerame
                    };
                    col = btn;
                    break;
                case "textbox":
                    var txt = new DataGridViewTextBoxColumn // Modify column type
                    {
                        AutoSizeMode = _AutoSizeMode,
                        Width = _colwidth,
                        DataPropertyName = _dgv.Columns[_colname].Name,
                        HeaderText = _headerame
                    };
                    col = txt;
                    break;
                case "combo":
                    var cbo = new DataGridViewComboBoxColumn // Modify column type
                    {
                        AutoSizeMode = _AutoSizeMode,
                        Width = _colwidth,
                        DataPropertyName = _dgv.Columns[_colname].Name,
                        HeaderText = _headerame
                    };
                    col = cbo;
                    break;
                case "check":
                    var chk = new DataGridViewCheckBoxColumn // Modify column type
                    {
                        AutoSizeMode = _AutoSizeMode,
                        Width = _colwidth,
                        DataPropertyName = _dgv.Columns[_colname].Name,
                        HeaderText = _headerame
                    };
                    col = chk;
                    break;
            }
            col.Name = String.Format("{0}-x",_colname);
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col.DisplayIndex = _displayindex;
            _dgv.Columns.Add(col); // Add new 
            var r = _dgv.Columns.OfType<DataGridViewTextBoxColumn>().Where(x => x.Name == _colname).FirstOrDefault();
            _dgv.Columns.Remove(r); // Remove the original column
        }
    }
}