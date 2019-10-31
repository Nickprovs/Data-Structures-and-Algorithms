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
            myList.AddLast(10);
            myList.AddLast(20);
            myList.AddLast(30);
            myList.AddLast(40);
            myList.AddLast(50);
            myList.AddLast(60);

            //Console.WriteLine($"Index of 10: {myList.IndexOf(10)}");
            //Console.WriteLine($"Index of 20: {myList.IndexOf(20)}");
            //Console.WriteLine($"Index of 30: {myList.IndexOf(30)}");
            //Console.WriteLine($"Index of 4: {myList.IndexOf(4)}");

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

        }
    }
}
