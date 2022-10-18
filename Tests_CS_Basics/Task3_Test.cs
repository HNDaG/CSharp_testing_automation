using NUnit.Framework;

namespace Tests_CS_Basics
{
    internal class Task3_Tests
    {
        [TestCase(9, 9)]
        [TestCase(100, 1)]
        [TestCase(222, 6)]
        [TestCase(155, 2)]
        [TestCase(2412455, 5)]
        public void DigitalRootReturnsSumOfDigits_ContinuesUnlessLowerThan10(int number, int expectedResult)
        {
            var result = CS_Tasks.Task3.DigitalRoot(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}