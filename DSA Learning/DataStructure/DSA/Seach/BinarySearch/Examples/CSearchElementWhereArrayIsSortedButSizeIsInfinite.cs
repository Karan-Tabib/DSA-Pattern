using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.BinarySearch.Examples
{
    /*
     here we have given a sorted  array of infinte size.
     search for elment in array
     
     As we know for sorted array we use binary search. but to use it we should know size of array
     
     */
    internal class CSearchElementWhereArrayIsSortedButSizeIsInfinite
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
        //    int target = 4;

        //    int start = 0;
        //    int end = 1;
        //    FindingRange(arr,ref start,ref end,target);
        //    Console.WriteLine(search(arr, start, end, target));
        //}

        private static int search(int[] arr, int start, int end, int target)
        {
            if (start > end)
            {
                return -1;
            }
            int mid = start + (end - start) / 2;
            if (arr[mid] == target)
            {
                return mid;
            }
            if (target > arr[mid])
            {
                return search(arr, mid + 1, end, target);
            }
            else
            {
                return search(arr, start, mid - 1, target);
            }
        }

        private static void FindingRange(int[] arr, ref int start, ref int end, int target)
        {
            while (target > arr[end])
            {
                int newstart = end + 1;
                end = end + (end - start + 1) * 2;
                start = newstart;
            }
        }
    }
}
