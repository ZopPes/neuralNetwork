using System;
using System.Collections.Generic;

namespace NeuralNetwork._2.Neurons
{
    public class Neuron
    {
        /// <summary>
        /// входящие связи
        /// </summary>
        public List<Connection> InWeights { get; set; } = new List<Connection>();

        /// <summary>
        /// исходящие связи
        /// </summary>
        public List<Connection> OutWeights { get; set; } = new List<Connection>();

        /// <summary>
        /// исходящий сигнал
        /// </summary>
        public double Output { get; set; } = 0;

        public double SigmoitDX 
        { get 
            {
                double r = Fank(Output);
                return r / (1 - r);
            }
        }

        /// <summary>
        /// ошибка
        /// </summary>
        public double delta { get; set; }

        
        private double sum;

        /// <summary>
        /// тип нейрона
        /// </summary>
        public NeuronType Type { get; }

        /// <summary>
        /// Входной нейрон
        /// </summary>
        public Neuron()
        {
            Type = NeuronType.Input;
        }

        /// <summary>
        /// нейрон нейросети
        /// </summary>
        /// <param name="type">тип нейрона</param>
        public Neuron(NeuronType type)
        {
            Type = type;            
        }

        /// <summary>
        /// вычисление коофицента ошибки выходного нейрона
        /// </summary>
        /// <param name="input">ожидаемый результат</param>
        public double CreateDelta(double input)
        {
            return delta = Output - input;
        }

        /// <summary>
        /// вычисление коофицента ошибки скрытого нейрона
        /// </summary>
        public double CreateDelta()
        {
            delta = 0;
                foreach (var item in OutWeights)
                {
                    delta += item.OutDelta;
                }
                return delta;
        }
        
        public double textCreateDelta(double LearninRate)
        {
            delta = 0;
            foreach (var item in OutWeights)
            {
                delta += item.OutDelta;
            }
            
            for (int i = 0; i < OutWeights.Count; i++)
            {
                OutWeights[i].Weight -=SigmoitDX * delta * LearninRate;
            }
            return delta;
        }

        /// <summary>
        /// активация нейрона
        /// </summary>
        /// <returns>результат нейрона</returns>
        public double activation()
        {
            if (Type==NeuronType.Input)
            {
                return Output;
            }
            else
            {
            sum = 0;
            for (int i = 0; i < InWeights.Count; i++)
            {
                sum += InWeights[i].InSignal;
            }
                Output = Fank(sum);
            }
            return Output;
        }

        /// <summary>
        /// функция активации
        /// </summary>
        /// <param name="x">число</param>
        /// <returns>число</returns>
        public double Fank(double x)
        {
            return 1.0 / (1.0 + Math.Pow(Math.E, -x));
        }

        /// <summary>
        /// активация входного нейрона
        /// </summary>
        /// <param name="input">входное значение</param>
        /// <returns>возвращяет входное значение</returns>
        public double activation(double input)
        {
           return Output  = input;        
        }
    }
}
