using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork._2.Neurons
{
    public class Connection
    {
        private double weight;
        /// <summary>
        /// вес связи
        /// </summary>
        public double Weight { get=>weight; set { weight = value; } }
        /// <summary>
        /// входной нейрон
        /// </summary>
        public Neuron Input { get; set; }
        /// <summary>
        /// выходной нейрон
        /// </summary>
        public Neuron OutputDelta { get; set; }

        /// <summary>
        /// входной сигнал
        /// </summary>
        public double InSignal
        { 
            get 
            {
               return  Weight* Input.Output; 
            }
        }

        /// <summary>
        /// дельта выходного сигнала
        /// </summary>
        public double OutDelta
        {
            get
            {
                return  Weight * OutputDelta.delta;
            }
        }

        /// <summary>
        /// сзязь нейрнов
        /// </summary>
        /// <param name="weightSignal">вес</param>
        /// <param name="input">входной нейрон</param>
        public Connection(double weightSignal, Neuron input)
        {
            Weight = weightSignal;
            Input = input;
            input.OutWeights.Add(this);
        }

        /// <summary>
        /// сзязь нейрнов
        /// </summary>
        /// <param name="weightSignal">вес</param>
        /// <param name="input">входной нейрон</param>
        /// <param name="output">выходной нейрон</param>
        public Connection(double weightSignal, Neuron input,Neuron output)
        {
            Weight = weightSignal;
            Input = input;
            OutputDelta = output;
            input.OutWeights.Add(this);
            output.InWeights.Add(this);
        }

        /// <summary>
        /// коректирование весов
        /// </summary>
        /// <param name="LearninRate">коофицент обучения</param>
        public void Corect(double LearninRate)
        {
            var d = OutputDelta.SigmoitDX;
            double rez = OutputDelta.delta * LearninRate * Input.Output * (1 - Input.Output) * OutputDelta.Output;
            Weight += rez;
        }
    }
}
