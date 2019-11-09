using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearLibrary
{
    public class WeightedGraph
    {
        private class Node
        {
            internal string Label;
            internal List<Edge> Edges;
            public Node(string label)
            {
                this.Edges = new List<Edge>();
                this.Label = label;
            }
            public override string ToString()
            {
                return this.Label;
            }
            public void AddEdge(Node to, int weight)
            {
                this.Edges.Add(new Edge(this, to, weight));
            }
            public List<Edge> GetEdges()
            {
                return this.Edges;
            }
        }

        private class Edge
        {
            internal Node From;
            internal Node To;
            internal int Weight;
            public Edge(Node from, Node to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }
            public override string ToString()
            {
                return $"{From} -> {To}, Weight: {Weight}";
            }
        }

        private class NodeEntry
        {
            internal Node Node;
            internal int Priority;

            public NodeEntry(Node node, int priority)
            {
                this.Node = node;
                this.Priority = priority;
            }
        }
        private class NodeEntryComparer : IComparer<NodeEntry>
        {
            public int Compare(NodeEntry x, NodeEntry y)
            {
                if (x.Priority > y.Priority)
                    return -1;
                if (x.Priority < y.Priority)
                    return 1;
                else
                    return 0;
            }
        }
        private class EdgeComparer : IComparer<Edge>
        {
            public int Compare(Edge x, Edge y)
            {
                if (x.Weight > y.Weight)
                    return -1;
                if (x.Weight < y.Weight)
                    return 1;
                else
                    return 0;
            }
        }

        private Dictionary<string, Node> _nodes;

        public WeightedGraph()
        {
            this._nodes = new Dictionary<string, Node>();
        }
        public void AddNode(string label)
        {
            if (!this._nodes.ContainsKey(label))
                this._nodes.Add(label, new Node(label));
        }

        public void AddEdge(string from, string to, int weight)
        {
            this._nodes.TryGetValue(from, out var fromNode);
            if (fromNode == null)
                throw new ArgumentException("From is not a valid node");

            this._nodes.TryGetValue(to, out var toNode);
            if (toNode == null)
                throw new InvalidOperationException("To is not a valid node");

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public void Print()
        {
            foreach (var node in this._nodes.Values)
            {
                var targets = node.GetEdges();
                if (targets.Count > 0)
                    Console.WriteLine($"{node} is connected to: {string.Join(",", targets)}");
            }
        }

        public List<string> GetShortestPath(string from, string to)
        {
            Dictionary<Node, int> distances = new Dictionary<Node, int>();
            foreach (var node in this._nodes.Values)
                distances.Add(node, int.MaxValue);

            var fromNode = this._nodes[from];
            if (fromNode == null)
                throw new ArgumentException(nameof(from));

            var toNode = this._nodes[to];
            if (toNode == null)
                throw new ArgumentException(nameof(to));

            distances[fromNode] = 0;

            Dictionary<Node, Node> previousNodes = new Dictionary<Node, Node>();

            HashSet<Node> visited = new HashSet<Node>();

            SortedSet<NodeEntry> queue = new SortedSet<NodeEntry>(new NodeEntryComparer());
            queue.Add(new NodeEntry(fromNode, 0));

            while (queue.Count > 0)
            {
                var current = queue.Max.Node;
                queue.Remove(queue.Max);

                visited.Add(current);
                foreach (var edge in current.GetEdges())
                {
                    if (visited.Contains(edge.To))
                        continue;

                    var newDistance = distances[current] + edge.Weight;
                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        previousNodes[edge.To] = current;
                        queue.Add(new NodeEntry(edge.To, newDistance));
                    }
                }
            }

            return this.BuildPath(toNode, previousNodes);
        }

        private List<string> BuildPath(Node toNode, Dictionary<Node, Node> previousNodes)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(toNode);
            previousNodes.TryGetValue(toNode, out var previous);
            while (previous != null)
            {
                stack.Push(previous);
                previousNodes.TryGetValue(previous, out previous);
            }

            List<string> path = new List<string>();
            while (stack.Count > 0)
                path.Add(stack.Pop().Label);

            return path;
        }

        public bool HasCycle()
        {
            var visited = new List<Node>();

            foreach (var node in this._nodes.Values)
            {
                if (!visited.Contains(node) && this.HasCycle(node, null, visited))
                    return true;     
            }

            return false;
        }
        private bool HasCycle(Node currentNode, Node parentNode, List<Node> visited)
        {
            visited.Add(currentNode);

            foreach (var edge in currentNode.GetEdges())
            {
                var neighbor = edge.To;
                if (neighbor == parentNode)
                    continue;

                if (visited.Contains(neighbor) || this.HasCycle(neighbor, currentNode, visited))
                    return true;
            }

            return false;
        }
        public WeightedGraph GetMinimumSpanningTree()
        {
            var tree = new WeightedGraph();

            if (this._nodes.Count == 0)
                return tree;

            //We use a sorted set since C# doesn't have priority queue.
            //Max will be the edge w/ the minimum weight due to our custom edge comparer.
            var edges = new SortedSet<Edge>(new EdgeComparer());

            if (edges.Count == 0)
                return tree;

            //A way to get first item in the hash-table...
            //...w /o converting whole thing to array
            var enumerator = this._nodes.Values.GetEnumerator();
            enumerator.MoveNext();
            var startNode = enumerator.Current;

            foreach (var edge in startNode.GetEdges())
                edges.Add(edge);

            tree.AddNode(startNode.Label);

            while(tree._nodes.Count < this._nodes.Count)
            {
                var minEdge = edges.Max;
                edges.Remove(edges.Max);

                var nextNode = minEdge.To;

                if (tree.ContainsNode(nextNode.Label))
                    continue;

                tree.AddNode(nextNode.Label);
                tree.AddEdge(minEdge.From.Label, nextNode.Label, minEdge.Weight);

                foreach(var edge in nextNode.GetEdges())
                {
                    if (!tree.ContainsNode(edge.To.Label))
                        edges.Add(edge);
                }
            }

            return tree;
        }

        public bool ContainsNode(string label)
        {
            return this._nodes.ContainsKey(label);
        }
    }
}
