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
        public const double _eps = 1.0e-9;
        public void Geometry_Function()
        {
            XYZ point_1 = new XYZ(0, 4, 5);
            XYZ vector = new XYZ(0, 0, 1);
            XYZ unifiedVector = point_1.Normalize();
            //XYZ reversVector = -point_1;
            XYZ reversVector = point_1.Negate();
            //XYZ modifiedVector = unifiedVector * 2;
            XYZ modifiedVector = unifiedVector.Multiply(3);
            XYZ addition = point_1.Add(modifiedVector);
            Line line_One = Line.CreateBound(point_1, addition);
            XYZ direction = line_One.Direction;
            double length = line_One.Length;
            XYZ startPoint = line_One.GetEndPoint(0);
            XYZ endPoint = line_One.GetEndPoint(1);
            Plane plane_One = Plane.CreateByNormalAndOrigin(vector, point_1);
            XYZ plane_Origin = plane_One.Origin;
            XYZ plane_Normal = plane_One.Normal;
        }

        public static XYZ PointIntersection_LinePlane(Line line, Plane plane, out double lineParameter)
        {
            XYZ plane_Point = plane.Origin;
            XYZ plane_Normal = plane.Normal;
            XYZ line_StartPoint = line.GetEndPoint(0);
            XYZ line_Direction = (line.GetEndPoint(1) - line_StartPoint).Normalize();
            if (IsZero(plane_Normal.DotProduct(line_Direction),_eps))
            {
                lineParameter = double.NaN;
                return null;
            }
            lineParameter = (plane_Normal.DotProduct(plane_Point - line_StartPoint)) / plane_Normal.DotProduct(line_Direction);
            return line_StartPoint + lineParameter * line_Direction;
        }
        public static bool IsZero(double a, double tolerance = _eps)
        {
            return tolerance > Math.Abs(a);
        }
    }

    public class CoordinateSystem
    {
        public XYZ Origin { get; set; }
        public XYZ XAxis { get; set; }
        public XYZ YAxis { get; set; }
        public XYZ ZAxis { get; set; }
    }
}
