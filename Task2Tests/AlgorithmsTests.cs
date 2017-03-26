using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2Logic;

namespace Task2Tests
{
    [TestClass]
    public class AlgorithmsTests
    {
        [TestMethod]
        public void EuclidTest()
        {
            int first = 585;
            int second = 81;
            int expected = 9;

            int gcd = Algorithms.GreatestCommonDivisorByEuclid(first, second);

            Assert.AreEqual(expected, gcd);

        }

        [TestMethod]
        public void BinTest()
        {
            int first = 585;
            int second = 81;
            int expected = 9;

            int gcd = Algorithms.BinaryGreatestCommonDivision(first, second);

            Assert.AreEqual(expected, gcd);
        }

        [TestMethod]
        public void MoreArgsEuclidTest()
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

        [TestMethod]
        public void MoreArgsBinTest()
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
        
        [TestMethod]
        public void NegativeArgEuclidTest()
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

        [TestMethod]
        public void NegativeArgsBinTest()
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
