using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.Queue.Example_Stack_And_Queue
{
    internal class CValidparenthesis
    {
        public bool IsValidParenthesis(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in s.ToCharArray())
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else
                {
                    if (ch == ')')
                    {
                        if (stack.IsEmpty() || stack.Pop() != '(')
                        {
                            return false;
                        }
                    }
                    else if (ch == '}')
                    {
                        if (stack.IsEmpty() || stack.Pop() != '{')
                        {
                            return false;
                        }
                    }
                    else if (ch == ']')
                    {
                        if (stack.IsEmpty() || stack.Pop() != '[')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public int MinimumAddTomakeValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in s.ToCharArray())
            {
                if (ch == ')')
                {
                    if (!stack.IsEmpty() && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(ch);
                    }
                }
                else
                {
                    stack.Push(ch);
                }
            }

            return stack.Count;
        }
    }
}
