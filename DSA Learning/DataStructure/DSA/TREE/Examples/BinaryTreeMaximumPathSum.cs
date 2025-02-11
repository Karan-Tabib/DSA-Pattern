using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class BinaryTreeMaximumPathSum
    {
        /*
         * 124. Binary Tree Maximum Path Sum
         * https://leetcode.com/problems/binary-tree-maximum-path-sum/description/?envType=problem-list-v2&envId=binary-tree
         */
        int maxSum = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            helper(root);
            return maxSum;
        }

        private int helper(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int left = helper(node.left);
            int right = helper(node.right);

            left = Math.Max(left, 0);
            right = Math.Max(right, 0);

            int pathSum = left + right + node.val;
            maxSum = Math.Max(maxSum, pathSum);

            return Math.Max(left, right) + node.val;
        }
        
    }
}
