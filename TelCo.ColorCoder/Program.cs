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

            ColorMap map = new ColorMap();

            int pairNumber = 4;
            ColorPair testPair1 = map.GetColorFromPairNumber(pairNumber);
            DisplayResultOfGetColorFromPairNumber(pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = map.GetColorFromPairNumber(pairNumber);
            DisplayResultOfGetColorFromPairNumber(pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = map.GetColorFromPairNumber(pairNumber);
            DisplayResultOfGetColorFromPairNumber(pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.Violet);
            Debug.Assert(testPair1.minorColor == Color.Green);

            ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pairNumber = map.GetPairNumberFromColor(testPair2);
            DisplayResultOfGetPairNumberFromColor(pairNumber, testPair2);
            Debug.Assert(pairNumber == 18);

            testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            pairNumber = map.GetPairNumberFromColor(testPair2);
            DisplayResultOfGetPairNumberFromColor(pairNumber, testPair2);
            Debug.Assert(pairNumber == 6);

            ColorPair pairs = new ColorPair();
            Console.WriteLine("TELECOMMUNICATION COLOR CODE MANUAL");
            pairs.PrintColorPairManual();
        }

        private static void DisplayResultOfGetColorFromPairNumber(int pairNumber, ColorPair testPair)
        {
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair);
        }

        private static void DisplayResultOfGetPairNumberFromColor(int pairNumber, ColorPair testPair)
        {
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair, pairNumber);
        }
    }
}
