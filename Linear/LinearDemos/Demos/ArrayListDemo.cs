using LinearLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonLibrary;

namespace LinearExperimentation.Demos
{
    public class ArrayListDemo : IRunnable
    {
        public void Run()
        {
            ArrayList myList = new ArrayList(3);
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);
            myList.Add(50);

            myList.RemoveAt(3);
            myList.Print();
            Console.WriteLine($"Index of 25: {myList.IndexOf(25)}");
            Console.WriteLine($"Index of 20: {myList.IndexOf(20)}");

            Console.WriteLine("Reversing");
            myList.Reverse();
            myList.Print();

            Console.WriteLine("Unreversing");
            myList.Reverse();
            myList.Print();

            Console.WriteLine("Inserting 40 back at index 3");
            myList.Insert(40, 3);
            myList.Print();

            List<int> secondaryList = new List<int> { 10, 5, 20, -1 };
            Console.Write($"Intersecting w/:  ");
            foreach (var number in secondaryList)
                Console.Write($"{number} ");
            Console.WriteLine("");

            var intersection = myList.Intersect(secondaryList).ToList();
            Console.Write($"Intersection: ");
            foreach (var number in intersection)
                Console.Write($"{number} ");
            Console.WriteLine("");

        }
    }
}
