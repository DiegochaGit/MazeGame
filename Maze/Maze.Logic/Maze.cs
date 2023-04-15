using System.Globalization;

namespace Maze.Logic
{
    public class MyMaze
    {
        private char[,] _maze;
        
        public MyMaze(int n, int obstacles)
        {
            N = n;
            Obstacles = obstacles;
            _maze = new char[N, N];
            FillMaze();
        }

        public int N { get; }

        public int Obstacles { get; }

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    output += $"{_maze[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        private void FillMaze()
        {
            FillBorders();
            FillObstacles();
        }

        private void FillBorders()
        {
            _maze[0, 0] = '█';
            for (int j = 1; j < N-1; j++)
            {
                _maze[0, j] = '▀';
            }
            _maze[0, N - 1] = '█';
            for (int j = 0; j < N - 1; j++)
            {
                _maze[1, j] = ' ';
            }
            _maze[1, N - 1] = '█';
            for (int i = 2; i < N - 1; i++)
            {
                _maze[i, 0] = '█';
                for (int j = 1; j < N - 1; j++)
                {
                    _maze[i, j] = ' ';
                }
                _maze[i, N - 1] = '█';
            }
            _maze[N - 2, N - 1] = ' ';
            _maze[N - 1, 0] = '█';
            for (int j = 1; j < N; j++)
            {
                _maze[N - 1, j] = '▄';
            }            
            _maze[N - 1, N - 1] = '█';
        }

        private void FillObstacles()
        {
            var random = new Random();
            int obstaclesCount = 0;
            do
            {
                var i = random.Next(1, N - 1);
                var j = random.Next(1, N - 1);
                if (!((i == 1 && j == 1) || (i == N - 2 && j == N - 2)))
                {
                    if (_maze[i, j] == ' ')
                    {
                        _maze[i, j] = '▓';
                        obstaclesCount++;
                    }
                }
            } while (obstaclesCount < Obstacles);
        }

         private void PrintMaze()
        {
            var output = "\n\n";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    output += $"{_maze[i, j]}";
                }
                output += "\n";
            }
            Console.Clear();
            Console.Write(output);
            Thread.Sleep(30);
        }

        private bool NoObstaclesOrBordersToTheRight(int row, int col)
        {
            if (_maze[row, col + 1] == '▓' || _maze[row, col + 1] == '█')
            {
                return false;
            }
            return true;
        }

        private bool NoObstaclesOrBordersAtTheBottom(int row, int col)
        {
            if (_maze[row + 1, col] == '▓' || _maze[row + 1, col] == '▄')
            {
                return false;
            }
            return true;
        }

        private bool NoObstaclesOrBordersToTheLeft(int row, int col)
        {
            if (_maze[row, col - 1] == '▓' || _maze[row, col - 1] == '█')
            {
                return false;
            }
            return true;
        }

         public bool Play()
        {
            int row = 1;
            int col = 0;
            _maze[row, col] = '►';
            PrintMaze();

            while (true)
            {
                if (row == N - 2 && col == N - 1)
                {
                    _maze[row, col] = '☺';
                    PrintMaze();
                    return true;
                }

                if (NoObstaclesOrBordersToTheRight(row, col) && _maze[row, col] != '◄')
                {
                    col++;
                    _maze[row, col] = '►';
                }
                else if (NoObstaclesOrBordersAtTheBottom(row, col))
                {
                    row++;
                    _maze[row, col] = '▼';
                }
                else if (NoObstaclesOrBordersToTheLeft(row, col) && !NoObstaclesOrBordersAtTheBottom(row, col) && _maze[row, col] != '►')
                {
                    col--;
                    _maze[row, col] = '◄';
                }
                else if (NoObstaclesOrBordersToTheLeft(row, col) && NoObstaclesOrBordersAtTheBottom(row, col))
                {
                    row++;
                    _maze[row, col] = '▼';
                }
                else 
                {
                    PrintMaze();
                    return false;
                }
                PrintMaze();
            }
         }

    }
}
