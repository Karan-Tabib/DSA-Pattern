using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    /*
     * 297. Serialize and Deserialize Binary Tree
     * https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/?envType=problem-list-v2&envId=binary-tree
     */
    internal class SerializeandDeserializeBinaryTree
    {
        public string serialize(TreeNode root)
        {
            List<string> list = new List<string>();
            helper(root, list);
            return string.Join(",", list);
        }

        private void helper(TreeNode root, List<string> list)
        {
            if(root == null)
            {
                list.Add(null);
                return;
            }

            list.Add(root.val.ToString());
            helper(root.left, list);
            helper(root.right, list);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
           List<string> strings = data.Split(',').ToList();
            strings.Reverse();
            TreeNode root = helper2(strings);
            return root;
        }

        private TreeNode helper2(List<string> data)
        {
            if (data.Count == 0)
            {
                return null; // No more data to process
            }
            string value = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            if (value == null || string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            TreeNode node = new TreeNode(Convert.ToInt32(value));

            node.left = helper2(data);
            node.right = helper2(data);

            return node;
        }
    }
}
