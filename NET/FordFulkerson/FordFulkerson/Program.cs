using FordFulkerson.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FordFulkerson
{
    class Program
    {
        private static long frequency = Stopwatch.Frequency;

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            
            List<string> fileLines = TextFile.ReadFileLines();
            FlowGraph flowGraph = new FlowGraph(fileLines);


            stopWatch.Start();
            var maxFlow = flowGraph.FordFulkerson();
            stopWatch.Stop();


            TimeSpan ts = stopWatch.Elapsed;
            var elapsedTime = (decimal) ts.Ticks / frequency;

            Console.WriteLine(maxFlow);
            Console.WriteLine($"RunTime " + elapsedTime.ToString("F10") + "s");
        }
    }
}
