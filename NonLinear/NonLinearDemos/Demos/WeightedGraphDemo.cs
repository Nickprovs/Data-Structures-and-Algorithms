using CommonLibrary;
using NonLinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Demos
{
    public class WeightedGraphDemo : IRunnable
    {
        public void Run()
        {
            var weightedGraphA = new WeightedGraph();
            weightedGraphA.AddNode("A");
            weightedGraphA.AddNode("B");
            weightedGraphA.AddNode("C");
            weightedGraphA.AddNode("D");
            weightedGraphA.AddNode("E");

            weightedGraphA.AddEdge("A", "B", 1);
            weightedGraphA.AddEdge("B", "C", 1);
            weightedGraphA.AddEdge("B", "E", 12);
            weightedGraphA.AddEdge("C", "D", 1);
            weightedGraphA.AddEdge("D", "E", 1);
            weightedGraphA.AddEdge("A", "E", 10);

            weightedGraphA.Print();

            Console.WriteLine($"Shortest path from A to E: {string.Join(",", weightedGraphA.GetShortestPath("A", "E"))}");
            Console.WriteLine("");

            Console.WriteLine($"Does graph A have a cycle?: {weightedGraphA.HasCycle()}");
            Console.WriteLine("");

            Console.WriteLine("Creating Graph B");
            var weightedGraphB = new WeightedGraph();
            weightedGraphB.AddNode("A");
            weightedGraphB.AddNode("B");
            weightedGraphB.AddNode("C");

            weightedGraphB.AddEdge("A", "B", 1);
            weightedGraphB.AddEdge("B", "C", 1);

            weightedGraphB.Print();
            Console.WriteLine("");

            Console.WriteLine($"Does graph B have a cycle?: {weightedGraphB.HasCycle()}");
            Console.WriteLine("");

            Console.WriteLine("Creating Graph C");
            var weightedGraphC = new WeightedGraph();
            weightedGraphC.AddNode("A");
            weightedGraphC.AddNode("B");
            weightedGraphC.AddNode("C");
            weightedGraphC.AddNode("D");
            weightedGraphC.AddEdge("A", "B", 3);
            weightedGraphC.AddEdge("B", "D", 4);
            weightedGraphC.AddEdge("C", "D", 5);
            weightedGraphC.AddEdge("A", "C", 1);
            weightedGraphC.AddEdge("B", "C", 2);
            weightedGraphC.Print();
            Console.WriteLine("");

            Console.WriteLine($"Minimum Spanning Tree for Graph C: ");
            var minimumSpanningTreeC = weightedGraphC.GetMinimumSpanningTree();
            minimumSpanningTreeC.Print();



        }
    }
}
