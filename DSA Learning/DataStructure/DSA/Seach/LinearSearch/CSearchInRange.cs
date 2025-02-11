using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.LinearSearch
{
    internal class CSearchInRange
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = { 1, 2, 4, 8, 9, 5, 6, 7, 8, 10};
        //    int start = 3;
        //    int end = 6;
        //    int target = 8;
        //    SearchInRange(arr, start, end, target);
        //}

        private static int SearchInRange(int[] arr, int start, int end, int target)
        {
            if (arr.Length == 0)
                return -1;

            for (int i = start; i <= end; i++)
            {
                if (arr[i] == target) return i;
            }

            return -1;
        }
    }
}
