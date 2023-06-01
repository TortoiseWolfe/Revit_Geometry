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

namespace Revit_VizForms
{
    internal class RevitGeometry
    {
        public const double _eps = 1.0e-9;
        public Line curveToLine(Curve cu)
        {
            return Line.CreateBound(cu.GetEndPoint(0), cu.GetEndPoint(1));
        }
        public XYZ PointIntersection_LinePlane(Line line, Plane plane, out double lineParameter)
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
        public bool IsZero(double a, double tolerance = _eps)
        {
            return tolerance > Math.Abs(a);
        }
        public Plane planeFromFace(Face f)
        {
            PlanarFace PF = f as PlanarFace;
            Plane PL = PF.GetSurface() as Plane;
            return PL;
        }
        public XYZ centerPointOfPlane(Plane PL, XYZ centroid)
        {
            return projectOnto(PL, centroid);
        }
        public double signedDistanceTo(Plane plane, XYZ p)
        {
            XYZ v = p - plane.Origin;
            return plane.Normal.DotProduct(v);
        }
        public XYZ projectOnto(Plane plane, XYZ p)
        {
            double d = signedDistanceTo(plane, p);
            XYZ q = p - d * plane.Normal;
            return q;
        }
        public XYZ midPointOfLine(Line line)
        {
            XYZ StartPoint = line.GetEndPoint(0);
            XYZ midPoint = StartPoint.Add(line.Direction.Normalize().Multiply(line.Length / 2));
            return midPoint;
        }
        public Line verticalLineFromPoint(XYZ point)
        {
            //return Line.CreateBound(point, point.Add(new XYZ(point.X,point.Y,5)));
            return Line.CreateBound(point, point.Add(new XYZ(0, 0, 1)));
        }
    }
    public class CoordinateSystem
    {
        public XYZ Origin { get; set; }
        public XYZ VecX { get; set; }
        public XYZ VecY { get; set; }
        public XYZ VecZ { get; set; }
    }
}
