using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.Stacks
{
    public class BalancedExpressions : IRunnable
    {
        public void Run()
        {
            //Balanced
            string balanced1 = "(1 + 2)";
            Console.WriteLine($"Checking String: {balanced1} - {this.IsBalanced(balanced1)}");

            string balanced2 = "(([1 + <2>]))[a]";
            Console.WriteLine($"Checking String: {balanced2} - {this.IsBalanced(balanced2)}");

            string notBalanced1 = "(1 + 2";
            Console.WriteLine($"Checking String: {notBalanced1} - {this.IsBalanced(notBalanced1)}");

            string notBalanced2 = ")1 + 2(";
            Console.WriteLine($"Checking String: {notBalanced2} - {this.IsBalanced(notBalanced2)}");

            string notBalanced3 = "(1 + 2>";
            Console.WriteLine($"Checking String: {notBalanced3} - {this.IsBalanced(notBalanced3)}");
        }

        public bool IsBalanced(string str)
        {
            List<char> openingCharacters = new List<char> { '(', '[', '<' };
            List<char> closingCharacters = new List<char> { ')', ']', '>' };

            Stack<char> stack = new Stack<char>();

            foreach(char character in str)
            {
                if (openingCharacters.Contains(character))
                    stack.Push(character);

                if (closingCharacters.Contains(character))
                {
                    var indexOfClosingCharacterInValidClosingSet = closingCharacters.IndexOf(character);
                    var associatedOpeningCharacter = openingCharacters[indexOfClosingCharacterInValidClosingSet];
                    if (stack.Count > 0 && stack.Peek() == associatedOpeningCharacter)
                        stack.Pop();
                    else
                        return false;
                }
            }

            if (stack.Count == 0)
                return true;
            else
                return false;
        }
    }
}
