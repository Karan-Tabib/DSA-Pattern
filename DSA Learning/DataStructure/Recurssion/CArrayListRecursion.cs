using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.Recurssion
{
    internal class CArrayListRecursion
    {
        static void CArrayListRecursion_Main(string[] args)
        {
            Console.WriteLine("Find array is sorted or not with recursion?");
            int[] arr = { 1, 2, 4, 16, 8, 16, 9, 12 };
            Console.WriteLine("Sorted Or Not :{0}", SortedArrayOrNot(arr, 0));

            Console.WriteLine("Linear search with recursion");
            int number = 16;
            Console.WriteLine("Linear search for Number ={0} at index ={1}", number, LinearSerachWithRecursion(arr, number, 0));

            Console.WriteLine("search All index of number  with recursion");
            number = 16;
            SearchAllindex(arr, number, 0);
            Console.WriteLine("search All index of number={0}  with recursion:{1}", number, string.Join(',', list.ToArray()));
        }


        private static bool SortedArrayOrNot(int[] arr)
        {
            bool sorted = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    sorted = false;
                    break;
                }
            }
            return sorted;
        }

        private static bool SortedArrayOrNot(int[] arr, int start)
        {
            if (start == arr.Length - 1)
            {
                return true;
            }

            return arr[start] < arr[start + 1] && SortedArrayOrNot(arr, start + 1);
        }

        private static bool LinearSerachWithRecursionReturnBool(int[] arr, int target, int start)
        {
            if (start == arr.Length)
            {
                return false;
            }

            return arr[start] == target || LinearSerachWithRecursionReturnBool(arr, target, start + 1);
        }
        private static int LinearSerachWithRecursion(int[] arr, int target, int start)
        {
            if (start > arr.Length - 1)
            {
                return -1;
            }
            if (arr[start] == target)
            {
                return start;
            }

            return LinearSerachWithRecursion(arr, target, start + 1);
        }
        private static int LinearSerachWithRecursionFromLast(int[] arr, int target, int start)
        {
            if (start == -1)
            {
                return -1;
            }
            if (arr[start] == target)
            {
                return start;
            }

            return LinearSerachWithRecursion(arr, target, start - 1);
        }

        static List<int> list = new List<int>();
        private static void SearchAllindex(int[] arr, int target, int start)
        {
            if (start == arr.Length)
            {
                return;
            }
            if (arr[start] == target)
            {
                list.Add(start);
            }

            SearchAllindex(arr, target, start + 1);
        }

        private List<int> SearchAllindex(int[] arr, int target, int start, List<int> list1)
        {
            if (start == arr.Length)
            {
                return list1;
            }
            if (arr[start] == target)
            {
                list1.Add(start);
            }

            return SearchAllindex(arr, target, start + 1, list1);
        }

        private List<int> SearchAllindex1(int[] arr, int target, int start)
        {
            List<int> list = new List<int>();

            if (start == arr.Length)
            {
                return list;
            }
            if (arr[start] == target)
            {
                list.Add(start);
            }

            List<int> list1 = SearchAllindex1(arr, target, start + 1);
            list.AddRange(list1);
            return list;
        }
    }
}
