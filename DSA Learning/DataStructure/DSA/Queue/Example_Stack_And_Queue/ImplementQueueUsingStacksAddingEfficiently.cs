using System.Collections.Generic;

namespace Learning.DataStructure.DSA.Queue.Example_Stack_And_Queue
{
    // Implement Queue Using Stacks
    // there are two approach adding or removing efficiently
    public class ImplementQueueUsingStacksAddingEfficiently
    {
        protected Stack<int> first;
        protected Stack<int> second;
        public ImplementQueueUsingStacksAddingEfficiently()
        {
            first = new Stack<int>();
            second = new Stack<int>();
        }

        public void add(int item)
        {
            first.Push(item);    // adding Efficiently
        }
        public int remove()
        {
            while (!first.IsEmpty())
            {
                second.Push(first.Pop());
            }
            int removed = second.Pop();
            while (!second.IsEmpty())
            {
                first.Push(second.Pop());
            }
            return removed;
        }

        public int peek()
        {
            while (!first.IsEmpty())
            {
                second.Push(first.Pop());
            }
            int Peeked = second.Peek();
            while (!second.IsEmpty())
            {
                first.Push(second.Pop());
            }
            return Peeked;
        }

        public bool isEmpty()
        {
            return first.IsEmpty();
        }
    }

    public static class StackExtension
    {
        public static bool IsEmpty<T>(this Stack<T> stack)
        {
            return stack.Count == 0;
        }
    }
}
