using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application
{
    public readonly struct LevelInfo
    {
        public readonly IEnumerable<KeyValuePair<BoardPosition, CellType>> Cells;
        public readonly LevelSolution Solution;

        public LevelInfo(IEnumerable<KeyValuePair<BoardPosition, CellType>> cells, LevelSolution solution)
        {
            Cells = cells;
            Solution = solution;
        }
    }
}