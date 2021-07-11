using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome.Tests
{
    [TestClass()]
    public class MyExtensionsTests
    {
        [TestMethod()]
        public void TrimFrontAndBackByOneTest()
        {
            string toTrim = "12345";
            Assert.AreEqual(toTrim.TrimFrontAndBackByOne(), "234");
        }
    }
}