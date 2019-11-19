using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool IsRotation(this string input, string possibleRotation)
        {
            if (input == null || possibleRotation == null)
                return false;

            return input.Length == possibleRotation.Length &&
                   (input + input).Contains(possibleRotation);
        }

        public static string RemoveDuplicateCharacters(this string input)
        {
            if (input == null)
                return "";

            var existingChars = new HashSet<char>();
            var duplicatesRemoved = new StringBuilder();

            foreach(var character in input)
            {
                if (existingChars.Contains(character))
                    continue;

                duplicatesRemoved.Append(character);
                existingChars.Add(character);
            }

            return duplicatesRemoved.ToString();
        }

        public static char MostRepeatedChar(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException();

            var charCount = new Dictionary<char, int>();        
            foreach(var character in input)
            {
                if (!charCount.ContainsKey(character))
                    charCount.Add(character, 0);

                charCount[character]++;
            }

            var maxChar = charCount.FirstOrDefault(kvp => kvp.Value == charCount.Values.Max()).Key;
            return maxChar;
        }

        public static char MostRepeatedCharWithoutHashTable(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException();

            const int ASCII_SIZE = 256;
            var frequencies = new int[ASCII_SIZE];
            foreach (var character in input)
                frequencies[character]++;

            int max = 0;
            char result = ' ';
            for(var i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i] > max)
                {
                    max = frequencies[i];
                    result = (char)i;
                }
            }

            return result;
        }
    }
}
