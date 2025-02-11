using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataStructure
{
    internal class CTicTacToe
    {
        public void PlayTicTacToe()
        {
            char[,] board = new char[3, 3];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = ' ';
                }
            }

            char player = 'X';
            bool gameover = false;
            while (!gameover)
            {
                PrintBoard(board);
                Console.WriteLine("Player:" + player + " Enter :");
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                if (board[row, col] == ' ')
                {
                    board[row, col] = player;
                    gameover = HaveWon(board, player);
                    if (!gameover)
                    {
                        player = player == 'X' ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Move!");
                }

                if (gameover)
                {
                    Console.WriteLine("Player {0} WON.Congratualtions!Play Again!", player);
                    PrintBoard(board);
                    break;
                }
                if (!HasEmptySpace(board))
                {
                    Console.WriteLine("NO One Win. Play Again!");
                    PrintBoard(board);
                    break;
                }
            }
        }

        private bool HaveWon(char[,] board, char player)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                //CHECK ROWS
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                {
                    return true;
                }
            }
            //CHECK COLUMN
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
                {
                    return true;
                }
            }

            //CHECK ROWS
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player ||
                  board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            return false;
        }

        private bool HasEmptySpace(char[,] board)
        {
            bool EmptyLeft = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == ' ')
                    {
                        EmptyLeft = true;
                        break;
                    }
                }
                if (EmptyLeft)
                    break;
            }
            return EmptyLeft;
        }
        private void PrintBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " |");
                }
                Console.WriteLine();
            }
        }
        static void Main_Method(string[] args)
        {
            CTicTacToe cTicTacToe = new CTicTacToe();
            cTicTacToe.PlayTicTacToe();
        }
    }
}
