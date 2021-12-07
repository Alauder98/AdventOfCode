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
                totalCost += TriangleNumber(Math.Abs((arr[i] - start)));
            }

            return totalCost;
        }

        static int TriangleNumber(int n)
        {
            if (n == 0) { return 0; }
            return (n * (n + 1)) / 2; 
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

                    int lowest = GetFuel(values.ToArray(), values[0]);
                    for (int i = 1; i < values.Count; i++)
                    {
                        int gottenValue = GetFuel(values.ToArray(), values[i]);

                        if (lowest > gottenValue)
                        {
                            lowest = gottenValue;
                        }
                    }

                    Console.WriteLine("Lowest is now: " + lowest);
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
