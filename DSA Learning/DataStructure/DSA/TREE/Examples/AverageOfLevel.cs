using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class AverageOfLevel
    {
        //637. Average of Levels in Binary Tree
        //https://leetcode.com/problems/average-of-levels-in-binary-tree/description/
        public IList<double> AverageOfLevels(TreeNode root)
        {
            IList<double> result = new List<double>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            
            while (queue.Count > 0)
            {
                int numOfElementAtlevel = queue.Count;
                double sum = 0;
                TreeNode node = queue.Dequeue();
                for (int i = 0; i < numOfElementAtlevel; i++)
                {
                    sum += node.val;
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                sum = sum / numOfElementAtlevel;
                result.Add(sum);
            }
            return result;
        }
    }
}
