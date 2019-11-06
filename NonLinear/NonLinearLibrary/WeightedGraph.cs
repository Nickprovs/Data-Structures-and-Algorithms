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
    }
}
