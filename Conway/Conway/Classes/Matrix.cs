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
        #region Readonly Fields

        private readonly int rows;
        private readonly int cols;
        private readonly ArrayWrapper _aw;

        #endregion

        #region Fields

        private CellStateEnums cellEnums;

        #endregion

        #region Constructor
        public Matrix(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
                throw new ArgumentException("Matrix dimensions cannot be smaller than 0");

            this.rows = rows;
            this.cols = cols;

            cellEnums = new CellStateEnums();
        
            _aw = new ArrayWrapper(rows, cols);
        }

        #endregion

        #region Methods

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

        #endregion

        #region Private Methods

        private string GetNeighbours(Point p, string[,] arr)       
        {
            List<Point> points = GetSurroundingNeightbours(p);
            List<string> values = GetSurroundingNeightbourValues(points);

            string currCellValue = _aw.GetValueByPoint(p);         
            //If cell is dead
            if(currCellValue == CellStateEnums.DEAD && 
                GetNrOfLiveNeighbors(CellStateEnums.ALIVE, values.ToArray()) == 3)
            {
                currCellValue = CellStateEnums.ALIVE;
            }
            else if(currCellValue == CellStateEnums.ALIVE && 
                    GetNrOfLiveNeighbors(CellStateEnums.ALIVE,values.ToArray()) < 2)
            {
                currCellValue = CellStateEnums.DEAD;
            }
            else if(currCellValue == CellStateEnums.ALIVE && 
                    GetNrOfLiveNeighbors(CellStateEnums.ALIVE, values.ToArray()) >= 2 && 
                    GetNrOfLiveNeighbors(CellStateEnums.ALIVE, values.ToArray()) < 3)
            {
                currCellValue = CellStateEnums.ALIVE;
            }
            else if(currCellValue == CellStateEnums.ALIVE && 
                    GetNrOfLiveNeighbors(CellStateEnums.ALIVE, values.ToArray()) > 3)
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

        private List<Point> GetSurroundingNeightbours(Point p)
        {
            List<Point> points = new List<Point>();

            if (p.Row - 1 >= 0 && p.Col - 1 >= 0)
            {
                //Valid point on the matrix
                Point p1 = new Point(p.Row - 1, p.Col - 1);

                points.Add(p1);
            }

            if (p.Row - 1 >= 0)
            {
                //Valid point on the matrix
                Point p1 = new Point(p.Row - 1, p.Col);

                points.Add(p1);
            }

            if (p.Row - 1 >= 0 && p.Col + 1 <= cols)
            {
                //Valid point on the matrix
                Point p1 = new Point(p.Row - 1, p.Col + 1);

                points.Add(p1);
            }

            if (p.Col + 1 <= cols)
            {
                //Valid point on the matrix
                Point p1 = new Point(p.Row, p.Col + 1);

                points.Add(p1);
            }

            if (p.Row + 1 <= rows && p.Col + 1 <= cols)
            {
                //Valid point on the matrix
                Point p1 = new Point(p.Row + 1, p.Col + 1);

                points.Add(p1);
            }

            if (p.Row + 1 <= rows)
            {
                //Valid point on the matrix
                Point p1 = new Point(p.Row + 1, p.Col + 1);

                points.Add(p1);
            }

            if (p.Row + 1 <= rows && p.Col - 1 >= 0)
            {
                //Valid point on the matrix
                Point p1 = new Point(p.Row + 1, p.Col + 1);

                points.Add(p1);
            }

            if (p.Col - 1 >= 0)
            {
                //Valid point on the matrix
                Point p1 = new Point( p.Row, p.Col - 1);

                points.Add(p1);
            }

            return points;
        }

        private List<string> GetSurroundingNeightbourValues(List<Point>points)
        {
            var resultList = new List<string>();

            foreach(Point point in points)
            {
                var val = _aw.GetValueByPoint(point);
                resultList.Add(val);
            }

            return resultList;
        }

        #endregion
    }
}
