using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using neural_network;

namespace NeuronnetworkTest
{
    [TestClass]
    public class UnitTest1
    {
        DataSet DataSet;
        static Random rand = new Random();

        private void CreateDateSet_1_4()
        {
            DataSet = new DataSet(4, 1);
            DataSet.Add(new double[] { 0 }, new double[] { 0, 0, 0, 0 });
            DataSet.Add(new double[] { 0 }, new double[] { 0, 0, 0, 1 });
            DataSet.Add(new double[] { 1 }, new double[] { 0, 0, 1, 0 });
            DataSet.Add(new double[] { 0 }, new double[] { 0, 0, 1, 1 });
            DataSet.Add(new double[] { 0 }, new double[] { 0, 1, 0, 0 });
            DataSet.Add(new double[] { 0 }, new double[] { 0, 1, 0, 1 });
            DataSet.Add(new double[] { 1 }, new double[] { 0, 1, 1, 0 });
            DataSet.Add(new double[] { 0 }, new double[] { 0, 1, 1, 1 });
            DataSet.Add(new double[] { 1 }, new double[] { 1, 0, 0, 0 });
            DataSet.Add(new double[] { 1 }, new double[] { 1, 0, 0, 1 });
            DataSet.Add(new double[] { 1 }, new double[] { 1, 0, 1, 0 });
            DataSet.Add(new double[] { 1 }, new double[] { 1, 0, 1, 1 });
            DataSet.Add(new double[] { 1 }, new double[] { 1, 1, 0, 0 });
            DataSet.Add(new double[] { 0 }, new double[] { 1, 1, 0, 1 });
            DataSet.Add(new double[] { 1 }, new double[] { 1, 1, 1, 0 });
            DataSet.Add(new double[] { 1 }, new double[] { 1, 1, 1, 1 });
        }

        [TestMethod]
        public void TestMethod1()
        {
            CreateDateSet_1_4();
            int[] item = new int[DataSet.Cout];

            Topolodgi topolodgi = new Topolodgi(DataSet, 0.3, 3,2);
            NeuronNetwork NeuronNetwork = new NeuronNetwork(topolodgi);

            Random rand = new Random();
            double eror = 0.0;

            for (int i = 0; i < item.Length; i++)
            {
                item[i] = i;
            }

            for (int ep = 0; ep < 10000; ep++)
            {

                for (int i = item.Length - 1; i >= 0; i--)
                {
                    int j = rand.Next(i);
                    int tmp = item[i];
                    item[i] = item[j];
                    item[j] = tmp;
                }
                eror = 0.0;
                for (int i = 0; i < item.Length; i++)
                {
                    var it = item[i];
                    eror += NeuronNetwork.Beckpropagation(it);
                }
            }
            var rer = eror;
            for (int i = 0; i < DataSet.Cout; i++)
            {
                var rez = NeuronNetwork.FeedForward(i);
                var raz = Math.Abs(DataSet.Outputs[i][0] - rez[0]);
                Assert.IsTrue(raz < 0.2, "raz=" + raz
                    + " rez=" + rez[0]
                    + " out=" + DataSet.Outputs[i][0]
                    + " eror=" + rer);
            }
        }
    }
}
