using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2NUnitTests
{
    [TestFixture]
    public class AlgorithmsNUnitTests
    {
        [Test]
        public void Euclid_Test()
        {
            int first = 585;
            int second = 81;
            int expected = 9;

            int gcd = Algorithms.GreatestCommonDivisorByEuclid(first, second);

            Assert.AreEqual(expected, gcd);

        }

        [Test]
        public void Bin_Test()
        {
            int first = 585;
            int second = 81;
            int expected = 9;

            int gcd = Algorithms.BinaryGreatestCommonDivision(first, second);

            Assert.AreEqual(expected, gcd);
        }

        [Test]
        public void MoreArgs_EuclidTest()
        {
            int first = 585;
            int second = 81;
            int third = 9;
            int fourth = 3;
            int more = 12;
            int expected = 3;

            int gcd = Algorithms.GreatestCommonDivisorByEuclid(first, second, third, fourth, more);

            Assert.AreEqual(expected, gcd);
        }

        [Test]
        public void MoreArgs_BinTest()
        {
            int first = 585;
            int second = 81;
            int third = 9;
            int fourth = 3;
            int more = 12;
            int expected = 3;

            int gcd = Algorithms.BinaryGreatestCommonDivision(first, second, third, fourth, more);

            Assert.AreEqual(expected, gcd);
        }

        [Test]
        public void NegativeArg_EuclidTest()
        {
            int first = -585;
            int second = 81;
            int third = -9;
            int fourth = 3;
            int more = 12;
            int expected = 3;

            int gcd = Algorithms.GreatestCommonDivisorByEuclid(first, second, third, fourth, more);

            Assert.AreEqual(expected, gcd);
        }

        [Test]
        public void NegativeArgs_BinTest()
        {
            int first = -585;
            int second = 81;
            int third = -9;
            int fourth = 3;
            int more = 12;
            int expected = 3;

            int gcd = Algorithms.BinaryGreatestCommonDivision(first, second, third, fourth, more);

            Assert.AreEqual(expected, gcd);
        }
    }
}
