using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort
{
    internal class CSelectionSort
    {
        static void CSelectionSort_Main(string[] args)
        {
            int[] arr = { 4, 5, 1, 3, 2 };
            SelectionSort(arr);
            Console.WriteLine($"{string.Join(',', arr)}");
        }

        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int last = arr.Length - 1 - i;
                int maxIndex = getMaxIndex(arr, 0, last);
                swapping(arr, last, maxIndex);
            }
        }

        private static void swapping(int[] arr, int last, int maxIndex)
        {
            int temp = arr[maxIndex];
            arr[maxIndex] = arr[last];
            arr[last] = temp;
        }

        private static int getMaxIndex(int[] arr, int start, int end)
        {
            int maxIndex = start;
            while (start <= end)
            {
                if (arr[start] > arr[maxIndex])
                {
                    maxIndex = start;
                }
                start++;
            }

            return maxIndex;
        }
    }
}
