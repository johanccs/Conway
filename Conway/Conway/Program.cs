using Conway.Classes;
using System;

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
            PrintHeader();

            GetMatrixDimension();

            Console.WriteLine("Matrix board preview");

            var matrix = new Matrix(rows, cols);

            Console.WriteLine("\n");

            matrix.DrawBoardDimension();

            Console.Write("Press Y to start the game: ");

            var answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                Console.Clear();
                PrintHeader();
                Console.WriteLine("Matrix board preview");

                matrix.Start();

                var restartAnswer = GetStartResponse();

                if(restartAnswer == "Y" || restartAnswer == "y")
                {
                    Console.Clear();
                    PrintHeader();
                    matrix.Start();
                }
            }
        }

        private static void PrintHeader()
        {
            Console.Write("\n\nRead a 2D array of size (rows x cols) and print the matrix :\n");
            Console.Write("----------------------------------------------------------------\n");
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
