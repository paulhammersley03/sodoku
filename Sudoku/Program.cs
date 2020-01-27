using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[9, 9] {
                {0,0,0, 0,0,2, 1,0,0 },
                {0,0,4, 0,0,8, 7,0,0 },
                {0,2,0, 3,0,0, 9,0,0 },

                {6,0,2, 0,0,3, 0,4,0 },
                {0,0,0, 0,0,0, 0,0,0 },
                {0,5,0, 6,0,0, 3,0,1 },

                {0,0,3, 0,0,5, 0,8,0 },
                {0,0,8, 2,0,0, 5,0,0 },
                {0,0,9, 7,0,0, 0,0,0 }};

            List<List<int>> rowList, colList;
            AddExistingNumbers(grid, out rowList, out colList);
            FillInEmptyNumbers(grid, rowList, colList);
            var x = 0;
            x = PrintResult(grid, x);
        }

        private static int PrintResult(int[,] grid, int x)
        {
            foreach (var item in grid)
            {
                Console.Write(item + " ");
                x += 1;
                if (x % 9 == 0)
                {
                    Console.Write(item + "\n");
                }
            }

            return x;
        }

        private static void FillInEmptyNumbers(int[,] grid, List<List<int>> rowList, List<List<int>> colList)
        {
            var random = new Random();
            var p = 0;
            var q = 0;

            foreach (var item in grid)
            {
                var randomNumber = random.Next(1, 9);

                if (grid[p, q] == 0 && !rowList[p].Contains(randomNumber) && !colList[q].Contains(randomNumber))
                {
                    grid[p, q] = randomNumber;
                    rowList[p].Add(randomNumber);
                    colList[q].Add(randomNumber);
                    q += 1;
                }
                else if(grid[p, q] > 0)
                {
                    continue;
                }

                if (q == 8)
                {
                    p += 1;
                    q = 0;
                }
            }
        }

        private static void AddExistingNumbers(int[,] grid, out List<List<int>> rowList, out List<List<int>> colList)
        {
            var i = 0;
            var j = 0;
            var l = 0;
            var m = 0;

            var eachRow = new List<int>();
            rowList = new List<List<int>>();
            var eachCol = new List<int>();
            colList = new List<List<int>>();
            for (int k = 1; k <= 81; k++)
            {
                if (grid[i, j] > 0)
                {
                    eachRow.Add(grid[i, j]);
                }
                j += 1;
                if (k % 9 == 0)
                {
                    rowList.Add(eachRow);
                    eachRow = new List<int>();
                    i += 1;
                    j = 0;
                }
            }

            for (int n = 1; n <= 81; n++)
            {
                if (grid[l, m] > 0)
                {
                    eachCol.Add(grid[l, m]);
                }
                l += 1;
                if (n % 9 == 0)
                {
                    colList.Add(eachCol);
                    eachCol = new List<int>();
                    m += 1;
                    l = 0;
                }
            }
        }
    }
}
