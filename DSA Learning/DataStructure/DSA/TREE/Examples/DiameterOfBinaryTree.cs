using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class DiameterOfBinaryTrees
    {
        /*
         * 543. Diameter of Binary Tree
         * https://leetcode.com/problems/diameter-of-binary-tree/description/?envType=problem-list-v2&envId=binary-tree
         */
        int diameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            Height(root);
            return diameter -1;
        }

        private int Height(TreeNode node)
        {
            if(node == null)
            {
                return 0;
            }

            int leftHeight = Height(node.left);
            int rightHeight = Height(node.right);

            int dia = leftHeight + rightHeight +1;
            diameter =Math.Max(diameter, dia);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
