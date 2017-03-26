using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1NUnitTests
{
    [TestFixture]
    public class AlgorithmNUnitTests
    {
        [Test]
        public void NeutonMethod_125Root3_5Res()
        {
            uint number = 16;
            uint power = 2;
            double eps = 1e-05;
            double expected = 4;

            double actual = Algorithm.NeutonMethod(number, power, eps);

            Assert.AreEqual(expected, actual, eps);
        }

        [Test]
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
