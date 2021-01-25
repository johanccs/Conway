using Conway.Dto;
using Conway.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Conway.Classes
{
    public class Matrix : IMatrix
    {
        private readonly int rows;
        private readonly int cols;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
        }

        public void DrawBoardDimension()
        {
            int i, j;
            string[,] arr1 = new string[rows, cols];

            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < cols; j++)
                {
                    arr1[i, j] = "  _";
                }
            }

            for (i = 0; i < rows; i++)
            {
                Console.Write("\n");

                for (j = 0; j < cols; j++)
                {
                    Console.Write("{0}\t", arr1[i, j]);
                }

                Console.Write("\n\n");
            }
        }

        public void PopulateBoard(List<Cell> cells)
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            Thread.Sleep(500);
            int i, j;
            string[,] arr1 = new string[rows, cols];

            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < cols; j++)
                {
                    arr1[i, j] = "  o";
                }
            }

            for (i = 0; i < rows; i++)
            {
                Console.Write("\n");

                for (j = 0; j < cols; j++)
                {
                    Thread.Sleep(400);
                    Console.Write("{0}\t", arr1[i, j]);
                }

                Console.Write("\n\n");
            }
        }
    }
}
