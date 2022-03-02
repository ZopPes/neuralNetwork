using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network3
{
    public class DataSet
    {
        public List<double[]> Inputs { get; }
        public List<double[]> Outputs { get; }

        public int Cout { get => Inputs.Count; }

        public int InputCout { get; }
        public int OutputCout { get; }

        public DataSet(int inputCout, int outputCout)
        {
            InputCout = inputCout;
            OutputCout = outputCout;
            Inputs = new List<double[]>();
            Outputs = new List<double[]>();
        }

        public void Add(double[] output, double[] input)
        {
            Inputs.Add(input);
            Outputs.Add(output);
        }
    }
}
