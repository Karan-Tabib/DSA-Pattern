using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class LowestCommonAncestorBinaryTree
    {
        /*
         * 236. Lowest Common Ancestor of a Binary Tree
         * https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/?envType=problem-list-v2&envId=binary-tree
         */
        public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }
            if (root == p || root == q)
            {
                return root;
            }

            TreeNode? left = LowestCommonAncestor(root.left, p, q);
            TreeNode? right = LowestCommonAncestor(root.right, p, q);
            if (left != null && right != null)
            {
                return root;
            }

            return left == null ? right : left;
        }
    }
}
