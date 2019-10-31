using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearLibrary.Trees.BST
{
    public class AvlTree
    {
        private AvlNode _root;

        public void Insert(int value)
        {
            this._root = this.Insert(this._root, value);
        }

        private AvlNode Insert(AvlNode root, int value)
        {
            if (root == null)
                return new AvlNode(value);

            if (value < root.Value)
                root.LeftChild = this.Insert(root.LeftChild, value);
            else
                root.RightChild = this.Insert(root.RightChild, value);

            this.SetNodeHeight(root);
            return this.Balance(root);
        }

        public void InsertWithoutBalancingForTest(int value)
        {
            this._root = this.InsertWithoutBalancingForTest(this._root, value);
        }

        private AvlNode InsertWithoutBalancingForTest(AvlNode root, int value)
        {
            if (root == null)
                return new AvlNode(value);

            if (value < root.Value)
                root.LeftChild = this.InsertWithoutBalancingForTest(root.LeftChild, value);
            else
                root.RightChild = this.InsertWithoutBalancingForTest(root.RightChild, value);

            this.SetNodeHeight(root);
            return root;
        }

        private AvlNode Balance(AvlNode root)
        {
            if (this.IsNodeLeftHeavy(root))
            {
                if (this.GetBalanceFactor(root.LeftChild) < 0)
                    root.LeftChild = this.RotateLeft(root.LeftChild);

                return this.RotateRight(root);
            }

            if (this.IsNodeRightHeavy(root))
            {
                if (this.GetBalanceFactor(root.RightChild) > 0)
                    root.RightChild = this.RotateRight(root.RightChild);

                return this.RotateLeft(root);
            }

            return root;
        }

        private AvlNode RotateLeft(AvlNode root)
        {
            var newRoot = root.RightChild;

            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;

            this.SetNodeHeight(root);
            this.SetNodeHeight(newRoot);

            return newRoot;
        }

        private AvlNode RotateRight(AvlNode root)
        {
            var newRoot = root.LeftChild;

            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;

            this.SetNodeHeight(root);
            this.SetNodeHeight(newRoot);

            return newRoot;
        }

        private bool IsNodeLeftHeavy(AvlNode node)
        {
             return this.GetBalanceFactor(node) > 1;
        }

        private bool IsNodeRightHeavy(AvlNode node)
        {
            return this.GetBalanceFactor(node) < -1;
        }

        private int GetBalanceFactor(AvlNode node)
        {
            if (node == null)
                return 0;

            return this.GetNodeHeight(node.LeftChild) -
                this.GetNodeHeight(node.RightChild);
        }

        private void SetNodeHeight(AvlNode node)
        {
            node.Height = 1 + Math.Max(this.GetNodeHeight(node.LeftChild), this.GetNodeHeight(node.RightChild));
        }

        private int GetNodeHeight(AvlNode node)
        {
            return node?.Height ?? -1;
        }

        public int Height()
        {
            if (this._root == null)
                return -1;

            return this.GetNodeHeight(this._root);
        }
        public int Size()
        {
            return this.Size(this._root);
        }

        private int Size(AvlNode root)
        {
            if (root == null)
                return 0;

            return 1 + Size(root.LeftChild) + Size(root.RightChild);
        }

        public bool IsBalanced()
        {
            return this.IsBalanced(this._root);
        }

        private bool IsBalanced(AvlNode root)
        {
            if (root == null)
                return true;

            return Math.Abs(this.GetBalanceFactor(root)) < 2 &&
                   this.IsBalanced(root.LeftChild) &&
                   this.IsBalanced(root.RightChild);
        }

        public bool IsPerfect()
        {
            return this.Size() == Math.Pow(2, this.Height() + 1) - 1;
        }

    }

    internal class AvlNode
    {
        internal int Value { get; set; }

        internal AvlNode LeftChild { get; set; }

        internal AvlNode RightChild { get; set; }

        internal int Height { get; set; }

        internal AvlNode(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"Node = {this.Value}";
        }
    }

}
