using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace neural_network
{
    public class DataSet
    {
        public List<double[]> Inputs { get; }
        public List<double[]> Outputs { get; }

        public int Cout { get => Inputs.Count; }

        public int[] item { get; private set; }


        public int InputCout { get; }
        public int OutputCout { get; }

        public DataSet(int inputCout, int outputCout)
        {
            Inputs = new List<double[]>();
            Outputs = new List<double[]>();
            CreateItem(inputCout);
            InputCout = inputCout;
            OutputCout = outputCout;

        }

        

        public DataSet(string Path)
        {
            
            Inputs = new List<double[]>();
            Outputs = new List<double[]>();
            using (var reader = new StreamReader(Path))
            {
                var zag = reader.ReadLine().Split(';').Select(a => int.Parse(a)).ToList();
                var input = 0;
                var output = 0;
                foreach (var item in zag)
                {
                    if (item == 0) input++;
                    if (item == 1) output++;
                }
                InputCout = input;
                OutputCout = output;
                Console.WriteLine(input + "\t" + output);
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(';');

                    var inp = new List<double>();
                    var outp = new List<double>();
                    for (int i = 0; i < zag.Count; i++)
                    {
                        if (zag[i] == 0)
                        {
                            inp.Add(double.Parse(values[i]));
                        }
                        else
                        {
                            outp.Add(double.Parse(values[i]));
                        }
                    }
                    Inputs.Add(inp.ToArray());
                    Outputs.Add(outp.ToArray());
                }
            }

            CreateItem(InputCout);
        }

        private void CreateItem(int inputCout)
        {
            item = new int[inputCout];

            for (int i = 0; i < item.Length; i++)
            {
                item[i] = i;
            }
        }

        public void Add(double[] output, double[] input)
        {
            Inputs.Add(input);
            Outputs.Add(output);
        }
    }
}
