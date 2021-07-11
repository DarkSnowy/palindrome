using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public class PalindromeServiceOptions
    {
        /// <summary>
        /// Whether or not to include palindromes made up of a single character when executing methods of this service instance. Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeSingleCharacters { get; set; } = true;

        /// <summary>
        /// Whether or not to include palindromes within a larger palindrome when executing methods of this service instance. Defaults to <c>false</c>.
        /// </summary>
        public bool OnlyWholePalindromes { get; set; } = false;

        /// <summary>
        /// Whether or not to include duplicate palindromes if they exist more than once for a given return.
        /// </summary>
        public bool IncludeDuplicates { get; set; } = true;
    }
}
