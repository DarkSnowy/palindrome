using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public class PalindromeService
    {
        private readonly PalindromeServiceOptions options;

        /// <summary>
        /// This class contains services relating to palindromes.
        /// </summary>
        public PalindromeService()
        {
            options = new PalindromeServiceOptions();
        }

        /// <summary>
        /// This class contains services relating to palindromes.
        /// </summary>
        /// <param name="options">Options may be passed to change default behaviours.</param>
        public PalindromeService(PalindromeServiceOptions options)
        {
            this.options = options;
        }

        /// <summary>
        /// Search a strings for palindromes.
        /// </summary>
        /// <param name="values">Strings to be searched.</param>
        /// <returns>Array of palindromes found.</returns>
        /// <note>It is expected that this will recieve an array containing a single value but it will handle multiple values if passed.</note>
        public string[] FindPalindromes(string[] values) => values.SelectMany(x => FindPalindromes(x)).ToArray();

        /// <summary>
        /// Search string for palindromes.
        /// </summary>
        /// <param name="values">String to be searched.</param>
        /// <returns>Array of palindromes found.</returns>
        public string[] FindPalindromes(string value)
        {
            var palindromes = new List<string>();
            int minEndIndex = 0;

            for (int index = 0; index < value.Length; index++)
            {
                var currentChar = value[index];

                if (options.IncludeSingleCharacters && options.IncludeDuplicates || !palindromes.Contains(currentChar.ToString()))
                    palindromes.Add(currentChar.ToString());

                var startAt = Math.Max(minEndIndex, index + 1);
                var matches = value.IndexOfMatchingChars(currentChar, startAt);
                matches.Sort();
                matches.Reverse();

                foreach (int match in matches)
                {
                    int diff = match - index;
                    int steps = 0;

                    while (steps < diff && value[index + steps] == value[match - steps])
                        steps++;

                    if (steps != diff)
                        continue;

                    // If a palindrome is found then any further palindrones must start after the end of this one.
                    minEndIndex = match;
                    var palindrome = value.Substring(index, diff + 1);
                    palindromes.Add(palindrome);

                    while(!options.OnlyWholePalindromes && palindrome.Length > 2)
                    {
                        palindrome = palindrome.TrimFrontAndBackByOne();

                        if(options.IncludeDuplicates || !palindromes.Contains(palindrome))
                            palindromes.Add(palindrome);
                    }

                    // Provided the list is sorted decending then all palindrones are accounted for.
                    break;
                }

                // Should a palindrome end at the length of the value then there are no more palindromes to be found.
                if (minEndIndex == value.Length)
                    break;
            }

            return palindromes.ToArray();
        }

    }
}
