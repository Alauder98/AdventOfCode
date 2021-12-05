using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC
{
    class Board
    {
        KeyValuePair<int, bool>[][] rows;

        public Board(List<string> rowsIn)
        {
            rows = new KeyValuePair<int, bool>[rowsIn.Count][];

            for (int i = 0; i < rowsIn.Count; i++)
            {
                List<string> valsIn = rowsIn[i].Split(' ').ToList();
                valsIn = valsIn.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                rows[i] = new KeyValuePair<int, bool>[valsIn.Count];

                for (int val = 0; val < valsIn.Count; val++)
                {
                    rows[i][val] = new KeyValuePair<int, bool>(int.Parse(valsIn[val]), false);
                }
            }
        }

        bool CheckIfWinner(int row, int col)
        {
            // check vertical
            bool win = true;
            for (int i = 0; i < rows.Length; i++)
            {
                if (win)
                {
                    win = rows[i][col].Value;
                }
            }
            if (win)
            {
                return true;
            }

            // check horizontal
            win = true;
            for (int i = 0; i < rows[row].Length; i++)
            {
                if (win)
                {
                    win = rows[row][i].Value;
                }
            }
            return win;
        }

        public bool InputValue(int valueToEnter)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                for (int x = 0; x < rows[i].Length; x++)
                {
                    if (rows[i][x].Key == valueToEnter)
                    {
                        rows[i][x] = new KeyValuePair<int, bool>(valueToEnter, true);

                        if (CheckIfWinner(i, x))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public int GetFinalValue()
        {
            int returnValue = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                for (int x = 0; x < rows[i].Length; x++)
                {
                    if (!rows[i][x].Value)
                    {
                        returnValue += rows[i][x].Key;
                    }
                }
            }

            return returnValue;
        }

        public new string ToString()
        {
            string returnVal = "";

            for (int i = 0; i < rows.Length; i++)
            {
                for (int x = 0; x < rows[i].Length; x++)
                {
                    returnVal += (" " + rows[i][x].Key);
                }

                returnVal += '\n';
            }

            return returnVal;
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
                    // Step 1: make the array of numbers we're gonna use
                    string[] numsIn = indvLines[0].Split(',');
                    int[] nums = new int[numsIn.Length];
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = int.Parse(numsIn[i]);
                    }

                    // Step 2: make boards and load into a list
                    List<Board> boards = new List<Board>();
                    List<string> stringsToSend = new List<string>();
                    for (int i = 1; i < indvLines.Length; i++)
                    {
                        if (string.IsNullOrEmpty(indvLines[i]) && stringsToSend.Count > 0)
                        {
                            boards.Add(new Board(stringsToSend));
                            stringsToSend = new List<string>();
                        }
                        else if (!string.IsNullOrEmpty(indvLines[i]))
                        {
                            stringsToSend.Add(indvLines[i]);
                        }
                    }

                    // Step 3: start inputting numbers and find a winner
                    Board winningBoard = null;
                    int winningValue = 0;
                    for (int i  = 0; i < nums.Length; i++)
                    {
                        if (winningBoard == null)
                        {
                            for (int board = 0; board < boards.Count; board++)
                            {
                                if (boards[board].InputValue(nums[i]))
                                {
                                    // Step 4: we found a winner, get the final result
                                    winningBoard = boards[board];
                                    winningValue = nums[i];
                                    break;
                                }
                            }
                        }
                    }

                    // Step 4: final result
                    Console.WriteLine("Final result is: " + winningBoard.GetFinalValue() * winningValue);
                }
            }
            else
            {
                Console.WriteLine("string is null!");
            }
        }
    }
}
