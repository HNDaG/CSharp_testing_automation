using NUnit.Framework;

namespace Tests_CS_Basics
{
    internal class Task7_Tests
    {
        [TestCase(2149583361, "128.32.10.1")]
        [TestCase((uint)32, "0.0.0.32")]
        [TestCase((uint)0, "0.0.0.0")]
        [TestCase((uint)256, "0.0.1.0")]
        public void GetIPFromUInt32(uint number, string expectedResult)
        {
            var result = CS_Tasks.Task7.GetIPFromInt(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}