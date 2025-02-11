using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class SumRoottoLeafNumbers
    {
        /*
         * 129. Sum Root to Leaf Numbers
         * https://leetcode.com/problems/sum-root-to-leaf-numbers/description/?envType=problem-list-v2&envId=binary-tree
         */
        public int SumNumbers(TreeNode root)
        {
            return helper(root, 0);
        }

        private int helper(TreeNode root, int sum)
        {
            if (root == null)
            {
                return 0;
            }
            sum = (sum * 10 + root.val);

            if (root.left == null & root.right == null)
            {
                return sum;
            }

            int left = helper(root.left, sum);
            int right = helper(root.right, sum);

            return left + right;
        }
    }
}
