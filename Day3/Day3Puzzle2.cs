using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC
{
    class Program
    {
        static string PerformSearch(List<string> list, bool mostComBit)
        {
            int characters = list[0].Length;

            for (int character = 0; character < characters; character++)
            {
                // First do calc to check what most common bit is 
                int ones = 0;
                int zeros = 0;
                for (int bit = list.Count - 1; bit >= 0; bit--)
                {
                    if (!string.IsNullOrEmpty(list[bit]))
                    {
                        if (list[bit][character].Equals('1'))
                        {
                            ones++;
                        }
                        else
                        {
                            zeros++;
                        }
                    }
                    else
                    {
                        list.RemoveAt(bit);
                    }
                }

                char valToSearchFor;
                if (ones == zeros)
                {
                    if (mostComBit)
                    {
                        valToSearchFor = '1';
                    }
                    else
                    {
                        valToSearchFor = '0';
                    }
                }
                else
                {
                    bool oneIsMostCommon = ones > zeros;
                    if (mostComBit)
                    {
                        if (oneIsMostCommon)
                        {
                            valToSearchFor = '1';
                        }
                        else
                        {
                            valToSearchFor = '0';
                        }
                    }
                    else
                    {
                        if (oneIsMostCommon)
                        {
                            valToSearchFor = '0';
                        }
                        else
                        {
                            valToSearchFor = '1';
                        }
                    }
                }


                for (int bit = list.Count - 1; bit >= 0; bit--)
                {
                    if (!list[bit][character].Equals(valToSearchFor))
                    {
                        list.RemoveAt(bit);
                        if (list.Count == 1)
                        {
                            return list[bit];
                        }
                    }
                }
            }

            return null;
        }

        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText("input.txt");
            if (!string.IsNullOrEmpty(text))
            {
                string[] indvLines = text.Split('\n');

                if (indvLines.Length > 0)
                {
                    string oxVal = PerformSearch(indvLines.ToList(), true);
                    string cOTwoVal = PerformSearch(indvLines.ToList(), false);

                    Console.WriteLine("Final result: " + (Convert.ToInt32(oxVal, 2) * Convert.ToInt32(cOTwoVal, 2)));
                    
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
