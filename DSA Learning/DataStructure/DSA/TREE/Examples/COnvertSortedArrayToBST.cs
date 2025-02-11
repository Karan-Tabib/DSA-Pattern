using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    internal class COnvertSortedArrayToBST
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return ConstructTree(nums, 0, nums.Length - 1);

        }
        private TreeNode ConstructTree(int[] arr, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(arr[mid], null, null);

            node.left = ConstructTree(arr, start, mid - 1);
            node.right = ConstructTree(arr, mid + 1, end);
            return node;
        }
    }
}
