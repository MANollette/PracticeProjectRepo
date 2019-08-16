using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Drawing.Imaging;


namespace PracticeProjectLibrary
{
    class ImageModMethods
    {
        static void ConvertToASCII(string filePath)
        {
            //Initialize directory, image, and instance of program
            string directory = Path.Combine(Directory.GetCurrentDirectory() + filePath);
            System.Drawing.Image img = System.Drawing.Image.FromFile(directory);

            //Modify image size for legibility
            img = ResizeImage(img, (int)(img.Width * .2), (int)(img.Height * .2));

            //Create text file as destination for ascii art
            File.Create(Path.Combine(Directory.GetCurrentDirectory() + "/asciiFile.txt")).Dispose();

            //Initialize streamwriter
            using (StreamWriter sw = File.AppendText(Path.Combine(Directory.GetCurrentDirectory() + "/asciiFile.txt")))
            {
                //Set up and fill out matrix for pixel data
                Color[][] imgMatrix = getImgColorMatrix(img);
                for (int i = 0; i < imgMatrix.Length; i++)
                {
                    for (int j = 0; j < imgMatrix[i].Length; j++)
                    {

                        Color c = imgMatrix[i][j];
                        double average = ((c.R + c.B + c.G) / 3);
                        #region asciiCharacterSwitch

                        if (average < 123)
                        {
                            if (average < 4)
                                sw.Write("$$$");
                            else if (average < 8)
                                sw.Write("@@@");
                            else if (average < 16)
                                sw.Write("%%%");
                            else if (average < 20)
                                sw.Write("888");
                            else if (average < 28)
                                sw.Write("WWW");
                            else if (average < 32)
                                sw.Write("MMM");
                            else if (average < 36)
                                sw.Write("###");
                            else if (average < 44)
                                sw.Write("ooo");
                            else if (average < 52)
                                sw.Write("hhh");
                            else if (average < 56)
                                sw.Write("kkk");
                            else if (average < 64)
                                sw.Write("ddd");
                            else if (average < 68)
                                sw.Write("ppp");
                            else if (average < 72)
                                sw.Write("qqq");
                            else if (average < 76)
                                sw.Write("www");
                            else if (average < 84)
                                sw.Write("ZZZ");
                            else if (average < 88)
                                sw.Write("OOO");
                            else if (average < 96)
                                sw.Write("QQQ");
                            else if (average < 100)
                                sw.Write("LLL");
                            else if (average < 104)
                                sw.Write("CCC");
                            else if (average < 108)
                                sw.Write("JJJ");
                            else if (average < 116)
                                sw.Write("YYY");
                            else if (average < 120)
                                sw.Write("XXX");
                            else if (average < 124)
                                sw.Write("zzz");
                        }
                        else if (average > 122)
                        {
                            if (average < 124)
                                sw.Write("zzz");
                            else if (average < 132)
                                sw.Write("vvv");
                            else if (average < 136)
                                sw.Write("uuu");
                            else if (average < 144)
                                sw.Write("xxx");
                            else if (average < 148)
                                sw.Write("rrr");
                            else if (average < 152)
                                sw.Write("jjj");
                            else if (average < 156)
                                sw.Write("fff");
                            else if (average < 164)
                                sw.Write("///");
                            else if (average < 168)
                                sw.Write("\\\\\\");
                            else if (average < 172)
                                sw.Write("|||");
                            else if (average < 176)
                                sw.Write("(((");
                            else if (average < 184)
                                sw.Write("111");
                            else if (average < 188)
                                sw.Write("{{{");
                            else if (average < 192)
                                sw.Write("}}}");
                            else if (average < 196)
                                sw.Write("[[[");
                            else if (average < 204)
                                sw.Write("???");
                            else if (average < 208)
                                sw.Write("---");
                            else if (average < 212)
                                sw.Write("___");
                            else if (average < 216)
                                sw.Write("+++");
                            else if (average < 220)
                                sw.Write("~~~");
                            else if (average < 224)
                                sw.Write("iii");
                            else if (average < 228)
                                sw.Write("!!!");
                            else if (average < 232)
                                sw.Write("l");
                            else if (average < 236)
                                sw.Write("III");
                            else if (average < 240)
                                sw.Write(";;;");
                            else if (average < 244)
                                sw.Write(":::");
                            else if (average < 248)
                                sw.Write(",,,");
                            else if (average < 252)
                                sw.Write("\"\"\"");
                            else if (average < 256)
                                sw.Write("```");
                        }
                        #endregion

                        if (j == imgMatrix[i].Length - 1)
                            sw.WriteLine("");

                    }
                }
            }
        }

        //Method for resizing image
        static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;


                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        //Method for retrieving pixel data
        static Color[][] getImgColorMatrix(System.Drawing.Image img)
        {
            Bitmap bmp = new Bitmap(img);
            Color[][] matrix;
            int height = bmp.Height;
            int width = bmp.Width;
            if (height > width)
            {
                matrix = new Color[bmp.Width][];
                for (int i = 0; i <= bmp.Width - 1; i++)
                {
                    matrix[i] = new Color[bmp.Height];
                    for (int j = 0; j < bmp.Height - 1; j++)
                    {
                        matrix[i][j] = bmp.GetPixel(i, j);
                    }
                }
            }
            else
            {
                matrix = new Color[bmp.Height][];
                for (int i = 0; i <= bmp.Height - 1; i++)
                {
                    matrix[i] = new Color[bmp.Width];
                    for (int j = 0; j < bmp.Width - 1; j++)
                    {
                        matrix[i][j] = bmp.GetPixel(j, i);
                    }
                }
            }
            return matrix;
        }
    }
}
