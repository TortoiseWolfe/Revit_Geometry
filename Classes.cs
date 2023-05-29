using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Structure;

namespace Revit_Geometry
{
    internal class E_element
    {
        public Element Element { get; set; }
        public XYZ BottomPoint { get; set; }
        public XYZ TopPoint { get; set; }
        public Line Line { get; set; }
        public FamilySymbol FamilySymbol { get; set; }
        public Level Level { get; set; }
    }
}
