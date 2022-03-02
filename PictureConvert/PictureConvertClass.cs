using System.Collections.Generic;
using System.Drawing;

namespace PictureConvert
{

    public class PictureConvertClass
    {
        public int Bounder { get; set; } = 128;

        public int Widht { get; set; }
        public int Height { get; set; }
        public double[] Convert(string path)
        {
            List<double> result = new List<double>();
            Bitmap image = new Bitmap(path);
            var resizeimage = new Bitmap(image, new Size(50, 50));

            for (int y = 0; y < resizeimage.Height; y++)
            {
                for (int x = 0; x < resizeimage.Width; x++)
                {


                    Color pixel = resizeimage.GetPixel(x, y);
                    double value = Brightness(pixel);
                    result.Add(value);
                }
            }
            return result.ToArray();
        }

        public Bitmap Convert(Bitmap bitmap)
        {
            List<double> result = new List<double>();
            var resizeimage = new Bitmap(bitmap, new Size(50, 50));
            Height = resizeimage.Height;
            Widht = resizeimage.Width;

            for (int x = 0; x < resizeimage.Width; x++)
            {
                for (int y = 0; y < resizeimage.Height; y++)
                {
                    Color pixel = resizeimage.GetPixel(x, y);
                    double value = Brightness(pixel);
                    result.Add(value);
                }
            }


            Bitmap image = new Bitmap(resizeimage.Width, resizeimage.Height);
            for (int y = 0; y < image.Width; y++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    Color color = result[y * image.Width + x] == 1 ? Color.White : Color.Black;
                    image.SetPixel(x, y, color);
                }
            }
            return image;
        }

        private double Brightness(Color pixel)
        {
            double result = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
            return result < Bounder ? 0 : 1;
        }

        public void Save(string path,int wight,int height,List<double> pixels)
        {

        }
    }
}
