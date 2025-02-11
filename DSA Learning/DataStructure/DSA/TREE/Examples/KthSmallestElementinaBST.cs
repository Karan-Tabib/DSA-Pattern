using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class KthSmallestElementinaBST
    {
        /*
         * 230. Kth Smallest Element in a BST
         * https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/?envType=problem-list-v2&envId=binary-tree
         */
        int cnt = 0;
        public int KthSmallest(TreeNode root, int k)
        {
            return helper(root, k).val;
        }

        private TreeNode helper(TreeNode node, int k)
        {
            if (node == null)
            {
                return null;
            }
            TreeNode left = helper(node.left, k);
            if (left != null)
            {
                return left;
            }
            cnt++;
            if (cnt == k)
            {
                return node;
            }
            return helper(node.right, k);
        }
    }
}
