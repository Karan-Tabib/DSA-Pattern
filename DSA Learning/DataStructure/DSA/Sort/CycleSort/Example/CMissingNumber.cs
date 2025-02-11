using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort.CycleSort.Example
{
    internal class CMissingNumber
    {
        //static void Main(string[] args)
        //{

        //    int[] arr = { 4, 0,2,1 };
        //    int missingNo= MissingNumber(arr);
        //    if(missingNo != -1)
        //    {
        //        Console.WriteLine(missingNo);
        //    }
        //    Console.WriteLine($"{string.Join(',', arr)}");
        //}

        private static int MissingNumber(int[] arr)
        {
            int MissingNum = -1;
            CycleSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i)
                {
                    MissingNum = i;
                    break;
                }
            }
            return MissingNum;
        }

        static private void CycleSort(int[] arr)
        {
            int i = 0;
            while (i < arr.Length)
            {
                int correct = arr[i];
                if (arr[i] < arr.Length && arr[i] != arr[correct])
                {
                    Swap(arr, i, correct);
                }
                else
                {
                    i++;
                }
            }
        }

        static private void Swap(int[] arr, int i, int correct)
        {
            int temp = arr[i];
            arr[i] = arr[correct];
            arr[correct] = temp;
        }
    }
}
