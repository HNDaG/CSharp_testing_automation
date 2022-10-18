using NUnit.Framework;

namespace Tests_CS_Basics
{
    internal class Task6_Tests
    {
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(966252, 966522)]
        [TestCase(16985, 18569)]
        public void NextBigger_IsPossible_ReturnsNextBigger(int number, int expectedResult)
        {
            var result = CS_Tasks.Task6.NextPermutation(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(32)]
        [TestCase(43110)]
        public void NextBigger_SomeNumberWhithoutBiger_ReturnsNegativeOne(int number)
        {
            var result = CS_Tasks.Task6.NextPermutation(number);
            Assert.That(result, Is.EqualTo(-1));
        }
    }
}