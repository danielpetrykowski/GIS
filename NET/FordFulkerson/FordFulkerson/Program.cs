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
            var maxFlow = flowGraph.FordFulkerson();
            Console.WriteLine(maxFlow);
        }
    }
}
