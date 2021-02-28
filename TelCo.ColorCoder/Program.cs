using System;
using System.Diagnostics;
using System.Drawing;
using static TelCo.ColorCoder.ColorMap;

namespace TelCo.ColorCoder
{
    class Program
    {
        /// <summary>
        /// Test code for the color mapping class
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int pairNumber = 4;
            ColorPair testPair1 = CallAndPrintResultOfGetColorFromPairNumber(pairNumber);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = CallAndPrintResultOfGetColorFromPairNumber(pairNumber);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = CallAndPrintResultOfGetColorFromPairNumber(pairNumber);
            Debug.Assert(testPair1.majorColor == Color.Violet);
            Debug.Assert(testPair1.minorColor == Color.Green);

            ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pairNumber = CallAndPrintResultOfGetPairNumberFromColor(testPair2);
            Debug.Assert(pairNumber == 18);

            testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            pairNumber = CallAndPrintResultOfGetPairNumberFromColor(testPair2);
            Debug.Assert(pairNumber == 6);

            ColorPair pairs = new ColorPair();
            Console.WriteLine("TELECOMMUNICATION COLOR CODE MANUAL");
            pairs.PrintColorPairManual();
        }

        /// <summary>
        /// Call and display the result of GetColorFromPairNumber
        /// </summary>
        private static ColorPair CallAndPrintResultOfGetColorFromPairNumber(int pairNumber)
        {
            ColorPair testPair1 = new ColorMap().GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            return testPair1;
        }

        /// <summary>
        /// Call and display the result of GetPairNumberFromColor
        /// </summary>
        private static int CallAndPrintResultOfGetPairNumberFromColor(ColorPair testPair)
        {
            int pairNumber = new ColorMap().GetPairNumberFromColor(testPair);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair, pairNumber);
            return pairNumber;
        }
    }
}
