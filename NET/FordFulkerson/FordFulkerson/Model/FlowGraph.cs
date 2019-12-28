using System;
using System.Collections.Generic;
using System.Text;

namespace FordFulkerson.Model
{
    public class FlowGraph
    {
        public int Vertics { get; private set; }
        public int Source { get; private set; }
        public int Sink { get; private set; }
        private readonly Dictionary<int, List<int>> AdjacencyListArray;
        private readonly Dictionary<Tuple<int, int>, Edge> Edges;


        public FlowGraph(List<string> lines)
        {
            AdjacencyListArray = new Dictionary<int, List<int>>();
            Edges = new Dictionary<Tuple<int, int>, Edge>();
            Vertics = int.Parse(lines[0]);
            Source = int.Parse(lines[1]);
            Sink = int.Parse(lines[2]);

            for (int i = 0; i < Vertics; i++)
            {
                AdjacencyListArray.Add(i, new List<int>());
            }

            for (int i = 0; i < Vertics; i++)
            {
                var tmp = lines[i + 3].Split(';');
                var capacities = Array.ConvertAll(tmp, s => int.Parse(s));
                for (int j = 0; j < Vertics; j++)
                {
                    if (i == j || capacities[j] == 0)
                        continue;


                    if (Edges.ContainsKey(new Tuple<int, int>(i, j)))
                    {
                        var updateCapacityEdge = Edges[new Tuple<int, int>(i, j)];
                        updateCapacityEdge.Capacity = capacities[j];
                        updateCapacityEdge.Flow = 0;
                        continue;
                    }

                    Edge edge = new Edge(i, j, capacities[j]);
                    AdjacencyListArray[i].Add(j);
                    Edges.Add(new Tuple<int, int>(i, j), edge);

                    edge = new Edge(j, i, 0);
                    AdjacencyListArray[j].Add(i);
                    Edges.Add(new Tuple<int, int>(j, i), edge);
                }
            }
        }


        public int FordFulkerson()
        {
            var maxFlow = 0;
            var extendedPath = FindExtendedPath();
            while (extendedPath != null)
            {
                var valueFlowToUpdate = GetExtendedFlow(extendedPath);
                UpdateFlow(extendedPath, valueFlowToUpdate);
                maxFlow += valueFlowToUpdate;
                extendedPath = FindExtendedPath();
            }

            return maxFlow;
        }

        private List<int>? FindExtendedPath()
        {
            Queue<QueueElement> queueVerticsToVisite = new Queue<QueueElement>();
            bool[] visitedVeertics = new bool[Vertics];

            queueVerticsToVisite.Enqueue(new QueueElement(Source, new List<int> { Source }));
            visitedVeertics[Source] = true;


            while (queueVerticsToVisite.Count > 0)
            {
                QueueElement queueElement = queueVerticsToVisite.Dequeue();
                var enumerator = AdjacencyListArray[queueElement.IdVertic].GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var vertic = enumerator.Current;
                    if (visitedVeertics[vertic] 
                        || Edges[new Tuple<int, int>(queueElement.IdVertic, vertic)].AvailableFlow == 0)
                        continue;
                    var path = new List<int>(queueElement.GetVerticPath());
                    path.Add(vertic);

                    if (vertic == Sink)
                    {
                        return path;
                    }

                    queueVerticsToVisite.Enqueue(new QueueElement(vertic, path));
                    visitedVeertics[vertic] = true;
                }
            }
            return null;
        }


        private int GetExtendedFlow(List<int> path)
        {
            int minAvailableFlow = int.MaxValue;
            var startVertic = path[0];
            for(int i = 1; i < path.Count; i++)
            {
                var endVertic = path[i];
                if(minAvailableFlow > Edges[new Tuple<int, int>(startVertic, endVertic)].AvailableFlow)
                {
                    minAvailableFlow = Edges[new Tuple<int, int>(startVertic, endVertic)].AvailableFlow;
                }
                startVertic = endVertic;
            }

            return minAvailableFlow;
        }


        private void UpdateFlow(List<int> path, int valueFlow)
        {
            var startVertic = path[0];
            for (int i = 1; i < path.Count; i++)
            {
                var endVertic = path[i];

                Edges[new Tuple<int, int>(startVertic, endVertic)].Flow 
                    = Edges[new Tuple<int, int>(startVertic, endVertic)].Flow + valueFlow;
                Edges[new Tuple<int, int>(endVertic, startVertic)].Flow
                    = Edges[new Tuple<int, int>(endVertic, startVertic)].Flow - valueFlow;

                startVertic = endVertic;
            }
        }
    }
}
