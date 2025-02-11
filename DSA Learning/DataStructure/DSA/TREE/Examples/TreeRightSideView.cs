using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class TreeRightSideView
    {
        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int numOfElementAtlevel = queue.Count;
                for (int i = 0; i < numOfElementAtlevel; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if ( i == numOfElementAtlevel - 1)
                    {
                        result.Add(node.val);
                    }
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }
            return result;
        }
    }
}
