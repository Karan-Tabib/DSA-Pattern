using System.Reflection.Metadata.Ecma335;

namespace Learning.DataStructure.DSA.Queue
{
    internal class CQueue
    {
        static void _Main(string[] args)
        {
            Console.WriteLine("QUEUE");
            //Queue<int> queue = new Queue<int>();
            //CCustomQueue queue = new CCustomQueue();
            CCircularQueue queue = new CCircularQueue();
            queue.insert(11);
            queue.insert(12);
            queue.insert(13);
            queue.insert(14);
            queue.insert(24);
            queue.display();
            Console.WriteLine(queue.remove());
            queue.insert(3);
            queue.display();
        }
    }
    public class CCustomQueue
    {
        public int[] data;
        public const int DEFAULT_SIZE = 5;
        public int ptr = 0;  // ptr is last index
        public CCustomQueue() : this(DEFAULT_SIZE)
        {
        }
        public CCustomQueue(int size)
        {
            data = new int[size];
        }

        public bool isFull()
        {
            return ptr == data.Length;
        }

        public bool isEmpty()
        {
            return ptr == 0;
        }


        public bool insert(int item)
        {
            if (isFull())
            {
                return false;
            }
            data[ptr++] = item;
            return true;
        }

        public int remove()
        {
            if (isEmpty())
            {
                return -1;
            }
            int remvoed = data[0];
            // shift element to left
            for (int i = 1; i < data.Length; i++)
            {
                data[i - 1] = data[i];
            }
            ptr--;
            return remvoed;
        }

        public int front()
        {
            if (isEmpty())
            {
                return -1;
            }
            return data[0];
        }

        public void display()
        {
            for (int i = 0; i < ptr; i++)
            {
                Console.Write("{0}<-", data[i]);
            }
            Console.WriteLine("<-END");
        }
    }

    public class CCircularQueue
    {
        protected int[] data;
        protected const int DEFAULT_SIZE = 5;
        protected int front = 0;
        protected int end = 0;
        protected int size = 0;

        public CCircularQueue() : this(DEFAULT_SIZE)
        {

        }
        public CCircularQueue(int size)
        {
            data = new int[size];
        }

        public bool isFull()
        {
            return size == DEFAULT_SIZE;
        }

        public bool isEmpty()
        {
            return size == 0;
        }
        public bool insert(int item)
        {
            if (isFull())
            {
                return false;
            }
            data[end++] = item;
            end = end % data.Length;
            size++;
            return true;
        }

        public int remove()
        {
            if (isEmpty())
            {
                throw new Exception("Circular Queue Full!");
            }

            int removed = data[front++];
            front = front % data.Length;
            size--;
            front++;
            return removed;
        }

        public int Front()
        {
            if (isEmpty())
            {
                throw new Exception("Queue is Empty");
            }
            return data[front];
        }

        public void display()
        {
            int i = front;
            do
            {
                Console.Write("{0}<-", data[i]);
                i++;
                i = i % data.Length;
            } while (i != end);
            Console.WriteLine("<-END");
        }
    }
}
