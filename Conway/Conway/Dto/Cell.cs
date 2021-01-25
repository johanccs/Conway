namespace Conway.Dto
{
    public class Cell
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public string InitialState { get; private set; }

        public Cell(int row, int col, string initialState="X")
        {
            Row = row;
            Col = col;
            InitialState = initialState;
        }
    }
}
