using Conway.Classes;
using Conway.Enums;
using Conway.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Conway
{
    class Program
    {
        #region Fields

        static int rows = 0;
        static int cols = 0;

        private static IMatrix matrix;
        private static IServiceProvider _serviceProvider;

        #endregion

        #region Constants

        private const string CONFIRM = "Y";

        #endregion

        #region Public Methods
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

            DisposeServices();
        }

        #endregion

        #region Private Methods
        private static void StartGame()
        {
            int iterations = SetupGame();

            Console.WriteLine("Setting up matrix board preview. Please wait");

            matrix = _serviceProvider.GetService<IMatrix>();

            Console.WriteLine("\n");

            try
            {
                matrix.DrawBoardDimension();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ExitGraceFullyOnException();
            }

            StartGameAfterConfirmation(iterations);
        }

        private static int SetupGame()
        {
            PrintHeader();

            GetMatrixDimension();

            _serviceProvider = RegisterServices();

            var iterations = GetIterationNumber();
            return iterations;
        }

        private static void StartGameAfterConfirmation(int iterations)
        {
            Console.Write("\nPress Y to start the game: ");
            var answer = Console.ReadLine();

            if (answer.ToLower() == CONFIRM.ToLower())
            {
                for (int x = 1; x <= iterations; x++)
                {
                    Thread.Sleep(1000);

                    Console.Clear();

                    PrintHeader();
                    Console.WriteLine("Matrix board preview");

                    PrintIterationMessage(x, iterations);

                    try
                    {
                        matrix.Start();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        ExitGraceFullyOnException();
                    }
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

        #region Helper Methods

        private static ServiceProvider RegisterServices()
        {
            ServiceCollection _serviceCollection = new ServiceCollection();

            _serviceCollection.AddSingleton<IMatrix>(new Matrix(rows,cols));

            return _serviceCollection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
                return;

            if (_serviceProvider is IDisposable)
                ((IDisposable)_serviceProvider).Dispose();
        }

        #endregion
    }
}
