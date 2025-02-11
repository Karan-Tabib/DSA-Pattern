using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE
{
    internal partial class BreadthFirstSearch
    {

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return result;
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                IList<int> list = new List<int>();
                int levelCount = queue.Count;
                for (int i = 0; i < levelCount; i++)
                {
                    TreeNode node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(list);

            }
            return result;
        }
    }
}
