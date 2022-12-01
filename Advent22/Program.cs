//AdventOfCode2022
using System.IO;
using System.Reflection;
class program
{
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

    static void Main(string[] args)
    {
        Console.WriteLine("Advent Of Code 2022\n");

        //Open the file
        
        string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", @"Input.txt");

        List<Elf> elves = new List<Elf>();
        List<Food> foods = new List<Food>();
        foreach(string line in File.ReadLines(filePath))
        {
            if(line.Length > 0)
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

        Console.WriteLine("Number of Elves: {0}\n", elves.Count());
        List<Elf>sortedElves = elves.OrderBy(o=>o.totalCalories).ToList();

        Console.WriteLine("Most Calories: {0}", sortedElves[sortedElves.Count - 1].totalCalories);
        uint top3ElvesCalories = sortedElves[sortedElves.Count - 3].totalCalories + sortedElves[sortedElves.Count - 2].totalCalories + sortedElves[sortedElves.Count - 1].totalCalories;
        Console.WriteLine("Last three elves: {0}", top3ElvesCalories);

        Console.ReadLine();
    }
}