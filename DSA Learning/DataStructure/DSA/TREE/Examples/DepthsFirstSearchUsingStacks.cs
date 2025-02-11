using Learning.DataStructure.DSA.Queue.Example_Stack_And_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Learning.DataStructure.DSA.LinkedList.CCircularLinkedList;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class DepthsFirstSearchUsingStacks
    {
        public void DFSUsingStack(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode removednode = stack.Pop();
                Console.Write(removednode.val + " ");
                if (removednode.right != null)
                {
                    stack.Push(removednode.right);
                }
                if (removednode.left != null)
                {
                    stack.Push(removednode.left);
                }
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            int sum = getNumbers(l1) + getNumbers(l2);
            string reverseno = new string(sum.ToString().Reverse().ToArray());
            ListNode list = new ListNode(Convert.ToInt32(reverseno[0]));
            for(int i = 1;i<reverseno.Length;i++)
            {
                list.next =new ListNode(Convert.ToInt32(reverseno[i]));
                list= list.next;
            }
            return list;
        }
        private int getNumbers(ListNode list)
        {
            int num = 0;
            int count = 0;
            while (list.next != null)
            {
                num = (int)(list.val * Math.Pow(10, count)) + num;
                count++;
            }
            return num;
        }
    }
}
