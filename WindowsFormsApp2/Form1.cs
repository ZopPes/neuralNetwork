using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork._2;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        Random random = new Random();

        double[] output = new double[]
        {
                0
                ,
                1
                ,
                0
                ,
                0.5
        };
        double[][] inputt = new double[][]
        {
                new double[]{0,0}
                ,
                new double[]{0,1}
                ,
                new double[]{1,0}
                ,
                new double[]{1,1}
        };

        NeuronNetwork network = new NeuronNetwork(2, 1, 0.1);


        public Form1()
        {
            InitializeComponent();

            
        }

        private void zap() 
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                var sq = random.Next(0, 4);
                network.backPropagationError(new double[] { output[sq] }, inputt[sq]);


            }
            zap();

            for (int j = 0; j < 4; j++)
            {
                var rezult = network.activation(inputt[j])[0];
            }
        }
    }
}
