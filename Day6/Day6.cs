using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC
{
    class Program
    {
        const int DAYSTORUN = 252;

        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText("input.txt");
            if (!string.IsNullOrEmpty(text))
            {
                string[] indvLines = text.Split('\n');

                if (indvLines.Length > 0)
                {
                    List<int> start = new List<int>();

                    string[] nums = indvLines[0].Split(',');

                    for (int i = 0; i < nums.Length; i++)
                    {
                        start.Add(int.Parse(nums[i]));
                    }
                    
                    Console.WriteLine("Final amount of fish is: " + SpawnFishUnlimited(256, start));
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }

        public static long SpawnFishUnlimited(int days, List<int> initalFish)
        {
            long[] fishArray = SetupFishArray(initalFish);

            while (days > 0)
            {
                fishArray = SpawnFish(fishArray);
                days--;
            }

            return fishArray.Sum();
        }

        private static long[] SetupFishArray(List<int> initalFish)
        {
            long[] fishArray = new long[9];
            foreach (int fish in initalFish)
            {
                fishArray[fish]++;
            }
            return fishArray;
        }

        private static long[] SpawnFish(long[] fishArray)
        {
            long zeroFish = 0;
            for (int index = 0; index < fishArray.Length; index++)
            {
                if (index == 0)
                    zeroFish = fishArray[index];
                else
                    fishArray[index - 1] += fishArray[index];
                fishArray[index] = 0;
            }
            fishArray[6] += zeroFish;
            fishArray[8] = zeroFish;
            return fishArray;
        }
    }
}
