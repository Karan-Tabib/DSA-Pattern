using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.BackTracking
{
    public class CNQueue
    {
        public CNQueue()
        {

        }

        public int NQueues(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                display(board);
                return 1;
            }

            int count = 0;
            //placing the Queue and checking for every row & col
            for (int col = 0; col < board.GetLength(0); col++)
            {
                if (isSafe(board, row, col))
                {
                    board[row, col] = true;
                    count = count + NQueues(board, row + 1);
                    board[row, col] = false;
                }

            }

            return count;
        }

        private bool isSafe(bool[,] board, int row, int col)
        {
            //CHECK FOR VERTICAL ROW
            for (int i = 0; i < row; i++)
            {
                if (board[i, col] == true)
                {
                    return false;
                }
            }

            // CHECK FOR DIAGONAL LEFT SIDE
            int maxLeft = Math.Min(row, col);
            for (int i = 0; i <= maxLeft; i++)
            {
                if (board[row - i, col - i] == true)
                {
                    return false;
                }
            }

            // CHECK FOR DIAGONAL RIGHT SIDE
            int maxRight = Math.Min(row, board.GetLength(0) - col - 1);
            for (int i = 0; i <= maxRight; i++)
            {
                if (board[row - i, col + i] == true)
                {
                    return false;
                }
            }
            return true;
        }

        private void display(bool[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == true)
                    {
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void _Main(string[] args)
        {
            CNQueue nQueue = new CNQueue();
            bool[,] board =
            {
                {false,false,false,false,false},
                {false,false,false,false,false},
                {false,false,false,false,false},
                {false,false,false,false,false},
                {false,false,false,false,false},
            };
            Console.WriteLine("Count:{0}", nQueue.NQueues(board, 0));
        }
    }
}
