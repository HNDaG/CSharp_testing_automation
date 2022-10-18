using CS_Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests_CS_Basics
{
    internal class Task1_Tests
    {
        [Test]
        public void GetIntegersFromList_ListWithTwoIntsAndOtherTypes_ReturnsListWithSameInts()
        {
            var List = new List<object>() { 1, -1, 'a', 'b', "aasf", '1', 2, 1.1,  100 };
            var result = Task1.GetIntegersFromList(List);
            Assert.That(result, Is.EqualTo(new List<int> { 1, 2, 100 }));
        }

        [Test]
        public void GetIntegersFromList_OnlyStringList_ReturnsEmptyList()
        {
            var List = new List<object>() { 'a', "ncsdk" };
            var result = Task1.GetIntegersFromList(List);
            Assert.That(result, Is.EqualTo(new List<int> { }));
        }
    }
}