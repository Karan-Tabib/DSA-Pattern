using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class Path_Sum
    {
        /*
         * 112. Path Sum
         * https://leetcode.com/problems/path-sum/description/?envType=problem-list-v2&envId=binary-tree
         */
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.val == targetSum && root.left == null && root.right == null)
            {
                return true;
            }

            bool left = HasPathSum(root.left, targetSum - root.val);
            bool right = HasPathSum(root.right, targetSum - root.val);

            return left || right;
        }
    }
}
