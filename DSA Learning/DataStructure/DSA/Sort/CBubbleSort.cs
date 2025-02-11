using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort
{

    /*
     * How Bubble Sort Works:
       Start at the beginning of the list.
       Compare the first two elements.
       If the first element is greater than the second, swap them.
       Otherwise, leave them as is.
       Move to the next pair of elements and repeat the process.
       Continue this process for every pair of adjacent elements in the list.
       After one complete pass through the list, the largest element will be at the correct position (the last index).
       Repeat the process for the remaining unsorted part of the list, ignoring the last sorted elements.


Time Complexity
Best Case: O(n) (when the array is already sorted, no swaps needed, and it only does one pass).
Average and Worst Case:O(n2) (since there are two nested loops).

Space Complexity: 
O(1) (in-place sorting, no extra space needed other than a few temporary variables).
Bubble Sort is inefficient for large lists but easy to understand and implement, which makes it useful for educational purposes and small datasets.
     * */
    internal class CBubbleSort
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = { 5, 3, 4, 1, 2 };

        //    BubbleSort(arr);
        //    Console.WriteLine($"{string.Join(',', arr)}");
        //}

        private static void BubbleSort(int[] arr)
        {
            bool swapped = false;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                // if array is already sorted break the loop
                if (swapped == false)
                {
                    break;
                }
            }
        }
    }
}
