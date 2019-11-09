using CommonLibrary;
using NonLinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Demos
{
    public class GraphDemo : IRunnable
    {
        public void Run()
        {
            //this.PerformGraphBuilding();
            //this.PerformTraversals();
            this.PerformCycleCheckingAndTopologicalSorting();
        }

        private void PerformGraphBuilding()
        {
            var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.Print();
            Console.WriteLine("Removing A's Connection To C");
            graph.RemoveEdge("A", "C");
            graph.Print();
            Console.WriteLine("Removing A's Connection To Non-Existent edge, D");
            graph.RemoveEdge("A", "D");
            graph.Print();
            Console.WriteLine("Removing Node B");
            graph.RemoveNode("B");
            graph.Print();
            Console.WriteLine("Removing Node A");
            graph.RemoveNode("A");
            graph.Print();
        }

        private void PerformTraversals()
        {
            var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");

            graph.AddEdge("A", "B");
            graph.AddEdge("B", "D");
            graph.AddEdge("D", "C");
            graph.AddEdge("A", "C");

            graph.Print();
            Console.WriteLine("");

            Console.WriteLine("Traversing Depth-First Recursively starting from A");
            graph.TraverseDepthFirstRecursive("A");
            Console.WriteLine("");

            Console.WriteLine("Traversing Depth-First Recursively Starting From C");
            graph.TraverseDepthFirstRecursive("C");
            Console.WriteLine("");

            Console.WriteLine("Traversing Depth-First Iteratively starting from A");
            graph.TraverseDepthFirstIterative("A");
            Console.WriteLine("");

            Console.WriteLine("Traversing Depth-First Iteratively Starting From C");
            graph.TraverseDepthFirstIterative("C");
            Console.WriteLine("");

            Console.WriteLine("Traversing Breadth-First Iteratively starting from A");
            graph.TraverseBreadthFirstIterative("A");
            Console.WriteLine("");

            Console.WriteLine("Traversing Breadth-First Iteratively Starting From C");
            graph.TraverseBreadthFirstIterative("C");
            Console.WriteLine("");
        }

        private void PerformCycleCheckingAndTopologicalSorting()
        {
            //Graph X... No Cycles
            var graphX = new Graph();
            graphX.AddNode("X");
            graphX.AddNode("A");
            graphX.AddNode("B");
            graphX.AddNode("P");
            graphX.AddEdge("X", "A");
            graphX.AddEdge("X", "B");
            graphX.AddEdge("A", "P");
            graphX.AddEdge("B", "P");

            Console.WriteLine("Graph X");
            graphX.Print();

            Console.WriteLine($"Checking if graph X has a cycle: {graphX.HasCycle()}");
            Console.WriteLine("Performing topological order on this new graph");
            Console.WriteLine("");
            Console.WriteLine(string.Join(",", graphX.TopologicalSort()));
            Console.WriteLine("");

            //Graph Y... Has A Cycle
            var graphY = new Graph();
            graphY.AddNode("A");
            graphY.AddNode("B");
            graphY.AddNode("C");
            graphY.AddEdge("A", "B");
            graphY.AddEdge("B", "C");
            graphY.AddEdge("C", "A");

            Console.WriteLine("Graph Y");
            graphY.Print();
            Console.WriteLine($"Checking if graph Y has a cycle: {graphY.HasCycle()}");
            Console.WriteLine("");
        }
    }
}
