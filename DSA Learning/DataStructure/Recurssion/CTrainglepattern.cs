using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.Recurssion
{
    internal class CTrainglepattern
    {

        static void CTrainglepattern_Main(string[] args)
        {
            Triangle1(4, 0);
            Console.WriteLine();
            Triangle2(4, 0);
            int[] arr = { 4, 3, 2, 1 };
            BubbleSort(arr, arr.Length - 1, 0);
            Console.WriteLine($"{string.Join(',', arr)}");

            int[] arr1 = { 4, 3, 2, 1 };
            SelectionSort(arr1, arr1.Length, 0, 0);
            Console.WriteLine($"{string.Join(',', arr1)}");
        }

        /*
         *          * * * *
         *          * * *
         *          * *
         *          *
         * 
         */

        static void Triangle1(int row, int col)
        {
            if (row == 0)
            {
                return;
            }

            if (col < row)
            {
                Console.Write("* ");
                Triangle1(row, col + 1);
            }
            else
            {
                Console.WriteLine();
                Triangle1(row - 1, 0);
            }
        }

        static void Triangle2(int row, int col)
        {
            if (row == 0)
            {
                return;
            }

            if (col < row)
            {
                Triangle2(row, col + 1);
                Console.Write("* ");
            }
            else
            {
                Triangle2(row - 1, 0);
                Console.WriteLine();
            }
        }

        static void BubbleSort(int[] arr, int row, int col)
        {
            if (row == 0)
            {
                return;
            }

            if (col < row)
            {
                if (arr[col] > arr[col + 1])
                {
                    swap(arr, col, col + 1);
                }
                BubbleSort(arr, row, col + 1);
            }
            else
            {
                BubbleSort(arr, row - 1, 0);
            }
        }


        // in selection sort we swap large elememt with last positon

        static void SelectionSort(int[] arr, int row, int col, int max)
        {
            if (row == 0)
            {
                return;
            }
            if (col < row)
            {
                if (arr[max] < arr[col])
                {
                    max = col;
                }
                // max = arr[max] < arr[col] ? col : max;
                SelectionSort(arr, row, col + 1, max);
            }
            else
            {
                swap(arr, row - 1, max);
                SelectionSort(arr, row - 1, 0, 0);
            }
        }

        private static void swap(int[] arr, int row, int max)
        {
            int temp = arr[row];
            arr[row] = arr[max];
            arr[max] = temp;
        }
    }
}
