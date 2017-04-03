using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task3Logic;


namespace Task3.NUnitTests
{
    [TestFixture]
    public class PolynomialNUnitTests
    {
        #region Plus

        public IEnumerable<TestCaseData> TestPlusData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(0, 1), null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new Polynomial(1, 2, 3), new Polynomial(2, 3, 4)).Returns(new Polynomial(3, 5, 7));
                yield return new TestCaseData(new Polynomial(-4, -2, 0), new Polynomial(2, 3, 4, 5)).Returns(new Polynomial(-2, 1, 4, 5));
                yield return new TestCaseData(new Polynomial(-4, 10, 33), new Polynomial(2, 1, 2, 1)).Returns(new Polynomial(-2, 11, 35, 1));
            }
        }

        [Test, TestCaseSource(nameof(TestPlusData))]
        public Polynomial PlusOperator_AddTwoPolynomials_Test(Polynomial p1, Polynomial p2)
        {
            return p1 + p2;
        }

        #endregion

        #region Multiplication

        public IEnumerable<TestCaseData> TestMultiplyData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(0, 1), null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new Polynomial(1, 2), new Polynomial(1)).Returns(new Polynomial(1, 2));
                yield return new TestCaseData(new Polynomial(-4, -2, 0), new Polynomial(2, 3, 4, 5)).Returns(new Polynomial(-8, -16, -22, -28, -10));
            }
        }

        [Test, TestCaseSource(nameof(TestMultiplyData))]
        public Polynomial MultiplyOperator_MultiplyPolynomailsWithYield(Polynomial p1, Polynomial p2)
        {
            return p1 * p2;
        }

        public IEnumerable<TestCaseData> TestMultiplyOnDoubleData
        {
            get
            {
                yield return new TestCaseData(null, 2).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new Polynomial(1, 2), 2).Returns(new Polynomial(2, 4));
                yield return new TestCaseData(new Polynomial(1, 2, 3), 1).Returns(new Polynomial(1,2,3));
                yield return new TestCaseData(new Polynomial(-4, -2, 3, 0), -2).Returns(new Polynomial(8, 4, -6));
            }
        }

        [Test, TestCaseSource(nameof(TestMultiplyOnDoubleData))]
        public Polynomial MultiplyOperator_MultiplyPolynomailOnDoubleWithYield(Polynomial p, double x)
        {
            return p * x;
        }
        #endregion

        #region Equals

        public IEnumerable<TestCaseData> TestEqualsData
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 2, 3)).Returns(true);
                yield return new TestCaseData(new Polynomial(1, 2, 3, 0, 0, 0)).Returns(false);
                yield return new TestCaseData(new Polynomial(1, 2)).Returns(false);
                yield return new TestCaseData(null).Returns(false);
            }
        }

        [Test, TestCaseSource(nameof(TestEqualsData))]
        public bool Equals_CompareTwoPolynomialsWithYield(Polynomial p)
        {
            Polynomial p1 = new Polynomial(1, 2, 3);
            return p1.Equals(p);
        }
        #endregion

        #region ToString
        public IEnumerable<TestCaseData> TestToStringData
        {
            get
            {
                yield return new TestCaseData().Returns("1+2x+3x^2");
            }
        }

        [Test, TestCaseSource(nameof(TestToStringData))]
        public string ToString_ReturnStringWithYield()
        {
            var p = new Polynomial(1, 2, 3);
            return p.ToString();
        }

        #endregion

        [Test]
        [TestCase(5,Result = 2343)]
        public double Evaluate_Test(double value)
        {
            var p = new Polynomial(3, 3, 3, 3, 3);
            
            return p.Evaluate(value);
        }

        [Test]
        public void Differentiate_Test()
        {
            var p = new Polynomial(100, 20, 4, 5, 5);

            var expected = new Polynomial(20, 8, 15, 20);
            var actual = p.Differentiate();

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }

        [Test]
        public void Integrate_Test()
        {
            var p = new Polynomial(20, 8, 15, 20);

            var expected = new Polynomial(100, 20, 4, 5, 5);
            var actual = p.Integrate(100);

            CollectionAssert.AreEqual(expected.Coefficients, actual.Coefficients);
        }
    }
}
