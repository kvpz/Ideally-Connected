using System;
using Windows.UI.ViewManagement;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyCollabLib;

namespace UnitTestGraphCollab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OGraph<int> og = new OGraph<int>();
            og.Begin(0);
            
        }


    }
}
