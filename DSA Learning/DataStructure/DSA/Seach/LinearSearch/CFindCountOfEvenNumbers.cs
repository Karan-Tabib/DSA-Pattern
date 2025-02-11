using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Seach.LinearSearch
{
    internal class CFindCountOfEvenNumbers
    {
        //static void Main(string[] args)
        //{
        //    int[] arr = { 1, 2, 34, 567, 8976 };
        //    //display count for having even no of digits
        //    // 1 is having single digit ==odd
        //    // 34  has 2 digit == even
        //    //ans =2
        //    int ans = FindCountOfEvenNumbers(arr);
        //    Console.WriteLine(ans);
        //    Console.ReadLine();

        //}

        private static int FindCountOfEvenNumbers(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (EvenDigitNumber(arr[i]))
                    count++;
            }

            return count;
        }

        //function to check, number contains even number of digit or not
        private static bool EvenDigitNumber(int num)
        {
            int count = NumOfDigit2(num);

            //if(count % 2 == 0)
            //    return true;

            //return false;

            return count % 2 == 0;
        }

        private static int NumOfDigit2(int num)
        {
            if (num < 0)
            {
                num = num * -1;
            }
            return (int)Math.Log10(num) + 1;

        }

        private static int NumOfDigit(int num)
        {
            int count = 0;
            if (num == 0)
                count = 1;

            while (num > 0)
            {
                count++;
                num = num / 10;
            }

            return count;
        }


    }
}
