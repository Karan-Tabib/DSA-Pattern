namespace Learning.DataStructure.DSA.Queue.Example_Stack_And_Queue
{
    // Implement Queue Using Stacks
    // there are two approach adding or removing efficiently
    public class ImplementQueueUsingStacksRemovingEffciently
    {
        protected Stack<int> first;
        protected Stack<int> second;
        public ImplementQueueUsingStacksRemovingEffciently()
        {
            first = new Stack<int>();
            second = new Stack<int>();
        }

        public void add(int item)
        {
            while (!first.IsEmpty())
            {
                second.Push(first.Pop());
            }
            first.Push(item);

            while (!second.IsEmpty())
            {
                first.Push(second.Pop());
            }
        }
        public int remove()
        {
            return first.Pop();  //REMOVING  Efficiently
        }

        public int peek()
        {
            return first.Peek();
        }

        public bool isEmpty()
        {
            return first.IsEmpty();
        }
    }
}
