using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Logic;

namespace Task3.NUnitTests
{
    [TestFixture]
    public class PolynomialNUnitTests
    {
        [Test]
        public void Op_AdditionTwoPolynomials_Test()
        {
            var a = new Polynomial(1, 2, 3);
            var b = new Polynomial(2, 4, 6);

            var expected = new Polynomial(3, 6, 9);
            var c = a + b;

            CollectionAssert.AreEqual(expected.Coefficients, c.Coefficients);
        }

        [Test]
        public void Op_UnaryNegation_Test()
        {
            var a = new Polynomial(1, 2, 3);

            var expected = new Polynomial(-1, -2, -3);

            var actual = -a;

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [Test]
        public void Op_Subtraction_Test()
        {
            var a = new Polynomial(6, 6, 6);
            var b = new Polynomial(1, 2, 3);

            var expected = new Polynomial(5, 4, 3);

            var actual = a - b;

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [Test]
        public void Op_Multiply_Test()
        {
            var a = new Polynomial(1, 2, 3);
            var b = new Polynomial(1, 2, 8, 4);

            var expected = new Polynomial(1, 4, 15, 26, 32, 12);

            var actual = a * b;

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [Test]
        public void Differentiate_Test()
        {
            var a = new Polynomial(100, 20, 4, 5, 5);

            var expected = new Polynomial(20, 8, 15, 20);
            var actual = a.Differentiate();

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [Test]
        public void Integrate_Test()
        {
            var a = new Polynomial(20, 8, 15, 20); 

            var expected = new Polynomial(100, 20, 4, 5, 5);
            var actual = a.Integrate(100);

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [Test]
        public void Evaluate_Test()
        {
            var a = new Polynomial(3, 3, 3, 3, 3);

            var expected = 2343;
            var actual = a.Evaluate(5);

            Assert.AreEqual(expected, actual);
        }
    }
}
