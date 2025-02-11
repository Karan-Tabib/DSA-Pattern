using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class InvertTrees
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if(root == null)
            {
                return null;
            }

            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);

            root.left = right;
            root.right = left;

            return root;
        }
    }
}
