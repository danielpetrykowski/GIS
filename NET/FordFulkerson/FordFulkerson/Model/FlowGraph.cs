using System;
using System.Collections.Generic;
using System.Text;

namespace FordFulkerson.Model
{
    public class FlowGraph
    {
        public int Vertics { get; set; }
        public int Source { get; set; }
        public int Sink { get; set; }
        public Dictionary<int, List<Edge>> AdjacencyListArray;


        public FlowGraph(List<string> lines)
        {
            AdjacencyListArray = new Dictionary<int, List<Edge>>();
            Vertics = int.Parse(lines[0]);
            Source = int.Parse(lines[1]);
            Sink = int.Parse(lines[2]);

            for(int i = 0; i < Vertics; i++){
                List<Edge> neighboursList = new List<Edge>();
                AdjacencyListArray.Add(i, neighboursList);
            }

            for (int i = 0; i < Vertics; i++)
            {
                var tmp = lines[i + 3].Split(';');
                var capacities = Array.ConvertAll(tmp, s => int.Parse(s));
                for (int j = i+1; j < Vertics; j++)
                {
                    if (capacities[j] != 0)
                    {
                        Edge edge = new Edge(i,j,capacities[j]);
                        AdjacencyListArray[i].Add(edge);
                        AdjacencyListArray[j].Add(edge);
                    }
                }
            }        
        }
    }
}
