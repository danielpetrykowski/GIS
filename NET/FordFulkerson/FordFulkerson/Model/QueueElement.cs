using System;
using System.Collections.Generic;
using System.Text;

namespace FordFulkerson.Model
{
    public class QueueElement
    {
        public QueueElement(int idVertic, List<int> currentVerticPath)
        {
            IdVertic = idVertic;
            VerticsPath = currentVerticPath;
        }

        public int IdVertic { get; private set; }
        private List<int> VerticsPath;

        public List<int> GetVerticPath()
        {
            return VerticsPath;
        }

        public void AddVerticToPath(int newVertic)
        {
            VerticsPath.Add(newVertic);
        }
    }
}
