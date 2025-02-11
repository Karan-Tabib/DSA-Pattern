using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class SymetricTree
    {
        /*
         * 101. Symmetric Tree
         * https://leetcode.com/problems/symmetric-tree/description/?envType=problem-list-v2&envId=binary-tree
         */
        public bool IsSymmetric(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);

            while (queue.Count > 0)
            {
                TreeNode left = queue.Dequeue();
                TreeNode right = queue.Dequeue();

                if (left == null && right == null)
                {
                    continue;
                }

                if (left == null || right == null)
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;
                }

                queue.Enqueue(left.left);
                queue.Enqueue(right.right);
                queue.Enqueue(left.right);
                queue.Enqueue(right.left);
            }
            return true;
        }
    }
}
