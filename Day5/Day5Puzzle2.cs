using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC
{
    struct Point
    {
        public int x;
        public int y;
    }

    enum LineType
    {
        Vertical,
        Horizontal,
        diagnol
    }

    class Grid
    {
        int[][] points;

        public Grid(int rows, int cols)
        {
            points = new int[rows][];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new int[cols];
            }
        }

        public void AddLine(string lineCordoniates)
        {
            // Split points and get start and end points
            string[] pointsIn = lineCordoniates.Split("->");

            string[] startValues = pointsIn[0].Trim().Split(',');
            Point start;
            start.x = int.Parse(startValues[0]);
            start.y = int.Parse(startValues[1]);
            
            string[] endValues = pointsIn[1].Trim().Split(',');
            Point end;
            end.x = int.Parse(endValues[0]);
            end.y = int.Parse(endValues[1]);

            LineType type = LineType.Vertical;
            if(start.x == end.x)
            {
                type = LineType.Vertical;
            }
            else if (start.y == end.y)
            {
                type = LineType.Horizontal;
            }
            else if ((start.x == end.y && start.y == end.x) | Math.Abs(start.x - end.x) == Math.Abs(start.y - end.y))
            {
                type = LineType.diagnol;
            }

            Console.WriteLine("Line: (" + start.x + "," + start.y + ") to (" + end.x + "," + end.y + ") is" + type);

            switch (type)
            {
                case LineType.Vertical:
                    for (int y = Math.Min(start.y, end.y); y != Math.Max(start.y, end.y) + 1; y++)
                    {
                        points[start.x][y]++;
                    }

                    break;
                case LineType.Horizontal:
                    for (int x = Math.Min(start.x, end.x); x != Math.Max(start.x, end.x) + 1; x++)
                    {
                        points[x][start.y]++;
                    }

                    break;
                case LineType.diagnol:

                    int xDir = 1;
                    int yDir = 1;

                    if (start.x > end.x) { xDir = -1; }
                    if (start.y > end.y) { yDir = -1; }

                    int xVal = start.x;
                    int yVal = start.y;

                    do
                    {
                        points[xVal][yVal]++;
                        xVal += xDir;
                        yVal += yDir;
                    }
                    while (xVal != (end.x + xDir) | yVal != (end.y + yDir));

                    break;
            }
        }

        public int GetOverlapPoints(int minOverlaps)
        {
            int overlaps = 0;

            for (int col = 0; col < points.Length; col++)
            {
                for (int row = 0; row < points[col].Length; row++)
                {
                    if (points[col][row] >= minOverlaps)
                    {
                        overlaps++;
                    }
                }
            }

            return overlaps;
        }
    }

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
                    Grid currentGrid = new Grid(1000, 1000);

                    for (int line = 0; line < indvLines.Length; line++)
                    {
                        if (!string.IsNullOrEmpty(indvLines[line]))
                        {
                            currentGrid.AddLine(indvLines[line]);
                        }
                    }

                    Console.WriteLine("Final result: " + currentGrid.GetOverlapPoints(2));
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
