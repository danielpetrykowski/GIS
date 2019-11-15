using System.IO;


namespace NetworkGenerator
{
    public class TextFile
    {
        public static void Save(string fileName, string data)
        {
            StreamWriter text = File.CreateText(fileName);
            text.WriteLine(data);
            text.Close();
        }
    }
}
