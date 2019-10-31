using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearLibrary.Trees.BST
{
    public class BinarySearchTree
    {
        private Node _root;

        public void Insert(int value)
        {
            var newNode = new Node(value);

            if (this._root == null)
            {
                this._root = newNode;
                return;
            }

            var current = this._root;
            while (true)
            {
                if (value < current.Value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = newNode;
                        break;
                    }
                    current = current.LeftChild;

                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = newNode;
                        break;
                    }
                    current = current.RightChild;
                }
            }
        }

        public bool FindIteratively(int value)
        {
            var current = this._root;
            while (current != null)
            {
                if (value < current.Value)
                    current = current.LeftChild;
                else if (value > current.Value)
                    current = current.RightChild;
                else
                    return true;
                ; }

            return false;
        }

        private bool IsLeaf(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        public void TraversePreOrder()
        {
            this.TraversePreOrder(this._root);
        }

        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.Value);
            this.TraversePreOrder(root.LeftChild);
            this.TraversePreOrder(root.RightChild);
        }

        public void TraverseInOrder()
        {
            this.TraverseInOrder(this._root);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            this.TraverseInOrder(root.LeftChild);
            Console.WriteLine(root.Value);
            this.TraverseInOrder(root.RightChild);
        }

        public void TraversePostOrder()
        {
            this.TraversePostOrder(this._root);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            this.TraversePostOrder(root.LeftChild);
            this.TraversePostOrder(root.RightChild);
            Console.WriteLine(root.Value);
        }

        public int Height()
        {
            if (this._root == null)
                return -1;

            return Height(this._root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (this.IsLeaf(root))
                return 0;

            return 1 + Math.Max(this.Height(root.LeftChild), this.Height(root.RightChild));
        }

        //O(log n)
        public int MinBst()
        {
            if (this._root == null)
                throw new InvalidOperationException();

            var current = this._root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.LeftChild;
            }

            return last.Value;
        }

        //O(n)
        public int MinNonBst()
        {
            return this.MinNonBst(this._root);
        }

        //O(n)
        private int MinNonBst(Node root)
        {
            if (this.IsLeaf(root))
                return root.Value;

            var left = this.MinNonBst(root.LeftChild);
            var right = this.MinNonBst(root.RightChild);

            return Math.Min(root.Value, Math.Min(left, right));
        }

        public bool Equals(BinarySearchTree secondTree)
        {
            if (this._root == null || secondTree == null || secondTree?._root == null)
                throw new InvalidOperationException();

            return this.Equals(this._root, secondTree._root);
        }

        private bool Equals(Node treeNode1, Node treeNode2)
        {
            if (treeNode1 == null && treeNode2 == null)
                return true;

            if(treeNode1 != null && treeNode2 != null)
            {
                return treeNode1.Value == treeNode2.Value 
                       && this.Equals(treeNode1.LeftChild, treeNode2.LeftChild) 
                       && this.Equals(treeNode1.RightChild, treeNode2.RightChild);
            }

            return false;
        }

        public bool IsBinarySearchTree()
        {
            return this.IsBinarySearchTree(this._root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if(root.Value < min || root.Value > max)
                return false;
            
            return this.IsBinarySearchTree(root.LeftChild, min, root.Value - 1)
                   && this.IsBinarySearchTree(root.RightChild, root.Value + 1, max);
        }

        public void MessUpBstBySwappingRootSubTrees()
        {
            var temp = this._root.LeftChild;
            this._root.LeftChild = this._root.RightChild;
            this._root.RightChild = temp;
        }

        public List<int> GetNodesAtKDistance(int distance)
        {
            List<int> valuesAtDistanceK = new List<int>();
            this.GetNodesAtKDistance(this._root, distance, valuesAtDistanceK);
            return valuesAtDistanceK;
        }

        private void GetNodesAtKDistance(Node root, int distance, List<int> list)
        {
            if (root == null)
                return;

            if(distance == 0)
            {
                list.Add(root.Value);
                return;
            }

            this.GetNodesAtKDistance(root.LeftChild, distance - 1, list);
            this.GetNodesAtKDistance(root.RightChild, distance - 1, list);
        }

        public void TraverseInLevelOrder()
        {
            for (var i = 0; i <= this.Height(); i++)
            {
                foreach (int nodeValue in this.GetNodesAtKDistance(i))
                    Console.WriteLine(nodeValue);
            }
        }

        public int Size()
        {
            return this.Size(this._root);
        }

        private int Size(Node root)
        {
            if (root == null)
                return 0;

            return 1 + Size(root.LeftChild) + Size(root.RightChild);
        }

        public int CountLeaves()
        {
            return this.CountLeaves(this._root);
        }

        private int CountLeaves(Node root)
        {
            if (root == null)
                return 0;

            if (this.IsLeaf(root))
                return 1;

            return CountLeaves(root.LeftChild) + CountLeaves(root.RightChild);
        }

        public int MaxBst()
        {
            if (this._root == null)
                throw new InvalidOperationException();

            return this.MaxBst(this._root);
        }

        private int MaxBst(Node root)
        {
            if (root.RightChild == null)
                return root.Value;

            return this.MaxBst(root.RightChild);
        }

        public bool FindRecursively(int valueToFind)
        {
            if (this._root == null)
                return false;

            return this.FindRecursively(this._root, valueToFind);
        }

        private bool FindRecursively(Node root, int valueToFind)
        {
            if (root == null)
                return false;

            return root.Value == valueToFind
                   || this.FindRecursively(root.LeftChild, valueToFind)
                   || this.FindRecursively(root.RightChild, valueToFind);
        }

        public bool AreSiblings(int value1, int value2)
        {
            if (this._root == null)
                return false;

            return this.AreSiblings(this._root, value1, value2);
        }

        private bool AreSiblings(Node root, int value1, int value2)
        {
            if (root == null)
                return false;

            if (root.LeftChild != null && root.RightChild != null)
                return (root.LeftChild.Value == value1 && root.RightChild.Value == value2)
                       || (root.LeftChild.Value == value2 && root.RightChild.Value == value1);

            return this.AreSiblings(root.LeftChild, value1, value2) || this.AreSiblings(root.RightChild, value1, value2);
        }

        public List<int> GetAncestors(int targetValue)
        {
            var ancestorList = new List<int>();
            this.GetAncestors(this._root, targetValue, ancestorList);
            return ancestorList;
        }

        private bool GetAncestors(Node root, int targetValue, List<int> currentAncestors)
        {
            if (root == null)
                return false;

            if (root.Value == targetValue)
                return true;

            var found = this.GetAncestors(root.LeftChild, targetValue, currentAncestors) || this.GetAncestors(root.RightChild, targetValue, currentAncestors);
            if (found)
                currentAncestors.Add(root.Value);

            return found;
        }

        public bool IsBalanced()
        {
            return IsBalanced(this._root);
        }

        private bool IsBalanced(Node root)
        {
            if (root == null)
                return true;

            var balanceFactor = this.Height(root.LeftChild) - this.Height(root.RightChild);

            return Math.Abs(balanceFactor) <= 1 &&
                    this.IsBalanced(root.LeftChild) &&
                    this.IsBalanced(root.RightChild);
        }

        public bool IsPerfect()
        {
            return this.Size() == (Math.Pow(2, this.Height() + 1) - 1);
        }

    }

    internal class Node
    {
        internal int Value { get; set; }

        internal Node LeftChild { get; set; }

        internal Node RightChild { get; set; }

        internal Node(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"Node = {this.Value}";
        }
    }
}
