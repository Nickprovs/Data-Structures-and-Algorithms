﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public static string CapitalizeFirstLetterOfEachWord(this string input)
        {
            if (input == null)
                throw new ArgumentException();

            return CapitalizeFirstLetterOfEachWordRegex(input);
        }

        private static string CapitalizeFirstLetterOfEachWordRegex(string input)
        {
            var endsTrimmed = input.Trim();
            if (string.IsNullOrWhiteSpace(endsTrimmed))
                return "";

            var noDuplicateSpaces = Regex.Replace(endsTrimmed, "  +", " ");
            var split = noDuplicateSpaces.Split(' ');

            for (int i = 0; i < split.Length; i++)           
                split[i] = split[i].First().ToString().ToUpper() + split[i].Substring(1);
            
            return string.Join(" ", split);
        }

        private static string CapitalizeFirstLetterOfEachWordStandard(string input)
        {
            var trimmedInput = input.Trim();
            var split = trimmedInput.Split();

            var outputBuilder = new StringBuilder();

            for (int i = 0; i < split.Length; i++)
            {
                var word = split[i];

                if (string.IsNullOrWhiteSpace(word))
                    continue;

                var capitalized = word.First().ToString().ToUpper() + word.Substring(1);
                outputBuilder.Append(capitalized);

                if (i < split.Length - 1)
                    outputBuilder.Append(" ");
            }

            return outputBuilder.ToString();
        }

        public static bool IsAnagram(this string input, string possibleRotation)
        {
            if (input == null || possibleRotation == null)
                return false;

            //return IsAnagramUsingSorting(input, possibleRotation);
            return IsAnagramUsingHistogrammingHashTable(input, possibleRotation);
        }

        //O(n)
        private static bool IsAnagramUsingHistogrammingHashTable(string input1, string input2)
        {
            var inputHashTable = new Dictionary<char, int>();

            //O(n)
            foreach (var character in input1)
            {
                if (inputHashTable.ContainsKey(character))
                    inputHashTable[character]++;
                else
                    inputHashTable.Add(character, 0);
            }

            //O(n)
            foreach (var character in input2)
            {
                if (inputHashTable.ContainsKey(character))
                    inputHashTable[character]--;
                else
                    return false;
            }
            //O(n)
            foreach(var key in inputHashTable.Keys)
            {
                if (inputHashTable[key] > 0)
                    return false;
            }

            return true;
        }

        //O(nlogn)
        private static bool IsAnagramUsingSorting(string input1, string input2)
        {
            if (input1.Length != input2.Length)
                return false;
            //O(n) + O(nlogn)
            var ordered1 = input1.ToLowerInvariant().OrderBy(c => c).ToArray();
            //O(n) + O(nlogn)
            var ordered2 = input2.ToLowerInvariant().OrderBy(c => c).ToArray();

            return Enumerable.SequenceEqual(ordered1, ordered2);
        }

        public static bool IsPalindrome(this string input)
        {
            if (input == null)
                return false;

            if (string.IsNullOrWhiteSpace(input))
                return true;

            return IsPalindromeBetter(input);
            //return IsPalindromeStandard(input);
        }

        private static bool IsPalindromeStandard(string input)
        {
            var reversed = input.Reverse();
            return input.Equals(reversed);
        }

        private static bool IsPalindromeBetter(string input)
        {
            int left = 0;
            int right = input.Length - 1;

            while(left < right)
            {
                if (input[left++] != input[right--])
                    return false;
            }

            return true;
        }
    }
}
