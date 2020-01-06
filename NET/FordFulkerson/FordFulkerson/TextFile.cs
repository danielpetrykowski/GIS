using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FordFulkerson
{
    class TextFile
    {
        public static List<string> ReadFileLines(string path)
        {
            List<string> lines = new List<string>();
            using (StreamReader file = new StreamReader(path))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                   // Console.WriteLine(ln);
                    lines.Add(ln);
                }
                file.Close();
            }
            return lines;
        }
    }
}
