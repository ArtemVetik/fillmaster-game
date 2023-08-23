using System;

namespace AV.FillMaster.FillEngine
{
    public readonly struct BoardPosition : IEquatable<BoardPosition>
    {
        public readonly int X;
        public readonly int Y;

        public BoardPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static BoardPosition operator +(BoardPosition a, BoardPosition b) => new(a.X + b.X, a.Y + b.Y);
        public static BoardPosition operator -(BoardPosition a, BoardPosition b) => new(a.X - b.X, a.Y - b.Y);
        public static bool operator ==(BoardPosition a, BoardPosition b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(BoardPosition a, BoardPosition b) => !(a == b);

        public override bool Equals(object obj)
        {
            return obj is BoardPosition position && Equals(position);
        }

        public bool Equals(BoardPosition other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }
}
