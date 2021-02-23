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
        private static Color[] major, minor;
        #endregion

        #region Constructor
        static ColorMap() {
            major = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            minor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        #endregion

        /// <summary>
        /// data type defined to hold the two colors of clor pair
        /// </summary>
        internal class ColorPair
        {
            internal Color majorColor, minorColor;
            public override string ToString() {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }

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
            int majorIndex = -1, minorIndex = -1;
            
            // Find the major color in the array and get the index
            for (int i = 0; i < major.Length; i++) {
                if (major[i] == pair.majorColor) {
                    majorIndex = i; break;
                } }
            
            // Find the minor color in the array and get the index
            for (int i = 0; i < minor.Length; i++) {
                if (minor[i] == pair.minorColor) {
                    minorIndex = i; break;
                } }
            
            // If colors can not be found throw an exception
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * minor.Length) + (minorIndex + 1);
        }
        
        /// <summary>
        /// Print the Color pair with Major and Minor colors and corresponding pair number
        /// </summary>
        public void PrintColorPairManual()
        {
            int pairNumber = 1;
            for (int i = 0; i < major.Length; i++) {
                for(int j = 0; j < minor.Length; j++) {           
                    Console.WriteLine("Pair Number: {0}, Colors: {1}\n", pairNumber, new ColorPair() { majorColor = major[i], minorColor = minor[j] });
                    pairNumber++;
                } }
        }
        #endregion
    }
}
