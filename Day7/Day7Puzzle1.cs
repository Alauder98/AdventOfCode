using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC
{
    class Program
    {
        static int GetFuel(int[] arr, int start)
        {
            int totalCost = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                totalCost += Math.Abs((arr[i] - start));
            }

            return totalCost;
        }

        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText("input.txt");
            if (!string.IsNullOrEmpty(text))
            {
                string[] indvLines = text.Split(',');

                if (indvLines.Length > 0)
                {
                    
                    List<int> values = new List<int>();

                    for (int i = 0; i < indvLines.Length; i++)
                    {
                        values.Add(int.Parse(indvLines[i]));
                    }

                    values.Sort();

                    int middle = values.Count / 2;

                    Console.WriteLine("Min is: " + Math.Min(Math.Min(GetFuel(values.ToArray(), values[middle]),
                       GetFuel(values.ToArray(), values[middle - 1])), GetFuel(values.ToArray(), values[middle + 1])));
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
