using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort
{
    internal class CSubSet
    {
        static void CSubSet_Main(string[] args)
        {
            int[] arr = { 1, 2, 2 };
            //SubsetDuplicate(arr);
            List<List<int>> ans = SubsetDuplicate(arr);
            foreach (List<int> list in ans)
            {
                Console.WriteLine($"{string.Join(',', list.ToArray())}");
            }
            Console.WriteLine();
        }

        static List<List<int>> Subset(int[] arr)
        {
            List<List<int>> outerlist = new List<List<int>>();
            outerlist.Add(new List<int>());

            foreach (int nums in arr)
            {

                int n = outerlist.Count();
                for (int i = 0; i < n; i++)
                {
                    List<int> internalList = new List<int>(outerlist[i]);

                    internalList.Add(nums);
                    outerlist.Add(internalList);
                }
            }
            return outerlist;
        }

        //1,2,2
        static List<List<int>> SubsetDuplicate(int[] arr)
        {
            Array.Sort(arr);
            List<List<int>> outerlist = new List<List<int>>();
            outerlist.Add(new List<int>());
            int start = 0;
            int end = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                start = 0;
                if (i > 0 && arr[i] == arr[i - 1])
                {
                    start = end + 1;
                }
                end = outerlist.Count - 1;
                int n = outerlist.Count();
                for (int j = start; j < n; j++)
                {
                    List<int> internalList = new List<int>(outerlist[j]);
                    internalList.Add(arr[i]);
                    outerlist.Add(internalList);
                }
            }
            return outerlist;
        }

    }
}
