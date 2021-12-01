using System;
using System.Collections.Generic;

namespace AOC
{
    class Window
    {
        int[] values;
        int index;

        public Window(int valLength)
        {
            values = new int[valLength];
            index = 0;
        }

        public void AddValue(int val)
        {
            values[index] = val;
            index++;
        }

        public bool ReadyToGo()
        {
            return index == values.Length;
        }

        public int GetValue()
        {
            int returnVal = 0;

            for (int i = 0; i < values.Length; i++)
            {
                returnVal += values[i];
            }

            return returnVal;
        }
    }

    class Tracker
    {
        List<Window> windows;
        List<Window> finishedWindows;

        public Tracker()
        {
            windows = new List<Window>();
            finishedWindows = new List<Window>();
        }

        void AddWindow()
        {
            windows.Add(new Window(3));
        }

        public void AddValue(int val)
        {
            AddWindow();

            for (int i = 0; i < windows.Count; i++)
            {
                windows[i].AddValue(val);
            }

            CheckWindows();
        }

        void CheckWindows()
        {
            for (int i = 0; i < windows.Count; i++)
            {
                if (windows[i].ReadyToGo())
                {
                    finishedWindows.Add(windows[i]);
                    windows.RemoveAt(i);
                }
            }
        }

        public int CheckDifs()
        {
            int increases = 0;

            int prev = finishedWindows[0].GetValue();

            for (int i = 0; i < finishedWindows.Count; i++)
            {
                int current = finishedWindows[i].GetValue();

                if (current > prev)
                {
                    increases++;
                }

                prev = current;
            }

            return increases;
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
                    Tracker track = new Tracker();

                    for (int i = 0; i < indvLines.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(indvLines[i]))
                        {
                            track.AddValue(int.Parse(indvLines[i]));
                        }
                    }

                    Console.WriteLine("Total increases: " + track.CheckDifs());
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
