using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    /*
     * 114. Flatten Binary Tree to Linked List
     * https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/?envType=problem-list-v2&envId=binary-tree
     */
    internal class FlattenBinaryTreeToLinkedList
    {
        public void Flatten(TreeNode root)
        {
            TreeNode current = root;

            while (current != null)
            {
                if (current.left != null)
                {
                    TreeNode temp= current.left;
                    while(temp.right != null)
                    {
                        temp = temp.right;
                    }
                    temp.right = current.right;
                    current.right = current.left;
                    current.left = null;
                }
                current = current.right;
            }
        }
    }
}
