using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void ArrayContainsItemNullOrEmptyArrayShouldReturnFalse(int[] array)
        {
            Assert.IsFalse(fixture.ArrayContainsItem(array, 1));
        }


        [DataRow(new int[1] { 1 }, 1, true)]
        [DataRow(new int[1] { 2 }, 1, false)]
        [TestMethod]
        public void ArrayContainsItemSingleItemArrayShouldReturnTrueIfItemEqualsTheElement(int[] array, int item, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, fixture.ArrayContainsItem(array, item), $"Array [ {(string.Join(",", array))} ] should {(expectedResult ? "" : "not")} contain {item}");
        }

        [DataRow(new int[] { 1, 3, 5 }, 0, false)]
        [DataRow(new int[] { 1, 3, 5 }, 1, true)]
        [DataRow(new int[] { 1, 3, 5 }, 5, true)]
        [DataRow(new int[] { 1, 3, 5 }, 6, false)]
        [TestMethod]
        public void ArrayContainsItemItemIsFirstOrLastElementInArrayShouldReturnTrue(int[] array, int item, bool expectedResult)
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
        public void ArrayContainsItemItemIsAnywhereInArrayShouldReturnTrue(int[] array, int item, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, fixture.ArrayContainsItem(array, item), $"Array [ {(string.Join(",", array))} ] should {(expectedResult ? "" : "not")} contain {item}");
        }


        [DataRow(5001)]
        [DataRow(10000)]
        [DataRow(100000)]
        [TestMethod]
        public void ArrayContainsItemLargeArrayOfRandomNumbersShouldReturnTrueIfItemIsFound(int numberOfElements)
        {
            var random = new Random();
            var array = Enumerable.Repeat(0, numberOfElements).Select(i => random.Next()).ToArray();
            Array.Sort(array);
            var chosenElement = array[random.Next(0, numberOfElements)];

            Assert.IsTrue(fixture.ArrayContainsItem(array, chosenElement), $"Large array should contain {chosenElement}");
        }

        [DataRow(null)]
        [DataRow(new int[0])]
        [TestMethod]
        public void ArrayFindNullOrEmptyArrayShouldReturnFalse(int[] array)
        {
            Assert.AreEqual(-1, fixture.ArrayFind(array, 1));
        }


        [DataRow(new int[1] { 1 }, 1, 0)]
        [DataRow(new int[1] { 2 }, 1, -1)]
        [TestMethod]
        public void ArrayFindSingleItemArrayShouldReturnTrueIfItemEqualsTheElement(int[] array, int item, int expectedPosition)
        {
            Assert.AreEqual(expectedPosition, fixture.ArrayFind(array, item), $"Array [ {(string.Join(",", array))} ] should {(expectedPosition >= 0 ? "" : "not")} contain {item} {(expectedPosition >= 0 ? "at position {expectedResult}" : "")}");
        }

        [DataRow(new int[] { 1, 3, 5 }, 0, -1)]
        [DataRow(new int[] { 1, 3, 5 }, 1, 0)]
        [DataRow(new int[] { 1, 3, 5 }, 5, 2)]
        [DataRow(new int[] { 1, 3, 5 }, 6, -1)]
        [TestMethod]
        public void ArrayFindItemIsFirstOrLastElementInArrayShouldReturnTrue(int[] array, int item, int expectedPosition)
        {
            Assert.AreEqual(expectedPosition, fixture.ArrayFind(array, item), $"Array [ {(string.Join(",", array))} ] should {(expectedPosition >= 0 ? "" : "not")} contain {item} {(expectedPosition >= 0 ? "at position {expectedResult}" : "")}");
        }

        [DataRow(new int[] { 1, 3, 5 }, 0, -1)]
        [DataRow(new int[] { 1, 3, 5 }, 2, -1)]
        [DataRow(new int[] { 1, 3, 5 }, 1, 0)]
        [DataRow(new int[] { 1, 3, 5 }, 3, 1)]
        [DataRow(new int[] { 1, 3, 5 }, 5, 2)]
        [DataRow(new int[] { 1, 3, 5 }, 6, -1)]
        [TestMethod]
        public void ArrayFindItemIsAnywhereInArrayShouldReturnTrue(int[] array, int item, int expectedPosition)
        {
            Assert.AreEqual(expectedPosition, fixture.ArrayFind(array, item), $"Array [ {(string.Join(",", array))} ] should {(expectedPosition >= 0 ? "" : "not")} contain {item} {(expectedPosition >= 0 ? "at position {expectedResult}" : "")}");
        }


        [DataRow(5001)]
        [DataRow(10000)]
        [DataRow(100000)]
        [TestMethod]
        public void ArrayFindLargeArrayOfRandomNumbersShouldReturnTrueIfItemIsFound(int numberOfElements)
        {
            var random = new Random();
            var array = Enumerable.Repeat(0, numberOfElements).Select(i => random.Next()).ToArray();
            Array.Sort(array);
            var chosenElementIndex = random.Next(0, numberOfElements);
            var chosenElement = array[chosenElementIndex];

            Assert.AreEqual(chosenElementIndex, fixture.ArrayFind(array, chosenElement), $"Large array should contain {chosenElement} at position {chosenElementIndex}");
        }
    }
}
