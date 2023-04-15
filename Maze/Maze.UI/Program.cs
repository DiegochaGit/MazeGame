using Maze.Logic;

Console.WriteLine("-------------------------------");
Console.WriteLine("Welcome to the maze!\n");

Console.Write("Enter the size of the maze: ");
int n = int.Parse(Console.ReadLine());

Console.Write("Enter the number of obstacles: ");
int obstacles = int.Parse(Console.ReadLine());

Console.BackgroundColor = ConsoleColor.Cyan;
Console.ForegroundColor = ConsoleColor.Red;
Console.Clear();

var myMaze = new MyMaze(n, obstacles);

Console.WriteLine($"This is the Maze: \n\n{myMaze}\n");
Console.WriteLine("Press any key to start the game...");
Console.ReadKey();

bool finish = myMaze.Play();
if (finish)
{
    Console.WriteLine($"\nCongratulations! You exited the maze!  \\(^v^)/ \n");
}
else
{
    Console.WriteLine("\nYou cannot exit the maze!  ¯\\_(o_o)_/¯ \n");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();