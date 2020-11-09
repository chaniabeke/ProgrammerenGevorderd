using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileIO
{
    public static class Extensions
    {
        public static IEnumerable<string> ReadAllLines(this StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public static string[] readLines(string path)
        {
            string[] result = null;
            using (StreamReader reader = new StreamReader(path))
            {
                result = reader.ReadAllLines().ToArray();
            }
            return result;
        }
    }
}