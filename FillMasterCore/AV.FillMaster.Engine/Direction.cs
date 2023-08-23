
namespace AV.FillMaster.FillEngine
{
    public class Direction
    {
        private enum Type
        {
            Left = 0,
            Up = 1,
            Right = 2,
            Down = 3,
        }

        public static Direction Left => new(Type.Left);
        public static Direction Up => new(Type.Up);
        public static Direction Right => new(Type.Right);
        public static Direction Down => new(Type.Down);

        private readonly Type _type;

        private Direction(Type type)
        {
            _type = type;
        }

        public static bool operator ==(Direction first, Direction second) => first._type == second._type;
        public static bool operator !=(Direction first, Direction second) => first._type != second._type;

        public BoardPosition Next(BoardPosition position)
        {
            return _type switch
            {
                Type.Left => position - new BoardPosition(1, 0),
                Type.Up => position + new BoardPosition(0, 1),
                Type.Right => position + new BoardPosition(1, 0),
                Type.Down => position - new BoardPosition(0, 1),
                _ => throw new InvalidOperationException(),
            };
        }

        public Direction TurnRight()
        {
            var nextSide = ((int)_type + 1) % Enum.GetNames(typeof(Type)).Length;

            return new Direction((Type)nextSide);
        }

        public Direction TurnLeft()
        {
            if (_type == 0)
                return new Direction((Type)(Enum.GetNames(typeof(Type)).Length - 1));

            return new Direction(_type - 1);
        }

        public override bool Equals(object obj)
        {
            return obj is Direction direction && _type == direction._type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_type);
        }
    }
}
