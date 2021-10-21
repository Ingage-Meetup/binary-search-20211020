using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BinarySearch.Tests
{
    [TestClass]
    public class SearchTest
    {
        private Search fixture;

        [TestInitialize]
        public void SetUp()
        {
            fixture = new Search();
        }

        [DataRow(null)]
        [DataRow(new int[0])]
        [TestMethod]
        public void SearchNullOrEmptyArrayShouldReturnFalse(int[] array)
        {
            Assert.IsFalse(fixture.ArrayContainsItem(array, 1));
        }


        [DataRow(new int[1] { 1 }, 1, true)]
        [DataRow(new int[1] { 2 }, 1, false)]
        [TestMethod]
        public void SearchSingleItemArrayShouldReturnTrueIfItemEqualsTheElement(int[] array, int item, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, fixture.ArrayContainsItem(array, item), $"Array [ {(string.Join(",", array))} ] should {(expectedResult ? "" : "not")} contain {item}");
        }

        [DataRow(new int[] { 1, 3, 5 }, 0, false)]
        [DataRow(new int[] { 1, 3, 5 }, 1, true)]
        [DataRow(new int[] { 1, 3, 5 }, 5, true)]
        [DataRow(new int[] { 1, 3, 5 }, 6, false)]
        [TestMethod]
        public void SearchItemIsFirstOrLastElementInArrayShouldReturnTrue(int[] array, int item, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, fixture.ArrayContainsItem(array, item), $"Array [ {(string.Join(",", array))} ] should {(expectedResult ? "" : "not")} contain {item}");
        }

        [DataRow(new int[] { 1, 3, 5 }, 0, false)]
        [DataRow(new int[] { 1, 3, 5 }, 2, false)]
        [DataRow(new int[] { 1, 3, 5 }, 1, true)]
        [DataRow(new int[] { 1, 3, 5 }, 3, true)]
        [DataRow(new int[] { 1, 3, 5 }, 5, true)]
        [DataRow(new int[] { 1, 3, 5 }, 6, false)]
        [TestMethod]
        public void SearchItemIsAnywhereInArrayShouldReturnTrue(int[] array, int item, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, fixture.ArrayContainsItem(array, item), $"Array [ {(string.Join(",", array))} ] should {(expectedResult ? "" : "not")} contain {item}");
        }


        [DataRow(5001)]
        [DataRow(10000)]
        [DataRow(100000)]
        [TestMethod]
        public void SearchLargeArrayOfRandomNumbersShouldReturnTrueIfItemIsFound(int numberOfElements)
        {
            var random = new Random();
            var array = Enumerable.Repeat(0, numberOfElements).Select(i => random.Next()).ToArray();
            Array.Sort(array);
            var chosenElement = array[random.Next(0, numberOfElements)];

            Assert.IsTrue(fixture.ArrayContainsItem(array, chosenElement), $"Large array should contain {chosenElement}");
        }
    }
}
