using Conway.Dto;
using System.Collections.Generic;

namespace Conway.Interfaces
{
    public interface IMatrix
    {
        void DrawBoardDimension();

        void Start();

        void PopulateBoard(List<Cell>cells);
    }
}
