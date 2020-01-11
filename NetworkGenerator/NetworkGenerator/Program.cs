using System;
using System.Collections.Generic;

namespace NetworkGenerator
{
    class Program
    {
        private const int VERTICAL = 2000;
        private const int AVG_VERTICAL_DEGREE = 2000;
        private const int MAX_VALUE = 100;
        private const int MIN_VALUE = 0;

        static void Main(string[] args)
        {
            NetworkGraph networkGraph = new NetworkGraph(
                VERTICAL,
                MAX_VALUE,
                MIN_VALUE,
                AVG_VERTICAL_DEGREE);
            networkGraph.GenerateRandomNetwork();
            var data = networkGraph.PrintNetwork();
            TextFile.Save("graph.txt", data);
        }
    }

    
}
