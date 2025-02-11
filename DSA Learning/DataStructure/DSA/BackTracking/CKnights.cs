using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.BackTracking
{
    internal class CKnights
    {
        static void _Main(string[] args)
        {
            bool[,] board = {
                {false,false,false,false},
                {false,false,false,false},
                {false,false,false,false},
                {false,false,false,false},
            };
            CKnights cKnights = new CKnights();
            cKnights.Knight(board, 0, 0, 4);
        }
        public void Knight(bool[,] board, int row, int col, int knights)
        {
            if (knights == 0)
            {
                display(board);
                return;
            }
            if (row == board.GetLength(0) - 1 && col == board.GetLength(1) - 1)
            {
                return;
            }
            if (col == board.GetLength(1))
            {
                Knight(board, row + 1, 0, knights);
                return;
            }

            if (isSafe(board, row, col))
            {
                board[row, col] = true;
                Knight(board, row, col + 1, knights - 1);
                board[row, col] = false;
            }

            Knight(board, row, col + 1, knights);

        }

        private bool isSafe(bool[,] board, int row, int col)
        {
            if (IsValid(board, row - 2, col - 1))
            {
                if (board[row - 2, col - 1])
                {
                    return false;
                }
            }
            if (IsValid(board, row - 2, col + 1))
            {
                if (board[row - 2, col + 1])
                {
                    return false;
                }
            }
            if (IsValid(board, row - 1, col + 2))
            {
                if (board[row - 1, col + 2])
                {
                    return false;
                }
            }
            if (IsValid(board, row - 1, col - 2))
            {
                if (board[row - 1, col - 2])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValid(bool[,] board, int row, int col)
        {
            if (row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1))
            {
                return true;
            }
            return false;
        }
        private void display(bool[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == true)
                    {
                        Console.Write("K ");
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
    }
}
