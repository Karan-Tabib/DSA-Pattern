using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.BinarySearch.Examples
{
    /*
     * Ceiling Number = smallest element in array which is grater than equal to target no.
     * 
     * int arr[] =={1,4,6,8,10,13,15,17,20}
     * target = 14 then ceilinng is 14 as 14 is present
     * if target 15 then 15 is  not there there 17,20 are greater than 15 and smallest among them is 17
     * 
     */
    internal class CceilingofNumber
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = { 2, 3, 5, 9, 14, 16, 18 };
        //    int target = 19;
        //    int index = FloorNumber(arr, target,0,arr.Length-1);
        //    index = CeilingNumber(arr, target, 0, arr.Length - 1);
        //    Console.WriteLine(index);
        //    Console.ReadLine();
        //}

        // number which greater than or equal to target
        private static int CeilingNumber(int[] arr, int target, int start, int end)
        {
            if (target > arr[arr.Length - 1])
            {
                return -1;
            }
            if (start > end)
            {
                return start;
            }
            int mid = start + (end - start) / 2;

            if (arr[mid] == target)
            {
                return mid;
            }

            if (arr[mid] < target)
            {
                return CeilingNumber(arr, target, mid + 1, end);
            }
            else
            {
                return CeilingNumber(arr, target, start, mid - 1);
            }
        }


        // number which less than or equal to target
        private static int FloorNumber(int[] arr, int target, int start, int end)
        {

            if (start > end)
            {
                return end;
            }
            int mid = start + (end - start) / 2;

            if (arr[mid] == target)
            {
                return mid;
            }

            if (arr[mid] < target)
            {
                return FloorNumber(arr, target, mid + 1, end);
            }
            else
            {
                return FloorNumber(arr, target, start, mid - 1);
            }
        }
    }
}
