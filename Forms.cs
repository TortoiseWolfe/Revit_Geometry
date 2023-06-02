using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Revit_VizForms
{
    internal class Forms
    {
        public static string single_ComboBox_Selector(string FormText,string Title, List<string> Items)
        {
            string result="value";
            Form form_One = new Form();
            form_One.Text = FormText;
            
            Label label_One = new Label();
            label_One.Text = Title;
            label_One.Location = new Point(20, 10);

            Button button_One = new Button();
            button_One.Text = "OK";
            button_One.DialogResult = DialogResult.OK;
            button_One.Location = new Point(20, 100);

            form_One.HelpButton = true;
            form_One.AcceptButton = button_One;
            form_One.StartPosition = FormStartPosition.CenterScreen;
            
            form_One.Controls.Add(label_One);
            form_One.Controls.Add(button_One);
            form_One.Size = new Size(200, 200);

            form_One.ShowDialog();

            return result;
        }
    }
}
