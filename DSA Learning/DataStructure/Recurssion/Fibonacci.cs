using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.Recurssion
{
    internal class CFibonacci
    {
        //0 1 1 2 3 5 8 
        static void CFibonacci_Main(string[] args)
        {
            int num = 5;
            int ans = Fibonacci(num);
            Console.WriteLine(ans);
        }
        private static int Fibonacci(int num)
        {
            if (num < 2)
            {
                return num;
            }

            return Fibonacci(num - 1) + Fibonacci(num - 2);
        }
    }
}
