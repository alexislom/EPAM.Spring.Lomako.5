using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Logic.Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void Operator_AdditionTwoPolynomials_Test()
        {
            var a = new Polynomial(1, 2, 3);
            var b = new Polynomial(2, 4, 6);

            var expected = new Polynomial(3, 6, 9);
            var c = a + b;

            CollectionAssert.AreEqual(expected.Coefficients, c.Coefficients);
        }

        [TestMethod]
        public void Operator_UnaryNegation_Test()
        {
            var a = new Polynomial(1, 2, 3);

            var expected = new Polynomial(-1, -2, -3);

            var actual = -a;

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [TestMethod]
        public void Operator_Subtraction_Test()
        {
            var a = new Polynomial(5, 5, 5);
            var b = new Polynomial(1, 2, 3);

            var expected = new Polynomial(4, 3, 2);

            var actual = a - b;

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [TestMethod]
        public void Operator_Multiply_Test()
        {
            var a = new Polynomial(1, 2, 3);
            var b = new Polynomial(1, 2, 8, 4);

            var expected = new Polynomial(1, 4, 15, 26, 32, 12);

            var actual = a * b;

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [TestMethod]
        public void DifferentiateTest()
        {
            var a = new Polynomial(1, 2, 3, 4, 5);

            var expected = new Polynomial(2, 6, 12, 20);
            var actual = a.Differentiate();

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [TestMethod]
        public void EvaluateTest()
        {
            var a = new Polynomial(3, 3, 3, 3, 3);

            var expected = 2343;
            var actual = a.Evaluate(5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideTest()
        {
            var a = new Polynomial(-42, 0, -12, 1);
            var b = new Polynomial(-3, 1);

            var q = new Polynomial(-27, -9, 1);
            var r = new Polynomial(-123, 0, 0, 0);
            var actualR = new Polynomial(2);

            var actual = Polynomial.Divide(a, b, out actualR);

            Console.WriteLine(actualR);

            CollectionAssert.AreEqual(q.Coefficients, actual.Coefficients);
            CollectionAssert.AreEqual(r.Coefficients, actualR.Coefficients);
        }
    }
}