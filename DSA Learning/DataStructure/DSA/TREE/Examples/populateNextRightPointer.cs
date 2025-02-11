using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    /*
     * 116. Populating Next Right Pointers in Each Node
     * 
     * 
     */
    internal class populateNextRightPointer
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public Node Connect(Node root)
        {
            if (root == null)
                return null;

            Node LeftMost = root;
            while (LeftMost.left != null)
            {
                Node Current = LeftMost;
                while (Current !=null)
                {
                    Current.left.next = Current.right;
                    if (Current.next != null)
                    {
                        Current.right.next = Current.next.left;
                    }
                    Current = Current.next;
                }
                LeftMost = LeftMost.left;
            }
            return root;
        }
    }
}
