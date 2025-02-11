using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DataStructurePatterns.PrefixSumSuffixSum
{
    /*
     * Prefix sum is Sum of all element till that index
     * int[] arr = new int[]{1,2,3,4,5} 
     * int[] prefixSum = new int[n];
     * result would be [1,3,6,10,15]
     * prefix[0] = arr[0] = 1
     * prefix[1] = prefix[0] +arr[1] = 1 +2 =3
     * prefix[2] = prefix[1] +arr[2] = 3+3  =6
     * prefix[3] = prefix[2] +arr[3] = 6+4  =10
     * prefix[4] = prefix[3] +arr[4] = 10+5 =15 
     * SuffixSum is sum of all element from current index till last index.
     * 
     * int[] suffix = new int[n];
     * suffix[4] = arr[4] = 5
     * suffix[3] = suffix[4] +arr[3]  = 5 +4 =9
     * suffix[2] = suffix[3] +arr[2]  = 9+3  =12
     * suffix[1] = suffix[2] +arr[1]  = 12+2  =14
     * suffix[0] = suffix[1] +arr[0]  = 14+1 =15
     * result would be [15,14,12,9,5]
     * 
     * 
     * 
     * 
     */
    class PreffixSum
    {
        public static int[] CalcualtePrefixSum(int[] arr)
        {
            int[] prefixSum = new int[arr.Length];
            prefixSum[0] = arr[0];
            for (int i = 1; i < prefixSum.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + arr[i];
            }
            return prefixSum;
        }
    }
    class SuffixSum
    {
        public static int[] CalcualteSuffixSum(int[] arr)
        {
            int[] suffixSum = new int[arr.Length];
            suffixSum[arr.Length - 1] = arr[arr.Length - 1];

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                suffixSum[i] = suffixSum[i + 1] + arr[i];
            }
            return suffixSum;
        }
    }

    class prefixSumExample
    {
        /*Divide Array into sub array having total as 15
        *  create sub array for given index i  to R;
        */
        public static int[] createSubArrayForGivenIndex(int[] arr, int startIndex, int endIndex)
        {
            List<int> subArray = new List<int>();

            for (int i = startIndex; i <= endIndex; i++)
            {
                subArray.Add(arr[i]);
            }
            return subArray.ToArray();

        }
        /* create All Possible Sub Arrays from given array
         * Output
         * Subarray: 1
           Subarray: 2
           Subarray: 3
           Subarray: 4
           Subarray: 5
           Subarray: 1, 2
           Subarray: 2, 3
           Subarray: 3, 4
           Subarray: 4, 5
           Subarray: 1, 2, 3
           Subarray: 2, 3, 4
           Subarray: 3, 4, 5
           Subarray: 1, 2, 3, 4
           Subarray: 2, 3, 4, 5
           Subarray: 1, 2, 3, 4, 5

         */
        public static List<int[]> CreateSubAllPossibleSubArray(int[] arr)
        {
            List<int[]> allsubArray = new List<int[]>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j <= arr.Length - i && j + i < arr.Length; j++)
                {
                    int[] subArray = createSubArrayForGivenIndex(arr, j, j + i);
                    allsubArray.Add(subArray);
                }
            }
            return allsubArray;
        }

        /*
         * Subarray: 1
           Subarray: 1, 2
           Subarray: 1, 2, 3
           Subarray: 1, 2, 3, 4
           Subarray: 1, 2, 3, 4, 5
           Subarray: 2
           Subarray: 2, 3
           Subarray: 2, 3, 4
           Subarray: 2, 3, 4, 5
           Subarray: 3
           Subarray: 3, 4
           Subarray: 3, 4, 5
           Subarray: 4
           Subarray: 4, 5
           Subarray: 5
         * 
         * 
         */
        public static List<int[]> GenerateAllSubArrays(int[] arr)
        {
            List<int[]> subarrays = new List<int[]>();

            // Loop over all start points
            for (int i = 0; i < arr.Length; i++)
            {
                // Loop over all end points
                for (int j = i; j < arr.Length; j++)
                {
                    // Extract the subarray from index i to j
                    int[] subArray = createSubArrayForGivenIndex(arr, i, j);
                    subarrays.Add(subArray);
                }
            }

            return subarrays;
        }


        /*
         * Divide Array Into Two Sub Array with equal sum = Sum and return Array
         * 
         */

        public static List<int[]> DivideArrayWithEqualSum(int[] arr)
        {
            List<int[]> subarrays = new List<int[]>();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int sum1 = GetprefixSum(arr, 0, i);
                int sum2 = GetprefixSum(arr, i + 1, arr.Length - 1);
                if (sum1 == sum2)
                {
                    subarrays.Add(createSubArrayForGivenIndex(arr, 0, i));
                    subarrays.Add(createSubArrayForGivenIndex(arr, i + 1, arr.Length - 1));
                    break;
                }
            }
            return subarrays;
        }

        private static int GetprefixSum(int[] arr, int startIndex, int endIndex)
        {
            int sum = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public static bool DivideArrayWithEqualSum_Optimized(int[] arr)
        {
            if (arr.Length == 0)
            {
                return false;
            }
            int totalsum = 0, prefixSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalsum += arr[i];
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                prefixSum += arr[i];
                int SuffixSumForNextIndex = totalsum - prefixSum;
                if (prefixSum == SuffixSumForNextIndex)
                {
                    return true;
                }
            }
            return false;
        }


        /* Subarray: 1
           Subarray: 1, 2
           Subarray: 1, 2, 3
           Subarray: 1, 2, 3, 4
           Subarray: 1, 2, 3, 4, 5
           Subarray: 2
           Subarray: 2, 3
           Subarray: 2, 3, 4
           Subarray: 2, 3, 4, 5
           Subarray: 3
           Subarray: 3, 4
           Subarray: 3, 4, 5
           Subarray: 4
           Subarray: 4, 5
           Subarray: 5
       */
        public static int LargetSumOfSubArray(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }
            int maxSumOfSubArray = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                int prefixSum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    prefixSum += arr[j];
                    maxSumOfSubArray = Math.Max(maxSumOfSubArray, prefixSum);
                }
            }
            return maxSumOfSubArray;
        }

        public static int LargetSumOfSubArray_Optimized(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }
            int maxSumOfSubArray = int.MinValue;
            int prefixSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                prefixSum += arr[i];
                maxSumOfSubArray = Math.Max(maxSumOfSubArray, prefixSum);
                if (prefixSum < 0)  // Kadane's Algorithm
                {
                    prefixSum = 0;
                }
            }
            return maxSumOfSubArray;
        }

        public static int MaxDiffernceBetweenTwoElement(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }
            int maxDiffOfTwoEle = int.MinValue;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int diff = arr[j] - arr[i];
                    maxDiffOfTwoEle = Math.Max(maxDiffOfTwoEle, diff);
                }
            }
            return maxDiffOfTwoEle;
        }

        public static int MaxDiffernceBetweenTwoElement_Optimized(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }
            int maxDiffOfTwoEle = int.MinValue;
            int sufixMax = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int diff = sufixMax - arr[i];
                maxDiffOfTwoEle = Math.Max(maxDiffOfTwoEle, diff);
                sufixMax = Math.Max(sufixMax, arr[i]);

            }
            return maxDiffOfTwoEle;
        }

        public static int MinSubArrayLen(int target, int[] nums)
        {
            // you will get Time limit Exceeding error need to handle with sliding window problem
            int minSubArrLen = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int prefixSum = 0,count=0;
                for (int j = i; j < nums.Length; j++)
                {
                    prefixSum += nums[j];
                    count++;
                    if (prefixSum == target)
                    {
                        minSubArrLen = Math.Min(minSubArrLen, count);
                    }
                }
            }
            return minSubArrLen;
        }
    }

    internal class PrefixSumofArray
    {
        static void PrefixSumofArray_Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            int[] prefixSum = PreffixSum.CalcualtePrefixSum(arr);

            Console.WriteLine();
            Console.WriteLine("Prefix Sum ->");
            for (int i = 0; i < prefixSum.Length; i++)
            {
                Console.Write(prefixSum[i] + " ");
            }

            Console.WriteLine();
            int[] sufixSum = SuffixSum.CalcualteSuffixSum(arr);
            Console.WriteLine("\nsuffix Sum ->");
            for (int i = 0; i < sufixSum.Length; i++)
            {
                Console.Write(sufixSum[i] + " ");
            }

            List<int[]> AllSubArray = prefixSumExample.CreateSubAllPossibleSubArray(arr);
            foreach (int[] sub in AllSubArray)
            {
                Console.WriteLine("Subarray: " + string.Join(", ", sub));
            }

            Console.WriteLine();
            AllSubArray = prefixSumExample.GenerateAllSubArrays(arr);
            foreach (int[] sub in AllSubArray)
            {
                Console.WriteLine("Subarray: " + string.Join(", ", sub));
            }

            Console.WriteLine();
            int[] arr1 = { 1, 2, 3, 4, 5, 15 };
            List<int[]> SubArraySum = prefixSumExample.DivideArrayWithEqualSum(arr1);
            foreach (int[] sub in SubArraySum)
            {
                Console.WriteLine("Subarray: " + string.Join(", ", sub));
            }

            Console.WriteLine();
            bool canbeDividedEqually = prefixSumExample.DivideArrayWithEqualSum_Optimized(arr1);
            if (canbeDividedEqually)
            {
                Console.WriteLine("Array Can be divided into Two Equal Sum Parts:{0}", canbeDividedEqually);
            }
            else
            {
                Console.WriteLine("Array Cannot be divided into Two Equal Sum Parts:{0}", canbeDividedEqually);
            }

            Console.WriteLine("Larget Sum of Sub Array :" + prefixSumExample.LargetSumOfSubArray(arr1).ToString());

            Console.WriteLine("Larget Sum of Sub Array Optimized:" + prefixSumExample.LargetSumOfSubArray_Optimized(arr1).ToString());
            int[] arr2 = new int[] { 9, 5, 8, 12, 12, 3, 7, 4 };
            Console.WriteLine("max difference bwteen two Element:" + prefixSumExample.MaxDiffernceBetweenTwoElement(arr2).ToString());
            Console.WriteLine("max difference bwteen two Element:" + prefixSumExample.MaxDiffernceBetweenTwoElement_Optimized(arr2).ToString());
            int[] arr3 = new int[] { 1, 4, 4 };
            int target = 4;
            Console.WriteLine("209. Minimum Size Subarray Sum:" + prefixSumExample.MinSubArrayLen(target,arr3).ToString());
        }
    }
}
