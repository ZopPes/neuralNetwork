using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network
{
    public class Topolodgi
    {
        public int InputCout { get; }
        public int OutputCout { get; }
        public double LearningRate { get; }
        public int[] Hiddenlayers { get; }
        public DataSet DataSet { get; }

        public int CoutLayer
        {
            get;
        }

        public Topolodgi(int inputCout, int outputCout, double learningRate, params int[] hiddenlayers)
        {
            InputCout = inputCout;
            OutputCout = outputCout;
            LearningRate = learningRate;
            Hiddenlayers = hiddenlayers;
            CoutLayer = 2 + hiddenlayers.Length;
        }

        public Topolodgi(DataSet dataSet, double learningRate, params int[] hiddenlayers)
        {
            DataSet = dataSet;
            InputCout = dataSet.InputCout;
            OutputCout = dataSet.OutputCout;
            LearningRate = learningRate;
            Hiddenlayers = hiddenlayers;
            CoutLayer = 2 + hiddenlayers.Length;

        }
    }
}
