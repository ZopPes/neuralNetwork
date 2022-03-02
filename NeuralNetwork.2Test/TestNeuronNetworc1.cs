using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using neural_network;

namespace NeuralNetwork._2Test
{
    [TestClass]
    class TestNeuronNetworc1
    {
        [TestMethod]
        public void neurontest()
        {
            Neuron neuron = new Neuron();
            List<double> vs = new List<double>();
            for (int i = -10; i < 11; i++)
            {
                vs.Add(neuron.Predict(i));
            }
        }
    }
}
