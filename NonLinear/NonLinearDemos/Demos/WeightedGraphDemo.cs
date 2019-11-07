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
        }
    }
}
