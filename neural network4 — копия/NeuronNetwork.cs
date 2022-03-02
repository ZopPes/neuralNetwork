using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace neural_network3
{
    public class NeuronNetwork
    {
        /// <summary>
        /// слои нейронной сети
        /// </summary>
        public List<Layer> Layers { get; private set; }

        public Connection[][] Connections { get; private set; }
        /// <summary>
        /// топология нейронной сети
        /// </summary>
        public Topolodgi Topolodgi { get; private set; }

        public ActivationFunction ActivationFunction { get; set; }

        public string Name { get; set; }

        public DataSet DataSet { get; set; }


        private Random random = new Random();

        /// <summary>
        /// нейронная сеть
        /// </summary>
        /// <param name="topolodgi">топология</param>
        public NeuronNetwork( Topolodgi topolodgi)
        {
            zapusc(topolodgi, ActivationFunction.Sigmoid);
            CreateRandomConnection();

        }

        public NeuronNetwork(Topolodgi topolodgi,ActivationFunction activationFunction)
        {
            zapusc(topolodgi, activationFunction);
            CreateRandomConnection();

        }

        public NeuronNetwork(Topolodgi topolodgi,List<List<double>> Weight)
        {
            zapusc(topolodgi, ActivationFunction.Sigmoid);

            Connections = new Connection[Weight.Count][];
            CreateInConnection(Weight);
        }

        private void CreateInConnection(List<List<double>> Weight)
        {
            for (int i = 0; i < Layers.Count - 1; i++)
            {
                var ninlayr = Layers[i];
                var sllayr = Layers[i + 1];
                var Connect = new Connection[ninlayr.Cout*sllayr.Cout];
                var index = 0;
                for (int j = 0; j < ninlayr.Cout; j++)
                {
                    var ninNeyrun = ninlayr.Neurons[j];
                    for (int k = 0; k < sllayr.Cout; k++, index++)
                    {
                        var sllneuron = sllayr.Neurons[k];
                        Connect[index]=new Connection(Weight[i][index], ninNeyrun, sllneuron);
                    }
                }
                Connections[i]=Connect;
            }
        }

        private void zapusc(Topolodgi topolodgi, ActivationFunction activationFunction)
        {
            
            Topolodgi = topolodgi;
            DataSet = topolodgi.DataSet;

            string path = Topolodgi.InputCout + "_" + Topolodgi.OutputCout;
            foreach (var item in Topolodgi.Hiddenlayers)
            {
                path += "_" + item;
            }
            Name = "NeuronNetwork" + path;

            Layers = new List<Layer>();
            ActivationFunction = activationFunction;
            Layers.Add(new Layer(topolodgi.InputCout, ActivationFunction));
            CreateHiddenLayers();
            Layers.Add(new Layer(topolodgi.OutputCout, ActivationFunction));
        }

        /// <summary>
        /// создание связий нейронов
        /// </summary>
        private void CreateRandomConnection()
        {
             var connections = new List<Connection[]>();
            for (int i = 0; i < Layers.Count-1; i++)
            {
                var ninlayr = Layers[i];
                var sllayr = Layers[i+1];
                var Connect =new List<Connection>();
                for (int j = 0; j < ninlayr.Cout; j++)
                {
                    var ninNeyrun = ninlayr.Neurons[j];

                    for (int k = 0; k < sllayr.Cout; k++)
                    {
                        var sllneuron = sllayr.Neurons[k];
                        Connect.Add(new Connection(random.NextDouble(), ninNeyrun, sllneuron));
                    }
                }
                connections.Add(Connect.ToArray());
            }
            Connections = connections.ToArray();
        }

        /// <summary>
        /// активация нейрона
        /// </summary>
        /// <param name="input">входные параметры</param>
        /// <returns>ответы нейронной сети</returns>
        public double[] FeedForward(params double[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Layers[0].Neurons[i].Output = input[i];
            }

            for (int i = 1; i < Layers.Count; i++)
            {
                var layer = Layers[i].Neurons;

                foreach (var neuron in layer)
                {
                    neuron.FeedForward();
                }
            }
            return Layers.Last().Outputs;
        }


        /// <summary>
        /// обратное распростроннение ошибки
        /// </summary>
        /// <param name="exprected">ожидаимое значение</param>
        /// <param name="input">входные данные</param>
        /// <returns></returns>
        public double Beckpropagation(double[] exprected,params double[] input)
        {
            FeedForward(input);
            var differens = 0.0;

            for (int i = 0; i < Layers.Last().Cout; i++)
            {
                var neuron = Layers.Last().Neurons[i];                
                differens += Math.Pow(neuron.Learn(exprected[i]), 2);
            }

            for (int i = Layers.Count - 2; i >= 0; i--)
            {
                var Layer = Layers[i];
                for (int j = 0; j < Layer.Cout; j++)
                {
                     Layer.Neurons[j].Learn();                   
                }
            }

            foreach (var Layers in Connections)
            {
                foreach (var connection in Layers)
                {
                    connection.Corect(Topolodgi.LearningRate);
                }
            }
            return differens;
        }

        public double Beckpropagation(int index)
        {
            return Beckpropagation(DataSet.Outputs[index], DataSet.Inputs[index]);            
        }

        public double AutoBeckpropagation(int epoh)
        {
            var eror = 0.0;
            for (int i = 0; i < epoh; i++)
            {
                var zn = random.Next(0, DataSet.Cout);
                eror += Beckpropagation(zn);
            }

            return eror / epoh;
        }
        /// <summary>
        /// создание скрытого слоя
        /// </summary>
        private void CreateHiddenLayers()
        {
            for (int i = 0; i < Topolodgi.Hiddenlayers.Count; i++)
            {
                Layers.Add(new Layer(Topolodgi.Hiddenlayers[i],ActivationFunction));
            }
        }

        public void Save(string Path)
        {
            Savejson(Path);
        }

        private void Savejson(string Path)
        {
            File.WriteAllText
                            (
                                Path, JsonConvert.SerializeObject
                                (
                                    Connections.Select
                                    (
                                        b => b.Select
                                        (
                                            a => a.Weight
                                        )
                                    )
                                )
                            );
        }

        public void Save()
        {
            string path=Topolodgi.InputCout+"_"+Topolodgi.OutputCout;
            foreach (var item in Topolodgi.Hiddenlayers)
            {
                path += "_" + item;
            }
            Savejson(Name+".json");
        }

        public void Read(string path)
        {
            CreateInConnection(JsonConvert.DeserializeObject<List<List<double>>>(File.ReadAllText(path)));
        }
        public bool Read()
        {
            if (!File.Exists(Name + ".json"))
            {
                return false;
            } 
            CreateInConnection(JsonConvert.DeserializeObject<List<List<double>>>(File.ReadAllText(Name+".json")));
            return true;
        }

        public static double[][] Scalling(double[][] input)
        {
            var rezult = new double[input.Length][];
            for (int i = 0; i < rezult.Length; i++)
            {
                rezult[i] = new double[input[0].Length];
            }
            for (int column = 0; column < input[0].Length; column++)
            {
                var min = input[0][column];
                var max = input[0][column];
                for (int row = 1; row < input.Length; row++)
                {
                    var item = input[row][ column];
                    if (min>item)
                    {
                        min = item;
                    }
                    if (max<item)
                    {
                        max = item;
                    }

                }
                rezult[column] = new double[rezult[column].Length];
                var divi = (max - min);
                for (int row = 0; row < input.Length; row++)
                {

                    rezult[row][column] = (input[row][column] - min) / divi;
                }
            }
            return rezult;
        }

        public static double[][] Normalization(double[][] input)
        {
            var rezult = new double[input.Length][];
            for (int i = 0; i < rezult.Length; i++)
            {
                rezult[i] = new double[input[0].Length];
            }
            for (int column = 0; column < input[0].Length; column++)
            {
                var sum = 0.0;
                for (int row = 0; row < input.Length; row++)
                {
                    sum += input[row][column];
                }
                var averent = sum / input.Length;

                var error = 0.0;
                for (int row = 0; row < input.Length; row++)
                {
                    error += Math.Pow(input[row][column] - averent, 2);
                }
                var standardError = Math.Sqrt(error / input.Length);

                for (int row = 0; row < input.Length; row++)
                {

                    rezult[row][column] = (input[row][column] - averent) / standardError;
                }
            }
            return rezult;
        }


    }
}
