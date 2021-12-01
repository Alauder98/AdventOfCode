using System;

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

                int increases = 0;

                if (indvLines.Length > 0)
                {
                    int prev = int.Parse(indvLines[0]);

                    for (int i = 1; i < indvLines.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(indvLines[i]))
                        {
                            int current = int.Parse(indvLines[i]);

                            if (current > prev)
                            {
                                increases++;
                            }

                            prev = current;
                        }
                    }
                }

                Console.WriteLine("Total increases: " + increases);
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
