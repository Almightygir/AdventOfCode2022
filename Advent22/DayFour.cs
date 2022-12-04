using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class DayFour
    {
        public static void Day_Four()
        {
            Console.WriteLine("Day Four:");

            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", @"Input4.txt");
            int redundantAssignments = 0;
            foreach (string line in File.ReadLines(filePath))
            {
                if (line.Length > 0)
                {
                    string[] lineSplit = line.Split(',');
                    int[,] elfRanges = new int[,] { { int.Parse(lineSplit[0].Split('-')[0]), int.Parse(lineSplit[0].Split('-')[1]) }, { int.Parse(lineSplit[1].Split('-')[0]), int.Parse(lineSplit[1].Split('-')[1]) } };

                    if((elfRanges[0, 0] >= elfRanges[1, 0] && elfRanges[0, 1] <= elfRanges[1, 1]) ||
                       (elfRanges[1, 0] >= elfRanges[0, 0] && elfRanges[1, 1] <= elfRanges[0, 1]))
                    {
                        redundantAssignments++;
                    }
                }
            }
            Console.WriteLine("Redundant Assignments: {0}", redundantAssignments);
        }
    }
}
