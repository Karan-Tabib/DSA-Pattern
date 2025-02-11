using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    /*
     * 103. Binary Tree Zigzag Level Order Traversal
     * https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/?envType=problem-list-v2&envId=binary-tree
     */
    internal class ZigzagLevelOrderTraversal
    {
        TreeNode root;
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int value)
            {
                this.val = value;
            }
        }

        public TreeNode Populate()
        {
            Console.WriteLine("Enter the Root Node:");
            int value = Convert.ToInt32(Console.ReadLine());
            root = new TreeNode(value);
            Populate(root);
            return root;
        }

        private void Populate(TreeNode node)
        {
            Console.WriteLine("Do you want to enter left of " + node.val);
            bool left = Convert.ToBoolean(Console.ReadLine());

            if (left)
            {
                Console.WriteLine("Enter the value of the left of " + node.val);
                int value = Convert.ToInt32(Console.ReadLine());
                node.left = new TreeNode(value);
                Populate(node.left);
            }

            Console.WriteLine("Do you want to enter Right of " + node.val);
            bool right = Convert.ToBoolean(Console.ReadLine());

            if (right)
            {
                Console.WriteLine("Enter the value of the Right of " + node.val);
                int value = Convert.ToInt32(Console.ReadLine());
                node.right = new TreeNode(value);
                Populate(node.right);
            }
        }
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            bool leftToRight = true;
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                LinkedList<int> list = new LinkedList<int>();
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (leftToRight)
                    {
                        list.AddLast(node.val);
                    }
                    else
                    {
                        list.AddFirst(node.val);
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                leftToRight = !leftToRight;
                result.Add(list.ToList());
            }
            return result;
        }
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
           List<List<int>> list = new List<List<int>>();
            while (queue.Count > 0)
            {
                List<int> lst = new List<int>();
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    lst.Add(node.val);
                }
                list.Add(lst); 
            }
            for (int i = list.Count - 1; i >= 0; i--)
            {
                result.Add(list[i]);
            }

            return result;
        }
        static void ZigzagLevelOrderTraversal_Main(string[] args)
        {
            ZigzagLevelOrderTraversal tree = new ZigzagLevelOrderTraversal();
            TreeNode root = tree.Populate();
            tree.ZigzagLevelOrder(root);
        }
    }
}
