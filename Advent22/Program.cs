//AdventOfCode2022
using System.IO;
using System.Reflection;
class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent Of Code 2022\n");

        DayOne();
        DayTwo();

        Console.ReadLine();
    }

    struct Food
    {
        public Food(uint calories)
        {
            this.calories = calories;
        }
        public uint calories;
    }

    struct Elf
    {
        public Elf(List<Food> foods)
        {
            this.foods = foods;
            this.totalCalories = 0;
            foreach (Food food in foods)
            {
                totalCalories += food.calories;
            }
        }
        public List<Food> foods;
        public uint totalCalories;
    }
    static void DayOne()
    {
        
        Console.WriteLine("Day One:");

        string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", @"Input1.txt");

        List<Elf> elves = new List<Elf>();
        List<Food> foods = new List<Food>();
        foreach (string line in File.ReadLines(filePath))
        {
            if (line.Length > 0)
            {
                uint calories = uint.Parse(line);
                foods.Add(new Food(calories));
            }
            else
            {
                elves.Add(new Elf(foods));
                foods = new List<Food>();
            }
        }

        if (elves.Count > 2)
        {
            Console.WriteLine("Number of Elves: {0}", elves.Count());
            List<Elf> sortedElves = elves.OrderBy(o => o.totalCalories).ToList();

            Console.WriteLine("Most Calories: {0}", sortedElves[sortedElves.Count - 1].totalCalories);
            uint top3ElvesCalories = sortedElves[sortedElves.Count - 3].totalCalories + sortedElves[sortedElves.Count - 2].totalCalories + sortedElves[sortedElves.Count - 1].totalCalories;
            Console.WriteLine("Last three elves: {0}", top3ElvesCalories);
        }
        else
        {
            Console.WriteLine("Something went wrong, there are not enoug elves...");
        }

        Console.WriteLine("\n");
    }

    struct Gesture
    {
        public Gesture(char singleInput)
        {
            switch(singleInput)
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
        public static int OutcomeScore(Gesture theirs, Gesture mine)
        {
            if(theirs.name == mine.name)
            {
                return 3;
            }
            switch(theirs.name)
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

    static void DayTwo()
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
                if(false) //quick way to get rid of part 1
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
                    switch(line[2])
                    {
                        case 'X': //lose
                            myGesture = (theirGesture.name == "Rock") ? new Gesture('C') : (theirGesture.name == "Paper") ? new Gesture('A') : new Gesture('B');
                            break;
                        case 'Y': //draw
                            myGesture = theirGesture;
                            break;
                        case 'Z': //win
                            myGesture = (theirGesture.name == "Rock") ? new Gesture('B') : (theirGesture.name == "Paper") ? new Gesture('C') : new Gesture('A');
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