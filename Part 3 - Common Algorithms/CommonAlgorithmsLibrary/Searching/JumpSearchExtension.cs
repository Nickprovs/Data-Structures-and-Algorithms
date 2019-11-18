using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Searching
{
    public static class JumpSearchExtension
    {
        public static int JumpSearch(this IList<int> inputList, int target)
        {
            int blockSize = (int)Math.Sqrt(inputList.Count);
            int start = 0;
            int next = blockSize;

            while (start < inputList.Count &&
                    inputList[next - 1] < target)
            {
                start = next;
                next += blockSize;
                if (next > inputList.Count)
                    next = inputList.Count;
            }

            for (var i = start; i < next; i++)
                if (inputList[i] == target)
                    return i;

            return -1;
        }
    }
}
