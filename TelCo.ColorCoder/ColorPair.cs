using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// This class provides the color coding and mapping of pair number to color and color to pair number.
    /// </summary>
    class ColorMap
    {
        #region Private Variables
        /// <summary>
        /// Array of Major and Minor colors
        /// </summary>
        public Color[] major, minor;
        #endregion

        #region Constructor
        public ColorMap() {
            major = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            minor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns></returns>
        public ColorPair GetColorFromPairNumber(int pairNumber) {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            if (pairNumber < 1 || pairNumber > (minor.Length) * (major.Length))
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            
            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1, majorIndex = zeroBasedPairNumber / minor.Length, minorIndex = zeroBasedPairNumber % minor.Length;
            return new ColorPair() { majorColor = major[majorIndex], minorColor = minor[minorIndex] };
        }
        
        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns></returns>
        public int GetPairNumberFromColor(ColorPair pair) {
            int majorIndex = this.FindMajorColorIndex(pair) , minorIndex = this.FindMinorColorIndex(pair);
                 
            // If colors can not be found throw an exception
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * minor.Length) + (minorIndex + 1);
        }

        /// <summary>
        /// Find the major color in the array and get the index
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        private int FindMajorColorIndex(ColorPair pair)
        {
            int majorIndex = -1;
            for (int i = 0; i < major.Length; i++)
            {
                if (major[i] == pair.majorColor)
                {
                    majorIndex = i; break;
                }
            }
            return majorIndex;
        }

        /// <summary>
        /// Find the minor color in the array and get the index
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        private int FindMinorColorIndex(ColorPair pair)
        {
            int minorIndex = -1;
            for (int i = 0; i < minor.Length; i++)
            {
                if (minor[i] == pair.minorColor)
                {
                    minorIndex = i; break;
                }
            }
            return minorIndex;
        }

        #endregion
    }
}
