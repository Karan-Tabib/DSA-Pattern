using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.LinkedList
{
    public class CSinglyLinkedList
    {
        public Node Head;
        private Node Tail;
        private int size;

        public CSinglyLinkedList()
        {
            size = 0;
        }
        public class Node
        {
            public int Value;
            public Node Next;
            public Node(int val)
            {
                Value = val;
            }
            public Node(int val, Node next)
            {
                Value = val;
                Next = next;
            }
        }
        public void Display()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.Write("{0}->", temp.Value);
                temp = temp.Next;
            }
            Console.Write("END");
            Console.WriteLine();
        }
        public void InsertFirst(int val)
        {
            Node node = new Node(val);
            node.Next = Head;
            Head = node;

            if (Tail == null)
            {
                Tail = Head;
                return;
            }
            size += 1;
        }
        public void InsertLast(int val)
        {
            if (Tail == null)
            {
                InsertFirst(val);
                return;
            }

            Node node = new Node(val);
            Tail.Next = node;
            Tail = node;
            size = size + 1;
        }
        public void InsertInBetween(int val, int index)
        {
            if (index == 0)
            {
                InsertFirst(val);
                return;
            }
            if (index == size)
            {
                InsertLast(val);
                return;
            }

            Node temp = Head;
            for (int i = 1; i < index; i++)
            {
                temp = temp.Next;
            }
            Node node = new Node(val, temp.Next);
            temp.Next = node;
            size = size + 1;
        }
        public void InsertWithRec(int index, int val)
        {
            Head = InsertWithRec(index, val, Head);
        }
        private Node InsertWithRec(int index, int val, Node nextNode)
        {
            if (index == 0)
            {
                Node node = new Node(val);
                node.Next = nextNode;
                return node;
            }

            nextNode.Next = InsertWithRec(--index, val, nextNode.Next);
            return nextNode;
        }
        public int DeleteFirst()
        {
            int val = Head.Value;
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            size -= 1;

            return val;
        }
        public int Deletelast()
        {
            if (size == 1)
            {
                return DeleteFirst();
            }

            Node secondLast = getIndexNode(size - 1);
            int val = Tail.Value;
            Tail = secondLast;
            Tail.Next = null;
            size -= 1;
            return val;
        }
        private Node getIndexNode(int index)
        {
            Node node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node;
        }
        public int DeleteIndex(int index)
        {
            if (index == 0)
            {
                return DeleteFirst();

            }
            if (index == size - 1)
            {
                return Deletelast();
            }

            Node pre = getIndexNode(index - 1);
            int val = pre.Next.Value;
            pre.Next = pre.Next.Next;
            return val;
        }
        public Node Find(int val)
        {
            Node temp = Head;
            while (temp != null)
            {
                if (temp.Value == val)
                {
                    return temp;
                }
                temp = temp.Next;
            }
            return null;
        }
        public void RemoveDuplicates(Node node)
        {
            //Ex 1->1->2->3->3 remove duplicates 
            // this is sorted list so we can compare current node with next, if same remove 

            while (node.Next != null)
            {
                if (node.Value == node.Next.Value)
                {
                    node.Next = node.Next.Next;
                }
                else
                {
                    node = node.Next;
                }
            }
        }
        public CSinglyLinkedList mergeSortedTwoList(Node headerFirst, Node headerSecond)
        {
            //List - 1->3->5>7
            //List - 2->4>-6->8
            //sorted list would be 1->2->3->4->5->6->7->8
            Node tmp = headerFirst;
            Node tempSec = headerSecond;
            CSinglyLinkedList mergeList = new CSinglyLinkedList();

            while (tmp != null && tempSec != null)
            {
                if (tmp.Value < tempSec.Value)
                {
                    mergeList.InsertLast(tmp.Value);
                    tmp = tmp.Next;
                }
                else
                {
                    mergeList.InsertLast(tempSec.Value);
                    tempSec = tempSec.Next;
                }
            }

            while (tmp != null)
            {
                mergeList.InsertLast(tmp.Value);
                tmp = tmp.Next;
            }

            while (tempSec != null)
            {
                mergeList.InsertLast(tempSec.Value);
                tempSec = tempSec.Next;
            }

            return mergeList;
        }

        public bool IsCyclePresent(Node head)
        {
            if (head == null || head.Next == null)
            {
                return false;
            }

            Node slow = head;
            Node fast = head.Next;
            while (slow != fast)
            {
                if (fast == null || fast.Next == null)
                {
                    return false;
                }
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return true;
        }

        public int FindLengthOfCycle(Node head)
        {
            int count = 0;

            Node slow = head;
            Node fast = head.Next;
            while (fast != null && fast.Next != null)
            {
                if (slow == fast)
                {
                    count = calculateLength(slow, fast);
                    break;
                }
            }

            return count;
        }

        private int calculateLength(Node slow, Node fast)
        {
            int c = 0;
            do
            {
                slow = slow.Next;
                c++;
            } while (slow != fast);
            return c;
        }
        public bool isHappy(int num)
        {
            int start = num;
            int fast = num;
            do
            {
                start = FindSqure(num);
                fast = FindSqure(FindSqure(num));

            } while (start != fast);

            if (start == 1)
                return true;

            return false;
        }

        private int FindSqure(int num)
        {
            int ans = 0;
            while (num > 0)
            {
                int rem = num % 10;
                ans += rem * rem;
                num /= 10;
            }
            return ans;
        }

        public Node MiddleOflinkList(Node node)
        {
            Node slow = node;
            Node fast = node;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            return slow;
        }

    }
    internal class CSinglyLinkedList_Main(string[] args)
    {
        static void _Main(string[] args)
        {
            CSinglyLinkedList ll = new CSinglyLinkedList();
            //ll.InsertFirst(1);
            //ll.InsertFirst(2);
            //ll.InsertLast(3);
            //ll.InsertLast(4);
            //ll.InsertInBetween(5, 3);
            //ll.Display();
            //ll.DeleteFirst();
            //ll.Display();
            //ll.Deletelast();
            //ll.Display();
            //ll.DeleteIndex(2);
            //ll.Display();
            //ll.InsertWithRec(2, 88);
            //ll.Display();

            //ll.InsertLast(1);
            //ll.InsertLast(1);
            //ll.InsertLast(2);
            //ll.InsertLast(3);
            //ll.InsertLast(3);
            //ll.InsertLast(3);
            //ll.Display();
            //ll.RemoveDuplicates(ll.Head);
            //ll.Display();


            CSinglyLinkedList listFirst = new CSinglyLinkedList();
            CSinglyLinkedList listSecond = new CSinglyLinkedList();

            listFirst.InsertLast(1);
            listFirst.InsertLast(3);
            listFirst.InsertLast(5);
            listFirst.InsertLast(7);
            listFirst.Display();
            listSecond.InsertLast(2);
            listSecond.InsertLast(4);
            listSecond.InsertLast(6);
            listSecond.InsertLast(8);
            listSecond.Display();

            CSinglyLinkedList mergList = ll.mergeSortedTwoList(listFirst.Head, listSecond.Head);
            mergList.Display();

        }
    }
}
