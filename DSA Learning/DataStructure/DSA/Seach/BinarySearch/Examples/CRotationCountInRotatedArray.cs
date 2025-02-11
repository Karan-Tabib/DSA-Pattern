using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.BinarySearch.Examples
{
    internal class CRotationCountInRotatedArray
    {
        /*Q Find Rotation count in rotated sorted Array
         * 
         * Approch : find pivot element which largest number
         * 
         */

        //static void Main(string[] args)
        //{
        //    int[] arr = { 4, 5, 6, 7, 1, 2, 3 };
        //    int pivot = FindRotationInRotateArray(arr);
        //    Console.WriteLine(pivot);
        //}

        private static int FindRotationInRotateArray(int[] arr)
        {
            int pivot = FindPivotElemtWithDuplicateElement(arr);
            return pivot + 1;
        }

        private static int FindPivotElemtWithDuplicateElement(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                //case 1:
                if (mid < end && arr[mid] > arr[mid + 1])
                {
                    return mid;
                }
                //case 2:
                if (mid > start && arr[mid] < arr[mid - 1])
                {
                    return mid - 1;
                }

                //Case 3,4:
                if (arr[mid] == arr[start] && arr[mid] == arr[end])
                {
                    if (arr[start] > arr[start + 1])
                    {
                        return start;
                    }
                    start++;

                    //check whether end is pivot
                    if (arr[end] < arr[end - 1])
                    {
                        return end - 1;
                    }
                    end--;
                }
                else if (arr[start] < arr[mid] || arr[start] == arr[mid] && arr[mid] > arr[end])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return -1;
        }
    }
}
