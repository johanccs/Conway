using System.Collections.Generic;

namespace Conway.Enums
{
    public class CellStateEnums
    {
        private static Dictionary<int, string> _cellStatus = new Dictionary<int, string>();

        public const string ALIVE = "   o";
        public const string DEAD = "   x";

        public CellStateEnums()
        {
            _cellStatus.Add(1, ALIVE);
            _cellStatus.Add(2, DEAD);
        }

        public string GetCellStatusById(int id)
        {
            if (_cellStatus.ContainsKey(id))
                return _cellStatus[id];

            return "   o";
        }
    }
}
