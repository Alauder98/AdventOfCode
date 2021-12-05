using System;
using System.Collections.Generic;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText("input.txt");
            if (!string.IsNullOrEmpty(text))
            {
                string[] indvLines = text.Split('\n');

                if (indvLines.Length > 0)
                {
                    List<int> ones = new List<int>();

                    for (int line = 0; line < indvLines.Length; line++)
                    {
                        string currentLine = indvLines[line];
                        for(int character = 0; character < currentLine.Length; character++)
                        {
                            if (character + 1 > ones.Count)
                            {
                                ones.Add(0);
                            }

                            char current = currentLine[character];
                            int value = current - '0';

                            if (value == 1)
                            {
                                ones[character]++;
                            }
                        }
                    }

                    string gamma = "";
                    string eplison = "";

                    for (int index = 0; index < ones.Count; index++)
                    {
                        // More ones than 0s

                        if (ones[index] > (indvLines.Length / 2))
                        {
                            gamma += "1";
                            eplison += "0";
                        }
                        else
                        {
                            gamma += "0";
                            eplison += "1";
                        }
                    }

                    Console.WriteLine("Final result: " + (Convert.ToInt32(gamma, 2) * Convert.ToInt32(eplison, 2)));
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
