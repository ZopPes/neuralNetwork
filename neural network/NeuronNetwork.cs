using System;
using System.Collections.Generic;
using System.Linq;

namespace neural_network
{
    public class NeuronNetwork
    {
        /// <summary>
        /// нейронные слои
        /// </summary>
        public List<Layer> Layers { get; private set; }

        public Layer Inputlayers { get => Layers?[0]; }

        public List<Connection>[] Connections { get; private set; }

        public DataSet DataSet { get => Topolodgi?.DataSet; }

        /// <summary>
        /// топология нейроной сети
        /// </summary>
        public Topolodgi Topolodgi { get; }
        public string Name { get; private set; }

        /// <summary>
        /// Нейронная сеть
        /// </summary>
        /// <param name="tonolodgi">топология нейроной сети</param>
        public NeuronNetwork(Topolodgi topolodgi)
        {
            Topolodgi = topolodgi;
            CreateDate();
            CreateNeuron();

            for (int i = 0; i < Layers.Count-1; i++)
            {
                Connections[i]= Layers[i].Connect(Layers[i + 1]);
            } 
        }

        private void CreateNeuron()
        {
            Layers.Add(new Layer(Topolodgi.InputCout));
            foreach (var item in Topolodgi.Hiddenlayers)
            {
                Layers.Add(new Layer(item));
            }
            Layers.Add(new Layer(Topolodgi.OutputCout));
        }

        private void CreateDate()
        {
            string path = Topolodgi.InputCout + "_" + Topolodgi.OutputCout;
            foreach (var item in Topolodgi.Hiddenlayers)
            {
                path += "_" + item;
            }
            Name = "NeuronNetwork" + path;

            Layers = new List<Layer>();
            Connections = new List<Connection>[Topolodgi.CoutLayer-1];
        }

        public double[] FeedForward(params double[] input)
        {
            for (int i = 0; i < Topolodgi.InputCout; i++)
            {
                Layers[0][i].Output = input[i];
            }


            for (int i = 0; i < Layers.Count; i++)
            {
                var Lo = Layers[i];
                for (int j = 0; j < Lo.Count; j++)
                {
                    var neuron = Lo[j];
                    for (int k = 0; k < neuron.InputWeights.Count; k++)
                    {
                        neuron.Output += neuron.InputWeights[k].OutWeight;
                    }
                    neuron.Predict();
                }
            }

            return Layers.Last().Select(a => a.Output).ToArray();

        }

        /// <summary>
        /// фктивационная функция по индексу в базе
        /// </summary>
        /// <param name="index">номер данных из базы</param>
        /// <returns>ответы нейронов</returns>
        public double[] FeedForward(int index)
        {
            return FeedForward(DataSet.Inputs[index]);
        }

        /// <summary>
        /// обучение нейронная
        /// </summary>
        /// <param name="exprected">ожидаеммые значения</param>
        /// <param name="input">входные данные</param>
        /// <returns>ошибка выходных нейронов</returns>
        public double Beckpropagation(double[] exprected, params double[] input)
        {
            FeedForward(input);

            var error = 0.0;
            for (int x = 0; x < Layers.Last().Count; x++)
            {
                var Lo = Layers.Last()[x];
                Lo.Delta = exprected[x] - Lo.Output;
                error += Math.Pow(Lo.Delta, 2);
            }

            for(int i = Layers.Count - 2; i >= 0; i--)
            {
                var Li = Layers[i];
                for (int x = 0; x < Li.Count; x++)
                {
                        Li[x].Learn();
                }
            }

            for (int i = 0; i < Connections.Length; i++)
            {
                for (int j = 0; j < Connections[i].Count; j++)
                {
                    Connections[i][j].Correct(Topolodgi.LearningRate);
                }
            }
            return error;
        }

        /// <summary>
        /// обучение сети по индексу из базы
        /// </summary>
        /// <param name="index">индекс из базы</param>
        /// <returns>ошибка выходных нейронов</returns>
        public double Beckpropagation(int index)
        {
            return Beckpropagation(DataSet.Outputs[index], DataSet.Inputs[index]);
        }

    }
}
