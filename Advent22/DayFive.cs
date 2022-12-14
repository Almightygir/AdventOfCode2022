using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class DayFive
    {
        public static void Run()
        {
            Console.WriteLine("Day Five:");

            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", @"Input5.txt");

            string[] puzzleInput = File.ReadAllLines(filePath);
            List<List<char>> crates = new List<List<char>>();
            List<List<int>> instructions = new List<List<int>>();
            for (int i = 0; i < 9; ++i)
            {
                crates.Add(new List<char>());
            }
            for (int i = 0; i < puzzleInput.Length; ++i)
            {
                if(i < 8)
                {
                    List<char> currentCrates = new List<char>();
                    for(int j = 1; j < 35; j+=4)
                    {
                        currentCrates.Add(puzzleInput[i][j]);
                    }
                    for(int j = 0; j < 9; ++j)
                    {
                        if (currentCrates[j] != ' ')
                        {
                            crates[j].Insert(0,currentCrates[j]);
                        }
                    }
                }
                else if(i > 9)
                {
                    string[] currentInstructions = puzzleInput[i].Replace("move ", "").Replace("from ", "").Replace("to ", "").Split(" ");
                    List<int> instructionInts = new List<int>();
                    for(int j = 0; j < currentInstructions.Length; ++j)
                    {
                        instructionInts.Add(int.Parse(currentInstructions[j]));
                    }
                    instructions.Add(instructionInts);
                }
            }

            foreach(List<int> instruction in instructions)
            {
                bool part1 = false;
                if (part1)
                {
                    for (int i = instruction[0] - 1; i >= 0; --i)
                    {
                        char crate = crates[instruction[1] - 1].Last();
                        crates[instruction[1] - 1].RemoveAt(crates[instruction[1] - 1].Count - 1);
                        crates[instruction[2] - 1].Add(crate);
                    }
                }
                else
                {
                    int numCrates = instruction[0] > crates[instruction[1] - 1].Count ? crates[instruction[1] - 1].Count : instruction[0];
                    List<char> pickedCrates = crates[instruction[1] - 1].ToArray()[^numCrates..].ToList();
                    crates[instruction[1] - 1].RemoveRange(crates[instruction[1] - 1].Count - numCrates, numCrates);
                    crates[instruction[2] - 1].AddRange(pickedCrates);
                }
            }

            string topCrates = "";
            foreach(List<char> crate in crates)
            {
                topCrates += crate[^1].ToString();
            }
            Console.WriteLine("{0}", topCrates);
        }
    }
}
