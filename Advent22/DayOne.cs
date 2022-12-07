using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class DayOne
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
        public static void Run()
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

                Console.WriteLine("Most Calories: {0}", sortedElves[^1].totalCalories);
                uint top3ElvesCalories = sortedElves[^3].totalCalories + sortedElves[^2].totalCalories + sortedElves[^1].totalCalories;
                Console.WriteLine("Last three elves: {0}", top3ElvesCalories);
            }
            else
            {
                Console.WriteLine("Something went wrong, there are not enoug elves...");
            }

            Console.WriteLine("\n");
        }
    }
}
