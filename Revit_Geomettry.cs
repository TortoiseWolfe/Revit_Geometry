using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB;
//using Autodesk.Revit.DB;
//using System.Windows.Forms;

namespace Revit_Geometry
{
    internal class Revit_Geomettry
    {
        public static XYZ p1 = new XYZ(0, 4, 5);
        XYZ vector = new XYZ(0, 0, 1);
        static XYZ unifiedVector = p1.Normalize();
        //XYZ reversVector = -p1;
        XYZ reversVector = p1.Negate();
        //XYZ modifiedVector = unifiedVector * 2;
        public static XYZ modifiedVector = unifiedVector.Multiply(3);
        XYZ addition = p1.Add(modifiedVector);
    }

    public class CoordinateSystem
    {
        public XYZ Origin { get; set; }
        public XYZ XAxis { get; set; }
        public XYZ YAxis { get; set; }
        public XYZ ZAxis { get; set; }
    }
}
