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
            if (left > right)
                return -1;

            int partitionSize = (right - left) / 3;
            int mid1 = left + partitionSize;
            int mid2 = right - partitionSize;

            if (list[mid1] == target)
                return mid1;

            if (list[mid2] == target)
                return mid2;

            if (target < list[mid1])
                return TernarySearch(list, target, left, mid1 - 1);

            if (target > list[mid2])
                return TernarySearch(list, target, mid2 + 1, right);

            return TernarySearch(list, target, mid1 + 1, mid2 - 1);
        }
    }
}
