using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NeuralNetwork._2;
using NeuralNetwork._2.Neurons;

namespace ConsoleApp1
{
    class Program
    {
        public static Random random = new Random();

        public static double[] output = new double[]
        {
                0
                ,
                1
                ,
                0
                ,
                0.5
        };
        public static double[][] inputt = new double[][]
        {
                new double[]{0,0}
                ,
                new double[]{0,1}
                ,
                new double[]{1,0}
                ,
                new double[]{1,1}
        };

       
        static void Main(string[] args)
        {

            NeuronNetwork network = new NeuronNetwork(2, 1, 0.1,2);



            for (int i = 0; i < 10000; i++)
            {
                var sq = random.Next(0, 4);
                network.backPropagationError(new double[] { output[sq] }, inputt[sq]);


            }
            for (int j = 0; j < 4; j++)
            {
                var rezult = network.activation(inputt[j])[0];
                Console.WriteLine(output[j] + "\t" + rezult);
            }
            return;
            var OutPuts = new List<double>();
            var IntPuts = new List<double[]>();
            using (var sr = new StreamReader(@"C:\Users\zop85\Source\Repos\neural network\ConsoleApp1\heart.csv"))
            {
                var header = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var row = sr.ReadLine();
                    var values = row.Split(';').Select(a => double.Parse(a)).ToList();
                    var outpot = values.Last();
                    var input = values.Take(values.Count - 1).ToArray();
                    OutPuts.Add(outpot);
                    IntPuts.Add(input);
                }
            }


            //for (int i = 0; i < OutPuts.Count; i++)
            //{
            //    Console.WriteLine(OutPuts[i]);
            //    foreach (var item in IntPuts[i])
            //    {
            //        Console.WriteLine("\t" + item);
            //    }
            //}


            NeuronNetwork neuralNetwork = new NeuronNetwork(IntPuts[0].Length, 1, 0.2, IntPuts[0].Length / 2);
            Console.WriteLine(OutPuts[0] + "\t" + neuralNetwork.activation(IntPuts[0])[0]);
            for (int i = 0; i < 2; i++)
            {
                var slu = random.Next(0, OutPuts.Count);
                neuralNetwork.backPropagationError(new double[] { OutPuts[slu] }, IntPuts[slu]);
            }
            for (int i = 0; i < 100; i++)
            {
                var slu = random.Next(0, OutPuts.Count);
                Console.WriteLine(OutPuts[slu] + "\t" + neuralNetwork.activation(IntPuts[slu])[0]);

            }



        }

        

    }
}
