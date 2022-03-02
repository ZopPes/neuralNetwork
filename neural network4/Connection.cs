using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network3
{
    public class Connection
    {
        /// <summary>
        /// вес связи
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// входной нейрон
        /// </summary>
        public Neuron Input { get; set; }
        /// <summary>
        /// выходной нейрон
        /// </summary>
        public Neuron Output { get; set; }

         /// <summary>
         /// входной сигнал нейрона
         /// </summary>
        public double InputSignal { get => Weight * Input.Output; }

        public double eror { get => Weight * Output.Delta; }

        /// <summary>
        /// связь нейронов
        /// </summary>
        /// <param name="weight">вес</param>
        /// <param name="input">входной нейрон</param>
        /// <param name="outputDelta">выходной нейрон</param>
        public Connection(double weight, Neuron input, Neuron outputDelta)
        {
            Weight = weight;
            Input = input;
            Output = outputDelta;
            outputDelta.InputWeights.Add(this);
            input.OutputWeight.Add(this);
        }

        public void Corect(double LearningRate)
        {
            Weight -= (0.1+Input.Output) * eror*LearningRate;
        }

        public override string ToString()
        {
            return Weight.ToString();
        }
    }
}
