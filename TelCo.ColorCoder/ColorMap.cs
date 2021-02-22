using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// This class provides the color coding and mapping of pair number to color and color to pair number.
    /// </summary>
    class ColorMapping
    {
        #region Private Variables
        private static Color[] colorMapMajor, colorMapMinor;
        #endregion

        #region Constructor
        static ColorMapping()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        #endregion

        #region DataType to hold major and minor colors in the color pair
        internal class ColorPair
        {
            internal Color majorColor, minorColor;
            public override string ToString()
            {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }
        #endregion

        #region Methods
        public ColorPair GetColorFromPairNumber(int pairNumber)
        {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            if (pairNumber < 1 || pairNumber > (colorMapMinor.Length) * (colorMapMajor.Length))
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
    
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / colorMapMinor.Length;
            int minorIndex = zeroBasedPairNumber % colorMapMinor.Length;
            return new ColorPair() { majorColor = colorMapMajor[majorIndex], minorColor = colorMapMinor[minorIndex] };
        }
        
        public int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = -1, minorIndex = -1;
            for (int i = 0; i < colorMapMajor.Length; i++)
            {
                if (colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i; break;
                }
            }
            for (int i = 0; i < colorMapMinor.Length; i++)
            {
                if (colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i; break;
                }
            }
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }
        
        public void PrintColorPairManual()
        {
            int pairNumber = 1;
            for (int i = 0; i < colorMapMajor.Length; i++)
            {
                for(int j = 0; j < colorMapMinor.Length; j++)
                {           
                    Console.WriteLine("Pair Number: {0}, Colors: {1}\n", pairNumber, new ColorPair() { majorColor = colorMapMajor[i], minorColor = colorMapMinor[j] });
                    pairNumber++;
                }
            }
        }
        #endregion
    }
}
