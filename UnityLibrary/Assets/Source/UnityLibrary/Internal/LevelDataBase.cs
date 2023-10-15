using AV.FillMaster.Application;
using AV.FillMaster.FillEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    [CreateAssetMenu(fileName = nameof(LevelDataBase), menuName = "FillMaster/Infrastructure/" + nameof(LevelDataBase), order = 51)]
    internal class LevelDataBase : ScriptableObject, ILevelsDataBase
    {
        [SerializeField] private Level[] _levels;

        public int Count => _levels.Length;

        public async Task<LevelInfo> LoadLevel(int index)
        {
            if (index >= Count)
                index = Count - 1;

            var level = _levels[index];

            await Task.Yield();

            var cells = level.Cells.Select(cell => new KeyValuePair<BoardPosition, CellType>(cell.Position.ToBoardPosition(), cell.CellType));

            var directions = level.Directions.Select(direction =>
            {
                return direction switch
                {
                    Direction.Left => FillEngine.Direction.Left,
                    Direction.Right => FillEngine.Direction.Right,
                    Direction.Up => FillEngine.Direction.Up,
                    Direction.Down => FillEngine.Direction.Down,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            });

            var solution = new LevelSolution(level.SetupPosition.ToBoardPosition(), directions);

            return new LevelInfo(cells, solution);
        }

        [Serializable]
        private struct Level
        {
            [field: SerializeField] public BoardCell[] Cells { get; private set; }
            [field: SerializeField] public Vector2Int SetupPosition { get; private set; }
            [field: SerializeField] public Direction[] Directions { get; private set; }
        }

        [Serializable]
        private struct BoardCell
        {
            [field: SerializeField] public Vector2Int Position { get; private set; }
            [field: SerializeField] public CellType CellType { get; private set; }
        }

        private enum Direction
        {
            Left,
            Right,
            Up,
            Down,
        }
    }
}
