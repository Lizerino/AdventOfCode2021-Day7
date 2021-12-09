using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Part2
    {
        public string[] Input { get; set; }
        public int[] Distances { get; set; }
        public Part2()
        {
            Input = File.ReadAllLines("Input.txt");
            string[] temp = Input[0].Split(",");
            Distances = Array.ConvertAll(temp, int.Parse);
        }
        public void Run()
        {

            int numberCount = Distances.Count();
            int halfIndex = Distances.Count() / 2;
            var sortedNumbers = Distances.OrderBy(n => n);
            double median;
            if ((numberCount % 2) == 0)
            {
                median = ((sortedNumbers.ElementAt(halfIndex) +
                    sortedNumbers.ElementAtOrDefault((halfIndex - 1))) / 2);
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
            }

            var mode = Distances.GroupBy(n => n).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();

            double bestFuel=int.MaxValue;
           for(int i=0; i<Distances.Max(); i++)
            {
                var spent = CalculateFuelSpent(i);
                if (spent<bestFuel)
                {
                    bestFuel = spent;
                }
            }
            Console.WriteLine(bestFuel);
            
        }

        private double CalculateFuelSpent(double goal)
        {
            double sumFuelSpent = 0;

            foreach (var distance in Distances)
            {
                var distanceTraveled = Math.Abs(goal - distance);
                double fuelSpent = (distanceTraveled * (distanceTraveled + 1)) / 2;
                sumFuelSpent = sumFuelSpent + fuelSpent;
            }        
            return sumFuelSpent;
        }
    }
}
