using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise01.Extension_Methods;

namespace ExerciseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Accepts_Integer()
        {
            var number = 10000;

          var Result = Convert.ToInt64(number).Towards();

            Assert.AreEqual(Result, "ten thousand ");
        }

        [TestMethod]
        public void Test_Accepts_Long()
        {
            var number = 100000000000000;

            var Result = number.Towards();

            Assert.AreEqual(Result, "one hundred  trillion ");
        }
    }
}
