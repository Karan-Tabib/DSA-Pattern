using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.BinarySearch.Examples
{
    internal class CSearchInBinaryRotatingArray
    {
        /*
         * Approach Find Pivot .
         * pivot is element from which next number are in ascending order here pivot will always be largest number
         * divide array into two part 0 to pivot & pivot +1  to end
         * apply binary search because this is sorted array
         * 
         * How do we find the pivot?
         * arr[3,4,5,6,7,1,2}
         * 
         * pivot
         * case 1 :
         *          where arr[mid] > arr[mid+1] 
         * 
         * case 2 :
         *          mid element < (mid -1) element
         *        
         * case 3 :
         *          start element  > mid element
         *          e= mid-1
         *         
         * case 4: start elemet < mid elment 
         *          start = mid +1;
         * 
         */

        //static void Main(string[] args)
        //{
        //    int[] arr = { 3, 4, 5, 6, 7, 1, 2 };
        //    int target = 5;
        //    int ans = Search(arr, target);

        //    Console.WriteLine(ans);
        //}

        private static int Search(int[] arr, int target)
        {
            int pivot = FindPivotElemt(arr);

            // if you did not find a pivot then array is not rotated
            if (pivot == -1)
            {
                return BinarySearch(arr, target, 0, arr.Length - 1);
            }

            // if pivot is found , you have found 2 asc array

            // case 1: pivot elemet == target element
            if (arr[pivot] == target)
            {
                return pivot;
            }

            if (target > arr[0])
            {
                // here we reduce the space to pivot -1 as pivot is largest number
                return BinarySearch(arr, target, 0, pivot - 1);
            }
            else
            {
                return BinarySearch(arr, target, pivot + 1, arr.Length - 1);
            }

        }

        private static int FindPivotElemt(int[] arr)
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
                if (arr[start] > arr[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return -1;
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

        static int BinarySearch(int[] arr, int target, int start, int end)
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
            if (target < arr[mid])
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }

            return BinarySearch(arr, target, start, end);
        }
    }
}
