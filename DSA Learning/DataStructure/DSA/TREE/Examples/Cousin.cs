using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class Cousin
    {
        /*
         * 993. Cousins in Binary Tree
         * https://leetcode.com/problems/cousins-in-binary-tree/description/?envType=problem-list-v2&envId=binary-tree
         */
        public bool IsCousins(TreeNode root, int x, int y)
        {
            TreeNode xx = findNode(root, x);
            TreeNode yy = findNode(root, y);
            return (Level(root, xx, 0) == Level(root, yy, 0) && !IsSibling(root, xx, yy));
        }

        private bool IsSibling(TreeNode root, TreeNode xx, TreeNode yy)
        {
            if (root == null)
            {
                return false;
            }

            return (root.left == xx && root.right == yy) || 
                    (root.left == yy && root.right == xx) ||
                    IsSibling(root.left, xx, yy) || 
                    IsSibling(root.right, xx, yy);
        }

        private int Level(TreeNode root, TreeNode xx, int lev)
        {
            if (root == null)
            {
                return 0;
            }
            if (root == xx)
            {
                return lev;
            }

            int l = Level(root.left, xx, lev + 1);
            if (l != 0)
            {
                return l;
            }

            return Level(root.right, xx, lev + 1);
        }

        private TreeNode findNode(TreeNode root, int val)
        {
            if (root == null)
            {
                return null;
            }
            if (root.val == val)
            {
                return root;
            }
            TreeNode node = findNode(root.left, val);
            if (node != null)
            {
                return node;
            }
            return findNode(root.right, val); ;
        }
    }
}
