using System;
using System.Collections.Generic;
using System.Linq;

namespace neural_network
{
    public class Layer : List<Neuron>
    {
        private Random random = new Random();

        public List<Connection> Connection { get; set; }

        public Layer(int cout)
        {
            Connection = new List<Connection>();

            for (int i = 0; i < cout; i++)
            {
                this.Add(new Neuron());

            }
        }


        public List<Connection> Connect(Layer layer)
        {
            Connection.Clear();
            for (int j = 0; j < this.Count; j++)
            {
                for (int k = 0; k < layer.Count; k++)
                {
                    Connection.Add(new Connection(random.NextDouble(), this[j], layer[k]));
                }
            }

            return Connection;
        }
    }
}
