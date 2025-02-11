using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.LinkedList
{
    internal class CCircularLinkedList
    {
        private ListNode head;
        private ListNode tail;

        public CCircularLinkedList()
        {
            head = null;
            tail = null;
        }

        public void insert(int val)
        {
            ListNode node = new ListNode(val);
            if (head == null)
            {
                head = node;
                tail = node;
                return;
            }

            tail.next = node;
            node.next = head;
            tail = node;
        }

        public void Display()
        {
            ListNode node = head;
            if (head != null)
            {
                do
                {
                    Console.Write("{0}->", node.val);
                    node = node.next;
                } while (node != head);
                Console.Write("End\n");
            }
        }

        public void delete(int val)
        {
            ListNode node = head;
            if (node.val == val)
            {
                head = head.next;
                tail = head;
                return;
            }

            do
            {
                ListNode nextnode = node.next;
                if (nextnode.val == val)
                {
                    node.next = nextnode.next;
                    break;
                }
                node = node.next;
            } while (node != head);
        }
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val)
            {
                this.val = val;
            }
        }
    }

    public class CCircularLinkedList_main
    {
        static void _Main(string[] args)
        {
            CCircularLinkedList ll = new CCircularLinkedList();
            ll.insert(1);
            ll.insert(2);
            ll.insert(3);
            ll.insert(4);
            ll.insert(5);
            ll.Display();
            ll.delete(3);
            ll.Display();
        }
    }
}
