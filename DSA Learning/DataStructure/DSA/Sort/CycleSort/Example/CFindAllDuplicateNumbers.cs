using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort.CycleSort.Example
{
    internal class CFindAllDuplicateNumbers
    {
        //static void Main(string[] args)
        //{

        //    int[] arr = { 4, 3, 2, 7, 8, 2, 3, 1 };
        //    List<int> duplicateNum = AllDuplicateNumber(arr);
        //    Console.WriteLine($"{string.Join(',', duplicateNum)}");
        //}
        private static List<int> AllDuplicateNumber(int[] arr)
        {
            List<int> result = new List<int>();
            CycleSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i + 1)
                {
                    result.Add(arr[i]);
                }
            }

            return result;
        }

        static void CycleSort(int[] arr)
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
