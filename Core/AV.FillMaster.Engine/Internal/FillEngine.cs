using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AV.FillMaster.FillEngine
{
    internal class FillEngine : ICellAffect, IFillEngineSetup, IFillEngine
    {
        private readonly Board _board;
        private readonly IFillRule _rule;
        private readonly List<BoardPosition> _fillTrail;

        private BoardPosition? _header;
        private MoveCancellationToken _cancelationToken;

        internal FillEngine(Board board, IFillRule rule)
        {
            _board = board;
            _rule = rule;
            _fillTrail = new List<BoardPosition>();
        }

        IReadOnlyList<BoardPosition> IFillEngine.FillTrail => _fillTrail;

        IFillEngine IFillEngineSetup.Setup(BoardPosition position)
        {
            if (_header != null)
                throw new InvalidOperationException();

            _board.Fill(position);
            _header = position;
            _cancelationToken.Cancel();

            return this;
        }

        async Task<FillStatus> IFillEngine.MoveAsync(Direction direction, IMoveDelay moveDelay)
        {
            EnsureAviableMove();

            _cancelationToken = new MoveCancellationToken();

            try
            {
                while (MoveStep(direction) == true)
                    await moveDelay.Delay();
                
                _cancelationToken.Cancel();
            }
            catch (Exception exception)
            {
                _cancelationToken.Cancel();
                throw exception;
            }

            return _rule.Status(_board, _header.Value);
        }

        FillStatus IFillEngine.Move(Direction direction)
        {
            EnsureAviableMove();

            _cancelationToken = new MoveCancellationToken();

            try
            {
                while (MoveStep(direction) == true) ;
                _cancelationToken.Cancel();
            }
            catch (Exception exception)
            {
                _cancelationToken.Cancel();
                throw exception;
            }

            return _rule.Status(_board, _header.Value);
        }

        private void EnsureAviableMove()
        {
            if (_header == null)
                throw new InvalidOperationException();

            if (_cancelationToken.Cancelled == false)
                throw new InvalidOperationException(nameof(_cancelationToken));
        }

        private bool MoveStep(Direction direction)
        {
            var nextPosition = direction.Next(_header.Value);

            if (_board.CanFill(nextPosition) == false || _cancelationToken.Cancelled)
                return false;

            _header = nextPosition;
            var cell = _board.Cell(_header.Value);

            _board.Fill(_header.Value);
            _fillTrail.Add(_header.Value);
            cell.FillAffect(this);

            return true;
        }

        void ICellAffect.Fill(BoardPosition position)
        {
            _board.Fill(position);
        }

        void ICellAffect.ForceStop()
        {
            _cancelationToken.Cancel();
        }
    }
}
