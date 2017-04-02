using System;
using System.Diagnostics;

namespace Task2Logic
{
    public class Algorithms
    {
        private delegate int gcdDelegate(int a, int b);

        #region Public methods

        /// <summary>
        /// Classic method of GCD by Euclid
        /// </summary>
        /// <param name="time">Time span</param>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>GCD</returns>
        public static int GreatestCommonDivisorByEuclid(out TimeSpan time, int a, int b)
        {
            var sw = Stopwatch.StartNew();

            int result = ClassicGCD(a, b);

            sw.Stop();
            time = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Classic method of GCD by Euclid without time span
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>GCD</returns>
        public static int GreatestCommonDivisorByEuclid(int a, int b) => ClassicGCD(a, b);

        /// <summary>
        /// Classic method of GCD by Euclid
        /// </summary>
        /// <param name="time">Time span</param>
        /// <param name="values">array of numbers</param>
        /// <returns>GCD</returns>
        public static int GreatestCommonDivisorByEuclid(out TimeSpan time, params int[] values)
        {
            var sw = Stopwatch.StartNew();

            int result = GDCForSeveralValues(ClassicGCD, values);

            sw.Stop();
            time = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Classic method of GCD by Euclid without time span
        /// </summary>
        /// <param name="values">array of numbers</param>
        /// <returns>GCD</returns>
        public static int GreatestCommonDivisorByEuclid(params int[] values) => GDCForSeveralValues(ClassicGCD, values);

        /// <summary>
        /// Binary Euclid's algorithm of GDC by Stein
        /// </summary>
        /// <param name="time">Time span</param>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>GDc</returns>
        public static int BinaryGreatestCommonDivision(out TimeSpan time, int a, int b)
        {
            var sw = Stopwatch.StartNew();

            int result = BinaryGCD(a, b);

            sw.Stop();
            time = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Binary Euclid's algorithm of GDC by Stein without time span
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>GCD</returns>
        public static int BinaryGreatestCommonDivision(int a, int b) => BinaryGCD(a, b);

        /// <summary>
        /// Binary Euclid's algorithm of GDC by Stein
        /// </summary>
        /// <param name="time">Time span</param>
        /// <param name="values">array of numbers</param>
        /// <returns>GDc</returns>
        public static int BinaryGreatestCommonDivision(out TimeSpan time, params int[] values)
        {
            var sw = Stopwatch.StartNew();

            int result = GDCForSeveralValues(BinaryGCD, values);

            sw.Stop();
            time = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Binary Euclid's algorithm of GDC by Stein without time span
        /// </summary>
        /// <param name="values">array of numbers</param>
        /// <returns>GDc</returns>
        public static int BinaryGreatestCommonDivision(params int[] values) => GDCForSeveralValues(BinaryGCD, values);

        #endregion

        #region Private methods

        /// <summary>
        /// Classic method of GCD by Euclid
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>GCD</returns>
        private static int ClassicGCD(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            return ClassicGCD(b, a % b);
        }

        /// <summary>
        /// Classic method of GCD by Euclid
        /// </summary>
        /// <param name="gdc">A delegate that defines the form of the algorithm</param>
        /// <param name="values">array of numbers</param>
        /// <returns>GCD</returns>
        private static int GDCForSeveralValues(gcdDelegate gdc, params int[] values)
        {
            if (values == null)
                throw new ArgumentNullException();
            if (values.Length < 3)
                throw new ArgumentException("Less than 3 values");

            int temp = gdc(values[0], values[1]);

            for (int i = 2; i < values.Length; i++)
            {
                if (temp == 1)
                    return 1;
                temp = gdc(temp, values[i]);
            }
            return temp;
        }

        /// <summary>
        /// Binary greatest common divisor
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>GCD</returns>
        private static int BinaryGCD(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * BinaryGCD(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return BinaryGCD(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return BinaryGCD(a, b / 2);
            return BinaryGCD(b, (int)Math.Abs(a - b));
        }

        #endregion
    }
}
