using AV.FillMaster.FillEngine;
using System.Collections.Generic;

namespace AV.FillMaster.Application
{
    public interface ISolutionView
    {
        void Render(BoardPosition setupPosition, IReadOnlyList<BoardPosition> fillTrail);
    }
}