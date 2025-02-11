using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort.CycleSort
{
    internal class CCyclickSort
    {
        //static void Main(string[] args)
        //{

        //    int[] arr = { 4, 5, 1, 3, 2 };
        //    CycleSort(arr);
        //    Console.WriteLine($"{string.Join(',', arr)}");
        //}

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
