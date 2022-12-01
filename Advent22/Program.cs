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
        }
        public uint GetTotalCalories()
        {
            uint totalCalories = 0;
            foreach(Food food in foods)
            {
                totalCalories += food.calories;
            }
            return totalCalories;
        }
        public List<Food> foods;
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
                foods.Clear();
            }    
        }

        Console.WriteLine("Number of Elves: {0}\n", elves.Count());

        uint mostCalories = 0;
        foreach(Elf elf in elves)
        {
            uint currentElfCalories = elf.GetTotalCalories();
            mostCalories = currentElfCalories > mostCalories ? currentElfCalories : mostCalories;
        }

        Console.WriteLine("Most Calories: {0}", mostCalories);

        Console.ReadLine();
    }
}