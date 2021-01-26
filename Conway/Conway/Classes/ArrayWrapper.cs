using Conway.Dto;
using System;

namespace Conway.Classes
{
    public class ArrayWrapper
    {
        #region Readonly Fields

        private readonly int _cols;
        private readonly int _rows;

        #endregion

        #region Properties

        public string[,] InternalArray { set; get; }

        #endregion

        public ArrayWrapper(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Invalid number of rows and columns");

            _rows = rows;
            _cols = cols;

            InternalArray = new string[rows, cols];
        }

        public string GetValueByPoint(Point p)
        {
            if (p.Col == _cols)
                p.SetColSize(_cols-1);

            if (p.Row == _rows)
                p.SetRowSize(_rows - 1);

            var val = InternalArray[p.Row, p.Col];

            return val;
        }
    }
}
