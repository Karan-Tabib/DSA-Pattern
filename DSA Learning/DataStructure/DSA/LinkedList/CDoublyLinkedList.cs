using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.LinkedList
{
    internal class CDoublyLinkedList
    {

        private Node Head;
        private Node Tail;
        private int Size;

        public CDoublyLinkedList()
        {
            Size = 0;
        }

        public class Node
        {
            public int val;
            public Node pre;
            public Node next;

            public Node(int val)
            {
                this.val = val;
            }

            public Node(int val, Node pre, Node next)
            {
                this.val = val;
                this.pre = pre;
                this.next = next;
            }
        }

        public void Display()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.Write("{0}->", temp.val);
                temp = temp.next;
            }
            Console.Write("END\n");
        }

        public void DisplayReverse()
        {
            Node temp = Tail;
            while (temp != null)
            {
                Console.Write("{0}->", temp.val);
                temp = temp.pre;
            }
            Console.Write("END\n");
        }

        public void InsertFirst(int val)
        {
            Node node = new Node(val);
            if (Head == null)
            {
                Head = Tail = node;
                return;
            }

            Head.pre = node;
            node.pre = null;
            node.next = Head;
            Head = node;
            Size += 1;
        }
        public void InsertLast(int val)
        {
            Node node = new Node(val);
            if (Tail == null)
            {
                InsertFirst(val);
            }

            Tail.next = node;
            node.next = null;
            node.pre = Tail;
            Tail = node;
            Size += 1;
        }

        public void InsertIndex(int val, int index)
        {
            Node node = new Node(val);
            if (index == 0)
            {
                InsertFirst(val);
            }
            if (index == Size)
            {
                InsertLast(val);
            }
            Node preNode = getIndex(index);
            if (preNode != null)
            {
                node.next = preNode.next;
                node.pre = preNode;
                preNode.next.pre = node;
                preNode.next = node;
            }
            Size += 1;
        }

        private Node getIndex(int index)
        {
            Node node = Head;
            int count = 0;
            while (node != null)
            {
                if (count == index - 1)
                {
                    return node;
                }
                node = node.next;
                count++;
            }
            return null;
        }

        public int DeleteFirst()
        {
            Node tmp = Head;
            Head = tmp.next;
            tmp.next.pre = null;
            return tmp.val;
        }

        public int Deletelast()
        {
            Node secondlast = getIndex(Size - 1);
            int val = secondlast.next.val;
            secondlast.next = null;
            Tail = secondlast;

            return val;
        }
    }

    internal class CDoublyLinkedList_Main(string[] args)
    {
        static void _Main(string[] args)
        {
            CDoublyLinkedList ll = new CDoublyLinkedList();
            ll.InsertFirst(1);
            ll.InsertFirst(2);
            ll.InsertFirst(3);
            ll.InsertFirst(4);
            ll.InsertIndex(10, 2);
            ll.InsertLast(5);
            ll.Display();
            ll.DisplayReverse();
            Console.WriteLine("Node deleted:{0}", ll.DeleteFirst());
            ll.Display();
        }
    }
}
