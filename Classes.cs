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

namespace Revit_VizForms
{
    internal class E_element
    {
        public Element element { get; set; }
        public XYZ bPoint { get; set; }
        public XYZ tPoint { get; set; }
        public Line line { get; set; }
        public Solid solid { get; set; }
        public List<Face> faces { get; set; }
        public FamilySymbol symbol { get; set; }
        public Level level { get; set; }
        public XYZ centroid { get; set; }
        public double horizontalAngle { get; set; }
    }

    public class reviewFamily
    {
        public XYZ point { get; set; }
        public double horizontalAngle { get; set; }
        public FamilySymbol symbol { get; set; }
    }
}
