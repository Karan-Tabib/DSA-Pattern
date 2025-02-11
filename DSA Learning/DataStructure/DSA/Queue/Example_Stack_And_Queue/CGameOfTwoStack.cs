using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Queue.Example_Stack_And_Queue
{
    public class CGameOfTwoStack
    {
        public CGameOfTwoStack()
        {

        }
        public int GameOfTwoStack(int num, int[] first, int[] second)
        {
            return GameOfTwoStack(num, first, second, 0, 0) - 1;
        }

        private int GameOfTwoStack(int num, int[] first, int[] second, int sum, int count)
        {
            if (sum > num)
            {
                return count;
            }
            if (first.Length == 0 || second.Length == 0)
            {
                return count;
            }
            int[] sendFirst = new int[first.Length - 1];
            int[] sendSecond = new int[second.Length - 1];

            Array.Copy(first, 1, sendFirst, 0, sendFirst.Length);
            Array.Copy(second, 1, sendSecond, 0, sendSecond.Length);

            int ans1 = GameOfTwoStack(num, sendFirst, second, sum + first[0], count + 1);
            int ans2 = GameOfTwoStack(num, first, sendSecond, sum + second[0], count + 1);

            return Math.Max(ans1, ans2);
        }

        static void _Main(string[] args)
        {
            CGameOfTwoStack cGameOfTwoStack = new CGameOfTwoStack();
            //Console.Write("Enter Max Sum:");
            //int MaxSum = int.Parse(Console.ReadLine());
            //Console.Write("\nEnter size of first Array:");
            //int firstArraySize = int.Parse(Console.ReadLine());
            //int[] firstArray = new int[firstArraySize];
            //Console.Write("\nEnter Element of first Array:");
            ////[1,2,3,4,5]
            //for (int i = 0; i < firstArraySize; i++)
            //{
            //    firstArray[i] = int.Parse(Console.ReadLine());
            //}
            ////[6,7,8,9]
            //Console.Write("\nEnter size of Second Array:");
            //int SecondArraySize = int.Parse(Console.ReadLine());
            //int[] secondArray = new int[SecondArraySize];
            //Console.Write("\nEnter Element of second Array:");
            //for (int i = 0; i < SecondArraySize; i++)
            //{
            //    secondArray[i] = int.Parse(Console.ReadLine());
            //}

            int MaxSum = 10;
            int[] firstArray = { 4, 2, 4, 6, 1 };
            int[] secondArray = { 2, 1, 8, 5 };
            Console.WriteLine("Count:{0}", cGameOfTwoStack.GameOfTwoStack(MaxSum, firstArray, secondArray));
        }
    }
}
