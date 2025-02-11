using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE.Examples
{
    /*
     * 105. Construct Binary Tree from Preorder and Inorder Traversal
     * https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/?envType=problem-list-v2&envId=binary-tree
     */
    internal class BinaryTreeFromPreorderandInorderTraversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
            {
                return null;
            }

            int root = preorder[0];
            int index = 0;

            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == root)
                {
                    index = i;
                    break;
                }
            }

            TreeNode node = new TreeNode(root);
            int leftpreSize = index;
            int remaininglen = inorder.Length - index - 1;

            int[] leftpreOrder = new int[leftpreSize];
            Array.Copy(preorder, index, leftpreOrder, 0, index);

            int[] leftinOrder = new int[leftpreSize];
            Array.Copy(inorder, 0, leftinOrder, 0, index);
            
            int[] RightpreOrder = new int[remaininglen];
            Array.Copy(preorder, index+1, RightpreOrder, 0, remaininglen);

            int[] RightinOrder = new int[remaininglen];
            Array.Copy(inorder, index + 1, RightinOrder, 0, remaininglen);


            node.left = BuildTree(leftpreOrder, leftinOrder);
            node.right = BuildTree(RightpreOrder, RightinOrder);
            return node;
        }
        public TreeNode BuildTree1(int[] preorder, int[] inorder)
        {
            // Base case: if preorder is empty, return null
            if (preorder.Length == 0 || inorder.Length == 0)
            {
                return null;
            }

            // The first element in preorder is the root of the current subtree
            int rootValue = preorder[0];
            TreeNode node = new TreeNode(rootValue);

            // Find the index of the root in the inorder array
            int index = 0;
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == rootValue)
                {
                    index = i;
                    break;
                }
            }

            // Now divide preorder and inorder arrays into left and right subtrees
            int leftTreeSize = index; // Elements in the left subtree
            int rightTreeSize = inorder.Length - index - 1; // Elements in the right subtree

            // Recursively build left and right subtrees
            node.left = BuildTree1(
                preorder.Skip(1).Take(leftTreeSize).ToArray(),
                inorder.Take(leftTreeSize).ToArray()
            );

            node.right = BuildTree1(
                preorder.Skip(1 + leftTreeSize).Take(rightTreeSize).ToArray(),
                inorder.Skip(index + 1).Take(rightTreeSize).ToArray()
            );

            return node;
        }
    }




    public class Program
    {
        public static void Main_(string[] args)
        {
            BinaryTreeFromPreorderandInorderTraversal solution = new BinaryTreeFromPreorderandInorderTraversal();

            int[] preorder = { 3, 9, 20, 15, 7 };
            int[] inorder = { 9, 3, 15, 20, 7 };

            TreeNode root = solution.BuildTree(preorder, inorder);

            // Output the tree or traverse to verify correctness
            Console.WriteLine("Tree constructed successfully.");
        }
    }

}
