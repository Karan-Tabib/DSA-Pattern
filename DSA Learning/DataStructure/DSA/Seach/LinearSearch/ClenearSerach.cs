using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.LinearSearch
{
    internal class ClenearSerach
    {
        //Time complexity :how your time is going to grow as the input is grow.

        //linear search best case scenario : O(1)
        // worst case : O(n)

        //static void Main(string[] args)
        //{
        //    //Q : search a number in array
        //    int[] arr = { 1, 2, 3, 4, 6, 7 };
        //    int target = 4;
        //    LenearSerach(arr, target);
        //}

        private static int LenearSerach(int[] arr, int target)
        {
            if (arr.Length == 0)
            {
                return int.MaxValue;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }

            return int.MaxValue;
        }

        private static int LenearSerachReturnNumber(int[] arr, int target)
        {
            if (arr.Length == 0)
            {
                return int.MaxValue;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    return arr[i];
                }
            }

            return int.MaxValue;
        }

        private static bool LenearSerachReturnBool(int[] arr, int target)
        {
            if (arr.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    return true;
                }
            }

            return false;
        }


    }
}
