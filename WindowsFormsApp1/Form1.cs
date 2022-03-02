using System;
using System.Drawing;
using System.Windows.Forms;
using neural_network;
using PictureConvert;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        AboutBox1 abautForm = new AboutBox1();
        PictureConvertClass PictureConvert = new PictureConvertClass();
        Topolodgi Topolodgi = new Topolodgi(2, 1, 0.001, 4);
        NeuronNetwork NeuronNetwork;
        Random Random = new Random();

        double[] output = new double[]
            {
                0
                ,0
                ,1
                ,0.5
            };
        double[,] input = new double[,]
        {
                {0,0 }
                ,
                {0,1 }
                ,
                {1,0 }
                ,
                {1,1 }

        };

        public Form1()
        {
            InitializeComponent();
            

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abautForm.ShowDialog();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                
                var inputs = PictureConvert.Convert(openFileDialog1.FileName);
                var result = Program.Controller.ImageNetwork.Predict(inputs)[0];
                
            }
        }

        private void enterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var enterDataForm = new EnterData();
            var result = enterDataForm.ShowForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           NeuronNetwork = new NeuronNetwork(Topolodgi);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var ou = new double[1];


            var j = Random.Next(0, 4);
            {
                ou[0] = output[j];
                var inp = NeuronNetwork.GetRow(input, j);
                var error = Math.Pow(NeuronNetwork.Learn(ou, inp), 2);
                var rez = NeuronNetwork.Predict(inp)[0].Output;
                textBox2.Text = rez.ToString();
                textBox3.Text = output[j].ToString();
                textBox1.Text = error.ToString();
                if (ou[0]==rez)
                {
                    timer1.Stop();
                }
            }

            
        }
    }
}
