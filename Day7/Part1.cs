using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    static class Part1
    {
        internal static void Run()
        {
            string[] input = File.ReadAllLines("testInput.txt");
            string[] temp = input[0].Split(",");
            int[] distances = Array.ConvertAll(temp, int.Parse);

            int numberCount = distances.Count();
            int halfIndex = distances.Count() / 2;
            var sortedNumbers = distances.OrderBy(n => n);
            double median;
            if ((numberCount % 2) == 0)
            {
                median = ((sortedNumbers.ElementAt(halfIndex) +
                    sortedNumbers.ElementAtOrDefault((halfIndex-1))) / 2);
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
            }

            var mode = distances.GroupBy(n => n).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();

            var goal = Math.Round(distances.Average());

            double fuelSpent = 0;

            foreach (var distance in distances)
            {
                fuelSpent = fuelSpent+Math.Abs(goal - distance);
            }

            Console.WriteLine(fuelSpent);
        }
    }
}
