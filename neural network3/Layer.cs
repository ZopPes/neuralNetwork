using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network3
{
    public class Layer
    {
        /// <summary>
        /// нейроны
        /// </summary>
        public Neuron[] Neurons { get; }

        /// <summary>
        /// количество нейронов
        /// </summary>
        public int Cout => Neurons?.Length ?? 0;

        public double[] outputs;

        public double[] Outputs
        {
            get
            {
                for (int i = 0; i < Neurons.Length; i++)
                {
                    outputs[i] = Neurons[i].Output;
                }
                return outputs;
            }
        }


        /// <summary>
        /// слой нейронной сети
        /// </summary>
        /// <param name="neurons">нейроны</param>
        /// <param name="type">тип нейронной сети</param>
        public Layer(List<Neuron> neurons)
        {
            Neurons = neurons.ToArray();
        }

        /// <summary>
        /// слой нейронной сети
        /// </summary>
        /// <param name="Cout">количество нейронов</param>
        /// <param name="type">тип нейронов</param>
        

        public Layer(int Cout, ActivationFunction activationFunction)
        {
            Neurons = new Neuron[Cout];
            outputs = new double[Cout];
            for (int i = 0; i < Cout; i++)
            {
                Neurons[i] = new Neuron(activationFunction);
            }
        }
    }
}
