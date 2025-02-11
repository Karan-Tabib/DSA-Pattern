using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure
{
    internal class CFactors
    {
        static void CFactorsMain(string[] args)
        {
            Console.WriteLine("Write Factors of a number");
            int number = 20;
            Factors(number);
            Console.WriteLine();
            //optimized 
            Factors2(number);
            Console.WriteLine();
            Factors3(number);
        }

        private static void Factors(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Console.Write("{0},", i);
                }
            }
        }

        private static void Factors2(int number)
        {
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    Console.Write("{0},{1},", i, number / i);
                }
            }
        }

        private static void Factors3(int number)
        {
            ArrayList list = new ArrayList();

            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    Console.Write("{0},", i);
                    list.Add(number / i);
                }
            }
            //list.Sort();
            //foreach (int i in list)
            //{
            //    Console.Write("{0},",i);
            //}
            for (int i = list.Count - 1; i >= 0; i--)
            {
                Console.Write("{0},", list[i]);
            }

        }
    }
}
