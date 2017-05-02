using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Test
{
    public class TestAnalysis
    {
        //[TestMethod]
        //[CheckThisMethod]
        public void TestPassedMethod()
        {
            // Custom assert
            //Assert.AreEqual(resultWhichShouldBeTrue, true, "Expected value is TRUE.");
        }

        //[TestMethod]
        //[CheckThisMethod]
        public void TestFailedMethod()
        {

        }
    }

    public struct UnitTestInfo
    {
        public bool DidTestPass { get; set; }
        public string TestFailureMessage { get; set; }
        public string MethodName { get; set; }
    }
}
