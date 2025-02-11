using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.BitManipulation
{
    /*
     *Bitwise AND(&) : both are true then true else false
     * 
     *     a  |  b   |
     *   -----------------
     *     0  | 0    | 0
     *     0  | 1    | 0
     *     1  | 0    | 0
     *     1  | 1    | 1
     *     
     *    Note : when you AND 1 with any number , digit will remain the same
     *              110010100
     *          &   111111111
     *          ---------------
     *              110010100 same number  
     *              
     *              a & b == !a || !b
     *Bitwise OR(|) : any one is true then true else false  
     *   
     *   Table : a|b
     *   
     *     a  |  b   |
     *   -----------------
     *     0  | 0    | 0
     *     0  | 1    | 0
     *     1  | 0    | 0
     *     1  | 1    | 1
     *     
     *
     *Bitwise XOR (^) : onlyu one should be true
     *
     *Table : a^b
     *   
     *     a  |  b   |
     *   -----------------
     *     0  | 0    | 0
     *     0  | 1    | 1
     *     1  | 0    | 1
     *     1  | 1    | 0
     *     
     * Note : 
     *     I) XOR any number with 1 will get complement of number
     *          a ^ 1 = a complement 
     *     II) XOR any number with 0 will get same number.
     *          a ^ 0 = a
     *     III) XOR with same number will be Zero
     *          a ^ a = 0
     *          
     * 
     * Complement(~) :
     *          a= 10110
     *          ~a = 01001
     *          
     *          
     * LEFT SHIFT OPERATOR: (<<)
     *      
     *      10 base 10 = (1010) base 2
     *     
     *     1010 << 1 == 10100 shifted towards left and added zero to right
     *     
     *     10 << 1 == 20 
     *     
     *     therefore  a << 1 == 2a  :: any nymber  left shift 1 will be twice of that number
     *     
     *     a << b == a * (a^b)
     * 
     * 
     * Right Shift Operator (>>)  
     * 
     *  Q = 0011001 >> 1 = 001100  right side number will be removed 
     *    
     *    a >> b = a /(2^b)
     *    
     *    
     * Range Formula for N bits :
     *  
     *  -2 raise to (n-1)  to  (2 raise to (n-1) -1)
     *  Ex for 2 bits
     *  -2 ^1 to 2 ^1 -1  == -2 to 1 -- 
     */


    internal class CBitManupulation
    {

        static void CBitManupulationMain(string[] args)
        {
            Console.WriteLine("Find Odd & Even number using bitwise?");
            int number = 13;
            bool isOddOrEven = findOddEvenBitwise(number);
            if (isOddOrEven)
            {
                Console.WriteLine("Odd Number");
            }
            else
            {
                Console.WriteLine("Even number");
            }


            Console.WriteLine("\nEvery element in array are duplicate/ repeated . Find Single number in array?");
            int[] arr = { 2, 3, 4, 1, 1, 2, 3, 6, 4 };
            int singleNo = FindNonRepeatedNumber(arr);
            Console.WriteLine("unique No:{0}", singleNo);


            Console.WriteLine("\n Find Ith Bit of Number?");
            int bitPos = 4;
            number = 27;
            int bitValue = FindParticularBit(number, bitPos);
            Console.WriteLine("ith Bit :{0}", bitValue);

            Console.WriteLine("\n Set Ith Bit of Number?");
            bitPos = 2;
            number = 27;
            bitValue = SetParticularBit(number, bitPos);
            Console.WriteLine("ith Bit :{0}", bitValue);

            Console.WriteLine("\n Find the position of right most set bit?");
            number = 27;
            bitValue = FindRightMostSetBit(number);
            Console.WriteLine("Right most set Bit :{0}", bitValue);

            Console.WriteLine("\n Find the nth magic number?");
            number = 6;
            int magicNo = FindMagicNumber(number);
            Console.WriteLine("Magic Number:{0}", magicNo);

            Console.WriteLine("\n Find no of digit in base 2");
            number = 235;
            int nodigit = FindNumberOfDigitinBinary(number);
            Console.WriteLine("No of Digit:{0}", nodigit);


            Console.WriteLine("\n Check number is power of 2");
            number = 16;
            Console.WriteLine("power of two:{0}", IspowerOfTwo(number));

            Console.WriteLine("\n Calaulate A raise to power B");
            number = 2;
            int power = 3;
            Console.WriteLine("A raise to B:{0}", FindPower(number, power));

        }

        private static int FindPower(int number, int power)
        {
            int ans = 1;
            while (power > 0)
            {
                if ((power & 1) == 1)
                {
                    ans = ans * number;
                }
                number = number * number;
                power = power >> 1;
            }
            return ans;
        }

        private static bool IspowerOfTwo(int number)
        {
            // handle Number= 0 case
            return (number & number - 1) == 0;
        }

        private static int FindNumberOfDigitinBinary(int number)
        {
            int baseno = 10;
            //change base to binary to count digit in binary
            //Log a base b =  log(a) /log(b)
            return (int)(Math.Log(number) / Math.Log(baseno)) + 1;
        }

        private static int FindMagicNumber(int number)
        {
            int ans = 0;
            int baseNumber = 5;
            while (number > 0)
            {
                int last = number & 1;
                number = number >> 1;
                ans = ans + last * baseNumber;
                baseNumber = baseNumber * 5;
            }
            return ans;
        }

        private static int FindRightMostSetBit(int number)
        {
            return -1;
        }

        private static int SetParticularBit(int number, int bitPos)
        {
            /*
              * let say number= 27   binary of 27  == 11011
                 any OR with 1 will set number to 1 but we have set bitpositon to 1 & others bit to zero
                  :: 1 << bitpos-1 == 000010
              */
            return number | 1 << bitPos - 1;
        }

        private static int FindParticularBit(int number, int bitpos)
        {
            /*
             * let say number= 27   binary of 27  == 11011
                any & with 1 will give you same number but we have set bitpositon to 1 & others bit to zero
                 :: 1 << bitpos-1 == 1000
             */

            return number & 1 << bitpos - 1;
        }

        private static bool findOddEvenBitwise(int number)
        {
            //point : every number is calaculated in binary form internally


            // note : 10011 -- execpt last digit every other digit is power of 2

            // so last digit is determinig whether no is odd or even
            // 2 raise to zero ==1 then number is odd  else number is even
            //

            // now how to get last number in binary ?
            //  will user number & 1 = = 1 then odd
            // the last digit is known as LSB( lease significant bit)
            return (number & 1) == 1;
        }
        private static int FindNonRepeatedNumber(int[] arr)
        {
            // As we know every number XOR with Zero will give you same number &
            // Every number XOR wih same number will give you Zero
            // so if you have dumplicate number then XOR of duplicate no will be zero and
            // single number XOR with Zero will give you same number that would be answer

            int unique = 0;

            foreach (int num in arr)
            {
                unique = unique ^ num;
                // unique ^= num; 
            }

            return unique;
        }
    }
}
