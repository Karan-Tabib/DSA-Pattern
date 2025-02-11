using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.BinarySearch.Examples
{
    /*
     * int[] arr ={ 1,2,3,4,7,7,7,7,7,8,9};
     * here target =7
     * first occurence is 4 & last occurence is 8 
     * ans [4,8] else return [-1,-1]
     */
    internal class CfindFirstAndLastOccuranceOfNumber
    {
        //static void Main(string[] args)
        //{
        //    int[] arr= {1,2,3,4,7,7,7,7,7,8,9};
        //    int target = 7;
        //    int[]ans = FindFirstAndLastOccuranceOfNumber(arr, target,0,arr.Length-1);
        //    Console.WriteLine($"{string.Join(',',ans)}");
        //}

        private static int[] FindFirstAndLastOccuranceOfNumber(int[] arr, int target, int start, int end)
        {
            int[] ans = { -1, -1 };

            int first = BinarySearch(arr, target, 0, arr.Length, true, -1);
            int second = BinarySearch(arr, target, 0, arr.Length, false, -1);
            ans[0] = first;
            ans[1] = second;
            return ans;
        }

        static public int BinarySearch(int[] arr, int target, int start, int end, bool isFirstElement, int ans)
        {

            if (start > end)
            {
                return ans;
            }
            int mid = start + (end - start) / 2;
            if (arr[mid] == target)
            {
                ans = mid;

                if (isFirstElement)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            else
            {
                if (target > arr[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return BinarySearch(arr, target, start, end, isFirstElement, ans);

        }
    }
}
