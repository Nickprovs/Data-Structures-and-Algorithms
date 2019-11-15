using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Searching
{
    public static class LinearSearchExtension
    {
        public static int LinearSearch(this IList<int> inputList, int target)
        {
            for(int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i] == target)
                    return i;
            }

            return -1;
        }
    }
}
