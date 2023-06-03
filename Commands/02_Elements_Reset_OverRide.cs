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
    internal class _02_Elements_Reset_OverRide : IExternalCommand
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
            List<FamilyInstance> genericModels = sel_Ection.GetAllFamilyInsancesOfCategory(doc, BuiltInCategory.OST_GenericModel);
            List<FamilyInstance> structuralColumns = sel_Ection.GetAllFamilyInsancesOfCategory(doc, BuiltInCategory.OST_StructuralColumns);
            List<FamilyInstance> structuralFramings = sel_Ection.GetAllFamilyInsancesOfCategory(doc, BuiltInCategory.OST_StructuralFraming);

            // Analysis

            // Creation
            
            // Transaction
            Transaction tx = new Transaction(doc);
            tx.Start("Transaction Trinam VizForms");
            foreach (FamilyInstance e in genericModels)
            {
                OverrideGraphicSettings ogs = new OverrideGraphicSettings();
                doc.ActiveView.SetElementOverrides(e.Id, ogs);   
            }
            foreach (FamilyInstance e in structuralColumns)
            {
                OverrideGraphicSettings ogs = new OverrideGraphicSettings();
                doc.ActiveView.SetElementOverrides(e.Id, ogs);
            }
            foreach (FamilyInstance e in structuralFramings)
            {
                OverrideGraphicSettings ogs = new OverrideGraphicSettings();
                doc.ActiveView.SetElementOverrides(e.Id, ogs);
            }
            tx.Commit();
            return Result.Succeeded;
        }
    }
}
