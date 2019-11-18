using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Searching
{
    public static class BinarySearchExtension
    {
        public static int BinarySearchRecursive(this IList<int> inputList, int target)
        {
            return BinarySearchRecursive(inputList, target, 0, inputList.Count - 1); ;
        }

        public static int BinarySearchRecursive(IList<int> list, int target, int left, int right)
        {
            if (right < left)
                return -1;

            var middle = (left + right) / 2;

            if (list[middle] == target)
                return middle;

            if (target < list[middle])
                return BinarySearchRecursive(list, target, left, middle - 1);

            return BinarySearchRecursive(list, target, middle + 1, right);
        }

        public static int BinarySearchIterative(this IList<int> inputList, int target)
        {
            var left = 0;
            var right = inputList.Count - 1;

            while(left <= right)
            {
                var middle = (left + right) / 2;
                if (inputList[middle] == target)
                    return middle;

                if (target < inputList[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }
    }
}
