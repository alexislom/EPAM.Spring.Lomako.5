using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    /// <summary>
    /// Class which contain Neuton method of calculating the nth root
    /// </summary>
    public static class Algorithm
    {
        #region public methods
        /// <summary>
        /// Neuton method of calculating the nth root
        /// </summary>
        /// <param name="value">The number from which the root is extracted</param>
        /// <param name="power">Degree of extracted root</param>
        /// <param name="epsilon">accuracy</param>
        /// <returns>The value of the root nth degree</returns>
        public static double NeutonMethod(uint value, uint power, double epsilon = 1e-05)
        {
            if (value == 0)
                return 0;
            if (power == 0)
                return value;
            if (epsilon < 0 || epsilon >= 1)
                throw new ArgumentException();

            return NeutonNthRoot(value, power, epsilon);
        }
        #endregion

        #region private methods 
        /// <summary>
        /// Intermediate method of calculating the nth root
        /// </summary>
        /// <param name="value"></param>
        /// <param name="power"></param>
        /// <param name="epsilon"></param>
        /// <returns>The value of the root nth degree</returns>
        private static double NeutonNthRoot(uint value, uint power, double epsilon = 1e-05)
        {
            double xNext = value / power;
            double xPrev = 0;
            double df = 0;

            while (true)
            {
                df = -(Math.Pow(xNext, power) - value) / (power * Math.Pow(xNext, power - 1));
                if (Math.Abs(xNext - xPrev) < epsilon) break;
                xPrev = xNext;
                xNext = xNext + df;
            }
            return xNext;
        }

        #endregion
    }
}
