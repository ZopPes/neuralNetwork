using System;
using System.Collections.Generic;
using System.Text;
using NeuralNetwork._2.Neurons;

namespace NeuralNetwork._2
{
    public class Layer
    {
        /// <summary>
        /// нейроны
        /// </summary>
        public Neuron[] Neurons { get; }

        /// <summary>
        /// тип слоя
        /// </summary>
        public NeuronType Type { get; }

        private double[] output;
        /// <summary>
        /// слой входных нейронов
        /// </summary>
        /// <param name="InputCout">количество нейронов</param>
        public Layer(int InputCout)
        {
            output = new double[InputCout];
            Neurons = new Neuron[InputCout];
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i] = new Neuron();
            }

        }

        /// <summary>
        /// слой нейронов
        /// </summary>
        /// <param name="CoutNeurons">количестов нейронов</param>
        /// <param name="type">тип слоя</param>
        public Layer(int CoutNeurons, NeuronType type)
        {
            output = new double[CoutNeurons];
            Neurons = new Neuron[CoutNeurons];
                for (int i = 0; i < Neurons.Length; i++)
                {
                Neurons[i] = new Neuron(type);
                }
            
        }

        /// <summary>
        /// активация слоя
        /// </summary>
        /// <returns></returns>
        public double[] activation()
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                output[i] = Neurons[i].activation();
            }
             return output;
        }

        /// <summary>
        /// активация входных нейронов
        /// </summary>
        /// <param name="inputs">входные параметры</param>
        /// <returns>просто значение не нужно</returns>
        public double[] activation(params double[] inputs)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].activation(inputs[i]);
            }
            return output;
        }

       
    }
}
