using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class DaySix
    {
        static bool CheckUnique(string str)
        {
            string one = "";
            string two = "";
            for (int i = 0; i < str.Length; i++)
            {
                one = str.Substring(i, 1);
                for (int j = 0; j < str.Length; j++)
                {
                    two = str.Substring(j, 1);
                    if ((one == two) && (i != j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void Run()
        {
            Console.WriteLine("Day Six:");

            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", @"Input6.txt");

            int marker = 0;
            int packetLength = 14;
            foreach (string line in File.ReadLines(filePath))
            {
                for(int i = packetLength; i < line.Length; i++)
                {
                    if(CheckUnique(line[(i - packetLength)..i]))
                    {
                        marker = i;
                        break;
                    }
                }
                break;
            }
            Console.WriteLine(marker);
        }
    }
}
