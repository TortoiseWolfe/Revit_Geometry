#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Structure;
using System.Windows.Forms;
#endregion

namespace Revit_Geometry
{
    internal class Extraction
    {
        public Document doc;
        public RevitGeometry Rvt_Geometry = new RevitGeometry();
        public E_element Get_e_Element_from_Element(Element elem) 
            {
            E_element E_Element1 = new E_element();
            E_Element1.element = elem;
            FamilySymbol familySymbol = doc.GetElement(elem.GetTypeId()) as FamilySymbol;    
            E_Element1.symbol = familySymbol;
            E_Element1.level = doc.GetElement(elem.LevelId) as Level;
            if(elem.Category.Name == "Structural Columns"|| elem.Category.Name == "Structural Foundations")
            {
                LocationPoint Loc = elem.Location as LocationPoint;
                E_Element1.bPoint = Loc.Point;
            }
            if(elem.Category.Name == "Structural Framing")
            {
                LocationCurve Loc = elem.Location as LocationCurve;
                E_Element1.line = Rvt_Geometry.curveToLine(Loc.Curve);
            }
            Options g_opt = new Options();
            GeometryElement geomElem = elem.get_Geometry(g_opt);
            foreach (object geomObj in geomElem)
            {
                if (geomObj.GetType().ToString() == "Autodesk.Revit.DB.GeometryInstance")
                {

                }
                if (geomObj.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                {

                }
            }
            return E_Element1;
            }
        public List<E_element> Get_e_Elements_from_Elements(List<Element> SelectedElements)
            {
            List<E_element> All_E_Elements = new List<E_element>();
            foreach (Element elemenT in SelectedElements)
            {
                E_element E_Element1 = Get_e_Element_from_Element(elemenT);
                All_E_Elements.Add(E_Element1);
            }
            return All_E_Elements;
            }
    }
}
