#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace Revit_VizForms
{
    internal class Graphical
    {
        public static Color createColor(int red, int green, int blue)
        {
            Color colorCreated = new Color((byte)red, (byte)green, (byte)blue);
            return colorCreated;
        }
        public static List<Color> create_List_of_Colors_by_Number(int number)
        {
            List<Color> allColors = new List<Color>();
            double a = 16581375 / number;
            for (int i = 1; i < number + 1; i++)
            {
                double C = Convert.ToDouble(a * i);
                int r = Convert.ToInt32(C / 65025);
                int g = Convert.ToInt32(((C % 65025) / 65025) * 255);
                double x = ((C % 65025) / 65025) * 255;
                double xf = x % 1;
                int b = Convert.ToInt32(xf * 255);
                Color ncol = createColor(r, g, b);
                allColors.Add(ncol);
            }
            return allColors;
        }
        public static OverrideGraphicSettings create_OverRide_ByColor_and_PatternName(Document doc, Color color, string patternName)
        {
            OverrideGraphicSettings ogs = new OverrideGraphicSettings();
            Element pattern = get_Pattern_ByName(doc, patternName);
            ogs.SetSurfaceBackgroundPatternColor(color);
            ogs.SetSurfaceForegroundPatternColor(color);
            ogs.SetProjectionLineColor(color);
            ogs.SetCutLineColor(color);
            ogs.SetSurfaceForegroundPatternId(pattern.Id);
            ogs.SetSurfaceBackgroundPatternId(pattern.Id);
            return ogs;
        }
        public static Element get_Pattern_ByName(Document doc, string patternName)
        {
            Element extracted = null;
            Element[] Collector = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement)).ToArray();
            foreach (Element item in Collector)
            {
                //FillPatternElement fpe = item as FillPatternElement;
                if (item.Name == patternName)
                {
                    extracted = item;
                    break;
                }
            }
            return extracted;
        }
    }
}
