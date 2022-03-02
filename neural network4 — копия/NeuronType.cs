using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network3
{
    public enum NeuronType
    {
        /// <summary>
        /// нейрон стрытого слоя
        /// </summary>
        Normal = 1
            ,
        /// <summary>
        /// входной нейрон
        /// </summary>
        Input = 0
            ,
        /// <summary>
        /// выходной нейрон
        /// </summary>
        Output = 2
    }
}
