using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.LinearSearch
{
    internal class C2DArraySearch
    {
        //static void Main(string[] args)
        //{
        //    int[,] arr = {{1,5,80},
        //                  { 2,7,3},
        //                  {45,76,40}
        //                  };
        //    int target = 45;
        //    int[] ans = search(arr, target);
        //    Console.WriteLine($"{string.Join(',',ans)}");
        //    Console.ReadLine();
        //}

        private static int[] search(int[,] arr, int target)
        {
            int[] ans = { -1, -1 };
            if (arr.Length == 0)
            {
                return ans;
            }

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(0); col++)
                {
                    if (arr[row, col] == target)
                    {
                        return new int[] { row, col };
                    }
                }
            }
            return ans;
        }


        private static int Max(int[,] arr)
        {
            int max = int.MinValue;
            if (arr.Length == 0)
            {
                return max;
            }

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(0); col++)
                {
                    if (arr[row, col] > max)
                    {
                        max = arr[row, col];
                    }
                }
            }
            return max;
        }
        private static int MIN(int[,] arr)
        {
            int min = int.MaxValue;
            if (arr.Length == 0)
            {
                return min;
            }

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(0); col++)
                {
                    if (arr[row, col] < min)
                    {
                        min = arr[row, col];
                    }
                }
            }
            return min;
        }

        private static int MaximumWhelth(int[,] arr)
        {
            int max = int.MinValue;
            if (arr.Length == 0)
            {
                return max;
            }

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                int whealth = 0;
                for (int col = 0; col < arr.GetLength(0); col++)
                {
                    whealth += arr[row, col];
                }
                if (whealth > max)
                {
                    max = whealth;
                }

            }
            return max;
        }
    }
}
