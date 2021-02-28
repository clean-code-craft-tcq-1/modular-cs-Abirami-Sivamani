using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// data type defined to hold the two colors of clor pair
    /// </summary>
    internal class ColorPair : ColorMap
    {
        internal Color majorColor, minorColor;
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
        }
        /// <summary>
        /// Print the Color pair with Major and Minor colors and corresponding pair number
        /// </summary>
        public void PrintColorPairManual()
        {
            int pairNumber = 1;
            for (int i = 0; i < major.Length; i++)
            {
                for (int j = 0; j < minor.Length; j++)
                {
                    Console.WriteLine("Pair Number: {0}, Colors: {1}\n", pairNumber, new ColorPair() { majorColor = major[i], minorColor = minor[j] });
                    pairNumber++;
                }
            }
        }
    }
    }
