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
            List<FamilyInstance> genericModels = Sel.GetAllFamilyInsancesOfCategory(doc, BuiltInCategory.OST_GenericModel);
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
