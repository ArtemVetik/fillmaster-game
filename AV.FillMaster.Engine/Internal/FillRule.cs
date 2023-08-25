namespace AV.FillMaster.FillEngine
{
    internal class FillRule : IFillRule
    {
        public FillStatus Status(IReadOnlyBoard board, BoardPosition header)
        {
            if (CanMove(board, header))
                return FillStatus.InProgress;

            if (HasEmptyCells(board))
                return FillStatus.Lose;

            return FillStatus.Win;
        }

        private bool CanMove(IReadOnlyBoard board, BoardPosition header)
        {
            var direction = Direction.Left;

            do
            {
                if (board.CanFill(direction.Next(header)))
                    return true;

                direction = direction.TurnRight();
            }
            while (direction != Direction.Left);

            return false;
        }

        private bool HasEmptyCells(IReadOnlyBoard board)
        {
            foreach (var position in board.Positions)
                if (board.CanFill(position))
                    return true;

            return false;
        }
    }
}
