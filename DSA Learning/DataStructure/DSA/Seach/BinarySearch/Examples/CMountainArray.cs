using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.BinarySearch.Examples
{
    /* Array which is inreasing order & then decreasing order
     *  1234521  ans =5
     * find peak in mountain array
     * 
     * check mid  > mid +1 your element is at left side so end = mid -1;
     *      mid < mid + 1 then element is at right side start = mid+1  store mid in possible ans
     * */
    internal class CMountainArray
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 5, 4, 2, 1 };
        //    Console.WriteLine(PeakElementMountainArray(arr,0,arr.Length-1));
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

        /* Search in moutain */


    }
}
