using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearLibrary
{
    public class Graph
    {
        private class Node
        {
            internal string Label;
            public Node(string label)
            {
                this.Label = label;
            }

            public override string ToString()
            {
                return this.Label;
            }
        }

        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> _adjacencyList = new Dictionary<Node, List<Node>>();
        public void AddNode(string label)
        {
            var node = new Node(label);
            if (!this._nodes.ContainsKey(label))
            {
                this._nodes.Add(label, node);
                this._adjacencyList.Add(node, new List<Node>());
            }
        }
        public void AddEdge(string from, string to)
        {
            this._nodes.TryGetValue(from, out var fromNode);
            if (fromNode == null)
                throw new ArgumentException("From is not a valid node");

            this._nodes.TryGetValue(to, out var toNode);
            if (toNode == null)
                throw new InvalidOperationException("To is not a valid node");

            this._adjacencyList[fromNode].Add(toNode);
        }
        public void RemoveNode(string label)
        {
            this._nodes.TryGetValue(label, out var nodeToRemove);
            if (nodeToRemove == null)
                return;

            //Remove this node from the edge list of all other nodes
            foreach (var node in this._adjacencyList.Keys)
                this._adjacencyList[node].Remove(nodeToRemove);

            this._adjacencyList.Remove(nodeToRemove);
            this._nodes.Remove(nodeToRemove.Label);
        }
        public void RemoveEdge(string from, string to)
        {
            this._nodes.TryGetValue(from, out var fromNode);
            this._nodes.TryGetValue(to, out var toNode);

            if (fromNode == null || toNode == null)
                return;

            this._adjacencyList[fromNode].Remove(toNode);
        }   
        public void Print()
        {
            foreach(var source in this._adjacencyList.Keys)
            {
                this._adjacencyList.TryGetValue(source, out var targets);
                if (targets != null && targets.Count > 0)
                    Console.WriteLine($"{source} is connected to: {string.Join(",", targets)}");
            }
        }
        public void TraverseDepthFirstRecursive(string start)
        {
            this._nodes.TryGetValue(start, out var startNode);
            if (startNode == null)
                return;

            this.TraverseDepthFirstRecursive(startNode, new HashSet<Node>());
        }

        private void TraverseDepthFirstRecursive(Node root, HashSet<Node> visited)
        {
            Console.WriteLine(root);
            visited.Add(root);

            foreach(var neighboringNode in this._adjacencyList[root])
            {
                if (!visited.Contains(neighboringNode))
                    this.TraverseDepthFirstRecursive(neighboringNode, visited);
            }
        }
        public void TraverseDepthFirstIterative(string start)
        {
            this._nodes.TryGetValue(start, out var startNode);
            if (startNode == null)
                return;

            Stack<Node> processingStack = new Stack<Node>();
            processingStack.Push(startNode);
            HashSet<Node> visitedNodes = new HashSet<Node>();

            while(processingStack.Count > 0)
            {
                var current = processingStack.Pop();
                if (visitedNodes.Contains(current))
                    continue;

                Console.WriteLine(current);
                visitedNodes.Add(current);

                foreach(var neighboringNode in this._adjacencyList[current])
                {
                    if (!visitedNodes.Contains(neighboringNode))
                        processingStack.Push(neighboringNode);
                }
            }
        }
        public void TraverseBreadthFirstIterative(string start)
        {
            this._nodes.TryGetValue(start, out var startNode);
            if (startNode == null)
                return;

            Queue<Node> processingQueue = new Queue<Node>();
            processingQueue.Enqueue(startNode);
            HashSet<Node> visitedNodes = new HashSet<Node>();

            while (processingQueue.Count > 0)
            {
                var current = processingQueue.Dequeue();
                if (visitedNodes.Contains(current))
                    continue;

                Console.WriteLine(current);
                visitedNodes.Add(current);

                foreach (var neighboringNode in this._adjacencyList[current])
                {
                    if (!visitedNodes.Contains(neighboringNode))
                        processingQueue.Enqueue(neighboringNode);
                }
            }
        }
        public List<string> TopologicalSort()
        {
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();

            foreach (var node in this._nodes.Values)
                this.TopologicalSort(node, visited, stack);

            var sorted = new List<string>();
            while (stack.Count > 0)
                sorted.Add(stack.Pop().Label);

            return sorted;
        }

        private void TopologicalSort(Node currentNode, HashSet<Node> visited, Stack<Node> stack)
        {
            if (visited.Contains(currentNode))
                return;

            visited.Add(currentNode);

            foreach(var neighboringNode in this._adjacencyList[currentNode])         
                this.TopologicalSort(neighboringNode, visited, stack);     

            stack.Push(currentNode);
        }

        public bool HasCycle()
        {
            HashSet<Node> starting = new HashSet<Node>();
            foreach (var node in this._nodes.Values)
                starting.Add(node);

            HashSet<Node> visiting = new HashSet<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            while(starting.Count != 0)
            {
                //A way to get first item in the hash-table...
                //...w /o converting whole thing to array
                //Note how we get a new enumerator after each deletion...
                var enumerator = starting.GetEnumerator();
                enumerator.MoveNext();
                var currentNode = enumerator.Current;
                if (this.HasCycle(currentNode, starting, visiting, visited))
                    return true;
            }

            return false;
        }
        private bool HasCycle(Node currentNode, HashSet<Node> starting, HashSet<Node> visiting, HashSet<Node> visited)
        {
            starting.Remove(currentNode);
            visiting.Add(currentNode);

            foreach(var neighboringNode in this._adjacencyList[currentNode])
            {
                if (visited.Contains(neighboringNode))
                    continue;

                if (visiting.Contains(neighboringNode))
                    return true;

                if (this.HasCycle(neighboringNode, starting, visiting, visited))
                    return true;
            }

            visiting.Remove(currentNode);
            visited.Add(currentNode);

            return false;
        }
    }
}
