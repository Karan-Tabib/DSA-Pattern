using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort
{

    internal class CQuickSort
    {
        /*
         * Quick Sort is a highly efficient, recursive sorting algorithm that uses the "divide and conquer" strategy.
         * It works by selecting a "pivot" element from the array and partitioning the other elements into two sub-arrays: elements less than the pivot and elements greater than the pivot. 
         * The sub-arrays are then recursively sorted.
            Steps of Quick Sort:
            Choose a Pivot: Pick an element as the pivot. Common choices include:
            The first element.
            The last element.
            The middle element.
            A random element.
            Partitioning: Rearrange the array such that:
            All elements smaller than the pivot come before it.
            All elements larger than the pivot come after it.
           
        Recursive Sorting: Recursively apply the same process to the sub-arrays of elements
                                with smaller and larger values than the pivot.
         */
        static void CQuickSort_Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] array = { 10, 80, 30, 90, 40, 50, 70 };
            //Ex-2
            int[] array1 = { 10, 80, 30, 90, 40, 50, 70 };
            QuickSort(array1, 0, array.Length - 1);
            Console.WriteLine($"{string.Join(",", array1)}");
            Console.WriteLine();
        }

        //low & high determines which part of array are getting sorted

        public static void QuickSort(int[] nums, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
            int start = low;
            int end = high;

            int mid = start + (high - start) / 2;
            int pivot = nums[mid];
            /* pivot condition - element which are less than pivot should be at left side of pivot 
                               element which are greater than pivot should be at right side of pivot */

            // bring pivot at correct position
            while (start <= end)   //which part of the array we are sorting
            {
                while (nums[start] < pivot)  // increment start till number is less than pivot
                {
                    start++;
                }
                while (nums[end] > pivot)  // decrement end till number is greater than pivot
                {
                    end--;
                }
                if (start <= end)              // this condition is required to have index withing range 
                {                             // to avoid out of bound exception  
                    int temp = nums[start];
                    nums[start] = nums[end];  // swap the element which are violating pivot condition
                    nums[end] = temp;
                    start++;
                    end--;
                }
            }

            // now pivot is my at correct position
            // sort left array & right array
            QuickSort(nums, low, end);
            QuickSort(nums, start, high);
        }
    }
}
