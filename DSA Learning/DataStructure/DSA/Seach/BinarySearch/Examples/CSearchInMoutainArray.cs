using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.BinarySearch.Examples
{
    internal class CSearchInMoutainArray
    {
        /*
         Approach find peak element from array devide array into two sorted array
         apply orderagnosticbinary search on first array which is from zero index to peak index
          if index not found then search in second array
         */

        //static void Main(string[] args)
        //{
        //    int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 5, 4, 2, 1 };
        //    int target = 7;
        //    int peak = PeakElementMountainArray(arr, 0, arr.Length - 1);
        //    int firstTry = OrderAgnosticBinarySearch(arr, target, 0, peak, arr[0] < arr[1]);
        //    if (firstTry != -1)
        //    {
        //        Console.WriteLine(firstTry);
        //    }
        //    else
        //    {
        //        int secondTry = OrderAgnosticBinarySearch(arr, target, peak + 1, arr.Length - 1, arr[peak + 1] < arr[peak + 2]);
        //        Console.WriteLine(secondTry);
        //    }
        //}

        private static int PeakElementMountainArray(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return start;
            }
            int mid = start + (end - start) / 2;
            if (arr[mid] < arr[mid + 1])
            {
                start = mid + 1;
            }
            else
            {
                end = mid;
            }

            return PeakElementMountainArray(arr, start, end);
        }

        private static int OrderAgnosticBinarySearch(int[] arr, int target, int start, int end, bool order)
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

            if (order)
            {

                if (arr[mid] < target)
                {
                    return OrderAgnosticBinarySearch(arr, target, mid + 1, end, order);
                }
                else
                {
                    return OrderAgnosticBinarySearch(arr, target, start, mid - 1, order);
                }
            }
            else
            {
                if (arr[mid] > target)
                {
                    return OrderAgnosticBinarySearch(arr, target, mid + 1, end, order);
                }
                else
                {
                    return OrderAgnosticBinarySearch(arr, target, start, mid - 1, order);
                }
            }
        }
    }
}
