using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.BinarySearch
{

    /*
     What is binary search ?
       This is optimized way of searching. In Binary search arrays are in sorted order.
        In linear search maximum no of comparison would be N.

        1) find the middle element
        2) As we have sorted array all the element at left hand side  of mid are less than mid & all the element which are right side are greaterthan mid.
        3) if target > mid then search element at right side or search left side
        3)if mid == target  then its your target element

        Best case : where your middle element is your target.only single iterator O(1)
        Worst case :N/2^k =1
                    log(n)= klog(2)
                    k = log(n)/log(2)
                    k = logN base 2
        
     */
    internal class CBinarySearch
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        //    int target = 5;

        //   int index= BinarySearch(arr, target,0,arr.Length-1);
        //    Console.WriteLine(index);

        //    // how to search element if we dont know whether array is sorted in asending or descending
        //    int[] arr1 = { 99, 88, 67, 44, 33, 28, 19, 16, 13, 8, 5, 3 };
        //    bool order = arr1[0] < arr1[arr1.Length-1];
        //     index = BinarySearchASCDSC(arr1, target, 0, arr1.Length - 1,order);
        //    Console.WriteLine(index);
        //}

        private static int BinarySearch(int[] arr, int target, int start, int end)
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

            if (arr[mid] < target)
            {
                return BinarySearch(arr, target, mid + 1, end);
            }
            else
            {
                return BinarySearch(arr, target, start, mid - 1);
            }
        }

        private static int BinarySearchASCDSC(int[] arr, int target, int start, int end, bool order)
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
                    return BinarySearchASCDSC(arr, target, mid + 1, end, order);
                }
                else
                {
                    return BinarySearchASCDSC(arr, target, start, mid - 1, order);
                }
            }
            else
            {
                if (arr[mid] > target)
                {
                    return BinarySearchASCDSC(arr, target, mid + 1, end, order);
                }
                else
                {
                    return BinarySearchASCDSC(arr, target, start, mid - 1, order);
                }
            }
        }
    }
}
