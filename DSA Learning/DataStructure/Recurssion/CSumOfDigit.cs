using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.Recurssion
{
    internal class CSumOfDigit
    {
        static void CSumOfDigit_Main(string[] args)
        {
            int number = 245;
            Console.WriteLine("Find Sum of Digit");
            Console.WriteLine("Sum Of Digit {0} = {1}", number, SumOfDigit(number));
            Console.WriteLine("product Of Digit {0} = {1}", number, ProductofDigit(number));
            Console.WriteLine("ReverseNumber Of Digit {0} = {1}", number, ReverseNumber(number, ""));
        }

        private static int ProductofDigit(int number)
        {
            if (number % 10 == number)
            {
                return number;
            }
            return number % 10 * SumOfDigit(number / 10);
        }

        private static int SumOfDigit(int number)
        {
            if (number % 10 == number)
            {
                return number;
            }
            return number % 10 + SumOfDigit(number / 10);
        }

        private static int ReverseNumber1(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int rem = number % 10;
                sum = sum * 10 + rem;
                number = number / 10;
            }
            return sum;
        }

        private static int ReverseNumber(int number, int sum)
        {
            sum = sum * 10 + number % 10;

            if (number % 10 == number)
            {
                return sum;
            }

            return ReverseNumber(number / 10, sum);
        }
        private static string ReverseNumber(int number, string sum)
        {
            int rem = number % 10;
            sum = sum + rem;
            if (rem == number)
            {
                return sum;
            }

            return ReverseNumber(number / 10, sum);
        }
    }
}
