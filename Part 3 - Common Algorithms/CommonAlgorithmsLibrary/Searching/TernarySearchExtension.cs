using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Searching
{
    public static class TernarySearchExtension
    {
        public static int TernarySearch(this IList<int> inputList, int target)
        {
            return TernarySearch(inputList, target, 0, inputList.Count - 1); ;
        }

        private static int TernarySearch(IList<int> list, int target, int left, int right)
        {
            return -1;
        }
    }
}
