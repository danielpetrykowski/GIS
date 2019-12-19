using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkGenerator
{
    public class NetworkGraph
    {
        private int maxValue;
        private int minValue;
        private int avgVerticalDegree;
        public NetworkGraph(
            int vertical,
            int maxValue,
            int minValue,
            int avgVerticalDegree)
        {
            Vertical = vertical;
            this.maxValue = maxValue;
            this.minValue = minValue;
            this.avgVerticalDegree = avgVerticalDegree;
        }

        public int Vertical { get; set; }
        public int Source { get; set; }
        public int Target { get; set; }
        public Matrix Matrix { get; set; }


        public void GenerateRandomNetwork()
        {
            var random = new Random();
            var gausian = new Gaussian(avgVerticalDegree, 10);
            Matrix = new Matrix(Vertical, Vertical);
            for (int row = 0; row < Vertical; row++)
            {
                var degree = (int)gausian.NextGaussian();
                if (degree <= 0) degree = 1;
                if (degree > Vertical) degree = Vertical;
                for (int d = 0; d < degree; d++)
                {
                    var col = random.Next(0, Vertical - 1);
                    while (col == row)
                    {
                        col = random.Next(0, Vertical - 1);
                    }
                    Matrix.SetValue(row, col, random.Next(minValue, maxValue));
                }
            }
            Matrix.RemoveDuplicateEdge();
            Source = random.Next(1, Vertical);
            Target = random.Next(1, Vertical);
        }

        public string PrintNetwork()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Vertical.ToString());
            stringBuilder.AppendLine(Source.ToString());
            stringBuilder.AppendLine(Target.ToString());
            for (int r = 0; r < Matrix.row; r++)
            {
                for (int c = 0; c < Matrix.col; c++)
                {
                    stringBuilder.Append(Matrix.GetValue(r, c));
                    if(c!= (Matrix.col - 1))
                        stringBuilder.Append(";");
                }
                stringBuilder.AppendLine();
            }
            Console.WriteLine(stringBuilder.ToString());
            return stringBuilder.ToString();
        }
    }
}
