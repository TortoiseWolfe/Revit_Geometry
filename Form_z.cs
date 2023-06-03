using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Revit_VizForms
{
    internal class Form_z
    {
        public static string single_ComboBox_Selector(string FormText,string Title, List<string> Items)
        {
            string result="value";
            System.Windows.Forms.Form form_One = new System.Windows.Forms.Form();
            form_One.Text = FormText;
            
            Label label_One = new Label();
            label_One.Text = Title;
            label_One.Location = new Point(20, 10);

            ComboBox comboBox_One = new ComboBox();
            foreach (var item in Items)
            {
                comboBox_One.Items.Add(item);
            }
            comboBox_One.Location = new Point(20, 30);
            comboBox_One.Size = new Size(200, 20);

            Button button_One = new Button();
            button_One.Text = "OK";
            button_One.DialogResult = DialogResult.OK;
            button_One.Location = new Point(20, 100);

            form_One.HelpButton = true;
            form_One.AcceptButton = button_One;
            form_One.StartPosition = FormStartPosition.CenterScreen;
            
            form_One.Controls.Add(button_One);
            form_One.Controls.Add(label_One);
            form_One.Controls.Add(comboBox_One);
            form_One.Size = new Size(200, 200);
            form_One.ShowDialog();
            result = comboBox_One.SelectedItem.ToString();

            return result;
        }
        public static string Single_ComboBox_and_Text_Selector(string FormText, string Title, List<string> Items)
        {
            string result = "value";
            System.Windows.Forms.Form form_One = new System.Windows.Forms.Form();
            form_One.Text = FormText;

            Label label_One = new Label();
            label_One.Text = Title;
            label_One.Location = new Point(20, 10);

            ComboBox comboBox_One = new ComboBox();
            foreach (var item in Items)
            {
                comboBox_One.Items.Add(item);
            }
            comboBox_One.Location = new Point(20, 40);
            comboBox_One.Size = new Size(200, 20);

            TextBox tb_Test_Value = new TextBox();
            tb_Test_Value.Location = new Point(20, 80);
            tb_Test_Value.Size = new Size(200, 20);


            Button button_One = new Button();
            button_One.Text = "OK";
            button_One.DialogResult = DialogResult.OK;
            button_One.Location = new Point(20, 120);

            form_One.HelpButton = true;
            form_One.AcceptButton = button_One;
            form_One.StartPosition = FormStartPosition.CenterScreen;

            form_One.Controls.Add(button_One);
            form_One.Controls.Add(label_One);
            form_One.Controls.Add(comboBox_One);
            form_One.Controls.Add(tb_Test_Value);
            form_One.Size = new Size(200, 200);
            form_One.ShowDialog();
            result = comboBox_One.SelectedItem.ToString()+"|"+tb_Test_Value;

            return result;
        }
    }
}
