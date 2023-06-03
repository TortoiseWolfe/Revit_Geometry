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
    internal class _05_Creation_byWinForm : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            // Selection
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            List<ElementType> all_elementTypes = sel_Ection.Get_All_ElementTypes_of_Category(doc, BuiltInCategory.OST_GenericModel);
            List<string> elementType_Names = new List<string>();
            foreach (var item in all_elementTypes)
            {
                elementType_Names.Add(item.Name);
            }
            List<string> UniqueTypes = elementType_Names.Distinct().ToList();
            elementData ed = Form_z.Element_Creation_Form(UniqueTypes);
            // Analysis

            FamilySymbol familySymbol = all_elementTypes[0] as FamilySymbol;
            foreach (ElementType elementType in all_elementTypes)
            {
                if (elementType.Name == ed.FamilyType)
                {
                    familySymbol = elementType as FamilySymbol;
                }
            }
            // Creation
            // Transaction
            Transaction tx = new Transaction(doc);
            tx.Start("Transaction Trinam VizForms");
            if(!familySymbol.IsActive)
            {
                familySymbol.Activate();
                doc.Regenerate();
            }
            FamilyInstance familyInstance = doc.Create.NewFamilyInstance(ed.point, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);

            tx.Commit();
            return Result.Succeeded;
        }
    }
}
