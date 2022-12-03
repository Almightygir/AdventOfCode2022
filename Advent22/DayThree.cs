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
            int lineEntry = 1;
            foreach (string line in File.ReadLines(filePath))
            {
                char[] lineCharArray = line.ToCharArray();
                if (lineCharArray.Length > 0)
                {
                    int halfLineLength = lineCharArray.Length / 2;
                    char[] compartmentOne = lineCharArray[..^halfLineLength];
                    char[] compartmentTwo = lineCharArray[halfLineLength..];
                    foreach (KeyValuePair<char, int> entry in alphabet)
                    {
                        if (compartmentOne.Contains(entry.Key) && compartmentTwo.Contains(entry.Key))
                        {
                            candidates.Add(entry.Key);
                        }
                    }
                }
                lineEntry++;
            }

            int finalScore = 0;
            foreach(char candidate in candidates)
            {
                finalScore += alphabet[candidate];
            }
            Console.WriteLine("Score: {0}", finalScore);
        }
    }
}
