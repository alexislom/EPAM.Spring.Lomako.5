using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task2Logic;


namespace Task2NUnitTests
{
    [TestFixture]
    public class AlgorithmsNUnitTests
    {

        #region GCD for 2 arguments

        public IEnumerable<TestCaseData> TestDataGDCFor2Args
        {
            get
            {
                yield return new TestCaseData(2, 8).Returns(2);
                yield return new TestCaseData(2, -8).Returns(2);
                yield return new TestCaseData(0, 0).Returns(0);
                yield return new TestCaseData(8, 16).Returns(8);
                yield return new TestCaseData(1, 2).Returns(1);
                yield return new TestCaseData(585, 81).Returns(9);
            }
        }

        [Test, TestCaseSource(nameof(TestDataGDCFor2Args))]
        public static double GCD_2Args_Euclid_Test(int first, int second)
        {
            return Algorithms.GreatestCommonDivisorByEuclid(first, second);
        }

        [Test, TestCaseSource(nameof(TestDataGDCFor2Args))]
        public static double GCD_2Args_Bin_Test(int first, int second)
        {
            return Algorithms.BinaryGreatestCommonDivision(first, second);
        }

        #endregion

        #region GDC for more than 2 args

        public IEnumerable<TestCaseData> TestDataGDCForMoreThan2Args
        {
            get
            {
                yield return new TestCaseData(new int[] { 24, 18, 6}).Returns(6);
                yield return new TestCaseData(new int[] { 2, 8, 4 }).Returns(2);
                yield return new TestCaseData(new int[] { 0, 0, 0, 0, 0, 0 }).Returns(0);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }).Returns(1);
                yield return new TestCaseData(new int[] { 585, 81, 9, 3, 12 }).Returns(3);
            }
        }

        [Test, TestCaseSource(nameof(TestDataGDCForMoreThan2Args))]
        public static double GDC_MoreThan2Arguments_Euclid_Test(params int[] values)
        {
            return Algorithms.GreatestCommonDivisorByEuclid(values);
        }

        [Test, TestCaseSource(nameof(TestDataGDCForMoreThan2Args))]
        public static double GDC_MoreThan2Arguments_Bin_Test(params int[] values)
        {
            return Algorithms.BinaryGreatestCommonDivision(values);
        }

        #endregion
    }
}
