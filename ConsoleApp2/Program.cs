using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using neural_network;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<double> outputs = new List<double>();
            //List<double[]> inputs = new List<double[]>();
            //using (StreamReader sr = new StreamReader(@"C:\Users\zop85\Source\Repos\neural network\ConsoleApp2\dataset\dataset.csv"))
            //{
            //    string header = sr.ReadLine();

            //    while (!sr.EndOfStream)
            //    {
            //        string row = sr.ReadLine();
            //        double[] values = row.Split(';').Select(a=> double.Parse(a)).ToArray();
            //        double result = values.Last();
            //        double[] input = values.Take(values.Length - 1).ToArray();
            //        outputs.Add(result);
            //        inputs.Add(input);
            //    }
            //}

            //double[,] inputsSignal = new double[inputs.Count, inputs[0].Length];

            //for (int i = 0; i < inputsSignal.GetLength(0); i++)
            //{
            //    for (int l = 0; l < inputsSignal.GetLength(1); l++)
            //    {
            //        inputsSignal[i, l] = inputs[i][l];

            //    }
            //}

            //NeuronNetwork neyronNetwork = new NeuronNetwork(new Topolodgi(outputs.Count, 1, 0.1, outputs.Count));
            //double differens = neyronNetwork.Learn(outputs.ToArray(),inputsSignal, 10000);

            //List<double> results = new List<double>();

            //for (int i = 0; i < inputsSignal.GetLength(0); i++)
            //{
            //    double[] data = NeuronNetwork.GetRow(inputsSignal, i);
            //    results.Add(neyronNetwork.Predict(data)[0]);
            //}


            //Console.WriteLine(differens);
            //for (int i = 0; i < results.Count; i++)
            //{
            //    double expected = Math.Round(outputs[i], 1);
            //    var actual = Math.Round(results[i], 1);

            //    Console.WriteLine(expected + "!=" + actual);
            //}

        }
    }
}
