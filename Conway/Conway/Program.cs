using Conway.Classes;
using Conway.Enums;
using System;
using System.Threading;

namespace Conway
{
    class Program
    {
        #region Fields

        static int rows = 0;
        static int cols = 0;

        #endregion

        static void Main(string[] args)
        {
            StartGame();

            var restartAnswer = GetStartResponse();
            if (restartAnswer == "Y" || restartAnswer == "y")
            {
                //todo: #JP #25-01-2021
                //Console.Clear();
                StartGame();
            }
        }

        private static void StartGame()
        {
            PrintHeader();

            GetMatrixDimension();

            var iterations = GetIterationNumber();

            Console.WriteLine("Setting up matrix board preview. Please wait");

            var matrix = new Matrix(rows, cols);

            Console.WriteLine("\n");

            matrix.DrawBoardDimension();

            Console.Write("\nPress Y to start the game: ");

            var answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                for (int x = 1; x <= iterations; x++)
                {
                    Thread.Sleep(1000);
                    //todo: #JP #25-01-2021
                    //Console.Clear();                  
                    PrintHeader();
                    Console.WriteLine("Matrix board preview");

                    PrintIterationMessage(x, iterations);

                    matrix.Start();
                }
            }
        }

        private static void PrintIterationMessage(int iteration, int totalIterations)
        {
            Console.Write("\n");
            Console.Write($"Iteration: {iteration} from {totalIterations}");
            Console.Write("\n");
        }

        private static int GetIterationNumber()
        {
            Console.WriteLine("\n");
            Console.Write("Iterations: ");

            int answer = Convert.ToInt32(Console.ReadLine());

            return answer;
        }

        private static void PrintHeader()
        {
            Console.WriteLine("\n\nRead a 2D array of size (rows x cols) and print the matrix :\n");
            Console.WriteLine($"Cell States: ALIVE - {CellStateEnums.ALIVE.Trim()} DEAD - {CellStateEnums.DEAD.Trim()}");
            Console.WriteLine("----------------------------------------------------------------\n");
        }

        private static void GetMatrixDimension()
        {
            Console.Write("Enter number of rows: ");
            rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of columns: ");
            cols = Convert.ToInt32(Console.ReadLine());
        }

        private static string GetStartResponse()
        {
            Console.WriteLine("\n\n");
            Console.Write("Do you want restart the game [Y/N] ?: ");

            string answer = Console.ReadLine();

            return answer;
        }
    }
}
