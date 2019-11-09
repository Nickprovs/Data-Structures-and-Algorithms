using CommonLibrary;
using NonLinearLibrary.Trees.BST;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Demos
{
    public class BstDemo : IRunnable
    {
        public void Run()
        {
            BinarySearchTree myBst1 = new BinarySearchTree();
            myBst1.Insert(7);
            myBst1.Insert(4);
            myBst1.Insert(9);
            myBst1.Insert(1);
            myBst1.Insert(6);
            myBst1.Insert(8);
            myBst1.Insert(10);

            BinarySearchTree myBst2 = new BinarySearchTree();
            myBst2.Insert(7);
            myBst2.Insert(4);
            myBst2.Insert(9);
            myBst2.Insert(1);
            myBst2.Insert(6);
            myBst2.Insert(8);
            myBst2.Insert(10);

            Console.WriteLine("Pre-Order Traversal");
            myBst1.TraversePreOrder();
            Console.WriteLine("");

            Console.WriteLine("In-Order Traversal");
            myBst1.TraverseInOrder();
            Console.WriteLine("");

            Console.WriteLine("Post-Order Traversal");
            myBst1.TraversePostOrder();
            Console.WriteLine("");

            Console.WriteLine($"Height of our tree: {myBst1.Height()}");
            Console.WriteLine("");

            Console.WriteLine($"Min of our tree: {myBst1.MinNonBst()}");
            Console.WriteLine("");


            Console.WriteLine($"Checking if Tree 1 and 2 are Equal: {myBst1.Equals(myBst2)}");
            Console.WriteLine("");

            //myBst1.MessUpBstBySwappingRootSubTrees();
            Console.WriteLine($"Checking if Tree 1 is a BST: {myBst1.IsBinarySearchTree()}");
            Console.WriteLine("");

            Console.WriteLine($"Getting Nodes at Distance 2: {string.Join(",",myBst1.GetNodesAtKDistance(2))}");
            Console.WriteLine("");

            Console.WriteLine("Level-Order Traversal:");
            myBst1.TraverseInLevelOrder();
            Console.WriteLine("");

            Console.WriteLine($"Size of Tree 1: {myBst1.Size()}");
            Console.WriteLine("");

            Console.WriteLine($"Num Leaves in Tree 1: {myBst1.CountLeaves()}");
            Console.WriteLine("");

            Console.WriteLine($"Max in BST Tree 1 using Recursion: {myBst1.MaxBst()}");
            Console.WriteLine("");

            Console.WriteLine($"Finding 9 Iteratively: {myBst1.FindIteratively(9)}");
            Console.WriteLine("");

            Console.WriteLine($"Finding 9 Recursively: {myBst1.FindRecursively(9)}");
            Console.WriteLine("");

            var eightsAncestors = myBst1.GetAncestors(8);
            Console.WriteLine($"Finding Ancestors of 8: {string.Join(",", eightsAncestors)}");
            Console.WriteLine("");

        }
    }
}
