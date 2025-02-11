using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort
{
    internal class CMegeSort
    {
        /* Merge Sort:
         *
         *     1)Divide arrray into two parts
         *     2)sort two array using recusrion
         *     3)merged those sorted array
         */

        static void CMegeSort_Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            //MergeSort(arr);

            //Console.WriteLine($"{string.Join(',', MergeSort(arr))}");
            MergeSortInplace(arr, 0, arr.Length);
            Console.WriteLine($"{string.Join(',', arr)}");

        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }
            //0,1,5,3,6 5/2 = 2
            int mid = arr.Length / 2;
            int FirstArraysize = mid;
            int SecondArraysize = arr.Length - mid;

            int[] dest1 = new int[FirstArraysize];
            int[] dest2 = new int[SecondArraysize];

            Array.Copy(arr, dest1, FirstArraysize);
            Array.Copy(arr, FirstArraysize, dest2, 0, SecondArraysize);

            int[] left = MergeSort(dest1);
            int[] right = MergeSort(dest2);

            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;
            int[] mix = new int[left.Length + right.Length];
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    mix[k] = left[i];
                    i++;
                    k++;
                }
                else
                {
                    mix[k] = right[j];
                    j++;
                    k++;
                }
            }

            while (i < left.Length)
            {
                mix[k] = left[i];
                i++;
                k++;
            }
            while (j < right.Length)
            {
                mix[k] = right[j];
                j++;
                k++;
            }

            return mix;
        }

        private static void MergeSortInplace(int[] arr, int start, int end)
        {
            if (end - start == 1)
            {
                return;
            }
            int mid = start + (end - start) / 2;

            MergeSortInplace(arr, start, mid);
            MergeSortInplace(arr, mid, end);

            MergeInplace(arr, start, end, mid);
        }


        private static void MergeInplace(int[] arr, int start, int end, int mid)
        {
            int i = start, j = mid, k = 0;
            int[] mix = new int[end - start];
            while (i < mid && j < end)
            {
                if (arr[i] < arr[j])
                {
                    mix[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    mix[k] = arr[j];
                    j++;
                    k++;
                }
            }

            while (i < mid)
            {
                mix[k] = arr[i];
                i++;
                k++;
            }
            while (j < end)
            {
                mix[k] = arr[j];
                j++;
                k++;
            }

            for (int l = 0; l < mix.Length; l++)
            {
                arr[start + l] = mix[l];
            }
        }
    }
}
