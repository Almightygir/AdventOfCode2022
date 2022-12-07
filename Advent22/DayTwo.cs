using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class DayTwo
    {
        struct Gesture
        {
            public Gesture(char singleInput)
            {
                switch (singleInput)
                {
                    default:
                    case 'A':
                    case 'X':
                        this.name = "Rock";
                        this.score = 1;
                        break;
                    case 'B':
                    case 'Y':
                        this.name = "Paper";
                        this.score = 2;
                        break;
                    case 'C':
                    case 'Z':
                        this.name = "Scissors";
                        this.score = 3;
                        break;
                }

            }
            public Gesture WinningGesture()
            {
                return (this.name == "Rock") ? new Gesture('B') : (this.name == "Paper") ? new Gesture('C') : new Gesture('A');
            }
            public Gesture LosingGesture()
            {
                return (this.name == "Rock") ? new Gesture('C') : (this.name == "Paper") ? new Gesture('A') : new Gesture('B');
            }
            public static int OutcomeScore(Gesture theirs, Gesture mine)
            {
                if (theirs.name == mine.name)
                {
                    return 3;
                }
                switch (theirs.name)
                {
                    default:
                    case "Rock":
                        return (mine.name == "Paper") ? 6 : 0;
                    case "Paper":
                        return (mine.name == "Scissors") ? 6 : 0;
                    case "Scissors":
                        return mine.name == "Rock" ? 6 : 0;
                }
            }
            public string name;
            public int score;
        }

        public static void Run()
        {
            Console.WriteLine("Day Two:");

            Gesture rock = new Gesture('A');
            Gesture paper = new Gesture('B');
            Gesture scissors = new Gesture('C');

            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", @"Input2.txt");

            int finalScore = 0;
            foreach (string line in File.ReadLines(filePath))
            {
                if (line.Length > 0)
                {
                    Gesture theirGesture = new Gesture(line[0]);
                    if (false) //quick way to get rid of part 1
                    {
                        Gesture myGesture = new Gesture(line[2]);

                        int score = 0;
                        score += myGesture.score;
                        score += Gesture.OutcomeScore(theirGesture, myGesture);
                        finalScore += score;
                    }
                    else
                    {
                        Gesture myGesture = new Gesture();
                        switch (line[2])
                        {
                            case 'X': //lose
                                myGesture = theirGesture.LosingGesture();
                                break;
                            case 'Y': //draw
                                myGesture = theirGesture;
                                break;
                            case 'Z': //win
                                myGesture = theirGesture.WinningGesture();
                                break;
                        }

                        int score = 0;
                        score += myGesture.score;
                        score += Gesture.OutcomeScore(theirGesture, myGesture);
                        finalScore += score;
                    }
                }
            }
            Console.WriteLine("Final score: {0}", finalScore);
        }
    }
}
