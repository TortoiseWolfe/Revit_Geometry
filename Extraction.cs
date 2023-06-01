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
            FamilyInstance e_familyInstance = elem as FamilyInstance;
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
                E_Element1.bPoint = Rvt_Geometry.midPointOfLine(E_Element1.line);
            }
            Options g_opt = new Options();
            GeometryElement geomElem = elem.get_Geometry(g_opt);
            List<Face> AllFaces = new List<Face>();
            foreach (object geomObj in geomElem)
            {
                if (geomObj.GetType().ToString() == "Autodesk.Revit.DB.GeometryInstance")
                {
                    GeometryInstance geo_Inst = geomObj as GeometryInstance;
                    foreach (GeometryObject geo_Obj in geo_Inst.GetInstanceGeometry())
                    {
                        if(geo_Obj is Solid)
                        {
                            try
                            {
                                Solid solid = geo_Obj as Solid;

                                //Transform transform1 = Transform.CreateTranslation(E_Element1.bPoint);
                                double ang = new XYZ(0, 1, 0).AngleTo(e_familyInstance.FacingOrientation);
                                if (e_familyInstance.FacingOrientation.X > 0)
                                {
                                    ang = ang * -1;
                                }
                                E_Element1.horizontalAngle = ang;
                                //Transform transform2 = Transform.CreateRotationAtPoint(new XYZ(0, 0, 1), ang, E_Element1.bPoint);
                                ///*Transform t2 = Transform.CreateRotationAtPoint(new XYZ(0, 0, 1),ang ,elem1.bPoint);
                                //Solid translateSolid = SolidUtils.CreateTransformed(solid, t1);
                                //Solid rotatedSolid = SolidUtils.CreateTransformed(translateSolid, t2);*/
                                //Solid translateSolid = SolidUtils.CreateTransformed(solid, transform1);
                                //Solid rotatedSolid = SolidUtils.CreateTransformed(translateSolid, transform2);
                                Transform transform1 = e_familyInstance.GetTransform();
                                Solid rotatedSolid = SolidUtils.CreateTransformed(solid, transform1);
                                //XYZ centroid = rotatedSolid.ComputeCentroid();  
                                XYZ centroid = solid.ComputeCentroid();

                                E_Element1.centroid = centroid;

                                E_Element1.solid = solid;
                                FaceArray faces = solid.Faces;
                                foreach (Face face in faces)
                                {
                                AllFaces.Add(face);
                                }
                                E_Element1.faces = AllFaces;
                            }
                            catch
                            {
                                MessageBox.Show("Error");
                            }
                        }
                    }
                }
                if (geomObj.GetType().ToString() == "Autodesk.Revit.DB.Solid")
                {
                    Solid solid = geomObj as Solid;
                    E_Element1.solid = solid;
                    FaceArray faces = solid.Faces;
                    foreach (Face face in faces)
                    {
                        AllFaces.Add(face);
                    }
                    E_Element1.faces = AllFaces;
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
