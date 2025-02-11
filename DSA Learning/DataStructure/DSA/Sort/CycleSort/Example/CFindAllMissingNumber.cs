using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort.CycleSort.Example
{
    internal class CFindAllMissingNumber
    {

        //static void Main(string[] args)
        //{

        //    int[] arr = { 4, 3, 2, 7, 8, 2, 3, 1 };
        //    List<int> missingNo = MissingNumber(arr);
        //    Console.WriteLine($"{string.Join(',', missingNo)}");
        //}

        private static List<int> MissingNumber(int[] arr)
        {
            List<int> MissingList = new List<int>();
            CycleSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i + 1)
                {
                    MissingList.Add(i + 1);
                }
            }
            return MissingList;
        }

        static private void CycleSort(int[] arr)
        {
            int i = 0;
            while (i < arr.Length)
            {
                int correct = arr[i] - 1;
                if (arr[i] != arr[correct])
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

