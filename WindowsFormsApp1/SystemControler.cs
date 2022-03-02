using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using neural_network;

namespace WindowsFormsApp1
{
    class SystemControler
    {
        public NeuronNetwork DataNetwork { get; }
        public NeuronNetwork ImageNetwork { get; }

        public SystemControler()
        {
            var dateTopologi = new Topolodgi(14, 1, 0.1, 7);
            DataNetwork = new NeuronNetwork(dateTopologi);
            var imageTopolodgi = new Topolodgi(400, 1, 0.1, 200);
            ImageNetwork = new NeuronNetwork(imageTopolodgi);
        }
    }
}
