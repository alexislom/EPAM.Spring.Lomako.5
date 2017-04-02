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
            double number = 125;
            int power = 3;

            double expected = 5;

            double actual = Algorithm.Root(number, power, double.Epsilon);

            Assert.AreEqual(expected, actual, double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongEpsilon_Test()
        {
            double number = 125;
            int power = 3;
            
            double expected = 5;

            double actual = Algorithm.Root(number, power, double.Epsilon + 5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Root_NegativeNumber_NaNRes_Test()
        {
            double expected = Math.Pow(-8, 1.0 / 3);

            double actual = Algorithm.Root(-8, 3, double.Epsilon);

            Assert.AreEqual(expected, actual);
        }
    }
}
