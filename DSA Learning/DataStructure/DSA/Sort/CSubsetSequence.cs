using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learning.DataStructure.DSA.Sort
{
    internal class CSubsetSequence
    {
        //static void Main(string[] args)
        //{
        //    //abc is given string find all posible substring for this
        //    // ans -> a,b,c,ab,ac,bc,abc

        //    //SubSequence(string.Empty, "abc");


        //    //ArrayList list = SubSequenceUsingArraylist(string.Empty, "abc");
        //    //Console.WriteLine($"{string.Join(",", list.ToArray())}");


        //    SubSequenceWithAscii(string.Empty, "abc");
        //    Console.WriteLine('a' + 1);
        //    Console.ReadLine();
        //}

        private static void SubSequence(string process, string unProcess)
        {
            if (string.IsNullOrEmpty(unProcess))
            {
                Console.WriteLine(process);
                return;
            }
            char ch = unProcess[0];
            SubSequence(ch + process, unProcess.Substring(1));
            SubSequence(process, unProcess.Substring(1));
        }

        //Return ArrayList

        private static ArrayList SubSequenceUsingArraylist(string process, string unProcess)
        {
            if (string.IsNullOrEmpty(unProcess))
            {
                ArrayList list = new ArrayList();
                list.Add(process);
                return list;
            }
            char ch = unProcess[0];
            ArrayList left = SubSequenceUsingArraylist(ch + process, unProcess.Substring(1));
            ArrayList right = SubSequenceUsingArraylist(process, unProcess.Substring(1));
            left.AddRange(right);
            return left;
        }


        private static void SubSequenceWithAscii(string process, string unProcess)
        {
            if (string.IsNullOrEmpty(unProcess))
            {
                Console.WriteLine(process);
                return;
            }
            char ch = unProcess[0];
            SubSequence(ch + process, unProcess.Substring(1));
            SubSequence(process, unProcess.Substring(1));
            SubSequence(process + (ch + 0), unProcess.Substring(1));
        }
    }
}
