using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Queue.Example_Stack_And_Queue
{
    internal class ClargestRectangleInHistogram
    {
        public static int LargetRetangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            int max = 0;
            for (int i = 1; i < heights.Length; i++)
            {
                while (!stack.IsEmpty() && heights[i] < heights[stack.Peek()])
                {
                    max = getMax(heights, stack, max, i);
                }
                stack.Push(i);
            }
            return max;
        }

        private static int getMax(int[] heights, Stack<int> stack, int max, int i)
        {
            int area;
            int popped = stack.Pop();
            if (stack.IsEmpty())
            {
                area = heights[popped] * i;
            }
            else
            {
                area = heights[popped] * (i - 1 - stack.Peek());
            }
            return Math.Max(max, area);
        }

        static void _Main(string[] args)
        {
            int[] heights = { 2, 1, 5, 6, 2, 3 };
            Console.WriteLine("{0}", LargetRetangleArea(heights));
        }
    }
}
