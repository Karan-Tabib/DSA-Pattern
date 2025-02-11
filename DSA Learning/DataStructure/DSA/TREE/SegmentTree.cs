using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.DataStructure.DSA.TREE
{
    internal class SegmentTree
    {
        public class Node
        {
            public int data;
            public int startInterval;
            public int endInterval;
            public Node left;
            public Node right;

            public Node(int start, int end)
            {
                this.startInterval = start;
                this.endInterval = end;
            }
        }
        public Node root;
        public SegmentTree(int[] arr)
        {
            //create a tree using array
            this.root = ConstructTree(arr, 0, arr.Length);
        }

        private Node ConstructTree(int[] arr, int start, int end)
        {
            if (start == end)
            {
                Node leaf = new Node(start, end);
                leaf.data = arr[start];
                return leaf;
            }

            Node node = new Node(start, end);
            int mid = (start + end) / 2;
            node.left = ConstructTree(arr, start, mid);
            node.right = ConstructTree(arr, mid, end);

            node.data = node.left.data + node.right.data;
            return node;
        }

        static void SegmentTree_Main(string[] args)
        {
            int[] arr = new int[] { 3, 8, 6, 7, -2, -8, 4, 9 };
            SegmentTree tree = new SegmentTree(arr);

        }
    }
}
