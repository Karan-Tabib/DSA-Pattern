using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.Recurssion
{
    /*
     * Rotating Binary Search is a variant of the classic binary search algorithm, designed to work with a rotated sorted array. A rotated sorted array is one where the elements are initially sorted in ascending order, but then some prefix of the array is moved to the end.

For example, consider the array [4, 5, 6, 7, 0, 1, 2]. This is a rotated version of [0, 1, 2, 4, 5, 6, 7].

The challenge with searching in such an array is that the middle element of the array does not give you the full picture of whether to move to the left or right half, as the array is not fully sorted in one direction.

Algorithm
Here is how Rotating Binary Search works:

Identify the middle element:

Let mid = (low + high) / 2.
Determine which half is sorted:

If arr[low] <= arr[mid], the left half is sorted.
Otherwise, the right half is sorted.
Check if the target lies in the sorted half:

If the left half is sorted (arr[low] <= arr[mid]), check if the target is between arr[low] and arr[mid]. If it is, reduce the search space to the left half (low to mid-1), otherwise, search in the right half.
If the right half is sorted (arr[mid] <= arr[high]), check if the target is between arr[mid] and arr[high]. If it is, reduce the search space to the right half (mid+1 to high), otherwise, search in the left half.
Repeat the process until the target is found or the search space is exhausted.

Example
Let’s walk through an example. Suppose you want to search for 6 in the rotated sorted array [4, 5, 6, 7, 0, 1, 2].

Start with the entire array:

low = 0, high = 6.
mid = (0 + 6) / 2 = 3. So, arr[mid] = 7.
Determine the sorted half:

The left half arr[0] to arr[3] is sorted because arr[0] <= arr[3].
Check if the target 6 is in the range [4, 5, 6, 7]. It is.
Update the search space to low = 0, high = 2.

Repeat:

mid = (0 + 2) / 2 = 1. So, arr[mid] = 5.
The left half is sorted (arr[0] <= arr[1]), but 6 is not in the range [4, 5].
So, search the right half: low = 2, high = 2.
Now, low = 2 and high = 2:

arr[mid] = 6. Found the target.
     * 
     */
    internal class CRotatingBinarySearch
    {
        static void CRotatingBinarySearch_Main(string[] args)
        {

        }

        static int Search(int[] arr, int target, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = start + (end - start) / 2;
            if (arr[mid] == target)
            {
                return mid;
            }

            if (arr[start] <= arr[mid])
            {
                if (target >= arr[start] && target <= arr[mid])
                {
                    Search(arr, target, start, mid - 1);
                }
                else
                {
                    Search(arr, target, mid + 1, end);
                }
            }

            if (target >= arr[mid] && target <= arr[end])
            {
                return Search(arr, target, mid + 1, end);
            }

            return Search(arr, target, start, mid - 1);

        }
    }
}
