using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learning.DataStructure.DSA.BackTracking
{
    internal class MazeProblem
    {
        public int countpath(int row, int col)
        {
            if (row == 1 || col == 1)
            {
                return 1;
            }

            int left = countpath(row - 1, col);
            int right = countpath(row, col - 1);

            return left + right;
        }

        public void Path(string process, int row, int col)
        {
            if (row == 1 && col == 1)
            {
                Console.WriteLine(process);
                return;
            }

            if (row > 1)
            {
                Path(process + "D", row - 1, col);
            }

            if (col > 1)
            {
                Path(process + "R", row, col - 1);
            }
        }

        public ArrayList Path_Arry(string process, int row, int col)
        {
            if (row == 1 && col == 1)
            {
                ArrayList list = new ArrayList();
                list.Add(process);
                return list;
            }
            ArrayList list1 = new ArrayList();
            if (row > 1)
            {
                list1.AddRange(Path_Arry(process + "D", row - 1, col));
            }

            if (col > 1)
            {
                list1.AddRange(Path_Arry(process + "R", row, col - 1));
            }

            return list1;
        }

        public ArrayList Path_ArryDiagonal(string process, int row, int col)
        {
            if (row == 1 && col == 1)
            {
                ArrayList list = new ArrayList();
                list.Add(process);
                return list;
            }
            ArrayList list1 = new ArrayList();
            if (col > 1 && row > 1)
            {
                list1.AddRange(Path_ArryDiagonal(process + "D", row - 1, col - 1));
            }
            if (row > 1)
            {
                list1.AddRange(Path_ArryDiagonal(process + "V", row - 1, col));
            }

            if (col > 1)
            {
                list1.AddRange(Path_ArryDiagonal(process + "H", row, col - 1));
            }

            return list1;
        }

        public void PathWithRestriction(string process, bool[,] maze, int row, int col)
        {
            if (row == maze.GetLength(0) - 1 && col == maze.GetLength(0) - 1)
            {
                Console.WriteLine(process);
                return;
            }

            if (maze[row, col] == false)
            {
                return;
            }

            if (row < maze.GetLength(0) - 1)
            {
                PathWithRestriction(process + "D", maze, row + 1, col);
            }

            if (col < maze.GetLength(0) - 1)
            {
                PathWithRestriction(process + "R", maze, row, col + 1);
            }
        }

        public void AllPAth(string process, bool[,] maze, int row, int col)
        {
            if (row == maze.GetLength(0) - 1 && col == maze.GetLength(0) - 1)
            {
                Console.WriteLine(process);
                return;
            }

            if (maze[row, col] == false)
            {
                return;
            }
            maze[row, col] = false;

            if (row < maze.GetLength(0) - 1)
            {
                AllPAth(process + "D", maze, row + 1, col);
            }

            if (col < maze.GetLength(0) - 1)
            {
                AllPAth(process + "R", maze, row, col + 1);
            }

            if (row > 0)
            {
                AllPAth(process + "U", maze, row - 1, col);
            }

            if (col > 0)
            {
                AllPAth(process + "L", maze, row, col - 1);
            }
            maze[row, col] = true;
        }

        public void AllPAthWithMetric(string process, bool[,] maze, int row, int col, int level, int[,] path)
        {
            if (row == maze.GetLength(0) - 1 && col == maze.GetLength(0) - 1)
            {
                path[row, col] = level;
                for (int i = 0; i < path.GetLength(0); i++)
                {
                    for (int j = 0; j < path.GetLength(1); j++)
                    {
                        Console.Write($"{path[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(process);
                Console.WriteLine();
                return;
            }

            if (maze[row, col] == false)
            {
                return;
            }
            maze[row, col] = false;
            path[row, col] = level;

            if (row < maze.GetLength(0) - 1)
            {
                AllPAthWithMetric(process + "D", maze, row + 1, col, level + 1, path);
            }

            if (col < maze.GetLength(0) - 1)
            {
                AllPAthWithMetric(process + "R", maze, row, col + 1, level + 1, path);
            }

            if (row > 0)
            {
                AllPAthWithMetric(process + "U", maze, row - 1, col, level + 1, path);
            }

            if (col > 0)
            {
                AllPAthWithMetric(process + "L", maze, row, col - 1, level + 1, path);
            }
            maze[row, col] = true;
            path[row, col] = 0;
        }

        static void _Main(string[] args)
        {
            MazeProblem mazeProblem = new MazeProblem();
            Console.WriteLine("No of Path :{0}", mazeProblem.countpath(3, 3));
            mazeProblem.Path("", 3, 3);
            Console.WriteLine($" Path : {string.Join(',', mazeProblem.Path_Arry("", 3, 3).ToArray())}");
            Console.WriteLine($" Path with List :{string.Join(',', mazeProblem.Path_Arry("", 3, 3).ToArray())}");
            Console.WriteLine($" Path with diagonal :{string.Join(',', mazeProblem.Path_ArryDiagonal("", 3, 3).ToArray())}");

            bool[,] maze =
            {
                { true,true,true },
                { true,true,true },
                { true,true,true }
            };

            Console.WriteLine("path with Restriction:");
            mazeProblem.PathWithRestriction("", maze, 0, 0);
            Console.WriteLine("All path with Restriction:");
            mazeProblem.AllPAth("", maze, 0, 0);

            int[,] path =
            {
               { 0,0,0 },
               { 0,0,0 },
               { 0,0,0 }
            };
            Console.WriteLine("All path with Metrix:");
            mazeProblem.AllPAthWithMetric("", maze, 0, 0, 1, path);
        }

    }
}
