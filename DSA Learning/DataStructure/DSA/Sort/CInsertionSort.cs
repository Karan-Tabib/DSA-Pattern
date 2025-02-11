using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort
{
    internal class CInsertionSort
    {
        /*
         *How Insertion Sort Works:
          The list is divided into two parts: the sorted part and the unsorted part.
          Initially, the first element is considered sorted.
          For each element in the unsorted part, starting with the second element, it is compared with elements in the sorted part and inserted into its correct position.
          This process is repeated until the entire list is sorted. 
         * 
         * 
         */
        static void CInsertionSort_Main(string[] args)
        {

            int[] arr = { 4, 5, 1, 3, 2 };
            InsertionSort(arr);
            Console.WriteLine($"{string.Join(',', arr)}");
        }

        static void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        swapping(arr, j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void swapping(int[] arr, int last, int maxIndex)
        {
            int temp = arr[maxIndex];
            arr[maxIndex] = arr[last];
            arr[last] = temp;
        }
    }
}
