using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Searching
{
    public static class ExponentialSearchExtension
    {
        public static int ExponentialSearch(this IList<int> inputList, int target)
        {
            int bound = 1;
            while (bound < inputList.Count && inputList[bound] < target)
                bound *= 2;

            int left = bound / 2;
            int right = Math.Min(bound, inputList.Count - 1);

            return BinarySearchExtension.BinarySearchRecursive(inputList, target, left, right);
        }
    }
}
