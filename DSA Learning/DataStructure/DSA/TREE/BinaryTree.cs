using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE
{
    internal class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {

        }

        public class Node
        {
            public int value;
            public Node left;
            public Node right;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public void Populate()
        {
            Console.WriteLine("Enter the Root Node:");
            int value = Convert.ToInt32(Console.ReadLine());
            root = new Node(value);
            Populate(root);
        }

        private void Populate(Node node)
        {
            Console.WriteLine("Do you want to enter left of " + node.value);
            bool left = Convert.ToBoolean(Console.ReadLine());

            if (left)
            {
                Console.WriteLine("Enter the value of the left of " + node.value);
                int value = Convert.ToInt32(Console.ReadLine());
                node.left = new Node(value);
                Populate(node.left);
            }

            Console.WriteLine("Do you want to enter Right of " + node.value);
            bool right = Convert.ToBoolean(Console.ReadLine());

            if (right)
            {
                Console.WriteLine("Enter the value of the Right of " + node.value);
                int value = Convert.ToInt32(Console.ReadLine());
                node.right = new Node(value);
                Populate(node.right);
            }
        }

        public void display()
        {
            display(root, "");
        }

        private void display(Node node, string indent)
        {
            if (node == null)
                return;

            Console.WriteLine(indent + node.value);
            display(node.left, indent + "\t");
            display(node.right, indent +"\t");
        }

        public static void BinaryTree_Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.Populate();
            tree.display();
        }
    }
}
