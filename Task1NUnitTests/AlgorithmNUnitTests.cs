using NUnit.Framework;
using System;
using System.Collections.Generic;

using Task1Logic;

namespace Task1NUnitTests
{
    [TestFixture]
    public class AlgorithmNUnitTests
    {
        public IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(9, 2, double.Epsilon).Returns(3);
                yield return new TestCaseData(-9, 2, double.Epsilon).Returns(double.NaN);
                yield return new TestCaseData(8, -3, double.Epsilon).Returns(Math.Pow(8, 1.0 / (-3)));
                yield return new TestCaseData(-8, 3, double.Epsilon).Returns(double.NaN);
                yield return new TestCaseData(10, 1, double.Epsilon).Returns(10);
                yield return new TestCaseData(2, 0, double.Epsilon).Returns(double.PositiveInfinity);
                yield return new TestCaseData(-2, 0, double.Epsilon).Returns(double.PositiveInfinity);
                yield return new TestCaseData(0, 2, double.Epsilon).Returns(0);
                yield return new TestCaseData(-2, 2, double.Epsilon).Returns(double.NaN);

            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public static double Root_Test(double number, int power, double epsilon)
        {
            return Algorithm.Root(number, power, epsilon);
        }
    }
}
