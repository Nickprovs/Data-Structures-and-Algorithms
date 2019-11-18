using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.StringManipulation
{
    public static class StringUtilities
    {
        public static int CountVowels(this string input)
        {
            if (input == null)
                return 0;

            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            int count = 0;

            foreach(var character in input.ToLowerInvariant())
            {
                if (vowels.Contains(character))
                    count++;
            }
            return count;
        }

        public static string Reverse(this string input)
        {
            if (input == null)
                return "";

            var reversedBuilder = new StringBuilder();
            for (var i = input.Length - 1; i >= 0; i--)
                reversedBuilder.Append(input[i]);

            return reversedBuilder.ToString();
        }

        public static string ReverseWords(this string input)
        {
            if (input == null)
                return "";

            var words = input.Trim().Split(' ');
            var reversedBuilder = new StringBuilder();

            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversedBuilder.Append(words[i]);
                reversedBuilder.Append(' ');
            }

            return reversedBuilder.ToString().Trim();
        }

        public static bool IsRotation(string inputA, string inputB)
        {
            return false;
        }
    }
}
