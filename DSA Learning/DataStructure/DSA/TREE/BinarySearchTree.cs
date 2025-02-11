using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE
{
    internal class BinarySearchTree
    {
        public class BST
        {
            public Node root;
            public BST() { }

            public class Node
            {
                public int value;
                public Node left;
                public Node right;
                public int height;

                public Node(int value)
                {
                    this.value = value;
                }

                public int getValue()
                {
                    return value;
                }

            }
            public int getHeight(Node node)
            {
                if (node == null)
                    return -1;

                return node.height;
            }

            public bool isEmpty()
            {
                return root == null;
            }

            public void Display()
            {
                Display(root, "Root Node:");
            }

            private void Display(Node node, string indent)
            {
                if (node == null)
                    return;
                Console.WriteLine(indent + node.getValue());
                Display(node.left, "Left child of " + node.getValue() + ": ");
                Display(node.right, "Right child of " + node.getValue() + ": ");
            }

            public Node Insert(int value)
            {
                root = Insert(root, value);
                return root;
            }
            public Node Insert(Node node, int value)
            {
                if (node == null)
                {
                    node = new Node(value);
                    return node;
                }

                if (value < node.getValue())
                {
                    node.left = Insert(node.left, value);
                }

                if (value > node.getValue())
                {
                    node.right = Insert(node.right, value);
                }

                node.height = Math.Max(getHeight(node.left), getHeight(node.right)) + 1;
                return node;
            }
            public void populates(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    Insert(nums[i]);
                }
            }

            public void PopulatedsortedArray(int[] nums)
            {
                PopulatedsortedArray(nums, 0, nums.Length);
            }

            private void PopulatedsortedArray(int[] nums, int start, int end)
            {
                if(start >= end)
                {
                    return;
                }
                int mid = (start + end) / 2;
                Insert(nums[mid]);
                PopulatedsortedArray(nums,start,mid); 
                PopulatedsortedArray(nums,mid+1,end);
            }

            public Boolean Balanced()
            {
                return Balanced(root);
            }

            private bool Balanced(Node node)
            {
                return Math.Abs(getHeight(node.left) - getHeight(node.right)) <= 1 && Balanced(node.right) && Balanced(node.left);
            }

            static void BST_Main(string[] args)
            {
                BST bST = new BST();
                bST.populates(new int[] { 1, 5, 8, 76, 66, 55, 14 });
                bST.Display();
            }
        }
    }
}
