using NUnit.Framework;

namespace Tests_CS_Basics
{
    internal class Task2_Tests
    {
        [Test]
        public void FirstNonRepeatingLetter_String_ReturnFirstNonRepeatingLetterInThisString()
        {
            var input = "sTreSS";
            var result = CS_Tasks.Task2.FirstNonRepeatingLetter(input);
            Assert.That(result, Is.EqualTo('T'));
        }

        [Test]
        public void FirstNonRepeatingLetter_EmptyString_ReturnsNull()
        {
            var input = "";
            var result = CS_Tasks.Task2.FirstNonRepeatingLetter(input);

            Assert.That(result, Is.EqualTo(null));
        }

        [TestCase("aaa")]
        [TestCase("bbaa")]
        public void FirstNonRepeatingLetter_StringWithRepeatingLettersOnly_ReturnsNull(string inputWithRepeatingLettersOnly)
        {
            var result = CS_Tasks.Task2.FirstNonRepeatingLetter(inputWithRepeatingLettersOnly);
            Assert.That(result, Is.EqualTo(null));
        }
    }
}