using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeallyConnected.Library;

namespace IdeallyConnected.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestAnalysis
    {
        [TestMethod]
        //[CheckThisMethod]
        public void TestPassedMethod()
        {
            Analysis aobject = new Analysis();
            var resultWhichShouldBeTrue = aobject.Run(false);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail();
            // Custom assert
            //Assert.AreEqual(resultWhichShouldBeTrue, true, "Expected value is TRUE.");
        }

        [TestMethod]
        //[CheckThisMethod]
        public void TestFailedMethod()
        {
            Analysis aobject = new Analysis();
            var resultWhichShouldBeFalse = aobject.Run();
            Assert.AreEqual(resultWhichShouldBeFalse, false, "Expected value is FALSE.");
        }
    }

    public struct UnitTestInfo
    {
        public bool DidTestPass { get; set; }
        public string TestFailureMessage { get; set; }
        public string MethodName { get; set; }
    }
}
