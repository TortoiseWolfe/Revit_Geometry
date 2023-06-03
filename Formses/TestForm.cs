using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace Revit_VizForms
{
    public partial class TestForm : System.Windows.Forms.Form
    {
        private static Document _doc;
        public TestForm(Document doc)
        {
            InitializeComponent();
            _doc = doc;
        }
    }
}
