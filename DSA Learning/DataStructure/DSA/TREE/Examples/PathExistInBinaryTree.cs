using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class PathExistInBinaryTree
    {
        public bool PathExistInBinaryTreeAtLeafNode(TreeNode root, int[] arr)
        {
            return helper(root, arr, 0);
        }

        private bool helper(TreeNode node, int[] arr, int index)
        {
            if (node == null)
            {
                return false;
            }

            if (index >= arr.Length || node.val != arr[index])
            {
                return false;
            }

            if (index == arr.Length - 1 && node.left == null && node.right == null)
            {
                return true;
            }

            bool left = helper(node.left, arr, index + 1);
            bool right = helper(node.right, arr, index + 1);

            return left || right;
        }

        public int PathExistInBinaryTreesAtAnyNode(TreeNode root, int target)
        {
            return CountPaths(root, target);
        }

        private int CountPaths(TreeNode root, int target)
        {
            List<int> paths = new List<int>();
            return CountPaths(root, target, paths);
        }

        private int CountPaths(TreeNode node, int target, List<int> paths)
        {
            if (node == null)
            {
                return 0;
            }
            paths.Add(node.val);
            int count = 0;
            int sum = 0;

            paths.Reverse();
            IEnumerator itr = paths.GetEnumerator();
            while (itr.MoveNext())
            {
                sum += Convert.ToInt32(itr.Current);
                if (sum == target)
                {
                    count++;
                }
            }
            paths.Reverse();
            count += CountPaths(node.left, target, paths) + CountPaths(node.right, target, paths);

            paths.Remove(paths.Count - 1);
            return count;
        }

        private List<List<int>> FindPaths(TreeNode root, int target)
        {
            List<List<int>> paths = new List<List<int>>();
            List<int> path = new List<int>();
            FindPaths(root, target,path,paths);
            return paths;
        }

        private void FindPaths(TreeNode node, int target, List<int> path, List<List<int>> paths)
        {
            if (node == null)
            {
                return;
            }
            path.Add(node.val);
           
            if(node.val == target && node.left ==null && node.right == null)
            {
                paths.Add(new List<int>(path));
            }
            else
            {
                FindPaths(node.left, target-node.val, path,paths);
                FindPaths(node.right, target-node.val, path,paths);
            }
   
            path.Remove(path.Count - 1);
        }
    }
}
