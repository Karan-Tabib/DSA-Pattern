using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort.CycleSort.Example
{
    internal class CDuplicateNumber
    {
        //static void Main(string[] args)
        //{

        //    int[] arr = { 1, 3, 4, 2, 2 };
        //    int duplicateNum = DuplicateNumber(arr);
        //    Console.WriteLine($"{string.Join(',', duplicateNum)}");
        //}

        private static int DuplicateNumber(int[] arr)
        {
            int i = 0;
            while (i < arr.Length)
            {
                if (arr[i] != i + 1)
                {
                    int correct = arr[i] - 1;
                    if (arr[i] != arr[correct])
                    {
                        Swap(arr, i, correct);
                    }
                    else
                    {
                        return arr[i];
                    }
                }
                else
                {
                    i++;
                }
            }
            return -1;
        }



        static private void Swap(int[] arr, int i, int correct)
        {
            int temp = arr[i];
            arr[i] = arr[correct];
            arr[correct] = temp;
        }
    }
}
