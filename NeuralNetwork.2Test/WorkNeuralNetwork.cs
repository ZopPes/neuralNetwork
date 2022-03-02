using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using neural_network3;
using Newtonsoft.Json;

namespace NeuralNetwork._3Test
{
    

    [TestClass]
    public class WorkNeuralNetwork
    {
        string path = @"C:\Users\zop85\Source\Repos\neural network\NeuralNetwork.2Test\weight.json";
        Random random = new Random();
        DataSet DataSet = new DataSet(1, 4);
        int epoh = 500000;
        int[] znacki = new int[] { 0, 0 };

        double coeferror = 2.1;

        [TestMethod]
        public void DataSetTest()
        {
            var DataSet = new Tuple<double, double[]>[]
            {
                new Tuple<double,double[]>(0,new double[]{0,0,0,0 })
                ,
                new Tuple<double,double[]>(0,new double[]{0,0,0,1 })
                ,
                new Tuple<double,double[]>(1,new double[]{0,0,1,0 })
                ,
                new Tuple<double,double[]>(0,new double[]{0,0,1,1 })
                ,
                new Tuple<double,double[]>(0,new double[]{0,1,0,0 })
                ,
                new Tuple<double,double[]>(0,new double[]{0,1,0,1 })
                ,
                new Tuple<double,double[]>(1,new double[]{0,1,1,0 })
                ,
                new Tuple<double,double[]>(0,new double[]{0,1,1,1 })
                ,
                new Tuple<double,double[]>(1,new double[]{1,0,0,0 })
                ,
                new Tuple<double,double[]>(1,new double[]{1,0,0,1 })
                ,
                new Tuple<double,double[]>(1,new double[]{1,0,1,0 })
                ,
                new Tuple<double,double[]>(1,new double[]{1,0,1,1 })
                ,
                new Tuple<double,double[]>(1,new double[]{1,1,0,0 })
                ,
                new Tuple<double,double[]>(0,new double[]{1,1,0,1 })
                ,
                new Tuple<double,double[]>(1,new double[]{1,1,1,0 })
                ,
                new Tuple<double,double[]>(1,new double[]{1,1,1,1 })

            };

            var topologi = new Topolodgi(4, 1,0.1, 2);
            var neuronNetworc = new NeuronNetwork(topologi);
            var eror = 0.0;
            for (int i = 0; i < epoh; i++)
            {
                var zn = random.Next(0, DataSet.Length);
                eror += neuronNetworc.Beckpropagation(new double[] { DataSet[zn].Item1 }, DataSet[zn].Item2);
            }
            Assert.IsTrue((eror /= epoh)< coeferror, "слишком большой коофицент ошибок: "+eror);

            for (int i = 0; i < DataSet.Length; i++)
            {
                var rez = neuronNetworc.FeedForward(DataSet[i].Item2)[0];
                var axp = Math.Round(DataSet[i].Item1, znacki[0]);
                var act = Math.Round(rez, znacki[1]);
                Assert.AreEqual(axp, act, "коэфицент ошибки "
                    + eror);
                
            }
        }


        [TestMethod]
        public void DataSetClassTest()
        {
            CreateDataSet();

            var topologi = new Topolodgi(4, 1, 0.1, 2);
            var neuronNetworc = new NeuronNetwork(topologi);
            neuronNetworc.DataSet = DataSet;
            var eror = 0.0;
            for (int i = 0; i < epoh; i++)
            {
                var zn = random.Next(0, DataSet.Cout);
                eror += neuronNetworc.Beckpropagation(zn);
            }
            Assert.IsTrue((eror /= epoh) < coeferror, "слишком большой коофицент ошибок: " + eror);

            for (int i = 0; i < DataSet.Cout; i++)
            {
                var rez = neuronNetworc.FeedForward(DataSet.Inputs[i])[0];
                var axp = Math.Round(DataSet.Outputs[i][0], znacki[0]);
                var act = Math.Round(rez, znacki[1]);
                Assert.AreEqual(axp, act, "коэфицент ошибки "
                    + eror);
            }
        }

