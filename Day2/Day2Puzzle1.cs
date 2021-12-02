using System;
using System.Collections.Generic;

namespace AOC
{
    class Program
    {
        const string FORWARD = "forward";
        const string DOWN = "down";
        const string UP = "up";

        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText("input.txt");
            if (!string.IsNullOrEmpty(text))
            {
                string[] indvLines = text.Split('\n');

                if (indvLines.Length > 0)
                {
                    int horizontal = 0;
                    int depth = 0;

                    for (int i = 0; i < indvLines.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(indvLines[i]))
                        {
                            string[] vals = indvLines[i].Split(' ');

                            int modifier = int.Parse(vals[1]);

                            switch (vals[0])
                            {
                                case FORWARD:
                                    horizontal += modifier;
                                    break;
                                case DOWN:
                                    depth += modifier;
                                    break;
                                case UP:
                                    depth -= modifier;
                                    break;
                            }
                        }
                    }

                    Console.WriteLine("End result: " + (horizontal * depth));
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
