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
            weightedGraphA.AddEdge("A", "B", 3);
            weightedGraphA.AddEdge("A", "C", 2);

            weightedGraphA.Print();
        }
    }
}
