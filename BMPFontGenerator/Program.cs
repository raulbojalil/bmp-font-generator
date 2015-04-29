using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Drawing.Imaging;

namespace BMPFontGenerator
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var fontFamily = "Arial";
                var fontSize = 12;
                var fontStyle = FontStyle.Regular;
                var foreColor = Color.White;
                var backColor = Color.Magenta;
                var charSet = "0123456789AÁBCDEÉFGHIÍJKLMNÑOÓPQRSTUÚVWXYZaábcdeéfghiíjklmnñoópqrstuúvwxyz .,_()-¿?¡!/\\=#$%&:;@";
                var width = 128;
                var height = 128;
                var paddingLeft = 0;
                var paddingRight = 0;
                var png = false;

                var argIndex = 1;
                foreach (var arg in args)
                {
                    if(argIndex!=args.Length)
                    {
                        switch (arg)
                        {
                            case "-fam": fontFamily = args[argIndex]; break;
                            case "-fs": fontSize = Convert.ToInt32(args[argIndex]); break;
                            case "-ft": if(args[argIndex] == "italic") fontStyle = FontStyle.Italic; else if(args[argIndex] == "bold") fontStyle = FontStyle.Bold; break;
                            case "-fc": foreColor = Color.FromArgb(Convert.ToInt32(args[argIndex], 16)); break;
                            case "-bc": backColor = Color.FromArgb(Convert.ToInt32(args[argIndex], 16)); break;
                            case "-cs": charSet = args[argIndex]; break;
                            case "-w": width = Convert.ToInt32(args[argIndex]); break;
                            case "-h": height = Convert.ToInt32(args[argIndex]); break;
                            case "-l": paddingLeft = Convert.ToInt32(args[argIndex]); break;
                            case "-r": paddingRight = Convert.ToInt32(args[argIndex]); break;
                        }
                    }
                    switch (arg)
                    {
                        case "-png": png = true; break;
                    }

                    argIndex++;
                }

                string headerFile = string.Empty;
                string filename = BMPFontGenerator.Main.GetFilename(fontFamily, fontStyle, fontSize, foreColor);

                using (var bmp = BMPFontGenerator.Main.GenerateFontMap(fontFamily, fontSize, fontStyle, foreColor, backColor,
                    png ? TextRenderingHint.AntiAlias : TextRenderingHint.SingleBitPerPixel, charSet, width, height, paddingLeft, paddingRight, false, out headerFile))
                {
                    var imageFilename = filename + (png ? ".png" : ".bmp");
                    Console.WriteLine("Writing " + imageFilename + " ...");
                    bmp.Save(imageFilename, png ? ImageFormat.Png : ImageFormat.Bmp);
                }

                Console.WriteLine("Writing " + filename + ".h ...");
                File.WriteAllText(filename + ".h", string.Format(headerFile, filename));

                Console.WriteLine("Process completed.");

            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
        }
    }
}
