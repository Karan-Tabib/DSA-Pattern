using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class ValidateBinarySearchTree
    {
        /*
         * 98. Validate Binary Search Tree
         * https://leetcode.com/problems/validate-binary-search-tree/description/?envType=problem-list-v2&envId=binary-tree
         */

        public bool IsValidBST(TreeNode root)
        {
            return helper(root, null, null);
        }

        private bool helper(TreeNode root, int? low, int? high)
        {
            if (root == null)
            {
                return true;
            }
            if (low.HasValue && root.val <= low.Value)
            {
                return false;
            }
            if (high.HasValue && root.val >= high.Value)
            {
                return false;
            }
            bool lefttree = helper(root.left, low, root.val);
            bool righttree = helper(root.right, root.val, high);
            return lefttree && righttree;
        }
    }
}
