using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neural_network3
{
    public class Topolodgi
    {
        public int InputCout { get; }
        public int OutputCout { get; }
        public double LearningRate { get; }
        public List<int> Hiddenlayers { get; }

        public DataSet DataSet { get; }

        public Topolodgi(int inputCout, int outputCout,double learningRate, params int[] hiddenlayers)
        {
            InputCout = inputCout;
            OutputCout = outputCout;
            LearningRate = learningRate;
            Hiddenlayers = hiddenlayers.ToList();
        }

        public Topolodgi(DataSet dataSet, double learningRate, params int[] hiddenlayers)
        {
            DataSet = dataSet;
            InputCout = dataSet.InputCout;
            OutputCout =dataSet.OutputCout;
            LearningRate = learningRate;
            Hiddenlayers = hiddenlayers.ToList();
        }
    }
}
