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
using System.Linq;
#endregion
namespace Revit_VizForms
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class _01_Elements_Visibilty:IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            // Selection
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Extraction EX = new Extraction();
            EX.doc = doc;
            List<FamilyInstance> genericModels = Sel.GetAllFamilyInsancesOfCategory(doc, BuiltInCategory.OST_GenericModel);
            List<E_element> eObjects = new List<E_element>();
            foreach (FamilyInstance fi in genericModels)
            {
                E_element val = EX.Get_e_Element_from_Element(fi as Element);
                eObjects.Add(val);
            }
            List<double> heights = new List<double>();
            foreach (E_element e in eObjects)
            {
                heights.Add(Math.Round(e.bPoint.Z,0));
            }
            List<double> uniqueHeights = heights.Distinct().ToList();
            // Analysis

            // Creation
            
            // Transaction
            Transaction tx = new Transaction(doc);
            tx.Start("Transaction Trinam VizForms");

            tx.Commit();
            return Result.Succeeded;
        }
    }
}
