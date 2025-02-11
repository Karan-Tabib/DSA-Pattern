using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.Recurssion
{
    internal class CFactorial
    {
        static void CFactorial_Main(string[] args)
        {
            int number = 5;
            Console.WriteLine("Find Factorial of Number:");
            Console.WriteLine("Factorial of {0} = {1}", number, Factorial(number));
        }

        private static int Factorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }
    }
}
