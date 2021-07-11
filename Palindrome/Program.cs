using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 0 && args[0].ToLower().Contains("help"))
            {
                Console.WriteLine("Returns list of palindromes within passed argument.");
                return;
            }

            var palindromeServices = new PalindromeService();
            var found = palindromeServices.FindPalindromes(args);

            foreach(string value in found)
                Console.WriteLine(value);
        }
    }
}
