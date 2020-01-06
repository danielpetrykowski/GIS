using FordFulkerson.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace FordFulkerson
{
    class Program
    {
        private const string TEST_EXAMPLES_DIRECTOR = "test";
        private static long frequency = Stopwatch.Frequency;

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            var exampleNetworkPath = Directory.GetCurrentDirectory() + "\\" + TEST_EXAMPLES_DIRECTOR;
            var filesPath = Directory.GetFiles(exampleNetworkPath);

            foreach(string filePath in filesPath)
            {
                List<string> fileLines = TextFile.ReadFileLines(filePath);
                FlowGraph flowGraph = new FlowGraph(fileLines);


                stopWatch.Start();
                var maxFlow = flowGraph.FordFulkerson();
                stopWatch.Stop();


                TimeSpan ts = stopWatch.Elapsed;
                var elapsedTime = (decimal)ts.Ticks / frequency;

                Console.WriteLine($"{maxFlow}; " + elapsedTime.ToString("F10"));
                stopWatch.Restart();
            }
            
            Console.ReadLine();
        }
    }
}
