using System;
using System.Collections.Generic;

namespace AV.FillMaster.FillEngine
{
    internal class Board : IReadOnlyBoard
    {
        private readonly IDictionary<BoardPosition, ICell> _cells;
        private readonly IFilledCellFactory _filledFactory;

        internal Board(IEnumerable<KeyValuePair<BoardPosition, ICell>> cells, IFilledCellFactory filledFactory)
        {
            _cells = new Dictionary<BoardPosition, ICell>(cells);
            _filledFactory = filledFactory;
        }

        public IEnumerable<BoardPosition> Positions => _cells.Keys;

        public bool CanFill(BoardPosition position)
        {
            return _cells.ContainsKey(position) && _cells[position].CanFill;
        }

        internal ICell Cell(BoardPosition position)
        {
            return _cells[position];
        }

        internal void Fill(BoardPosition position)
        {
            if (CanFill(position) == false)
                throw new InvalidOperationException();

            _cells[position] = _filledFactory.Create(position);
        }
    }
}
