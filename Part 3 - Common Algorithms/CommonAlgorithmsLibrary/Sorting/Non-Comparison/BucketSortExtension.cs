using LinearLibrary.LinkedListSingle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonAlgorithmsLibrary.Sorting.Non_Comparison
{
    public static class BucketSortExtension
    {
        public static void BucketSort(this IList<int> inputList, int numBuckets)
        {
            var buckets = CreateBuckets(inputList, numBuckets);

            var a = 0;
            foreach(var bucket in buckets)
            {
                bucket.Sort();
                while (!bucket.IsEmpty())
                    inputList[a++] = bucket.RemoveFirst();
            }
            
        }

        private static List<LinkedListSingle> CreateBuckets(IList<int> inputList, int numBuckets)
        {
            //.NET has no in-place sorting for a linked list. 
            //So we're using our own linked list which does have a sort implementation.
            var buckets = new List<LinkedListSingle>();
            for (int i = 0; i < numBuckets; i++)
                buckets.Add(new LinkedListSingle());

            foreach (var item in inputList)
                buckets[item / numBuckets].AddLast(item);

            return buckets;
        }

    }
}
