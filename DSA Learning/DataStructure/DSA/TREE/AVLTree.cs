using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE
{
    internal class AVLTree
    {
        public class Node
        {
            public int value;
            public int height;
            public Node left;
            public Node right;

            public Node(int value)
            {
                this.value = value;
            }
            public int GetValue()
            {
                return value;
            }
        }

        public Node root;
        public AVLTree()
        {

        }

        public int GetHeight()
        {
            return GetHeight(root);
        }
        public int GetHeight(Node node)
        {
            if (node == null)
            {
                return -1;
            }

            return node.height;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public bool IsBalance()
        {
            return IsBalance(root);
        }

        private bool IsBalance(Node node)
        {
            return Math.Abs(GetHeight(node.left) - GetHeight(node.right)) <= 1 && IsBalance(node.right) && IsBalance(node.left);
        }

        public void Display()
        {
            Display(root, "Root Node:");
        }

        private void Display(Node node, string indent)
        {
            if (node == null)
                return;
            Console.WriteLine(indent + node.GetValue());
            Display(node.left, "Left child of " + node.GetValue() + ": ");
            Display(node.right, "Right child of " + node.GetValue() + ": ");
        }

        public Node Insert(int value)
        {
            root = Insert(root, value);
            return root;
        }

        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                node = new Node(value);
                //node.height = Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
                return node;
            }
            if (node.value > value)
            {
                node.left = Insert(node.left, value);
            }
            if (node.value < value)
            {
                node.right = Insert(node.right, value);
            }
            node.height = Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;

            return Rotate(node);
        }

        private Node Rotate(Node node)
        {
            if (GetHeight(node.left) - GetHeight(node.right) > 1)
            {
                // left side heavy

                if (GetHeight(node.left.left) - GetHeight(node.left.right) > 0)
                {
                    //left left case
                    return RightRotate(node);
                }
                if (GetHeight(node.left.left) - GetHeight(node.left.right) < 0)
                {
                    // left Right case
                    node.left = LeftRotate(node.left);
                    return RightRotate(node);
                }
            }

            if (GetHeight(node.left) - GetHeight(node.right) < -1)
            {
                // Right side Heavy
                if (GetHeight(node.right.left) - GetHeight(node.right.right) < 0)
                {
                    //Right right case
                    return LeftRotate(node);
                }
                if (GetHeight(node.right.left) - GetHeight(node.right.right) > 0)
                {
                    //Right left case
                    node.right = RightRotate(node);
                    return LeftRotate(node);
                }
            }

            return node;
        }

        private Node LeftRotate(Node c)
        {
            Node p = c.right;
            Node t = p.left;

            p.left = c;
            c.right = t;

            p.height = Math.Max(GetHeight(p.left), GetHeight(p.right) + 1);
            c.height = Math.Max(GetHeight(c.left), GetHeight(c.right) + 1);
            return p;
        }

        private Node RightRotate(Node p)
        {
            Node c = p.left;
            Node t = c.right;

            c.right = p;
            p.left = t;

            p.height = Math.Max(GetHeight(p.left), GetHeight(p.right) + 1);
            c.height = Math.Max(GetHeight(c.left), GetHeight(c.right) + 1);
            return c;
        }

        static void AVLTree_Main(string[] args)
        {
            AVLTree aVLTree = new AVLTree();
           
            for (int i = 0; i < 1000; i++)
            {
                aVLTree.Insert(i);
            }

            Console.WriteLine("Height of Tree:" + aVLTree.GetHeight());
        }
    }
}
