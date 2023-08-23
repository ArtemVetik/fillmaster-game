using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application
{
    internal class FillApplication
    {
        private readonly IBoardInput _input;
        private readonly IFillEngineSetup _fillSetup;
        
        private IFillEngine _fillEngine;
        private FillStatus _status;

        public FillApplication(IFillEngineSetup fillSetup, IBoardInput input)
        {
            _fillSetup = fillSetup;
            _input = input;
            _status = FillStatus.InProgress;
        }

        public FillStatus Update(IMoveDelay moveDelay)
        {
            if (_status != FillStatus.InProgress)
                return _status;

            if (_fillEngine == null)
                Setup();
            else
                Move(moveDelay);

            return FillStatus.InProgress;
        }

        private void Setup()
        {
            if (_input.Click(out BoardPosition position))
                _fillEngine = _fillSetup.Setup(position);
        }

        private async void Move(IMoveDelay moveDelay)
        {
            if (_input.Move(out Direction direction))
                _status = await _fillEngine.MoveAsync(direction, moveDelay);
        }
    }
}