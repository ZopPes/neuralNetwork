using System;
using System.Collections.Generic;

namespace neural_network3
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
        public double Delta { get; private set; }
        public ActivationFunction ActivationFunction { get; }

        private double sum;  

        public Neuron(ActivationFunction activationFunction)
        {
            InputWeights = new List<Connection>();
            OutputWeight = new List<Connection>();
            ActivationFunction = activationFunction;
        }

        /// <summary>
        /// активация нейрона
        /// </summary>
        /// <returns>выходное значение нейрона</returns>
        public double FeedForward()
        {
            sum = 0;
            for (int i = 0; i < InputWeights.Count; i++)
            {
                sum += InputWeights[i].InputSignal;
            }
            Output = ActivationFunction.Equation(sum);
            return Output;
        }

        /// <summary>
        /// функция активации
        /// </summary>
        /// <param name="x">входное значение</param>
        /// <returns>обработанное значение</returns>

        /// <summary>
        /// используеться для входных нейронов
        /// </summary>
        /// <param name="error">коофицент ошибки</param>
        /// <param name="learningRate">коэфицент обучения</param>
        public void Learn(double error, double learningRate)
        {
            Delta = (Output - error) * ActivationFunction.Derivative(Output);
            double DeltalearningRate = Delta * learningRate;
            for (int i = 0; i < InputWeights.Count; i++)
            {
                InputWeights[i].Corect(DeltalearningRate);
            }
        }

        /// <summary>
        /// используется для всех нейронов кроме входнова слоя
        /// </summary>
        /// <param name="learningRate">коэфицент ошибки</param>
        public void Learn(double learningRate)
        {
            sum = 0;
            for (int i = 0; i < OutputWeight.Count; i++)
            {
                sum += OutputWeight[i].eror;
            }
            Delta = sum * ActivationFunction.Derivative(Output);
            double DeltalearningRate = Delta * learningRate;
            for (int i = 0; i < InputWeights.Count; i++)
            {
                InputWeights[i].Corect(DeltalearningRate);
            }
        }

        public override string ToString()
        {
            return Output.ToString(); 
        }
    }
}
