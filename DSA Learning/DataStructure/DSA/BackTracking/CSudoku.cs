using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure.DSA.BackTracking
{
    internal class CSudoku
    {
        static void _Main(string[] args)
        {
            int[,] board = {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
            };

            CSudoku cSudoku = new CSudoku();
            if (cSudoku.Sudoku(board))
            {
                cSudoku.PrintBoard(board);
            }
            else
            {
                Console.WriteLine("Can not solved!");
            }
        }

        public bool Sudoku(int[,] board)
        {
            int n = board.GetLength(0);
            int row = -1;
            int col = -1;

            bool emptyLeft = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == 0)  //Empty number found
                    {
                        row = i;
                        col = j;
                        emptyLeft = false;
                        break;
                    }
                }

                if (emptyLeft == false)
                {
                    break;
                }
            }

            if (emptyLeft == true)
            {
                return true;
            }

            //BackTracking 
            for (int number = 1; number <= 9; number++)
            {
                if (isSafe(board, row, col, number))
                {
                    board[row, col] = number;
                    if (Sudoku(board))
                    {
                        return true;
                    }
                    else
                    {
                        board[row, col] = 0;
                    }
                }
            }

            return false;
        }

        public bool isSafe(int[,] board, int row, int col, int num)
        {
            // CHECK FOR ROW
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[row, i] == num)
                {
                    return false;
                }
            }

            //CHECK FOR COLUMN
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, col] == num)
                {
                    return false;
                }
            }

            //CHECK FOR 3*3 Combo
            //start of the 3 * 3
            int sqrt = (int)Math.Sqrt(board.GetLength(0));
            int startRow = row - row % sqrt;
            int startCol = col - col % sqrt;
            for (int i = startRow; i < startRow + sqrt; i++)
            {
                for (int j = startCol; j < startCol + sqrt; j++)
                {
                    if (board[i, j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void PrintBoard(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
