using Conway.Dto;
using Conway.Enums;
using Conway.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Conway.Classes
{
    public class Matrix : IMatrix
    {
        private readonly int rows;
        private readonly int cols;

        private readonly CellStateEnums cellEnums;

        //private readonly string[,] arr1;

        private readonly ArrayWrapper _aw;
        
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            cellEnums = new CellStateEnums();

            //arr1 = new string[rows, cols];

            _aw = new ArrayWrapper(rows, cols);
        }

        public void DrawBoardDimension()
        {
            int i, j;                     

            for (i = 0; i < rows; i++)
            {
                Random rand = new Random();

                for (j = 0; j < cols; j++)
                {
                    var randInt = rand.Next(1,3);
                    Trace.WriteLine(randInt);                    
                    _aw.InternalArray[i, j] = cellEnums.GetCellStatusById(randInt);                    
                }
            }

            for (i = 0; i < rows; i++)
            {
                Thread.Sleep(100);
                Console.Write("\n");

                for (j = 0; j < cols; j++)
                {
                    Console.Write("{0}\t", _aw.InternalArray[i, j]);
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

            for (i = 0; i < rows; i++)
            {
                Console.Write("\n");

                for (j = 0; j < cols; j++)
                {
                    Thread.Sleep(400);
                    //Console.Write("{0}\t", arr1[i, j]);
                    Point p = new Point(i, j);
                    Console.Write("{0}\t", GetNeighbours(p, _aw.InternalArray));
                }

                Console.Write("\n\n");
            }
        }

        public void Start(bool @overwrite)
        {
            int i, j;
            string[,] arr1 = new string[rows, cols];

            for (i = 0; i < rows; i++)
            {
                Console.Write("\n");

                for (j = 0; j < cols; j++)
                {
                    Thread.Sleep(400);
                    Console.Write("{0}x\t", arr1[i, j]);
                }

                Console.Write("\n\n");
            }
        }

        #region Private Methods

        private string GetNeighbours(Point p, string[,] arr)       
        {
            Point newPointX = new Point(p.Row, p.Col + 1);
            Point newPointXX = new Point(p.Row, p.Col + 2);
            Point newPointXXX = new Point(p.Row, p.Col + 3);

            string currCellValue = _aw.GetValueByPoint(p);
            string cellValueX = _aw.GetValueByPoint(newPointX);
            string cellValueXX = _aw.GetValueByPoint(newPointXX);
            string cellValueXXX = _aw.GetValueByPoint(newPointXXX);

            //If cell is dead
            if(currCellValue == CellStateEnums.DEAD && 
                cellValueX == CellStateEnums.ALIVE && 
                cellValueXX == CellStateEnums.ALIVE && 
                cellValueXXX == CellStateEnums.ALIVE)
            {
                currCellValue = CellStateEnums.ALIVE;
            }
            else if(currCellValue == CellStateEnums.ALIVE && 
                    GetNrOfLiveNeighbors(CellStateEnums.ALIVE, cellValueX, cellValueXX, cellValueXXX) < 2)
            {
                currCellValue = CellStateEnums.DEAD;
            }
            else if(currCellValue == CellStateEnums.ALIVE && 
                    GetNrOfLiveNeighbors(CellStateEnums.ALIVE, cellValueX, cellValueXX, cellValueXXX) >= 2 && 
                    GetNrOfLiveNeighbors(CellStateEnums.ALIVE, cellValueX, cellValueXX, cellValueXXX) < 3)
            {
                currCellValue = CellStateEnums.ALIVE;
            }
            else if(currCellValue == CellStateEnums.ALIVE && 
                    GetNrOfLiveNeighbors(CellStateEnums.ALIVE, cellValueX, cellValueXX, cellValueXXX) > 3)
            {
                currCellValue = CellStateEnums.DEAD;
            }

            return currCellValue;
        }

        private int GetNrOfLiveNeighbors(string cellState, params string[] values)
        {
            var counter = 0;
            for(int x = 0; x <= values.Length -1; x++)
            {
                if (values[x] == cellState)
                    counter++;
            }

            return counter;
        }

        private Point 

        #endregion
    }
}
