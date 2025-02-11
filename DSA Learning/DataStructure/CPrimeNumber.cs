using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure
{
    internal class CPrimeNumber
    {
        static void CPrimeNumberMain(string[] args)
        {
            int number = 36;
            // bool isprime = IsPrimeNumber(number);

            bool[] primes = new bool[number + 1];
            AllPrimeNumber(number, primes);

        }

        private static bool IsPrimeNumber(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            for (int i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //optimized
        private static bool IsPrimeNumber2(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            int i = 2;
            while (i * i <= number)  // number of iteration are reduced to half
            {
                if (number % i == 0)
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        //again optimized 
        private static void AllPrimeNumber(int number, bool[] primes)
        {
            for (int i = 2; i * i <= number; i++)
            {
                if (!primes[i])
                {
                    for (int j = i * 2; j <= number; j = j + i)
                    {
                        primes[j] = true;
                    }
                }
            }

            for (int i = 2; i < number; i++)
            {
                if (!primes[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
