using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Logic;

namespace Task1Tests
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        public void NeutonMethod_125Root3_5Res()
        {
            uint number = 125;
            uint power = 3;
            double eps = 1e-05;
            double expected = 5;

            double actual = Algorithm.NeutonMethod(number, power, eps);

            Assert.AreEqual(expected, actual, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EpsIsNegativeTest()
        {
            uint number = 125;
            uint power = 3;
            double eps = 5;
            double expected = 5;

            double actual = Algorithm.NeutonMethod(number, power, eps);

            Assert.AreEqual(expected, actual, eps);
        }
    }
}
