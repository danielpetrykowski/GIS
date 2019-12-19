using System;
using System.Collections.Generic;
using System.Text;

namespace FordFulkerson.Model
{
    public class Edge
    {
        public Edge(int fromVer, int toVer, int capacity)
        {
            FromVertic = fromVer;
            ToVertic = toVer;
            Capacity = capacity;
            Direction = 0;
            Flow = 0;
        }

        public int FromVertic { get; private set; }
        public int ToVertic { get; private set; }
        public int Capacity { get; private set; }
        private int Direction { get; set; }


        public void SetFlow(int toVertic, int flow)
        {
            if (toVertic != FromVertic && toVertic != ToVertic)
                throw new Exception($"This edge isn't connected with {toVertic} vertic");
            Flow = flow;
            if (toVertic == ToVertic)
                Direction = 1;
            else
                Direction = -1;
        }

        private int _flow;
        public int Flow
        {
            get
            {
                return Direction * _flow;
            }
            private set
            {
                _flow = value;
                _residualCapacity = Capacity - _flow;
            }
        }

        private int _residualCapacity;
        public int ResidualCapcity
        {
            get
            {
                return Direction * _residualCapacity;
            }
            private set
            {
                _residualCapacity = value;
                _flow = Capacity - _residualCapacity;
            }
        }


    }
}
