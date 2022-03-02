using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EnterData : Form
    {
        private List<TextBox> Inputs = new List<TextBox>();

        public EnterData()
        {
            InitializeComponent();
            PropertyInfo[] PropertisInfo = typeof(Patient).GetProperties();
            for (int i = 0; i < PropertisInfo.Length; i++)
            {
                var property = PropertisInfo[i];
                var textBox = CreateTextBox(i, property);
                Inputs.Add(textBox);
                Controls.Add(textBox);
            }
            

        }

        public bool? ShowForm()
        {
            //var form = new EnterData();
            //if (form.ShowDialog()==DialogResult.OK)
            //{
            //    var patient = new Patient();

            //    foreach (var textBox in form.Inputs)
            //    {
            //        patient.GetType().InvokeMember(
            //            textBox.Tag.ToString()
            //            ,
            //            BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty
            //            ,
            //            Type.DefaultBinder
            //            ,
            //            patient
            //            ,
            //            new object[] { textBox.Text});
            //    }

            //    var result = Program.Controller.DataNetwork.Predict()?[0];
            //    return result == 1.0;
            //}
            return null;
        }

        private TextBox CreateTextBox(int number,PropertyInfo property)
        {
            var y = (number+1) * 25;
            var textBox =new TextBox();
            textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            textBox.Location = new System.Drawing.Point(10, y);
            textBox.Name = "textBox"+number;
            textBox.Size = new System.Drawing.Size(366, 20);
            textBox.TabIndex = number;
            textBox.Text = property.Name;
            textBox.Tag = property.Name;
            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
            return textBox;
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "")
            {
                textBox.Text = textBox.Tag.ToString();
            }
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == textBox.Tag.ToString())
            {
            textBox.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
