namespace Learning.DataStructure.DSA.Stack
{
    public class CustomStack
    {
        protected int[] data;
        private const int DEFAULT_SIZE = 5;
        public int ptr = -1;

        public CustomStack() : this(DEFAULT_SIZE)
        {

        }

        public CustomStack(int size)
        {
            data = new int[size];
        }

        public virtual bool push(int item)
        {
            if (isFull())
            {
                Console.WriteLine("Stack is full");
                return false;
            }
            ptr++;
            data[ptr] = item;
            return true;
        }

        public int pop()
        {
            if (isEmpty())
            {
                throw new Exception("Cannot pop Element from an empty stack");
            }
            //int remvoed = data[ptr];
            //ptr--;
            return data[ptr--];
        }

        public bool isFull()
        {
            return ptr == data.Length - 1;
        }

        public bool isEmpty()
        {
            return ptr == -1;
        }

        public int peak()
        {
            return data[ptr];
        }
    }

    public class stackMain
    {
        static void _Main(string[] args)
        {
            CDynamicStack stack = new CDynamicStack();
            stack.push(1);
            stack.push(2);
            stack.push(3);
            stack.push(4);

            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());

        }
    }
}
