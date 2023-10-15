using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application.Tests
{
    internal class TestBoardInput : IBoardInput
    {
        private BoardPosition? _click;
        private Direction _direction;

        public bool HasClick => _click != null;
        public bool HasDirection => _direction != null;

        public void SetupClick(BoardPosition position) => _click = position;
        
        public void SetupDirection(Direction direction) => _direction = direction;

        public bool Click(out BoardPosition position)
        {
            position = default;

            if (_click == null)
                return false;

            position = _click.Value;
            _click = null;

            return true;
        }

        public bool Move(out Direction direction)
        {
            direction = default;

            if (_direction == null)
                return false;

            direction = _direction;
            _direction = null;

            return true;
        }
    }
}