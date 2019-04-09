using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;

namespace gifExtract
{
    class Program
    {
        private static int GetFrames(string pGifFile, string pSavedPath)
        {
            Image gif = Image.FromFile(pGifFile);
            FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);
            int count = gif.GetFrameCount(fd);
            for (int i = 0; i < count; i++)
            {
                gif.SelectActiveFrame(fd, i);
                gif.Save(pSavedPath + "\\gifFrame_" + i + ".jpg", ImageFormat.Jpeg);
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("----- gifExtract -----");
            Console.WriteLine("v0.1.0.0 2019/04/09");
            Console.WriteLine("Copyright © 2019 KondeU. All rights reserved.");

            if (args.Length != 2)
            {
                Console.WriteLine("gifExtract requires 2 arguments!");
                Console.WriteLine("gifExtract.exe <gifFileName> <jpgSavePath>");
                return;
            }

            Console.WriteLine("gifFileName: " + args[0]);
            Console.WriteLine("jpgSavePath: " + args[1]);

            int genCount = GetFrames(args[0], args[1]);
            Console.WriteLine("Generated total frames count: " + genCount);
        }
    }
}
