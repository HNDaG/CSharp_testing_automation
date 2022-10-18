using NUnit.Framework;
using System;

namespace Tests_CS_Basics
{
    internal class Task5_Tests
    {
        [Test]
        public void ChangeFriendList__ReturnsRequiredOutput()
        {
            var s = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            var requiredResult = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            string result = CS_Tasks.Task5.ChangeFriendList(s);
            Assert.That(result, Is.EqualTo(requiredResult));
        }

        [TestCase("")]
        [TestCase("::;;")]
        public void ChangeFriendList_WrongFormat_ThrowsException(string s)
        {
            TestDelegate action = () => CS_Tasks.Task5.ChangeFriendList(s);
            Assert.Throws<Exception>(action);
        }
    }
}