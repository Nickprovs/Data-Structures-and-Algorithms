using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.Sets
{
    public class GetUniqueListFromListWithDuplicates : IRunnable
    {
        public void Run()
        {
            int[] listWithDuplicates = new int[] {1,1,2,3,3,3,4};
            Console.WriteLine($"List before using a set: {string.Join(",", listWithDuplicates)}");

            var listWithoutDuplicates = new HashSet<int>();
            foreach(var number in listWithDuplicates)
            {
                listWithoutDuplicates.Add(number);
            }

            Console.WriteLine($"List after using a set: {string.Join(",", listWithoutDuplicates)}");
        }
    }
}
