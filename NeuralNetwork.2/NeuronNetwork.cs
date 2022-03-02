using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork._2.Neurons;

namespace NeuralNetwork._2
{
    public class NeuronNetwork
    {
        /// <summary>
        /// слои нейросети
        /// </summary>
        public List<Layer> layers { get; }

        /// <summary>
        /// количество входных нейронов
        /// </summary>
        public int InputCout { get; private set; }

        /// <summary>
        /// коэфицен обучения
        /// </summary>
        public double LearninRate { get; }


        /// <summary>
        /// выходной слой
        /// </summary>
        public int OutputCout { get; }

        /// <summary>
        /// веса
        /// </summary>
        public Connection[][] Weights { get; set; }

        /// <summary>
        /// нейронная сеть
        /// </summary>
        /// <param name="inputCout">количество входных нейронов</param>
        /// <param name="outputCout">количество выходных нейронов</param>
        /// <param name="LearninRate">коэфицент обучения</param>
        /// <param name="hiddenLeyer">скрытый слой</param>
        public NeuronNetwork(int inputCout, int outputCout, double LearninRate, params int[] hiddenLeyer )
        {
            OutputCout = outputCout;
            this.LearninRate = LearninRate;
            InputCout = inputCout;

            layers = new List<Layer>();

            layers.Add(new Layer(inputCout));

            CreateniddenLeyer(hiddenLeyer);

            layers.Add(new Layer(outputCout, NeuronType.Output));

            CreateWeight();
        }

        /// <summary>
        /// создание связий
        /// </summary>
        private void CreateWeight()
        {
            Random random = new Random();
            for (int LayersIndex = 0; LayersIndex < layers.Count - 1; LayersIndex++)
            {
                Neuron[] ninNeurons = layers[LayersIndex].Neurons;
                Neuron[] sleddNeurons = layers[LayersIndex + 1].Neurons;


                for (int i = 0; i < sleddNeurons.Length; i++)
                {
                    for (int j = 0; j < ninNeurons.Length; j++)
                    {
                        new Connection(random.NextDouble(), ninNeurons[j],sleddNeurons[i]);
                    }
                }
            }
        }

        /// <summary>
        /// создание скрытого слоя
        /// </summary>
        /// <param name="hiddenLeyer">количестов скрытых слоёв</param>
        private void CreateniddenLeyer(int[] hiddenLeyer)
        {
            if (hiddenLeyer == null) return;
            for (int i = 0; i < hiddenLeyer.Length; i++)
            {
                layers.Add(new Layer(hiddenLeyer[i],NeuronType.Normal));
            }
        }


        /// <summary>
        /// обучение
        /// </summary>
        /// <param name="output">ожидаемый результат</param>
        /// <param name="input">входные данные</param>
        public void backPropagationError(double[] output,double[] input)
        {
            activation(input);
            Layer end = layers.Last();
            for (int i = 0; i < end.Neurons.Length; i++)
            {
                end.Neurons[i].CreateDelta(output[i]);

            }

            for (int i = layers.Count - 2; i >= 0; i--)
            {
                foreach (var item in layers[i].Neurons)
                {
                    item.textCreateDelta(LearninRate);
                }
            }

        }
        
        /// <summary>
        /// активация нейросети
        /// </summary>
        /// <param name="input">входные сигналы</param>
        /// <returns>результат</returns>
        public double[] activation(params double[] input)
        {            
            double[] result= layers[0].activation(input); 
            for (int i = 1; i < layers.Count; i++)
            {
               result= layers[i].activation();
            }
            return result;
        }
    }
}
