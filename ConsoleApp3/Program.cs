using System;
using System.Collections.Generic;
using System.IO;
using neural_network;
using PictureConvert;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 1000;
            var parasitizedPath = @"C:\Users\zop85\Desktop\cell_images\Parasitized\";
            var unparasitizedPath = @"C:\Users\zop85\Desktop\cell_images\Uninfected\";

            var connertor = new PictureConvertClass();
            var testImage = connertor.Convert(@"C:\Users\zop85\Desktop\cell_images\Parasitized\C33P1thinF_IMG_20150619_114756a_cell_181.png");

            var tonologi = new Topolodgi(testImage.Length, 1, 0.1, testImage.Length/ 2);
            var neyronNetwork = new NeuronNetwork(tonologi);


            double[,] parasitizedInput = GetData(parasitizedPath, connertor, testImage,size);
            neyronNetwork.Learn( new double[] { 1 }, parasitizedInput, 1);

            double[,] unparasitizedInput = GetData(unparasitizedPath, connertor, testImage,size);
            neyronNetwork.Learn(new double[] { 0 }, unparasitizedInput, 1);

            var par=neyronNetwork.Predict(connertor.Convert(@"C:\Users\zop85\Desktop\cell_images\Parasitized\C33P1thinF_IMG_20150619_114756a_cell_181.png"));
            var unpar=neyronNetwork.Predict(connertor.Convert(@"C:\Users\zop85\Desktop\cell_images\Uninfected\C1_thinF_IMG_20150604_104722_cell_73.png"));

            Console.WriteLine(1 + "\t" + par);
            Console.WriteLine(0 + "\t" + unpar);
        }

        private static double[,] GetData(string parasitizedPath, PictureConvertClass connertor, double[] testImage,int size)
        {
            var images = Directory.GetFiles(parasitizedPath);

            var result = new double[size, testImage.Length];
            for (int i = 0; i < size; i++)
            {
                var image = connertor.Convert(images[i]);
                for (int j = 0; j < image.Length; j++)
                {
                    result[i, j] = image[j];
                }
            }

            return result;
        }
    }
}
