using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public static class MyExtensions
    {
        public static void AddToFront<T>(this List<T> list, T item)
        {
            // omits validation, etc.
            list.Insert(0, item);
        }

        /// <summary>
        /// Removes string with first and last character removes.
        /// </summary>
        /// <param name="value">Value to trim.</param>
        /// <returns>Value with first and last character removed.</returns>
        public static string TrimFrontAndBackByOne(this string value) => value[1..^1];

        /// <summary>
        /// Find the index of each matching character.
        /// </summary>
        /// <param name="value">Value to search.</param>
        /// <param name="character">Character to search for.</param>
        /// <param name="startAt">Index to start searching at.</param>
        /// <returns>List of indexes for matching characters.</returns>
        public static List<int> IndexOfMatchingChars(this string value, char character, int startAt = 0)
        {
            var t = value.Where((x, index) => x == character);

            var indexes = new List<int>();
            for (int index = startAt; index < value.Length; index++)
            {
                if (value[index] == character)
                    indexes.Add(index);
            }

            return indexes;
        }
    }
}