        private void CreateDataSet()
        {
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
        public void AutoBeckpropagationTest()
        {
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

            var topologi = new Topolodgi(4, 1, 0.1, 2);
            var neuronNetworc = new NeuronNetwork(topologi);
            neuronNetworc.DataSet = DataSet;
            var eror = neuronNetworc.AutoBeckpropagation(epoh);
           
            Assert.IsTrue((eror) < coeferror, "слишком большой коофицент ошибок: " + eror);

            for (int i = 0; i < DataSet.Cout; i++)
            {
                var rez = neuronNetworc.FeedForward(DataSet.Inputs[i])[0];
                var axp = Math.Round(DataSet.Outputs[i][0], znacki[0]);
                var act = Math.Round(rez, znacki[1]);
                Assert.AreEqual(axp, act, "коэфицент ошибки "
                    + eror);
            }
        }

        [TestMethod]
        public void NeuronNetworkWeightTest()
        {

            var wes = new List<List<double>>()
            {
                new List<double>()
                {
                    random.NextDouble()
                    ,
                    random.NextDouble()
                    ,
                    random.NextDouble()
                    ,
                    random.NextDouble()
                    ,
                    random.NextDouble()
                    ,
                    random.NextDouble()
                    ,
                    random.NextDouble()
                    ,
                    random.NextDouble()
                }
                ,
                new List<double>()
                {
                    random.NextDouble()
                    ,
                    random.NextDouble()
                }
            };

            var topologi = new Topolodgi(4, 1, 0.1, 2);
            var neuronNetworc = new NeuronNetwork(topologi,wes);
            var srt = JsonConvert.SerializeObject(neuronNetworc.Connections.Select(b=>b.Select(a=>a.Weight)));
            var rez = JsonConvert.DeserializeObject<List<List<double>>>(srt);
            for (int i = 0; i < wes.Count; i++)
            {
                for (int g = 0; g < wes[i].Count; g++)
                {
                    Assert.AreEqual(wes[i][g], rez[i][g]);
                }
            }
        }

        [TestMethod]
        public void NeuronNetworkSaveTest()
        {
            var topologi = new Topolodgi(4, 1, 0.1, 2);
            var neuronNetworc = new NeuronNetwork(topologi);
            neuronNetworc.Save();
            neuronNetworc.Save(path);
            Assert.IsTrue(File.Exists(@"C:\Users\zop85\Source\Repos\neural network\NeuralNetwork.2Test\bin\Debug\NeuronNetwork4_1_2.json"));
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void NeuronNetworkReadTest()
        {
            CreateDataSet();

            var topologi = new Topolodgi(4, 1, 0.1, 2);
            var neuronNetworc = new NeuronNetwork(topologi);
            neuronNetworc.DataSet = DataSet;
            var eror= neuronNetworc.AutoBeckpropagation(epoh);
            neuronNetworc.Save(path);
            neuronNetworc.Read(path);

            Assert.IsTrue((eror) < coeferror, "слишком большой коофицент ошибок: " + eror);

            for (int i = 0; i < DataSet.Cout; i++)
            {
                var rez = neuronNetworc.FeedForward(DataSet.Inputs[i])[0];
                var axp = Math.Round(DataSet.Outputs[i][0], znacki[0]);
                var act = Math.Round(rez, znacki[1]);
                Assert.AreEqual(axp, act, "коэфицент ошибки "
                    + eror);
            }

            eror = neuronNetworc.AutoBeckpropagation(epoh);

            Assert.IsTrue((eror) < coeferror, "слишком большой коофицент ошибок: " + eror);

            for (int i = 0; i < DataSet.Cout; i++)
            {
                var rez = neuronNetworc.FeedForward(DataSet.Inputs[i])[0];
                var axp = Math.Round(DataSet.Outputs[i][0], znacki[0]);
                var act = Math.Round(rez, znacki[1]);
                Assert.AreEqual(axp, act, "коэфицент ошибки "
                    + eror);
            }

            neuronNetworc.Save();
            neuronNetworc.Read();

            

        }

        [TestMethod]
        public void MyTestMethod()
        {
            var dataSet = new DataSet(2, 2);
            dataSet.Add(new double[] { 1, 1 }, new double[] { 0, 0 });
            dataSet.Add(new double[] { 1, 0 }, new double[] { 0, 1 });
            dataSet.Add(new double[] { 0, 1 }, new double[] { 1, 0 });
            dataSet.Add(new double[] { 0, 0 }, new double[] { 1, 1 });
            var top = new Topolodgi(dataSet, 0.3, 2);
            var network = new NeuronNetwork(top);
            var error = network.AutoBeckpropagation(1000000);
            TestFeedForward(network);
        }

        [TestMethod]
        public void outputNeuronsTest()
        {
            var DataSet = new DataSet(9, 3);

            DataSet.Add(new double[] { 1, 0, 0 }, new double[] { 1, 1, 1, 0, 0, 0, 0, 0, 0 });
            DataSet.Add(new double[] { 1, 0, 1 }, new double[] { 0, 0, 0, 1, 1, 1, 0, 0, 0 });
            DataSet.Add(new double[] { 1, 0, 0 }, new double[] { 0, 0, 0, 0, 0, 0, 1, 1, 1 });
            DataSet.Add(new double[] { 0, 1, 0 }, new double[] { 1, 0, 0, 1, 0, 0, 1, 0, 0 });
            DataSet.Add(new double[] { 0, 1, 1 }, new double[] { 0, 1, 0, 0, 1, 0, 0, 1, 0 });
            DataSet.Add(new double[] { 0, 1, 0 }, new double[] { 0, 0, 1, 0, 0, 1, 0, 0, 1 });
            DataSet.Add(new double[] { 1, 1, 0 }, new double[] { 1, 1, 1, 1, 0, 0, 1, 0, 0 });
            DataSet.Add(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1, 0, 1, 0, 0, 1, 0 });
            DataSet.Add(new double[] { 1, 1, 0 }, new double[] { 1, 1, 1, 0, 0, 1, 0, 0, 1 });
            DataSet.Add(new double[] { 1, 1, 1 }, new double[] { 1, 0, 0, 1, 1, 1, 1, 0, 0 });
            DataSet.Add(new double[] { 1, 1, 1 }, new double[] { 0, 1, 0, 1, 1, 1, 0, 1, 0 });
            DataSet.Add(new double[] { 1, 1, 1 }, new double[] { 0, 0, 1, 1, 1, 1, 0, 0, 1 });
            DataSet.Add(new double[] { 1, 1, 0 }, new double[] { 1, 0, 0, 1, 0, 0, 1, 1, 1 });
            DataSet.Add(new double[] { 0, 0, 0 }, new double[] { 0, 1, 0, 0, 1, 0, 1, 1, 1 });
            DataSet.Add(new double[] { 1, 0, 0 }, new double[] { 0, 0, 1, 0, 0, 1, 1, 1, 1 });
            DataSet.Add(new double[] { 0, 1, 0 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            var topologi = new Topolodgi(DataSet, 0.3, 5, 3);
            var neuronNetworc = new NeuronNetwork(topologi);
            var eror = neuronNetworc.AutoBeckpropagation(epoh)/3;

            Assert.IsTrue((eror) < coeferror, "слишком большой коофицент ошибок: " + eror);
            TestFeedForward(neuronNetworc);
        }

        private void TestFeedForward(NeuronNetwork neuronNetworc)
        {
            for (int i = 0; i < neuronNetworc.DataSet.Cout; i++)
            {
                var rez = neuronNetworc.FeedForward(neuronNetworc.DataSet.Inputs[i]);
                var axp = neuronNetworc.DataSet.Outputs[i];
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(axp[j], Math.Round(rez[j], znacki[1]), " i= " + i + " j= " + j);
                }

            }
        }
    }
}
