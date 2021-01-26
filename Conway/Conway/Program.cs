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

        private static Matrix matrix; 

        #endregion

        static void Main(string[] args)
        {
            StartGame();

            var restartAnswer = GetStartResponse();
            if (restartAnswer == "Y" || restartAnswer == "y")
            {
                Console.Clear();
                StartGame();
            }
            else
            {
                Console.Write("Thanks for playing Conways game. Press [e]xit to stop: ");
                var exitCode = Console.ReadLine();
                if (exitCode.ToString().ToLower().Equals("e"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    StartGame();
                }
            }
        }

        #region Private Methods

        private static void StartGame()
        {
            PrintHeader();

            GetMatrixDimension();

            var iterations = GetIterationNumber();

            Console.WriteLine("Setting up matrix board preview. Please wait");

            try
            {
                matrix = new Matrix(rows, cols);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ExitGraceFullyOnException();
            }

            Console.WriteLine("\n");

            matrix.DrawBoardDimension();

            Console.Write("\nPress Y to start the game: ");

            var answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                for (int x = 1; x <= iterations; x++)
                {
                    Thread.Sleep(1000);

                    Console.Clear();
                    
                    PrintHeader();
                    Console.WriteLine("Matrix board preview");

                    PrintIterationMessage(x, iterations);

                    matrix.Start();
                }
            }
        }

        private static void ExitGraceFullyOnException()
        {
            Console.Write("Thanks for playing Conways game. Press any key to exit: ");
            var exitCode = Console.ReadLine();

            Environment.Exit(0);
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

        #endregion
    }
}
