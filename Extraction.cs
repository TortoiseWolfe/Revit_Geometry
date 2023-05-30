﻿using System;
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

namespace Revit_Geometry
{
    internal class Extraction
    {
        public Document doc;
        public E_element Get_e_Element_from_Element(Element elem) 
            {
                E_element E_Element1 = new E_element();
                E_Element1.Element = elem;
                FamilySymbol familySymbol = doc.GetElement(elem.GetTypeId()) as FamilySymbol;    
                E_Element1.FamilySymbol = familySymbol;
                E_Element1.Level = doc.GetElement(elem.LevelId) as Level;
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