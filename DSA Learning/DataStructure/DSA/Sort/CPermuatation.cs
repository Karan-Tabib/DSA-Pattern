using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Sort
{
    internal class CPermuatation
    {
        static void CPermuatation_Main(string[] args)
        {
            Permutation(string.Empty, "abc");
            Console.ReadLine();
        }
        static void Permutation(string p, string up)
        {
            if (string.IsNullOrEmpty(up))
            {
                Console.WriteLine(p);
                return;
            }

            char ch = up[0];

            for (int i = 0; i<=p.Length; i++)
            {
                string first = p.Substring(0, i);
                string second = p.Substring(i);
                Permutation(first + ch + second, up.Substring(1));
            }
        }

        static int PermutationCount(string p, string up)
        {
            if (string.IsNullOrEmpty(up))
            {
                Console.WriteLine(p);
                return 1;
            }
            int count = 0;

            char ch = up[0];

            for (int i = 0; i < p.Length; i++)
            {
                string first = p.Substring(0, i);
                string second = p.Substring(i, p.Length);
                count = count + PermutationCount(first + ch + second, up.Substring(1));
            }

            return count;
        }
    }
}
