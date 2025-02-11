using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    /*
     * 104. Maximum Depth of Binary Tree
     * https://leetcode.com/problems/maximum-depth-of-binary-tree/description/?envType=problem-list-v2&envId=binary-tree
     */
    internal class MaxDepthOfBinaryTree
    {

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);
            int nodeDepth = Math.Max(left, right) + 1;
            return nodeDepth;
        }
        List<int> result = new List<int>();
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            IList<int> left = InorderTraversal(root.left);
            IList<int> right = InorderTraversal(root.right);

            if (left.Count > 0)
            {
                result.AddRange(left);
            }
            result.Add(root.val);
            if (right.Count > 0)
            {
                result.AddRange(right);
            }
            return result;
        }
    }
}
