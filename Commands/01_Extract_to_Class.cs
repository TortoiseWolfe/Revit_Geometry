#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.DB.Structure;
#endregion
namespace Revit_Geometry
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class _01_Extract_to_Class : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            // Selection
            Extraction Extraction = new Extraction();
            RevitGeometry revitGeometry = new RevitGeometry();
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Extraction.doc = doc;
            List<Element> SelectedElements = Sel.MultipleStructuralColumnElementSelection(uiapp);
            List<E_element> All_E_Elements = Extraction.Get_e_Elements_from_Elements(SelectedElements);
            FamilySymbol Symbol = Sel.GetFamilySymbolOfCategoryFamilyName(doc, BuiltInCategory.OST_GenericModel,"Family1");
            List<reviewFamily>RF = new List<reviewFamily>();
            foreach (E_element eEl in All_E_Elements)
            {
                foreach(Face f in eEl.faces)
                {
                    reviewFamily rf = new reviewFamily();
                    rf.point = revitGeometry.centerPointOfPlane(revitGeometry.planeFromFace(f), eEl.centroid);
                    rf.symbol = Symbol;
                    RF.Add(rf);

                }
            }
            // Analysis

            // Creation
            //Transaction
           Transaction tx = new Transaction(doc);
            tx.Start("Transaction Name");
            if (!Symbol.IsActive)
            {
                Symbol.Activate();
            }
            //FamilyInstance newColumn = doc.Create.NewFamilyInstance(
            //                   new XYZ(0, 0, 0),
            //                   allColumnsfamilySymbols[0],
            //                   StructuralType.NonStructural);
            foreach(reviewFamily rf in RF)
            {
                FamilyInstance newColumn = doc.Create.NewFamilyInstance(
                    rf.point,
                    rf.symbol,
                    StructuralType.NonStructural);
            }
            tx.Commit();
            return Result.Succeeded;
        }
    }
}