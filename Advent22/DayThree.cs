using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class DayThree
    {
        public static void Day_Three()
        {
            Console.WriteLine("Day Three:");

            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", @"Input3.txt");

            IDictionary<char, int> alphabet = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                int key = c - 'a' + 1;
                alphabet.Add(c, key);
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                int key = c - 'A' + 27;
                alphabet.Add(c, key);
            }

            List<char> candidates = new List<char>();
            string[] allLines = File.ReadAllLines(filePath);
            for (int i = 0; i < allLines.Length; i += 3)
            {
                string[] elfGroup = new string[3];
                Array.Copy(allLines, i, elfGroup, 0, 3);
                foreach (KeyValuePair<char, int> entry in alphabet)
                {
                    char[] line1 = elfGroup[0].ToCharArray();
                    char[] line2 = elfGroup[1].ToCharArray();
                    char[] line3 = elfGroup[2].ToCharArray();
                    if (line1.Contains(entry.Key) && line2.Contains(entry.Key) && line3.Contains(entry.Key))
                    {
                        candidates.Add(entry.Key);
                    }
                }
            }


            int finalScore = 0;
            foreach (char candidate in candidates)
            {
                finalScore += alphabet[candidate];
            }
            Console.WriteLine("Score: {0}", finalScore);
        }
    }
}
