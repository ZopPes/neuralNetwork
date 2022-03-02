using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using neural_network3;
namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var DataSet = new DataSet(9, 3);

            DataSet.Add(new double[] { 1, 0, 0 }, new double[] { 1, 1, 1, 0, 0, 0, 0, 0, 0 });
            DataSet.Add(new double[] { 1, 0, 1 }, new double[] { 0, 0, 0, 1, 1, 1, 0, 0, 0 });
            DataSet.Add(new double[] { 1, 0, 0 }, new double[] { 0, 0, 0, 0, 0, 0, 1, 1, 1 });
            DataSet.Add(new double[] { 0, 1, 0 }, new double[] { 1, 0, 0, 1, 0, 0, 1, 0, 0 });
            DataSet.Add(new double[] { 0, 1, 1 }, new double[] { 0, 1, 0, 0, 1, 0, 0, 1, 0 });
            DataSet.Add(new double[] { 0, 1, 0 }, new double[] { 0, 0, 1, 0, 0, 1, 0, 0, 1 });
            DataSet.Add(new double[] { 1, 1, 0 }, new double[] { 1, 1, 1, 1, 0, 0, 1, 0, 0 });
            DataSet.Add(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1, 0, 1, 0, 0, 1, 0 });
            DataSet.Add(new double[] { 1, 1, 0 }, new double[] { 1, 1, 1, 0, 0, 1, 0, 0, 1 });
            DataSet.Add(new double[] { 1, 1, 1 }, new double[] { 1, 0, 0, 1, 1, 1, 1, 0, 0 });
            DataSet.Add(new double[] { 1, 1, 1 }, new double[] { 0, 1, 0, 1, 1, 1, 0, 1, 0 });
            DataSet.Add(new double[] { 1, 1, 1 }, new double[] { 0, 0, 1, 1, 1, 1, 0, 0, 1 });
            DataSet.Add(new double[] { 1, 1, 0 }, new double[] { 1, 0, 0, 1, 0, 0, 1, 1, 1 });
            DataSet.Add(new double[] { 0, 0, 0 }, new double[] { 0, 1, 0, 0, 1, 0, 1, 1, 1 });
            DataSet.Add(new double[] { 1, 0, 0 }, new double[] { 0, 0, 1, 0, 0, 1, 1, 1, 1 });
            DataSet.Add(new double[] { 0, 1, 0 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            var topologi = new Topolodgi(DataSet, 0.3, 5, 3);
            var neuronNetworc = new NeuronNetwork(topologi);
            Console.WriteLine(neuronNetworc.Read());
            double eror = neuronNetworc.AutoBeckpropagation(500000) / 3;



            Console.WriteLine(eror.ToString());
            TestFeedForward(neuronNetworc);
            Console.ReadKey();
        }

        public static void TestFeedForward(NeuronNetwork neuronNetworc)
        {
            for (int i = 0; i < neuronNetworc.DataSet.Cout; i++)
            {
                var rez = neuronNetworc.FeedForward(neuronNetworc.DataSet.Inputs[i]);
                var axp = neuronNetworc.DataSet.Outputs[i];
                Console.WriteLine("---");

                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(axp[j]+"\t"+rez[j].ToString());
                }
                Console.WriteLine("---");

            }
        }
    }
}
