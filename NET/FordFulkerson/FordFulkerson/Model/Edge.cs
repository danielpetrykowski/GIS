using System;
using System.Collections.Generic;
using System.Text;

namespace FordFulkerson.Model
{
    public class Edge
    {
        public Edge(int stratVertic, int endVertic, int capacity)
        {
            StartVertic = stratVertic;
            EndVertic = endVertic;
            Capacity = capacity;
            Flow = 0;
        }

        private readonly int StartVertic;
        private readonly int EndVertic;
        public int Capacity { get; set; }


        private int _flow;
        public int Flow
        {
            get
            {
                return _flow;
            }
            set
            {
                _flow = value;
                _availableFlow = Capacity - _flow;
            }
        }

        private int _availableFlow;
        public int AvailableFlow
        {
            get
            {
                return _availableFlow;
            }
            private set
            {
                _availableFlow = value;
                _flow = Capacity - _availableFlow;
            }
        }
    }
}
