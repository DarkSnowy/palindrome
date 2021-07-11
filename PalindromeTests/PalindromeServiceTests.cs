using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome.Tests
{
    [TestClass()]
    public class PalindromeServiceTests
    {
        [TestMethod()]
        public void FindPalindromesTest()
        {
            var service = new PalindromeService();
            var results = service.FindPalindromes("aabttbabt");
            string[] expected = new string[]
            {
                "aa",
                "abttba",
                "bttb",
                "bttb",
                "tt",
                "a",
                "tbabt",
                "bab"
            };

            bool foundMissing = false;
            var missing = new List<string>();

            foreach(string value in expected)
            {
                if(!results.Contains(value))
                {
                    foundMissing = true;
                    missing.Add(value);
                }
            }

            if (foundMissing)
                Assert.Fail("Failed to find expected palindrome", missing);
        }

        [TestMethod()]
        public void FindPalindromesTestMultiple()
        {
            var service = new PalindromeService();
            var results = service.FindPalindromes(new string[3] {
                "aabttbabt",
                "yolo",
                "gigabite" });

            string[] expected = new string[]
            {
                "aa",
                "abttba",
                "bttb",
                "bttb",
                "tt",
                "a",
                "tbabt",
                "bab",
                "olo",
                "gig",
                "y",
                "o",
            };

            bool foundMissing = false;
            var missing = new List<string>();

            foreach (string value in expected)
            {
                if (!results.Contains(value))
                {
                    foundMissing = true;
                    missing.Add(value);
                }
            }

            if (foundMissing)
                Assert.Fail("Failed to find expected palindrome", missing);
        }
    }
}