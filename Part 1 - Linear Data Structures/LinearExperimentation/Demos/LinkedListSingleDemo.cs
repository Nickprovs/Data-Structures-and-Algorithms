using LinearLibrary;
using LinearLibrary.LinkedListSingle;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Demos
{
    public class LinkedListSingleDemo : IRunnable
    {
        public void Run()
        {
            LinkedListSingle myList = new LinkedListSingle();
            myList.AddLast(33);
            myList.AddLast(4);
            myList.AddLast(377);
            myList.AddLast(2);
            myList.AddLast(1);

            //Console.WriteLine($"Index of 9: {myList.IndexOf(9)}");

            //Console.WriteLine($"Size: {myList.Size()}");
            //Console.WriteLine("Removing Last");
            //myList.RemoveLast();
            //Console.WriteLine($"Size: {myList.Size()}");

            //Console.WriteLine("Reversing");
            //myList.Reverse();
            Console.WriteLine($"Kth from end where K = 2: {myList.GetKthFromTheEnd(2)}");

            myList.PrintMiddle();

            Console.WriteLine("Creating List W/ Loop");
            var myListWithLoop = LinkedListSingle.CreateWithLoop();
            Console.WriteLine($"Detecting if created list has loop: {myListWithLoop.HasLoop()}");

            Console.WriteLine("Sorting Linked List...");
            myList.Sort();     
        }
    }
}
