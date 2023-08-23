using System.Collections.Generic;

namespace AV.FillMaster.FillEngine
{
    internal interface IReadOnlyBoard
    {
        IEnumerable<BoardPosition> Positions { get; }
        bool CanFill(BoardPosition position);
    }
}
