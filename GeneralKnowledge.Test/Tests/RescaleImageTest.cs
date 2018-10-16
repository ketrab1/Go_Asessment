using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO:
            // Grab an image from a public URL and write a function thats rescale the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)
            Bitmap image;
            image = LoadPicture();


            var rescaled1 = Rescale(image, 100, 80);
            var rescaled2 = Rescale(image, 1200, 1600);

            rescaled1.Save(@"C:\my\img.bmp");
            rescaled2.Save(@"C:\my\img1.bmp");
        }

        private Bitmap Rescale(Bitmap bitmap, float newHeight, float newWidth)
        {
            var scaleHeight = newHeight / bitmap.Height;
            var scaleWidth = newWidth / bitmap.Width;
            var scale = Math.Min(scaleHeight, scaleWidth);

            return new Bitmap(bitmap, (int) (bitmap.Width * scale), (int) (bitmap.Height * scale));
        }


        private Bitmap LoadPicture()
        {
            using (WebClient webClient = new WebClient())
            {
                using (var stream =
                    webClient.OpenRead("https://www.rencontres-arles.com/files/media_file_2106.jpg")
                )
                {
                    if (stream != Stream.Null)
                        return new Bitmap(stream);
                    throw new Exception("Error when loading the file ");
                }
            }
        }
    }
}