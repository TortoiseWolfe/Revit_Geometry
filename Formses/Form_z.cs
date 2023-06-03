#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Autodesk.Revit;
#endregion
namespace Revit_VizForms
{
    internal class Form_z
    {
        public static string Single_ComboBox_Selector(string FormText,string Title, List<string> Items)
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
        public static elementData Element_Creation_Form (List<string> Items)
        {
            elementData e_Data = new elementData();
            //   string result = "value";
            System.Windows.Forms.Form form_One = new System.Windows.Forms.Form();
            form_One.Text = "Element Creation";

            Label label_One = new Label();
            label_One.Text = "Selected Family";
            label_One.Location = new Point(202, 15);
            label_One.Size = new Size(81, 13);

            Label label_Two = new Label();
            label_Two.Text = "X";
            label_Two.Location = new Point(119, 43);
            label_Two.Size = new Size(68, 13);

            Label label_Three = new Label();
            label_Three.Text = "Y";
            label_Three.Location = new Point(119, 69);
            label_Three.Size = new Size(68, 13);

            Label label_Four = new Label();
            label_Four.Text = "Z";
            label_Four.Location = new Point(119, 95);
            label_Four.Size = new Size(68, 13);

            ComboBox comboBox_One = new ComboBox();
            foreach (var item in Items)
            {
                comboBox_One.Items.Add(item);
            }
            comboBox_One.Location = new Point(12, 12);
            comboBox_One.Size = new Size(200, 21);

            TextBox tb_X = new TextBox();
            tb_X.Text = "0.0";
            tb_X.Location = new Point(12, 40);
            tb_X.Size = new Size(100, 20);

            TextBox tb_Y = new TextBox();
            tb_Y.Text = "0.0";
            tb_Y.Location = new Point(13, 66);
            tb_Y.Size = new Size(100, 20);

            TextBox tb_Z = new TextBox();
            tb_Z.Text = "0.0";
            tb_Z.Location = new Point(13, 92);
            tb_Z.Size = new Size(100, 20);

            Button button_One = new Button();
            button_One.Text = "accept OK";
            button_One.DialogResult = DialogResult.OK;
            button_One.Location = new Point(258, 90);
            button_One.Size = new Size(75, 23);


            form_One.HelpButton = true;
            form_One.AcceptButton = button_One;
            form_One.StartPosition = FormStartPosition.CenterScreen;

            form_One.Controls.Add(button_One);
            form_One.Controls.Add(label_One);
            form_One.Controls.Add(label_Two);
            form_One.Controls.Add(label_Three);
            form_One.Controls.Add(label_Four);
            form_One.Controls.Add(comboBox_One);
            form_One.Controls.Add(tb_X);
            form_One.Controls.Add(tb_Y);
            form_One.Controls.Add(tb_Z);
            form_One.Size = new Size(200, 200);
            form_One.ShowDialog();
            e_Data.FamilyType = comboBox_One.SelectedItem.ToString();
            e_Data.point = new Autodesk.Revit.DB.XYZ(Convert.ToDouble(tb_X.Text), Convert.ToDouble(tb_Y.Text), Convert.ToDouble(tb_Z.Text));
   
            return e_Data;
        }
    }

        public class elementData
        {
            public string FamilyType { get; set; }
            public Autodesk.Revit.DB.XYZ point { get; set; }
        }

}
