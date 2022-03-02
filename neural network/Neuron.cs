using System;
using System.Collections.Generic;

namespace neural_network
{
    public class Neuron
    {
        /// <summary>
        /// входные веса
        /// </summary>
        public List<Connection> InputWeights { get; }


        /// <summary>
        /// выходные веса
        /// </summary>
        public List<Connection> OutputWeight { get; }

        /// <summary>
        /// выходное значение
        /// </summary>
        public double Output { get; set; }

        /// <summary>
        /// ошибка
        /// </summary>
        public double Delta { get; set; }



        public Neuron()
        {
            InputWeights = new List<Connection>();
            OutputWeight = new List<Connection>();
        }

        public double Learn()
        {
            Delta = 0;
            for (int i = 0; i < OutputWeight.Count; i++)
            {
                Delta += OutputWeight[i].OutWeight;
            }
            return Delta;
        }

        public double LearnBeta(double LearninRate)
        {
            return LearninRate * Output*(1-Output) * Output;
        }

        /// <summary>
        /// запуск нейрона
        /// </summary>
        /// <param name="inputs">входные значения</param>
        /// <returns>ответ нейрона</returns>
        public double Predict()
        {
            return Output = Equation(Output);
        }

        private double Equation(double x) => 1.0 / (1.0 + Math.Exp(-x)); 

    /// <summary>
    /// преоброзование в строку
    /// </summary>
    /// <returns>выходной сигнал нейрона</returns>
    public override string ToString()
        {
            return Output.ToString();
        }
    }
}
