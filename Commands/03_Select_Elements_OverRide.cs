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
    internal class _03_Select_Elements_OverRide:IExternalCommand
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

            List<string> s_values = new List<string>() { "Generic Models", "Structural Columns", "Structural Framing" };
            Dictionary<string, BuiltInCategory> s_dict = new Dictionary<string, BuiltInCategory>();
            s_dict.Add("Generic Models", BuiltInCategory.OST_GenericModel);
            s_dict.Add("Structural Columns", BuiltInCategory.OST_StructuralColumns);
            s_dict.Add("Structural Framing", BuiltInCategory.OST_StructuralFraming);

            string selected = Form_z.Single_ComboBox_Selector("Selector","Selection", s_values);

            List<FamilyInstance> elements_Selected = sel_Ection.GetAllFamilyInsancesOfCategory(doc, s_dict[selected]);

            List<E_element> eObjects = new List<E_element>();
            foreach (FamilyInstance fi in elements_Selected)
            {
                E_element val = EX.Get_e_Element_from_Element(fi as Element);
                eObjects.Add(val);
            }
            List<double> heights = new List<double>();
            foreach (E_element e in eObjects)
            {
                heights.Add(Math.Round(e.bPoint.Z,1));
            }
            List<double> uniqueHeights = heights.Distinct().ToList();
            List<Color> ColorSet = Graphical.create_List_of_Colors_by_Number(uniqueHeights.Count);
            Dictionary<double, OverrideGraphicSettings> overRides_dictionary = new Dictionary<double, OverrideGraphicSettings>();
            int i = 0;
            foreach(double d in uniqueHeights)
            {
                overRides_dictionary.Add(d, Graphical.create_OverRide_ByColor_and_PatternName(doc, ColorSet[i], "<Solid fill>"));
                i++;
            }
            // Analysis

            // Creation
            
            // Transaction
            Transaction tx = new Transaction(doc);
            tx.Start("Transaction Trinam VizForms");
            foreach (E_element e in eObjects)
            {
                doc.ActiveView.SetElementOverrides(e.element.Id, overRides_dictionary[Math.Round(e.bPoint.Z,1)]);   
            }
            tx.Commit();
            return Result.Succeeded;
        }
    }
}
