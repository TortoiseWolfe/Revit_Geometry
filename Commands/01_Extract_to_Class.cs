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
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Extraction.doc = doc;
            List<Element> SelectedElements = Sel.MultipleStructuralColumnElementSelection(uiapp);
            List<E_element> All_E_Elements = Extraction.Get_e_Elements_from_Elements(SelectedElements);

            // Analysis
            //MessageBox.Show(
            //    "Selected Element: " + 
            //    SelectedElement.Category.Name + 
            //    ":|:" + 
            //    SelectedElement.Id.ToString());
            //          Analysis.ShowElementsData(SelectedElements);
            //          Analysis.ShowFamilyInstanceData(allColumns);
  //          Analysis.ShowFamilySymbolsData(allColumnsfamilySymbols);
  //          Analysis.ShowElementTypesData(allColumnsElementTypes);

            // Creation
            // Transaction
            //Transaction tx = new Transaction(doc);
            //tx.Start("Transaction Name");
            //if (!allColumnsfamilySymbols[0].IsActive)
            //{
            //    allColumnsfamilySymbols[0].Activate();
            //}
            ////FamilyInstance newColumn = doc.Create.NewFamilyInstance(
            ////                   new XYZ(0, 0, 0),
            ////                   allColumnsfamilySymbols[0],
            ////                   StructuralType.NonStructural);
            //FamilyInstance newColumn = doc.Create.NewFamilyInstance(
            //       new XYZ(0, 0, 0),
            //       allColumnsfamilySymbols[0],
            //       allLevels[0],
            //       StructuralType.NonStructural);


            //try
            //{
            //    // Creation
                
            //    // Modification
            //    // Return
            //    tx.Commit();
            //    return Result.Succeeded;
            //}
            //catch (Exception ex)
            //{
            return Result.Succeeded;

            //}
        }
    }
}

