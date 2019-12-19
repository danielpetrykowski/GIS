using FordFulkerson.Model;
using System;
using System.Collections.Generic;

namespace FordFulkerson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fileLines = TextFile.ReadFileLines();
            FlowGraph flowGraph = new FlowGraph(fileLines);
            var toVer = flowGraph.AdjacencyListArray[0][0].ToVertic;
            flowGraph.AdjacencyListArray[0][0].SetFlow(toVer, 5);
            Console.WriteLine("dfg");
        }
    }
}
