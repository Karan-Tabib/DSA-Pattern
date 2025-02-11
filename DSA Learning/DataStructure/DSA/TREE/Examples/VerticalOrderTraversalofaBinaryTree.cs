using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class VerticalOrderTraversalofaBinaryTree
    {
        /*
         * 987. Vertical Order Traversal of a Binary Tree
         * https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/description/
         */

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            if (root == null)
            {
                return ans;
            }
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            int min = 0;
            int max = 0;
            queue.Enqueue((root, 0));
            while (queue.Count > 0)
            {
                var (node, col) = queue.Dequeue();
                if (node != null)
                {
                    if (!dict.ContainsKey(col))
                    {
                        dict[col] = new List<int>();
                    }
                    dict[col].Add(node.val);

                    min = Math.Min(min, col);
                    max = Math.Max(max, col);

                    queue.Enqueue((node.left, col - 1));
                    queue.Enqueue((node.right, col + 1));
                }
            }

            for (int i = min; i <= max; i++)
            {
                if (dict.ContainsKey(i))
                {
                    ans.Add(dict[i].OrderBy(x => x).ToList());
                    //var sortedValues = dict[key].OrderBy(x => x.level).ThenBy(x => x.val).Select(x => x.val).ToList();
                    //ans.Add(sortedValues);
                }
            }
            return ans;
        }
    }
}
