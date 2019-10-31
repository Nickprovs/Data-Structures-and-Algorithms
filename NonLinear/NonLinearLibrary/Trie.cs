using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NonLinearLibrary
{
    public class Trie
    {
        private Node _root = new Node(' ');
        public void Insert(string word)
        {
            var current = this._root;
            foreach(var character in word)
            {
                if (!current.HasChild(character))
                    current.AddChild(character);

                current = current.GetChild(character);
            }
            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            var current = this._root;
            foreach(var character in word)
            {
                if (!current.HasChild(character))
                    return false;

                current = current.GetChild(character);
            }

            return current.IsEndOfWord;
        }
        public void Remove(string wordToRemove)
        {
            if (string.IsNullOrWhiteSpace(wordToRemove))
                return;

            this.Remove(wordToRemove, 0, this._root);
        }

        private void Remove(string wordToRemove, int index, Node current)
        {
            if (index == wordToRemove.Length)
            {
                current.IsEndOfWord = false;
                return;

            }

            var ch = wordToRemove[index];
            var child = current.GetChild(ch);
            if (child == null)
                return;

            this.Remove(wordToRemove, index + 1, child);

            if (!child.HasChildren() && !child.IsEndOfWord)
                current.RemoveChild(ch);
        }
        public void Traverse()
        {
            this.Traverse(this._root);
        }

        // Prints the Trie in Pre-Order
        // If we print after the recursion... we'd be printing in post-order
        // i.e. we wont print until we start unwinding.
        private void Traverse(Node root)
        {
            Console.WriteLine(root.Value);

            foreach (var child in root.GetChildren())
                this.Traverse(child);

        }

        internal class Node
        {
            internal char Value;
            internal Dictionary<char, Node> Children;
            internal bool IsEndOfWord;

            internal Node(char value)
            {
                this.Value = value;
                this.Children = new Dictionary<char, Node>();
            }

            public override string ToString()
            {
                return $"Value: {this.Value}";
            }

            internal bool HasChild(char childChar)
            {
                return this.Children.ContainsKey(childChar);
            }

            internal void AddChild(char childChar)
            {
                this.Children.Add(childChar, new Node(childChar));
            }

            internal Node GetChild(char childChar)
            {
                this.Children.TryGetValue(childChar, out var childNode);
                return childNode;
            }

            internal Node[] GetChildren()
            {
                return this.Children.Values.ToArray();
            }

            internal bool HasChildren()
            {
                return this.Children.Values.Count != 0;
            }

            internal void RemoveChild(char ch)
            {
                this.Children.Remove(ch);
            }
        }

        public int CountWords()
        {
            return this.CountWords(this._root);
        }

        private int CountWords(Node currentNode)
        {
            if (currentNode == null)
                return 0;

            int totalWords = 0;

            if (currentNode.IsEndOfWord)
                totalWords++;

            foreach (var childNode in currentNode.GetChildren())  
                totalWords += this.CountWords(childNode);
            
            return totalWords;
        }
        public bool ContainsRecursive(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            return this.ContainsRecursive(word, 0, this._root);
        }

        private bool ContainsRecursive(string word, int index, Node currentNode)
        {
            if (index == word.Length)
                return currentNode.IsEndOfWord;

            var characterToMatch = word[index];
            var matchingChildNode = currentNode.GetChild(characterToMatch);
            if (matchingChildNode == null)
                return false;

            return this.ContainsRecursive(word, index + 1, matchingChildNode);
        }

        public List<string> GetAutoCompletedWords(string prefix)
        {
            var autoCompletedWords = new List<string>();

            //If we don't have this word in our collection... we have no matches
            var lastNodeInWord = this.FindLastNodeOf(prefix);
            if (lastNodeInWord == null)
                return autoCompletedWords;

            this.GetAutoCompletedWords(prefix, autoCompletedWords, lastNodeInWord);
            return autoCompletedWords;
        }
        private void GetAutoCompletedWords(string prefix, List<string> words, Node currentNode)
        {
            if (currentNode == null)
                return;

            if (currentNode.IsEndOfWord)
                words.Add(prefix);

            foreach (var child in currentNode.GetChildren())
                this.GetAutoCompletedWords(prefix + child.Value, words, child);

        }
        private Node FindLastNodeOf(string prefix)
        {
            var current = this._root;
            foreach (var character in prefix)
            {
                var child = current.GetChild(character);
                if (child == null)
                    return null;

                current = child;
            }

            return current;
        }

        public static string GetLongestCommonPrefix(IList<string> strings)
        {
            if (strings == null || strings.Count == 0)
                return "";

            var trie = new Trie();
            foreach (var word in strings)
                trie.Insert(word);

            var longestActualPrefix = new StringBuilder();
            var longestPossiblePrefix = GetShortestStringInList(strings);

            var current = trie._root;
            foreach (var character in longestPossiblePrefix)
            {
                var currentChildren = current.GetChildren();

                //If we have no children or branch off at all... 
                //...we no longer have a common prefix
                if (currentChildren.Length != 1)
                    break;

                current = currentChildren[0];
                longestActualPrefix.Append(character);
            }

            return longestActualPrefix.ToString();
        }

        private static string GetShortestStringInList(IList<string> strings)
        {
            var shortestString = strings[0];
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i].Length < shortestString.Length)
                    shortestString = strings[i];
            }

            return shortestString;
        }

    }
}
