using CommonLibrary;
using NonLinearLibrary.Trees.BST;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Demos
{
    public class AvlDemo : IRunnable
    {
        public void Run()
        {
            BinarySearchTree myNonBalancingBinarySearchTree = new BinarySearchTree();
            myNonBalancingBinarySearchTree.Insert(10);
            myNonBalancingBinarySearchTree.Insert(30);
            myNonBalancingBinarySearchTree.Insert(20);
            myNonBalancingBinarySearchTree.Insert(40);
            myNonBalancingBinarySearchTree.Insert(60);
            myNonBalancingBinarySearchTree.Insert(50);
            myNonBalancingBinarySearchTree.Insert(70);
            myNonBalancingBinarySearchTree.Insert(80);
            myNonBalancingBinarySearchTree.Insert(90);
            myNonBalancingBinarySearchTree.Insert(5);
            myNonBalancingBinarySearchTree.Insert(34);

            AvlTree mySelfBalancingBinarySearchTree = new AvlTree();
            mySelfBalancingBinarySearchTree.Insert(10);
            mySelfBalancingBinarySearchTree.Insert(30);
            mySelfBalancingBinarySearchTree.Insert(20);
            mySelfBalancingBinarySearchTree.Insert(40);
            mySelfBalancingBinarySearchTree.Insert(60);
            mySelfBalancingBinarySearchTree.Insert(50);
            mySelfBalancingBinarySearchTree.Insert(70);
            mySelfBalancingBinarySearchTree.Insert(80);
            mySelfBalancingBinarySearchTree.Insert(90);
            mySelfBalancingBinarySearchTree.Insert(5);
            mySelfBalancingBinarySearchTree.Insert(34);

            Console.WriteLine($"Checking if my non balancing bst is balanced: {myNonBalancingBinarySearchTree.IsBalanced()}");
            Console.WriteLine($"Checking if my avl tree is balanced: {mySelfBalancingBinarySearchTree.IsBalanced()}");
        }
    }
}
