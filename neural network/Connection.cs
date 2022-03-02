using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network
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

        public double IntWeight { get => Weight * Input.Output; }
        public double OutWeight { get => Weight * Output.Output; }

        private double OutCorrect { get => Output.Delta * Output.Output * (1 - Output.Output) * Output.Output; }

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

        public void Correct(double LearningRate)
        {
            Weight += LearningRate * OutCorrect;
        }

    }
}
