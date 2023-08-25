using AV.FillMaster.FillEngine;
using System.Collections.Generic;

namespace AV.FillMaster.Application
{
    public readonly struct LevelSolution
    {
        public readonly BoardPosition SetupPosition;
        public readonly IEnumerable<Direction> Directions;

        public LevelSolution(BoardPosition setupPosition, IEnumerable<Direction> directions)
        {
            SetupPosition = setupPosition;
            Directions = directions;
        }
    }
}