using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application
{
    internal class FillApplication : IFillApplication, IUpdate
    {
        private readonly IBoardInput _input;
        private readonly IMoveDelay _moveDelay;

        private IFillEngineSetup _fillSetup;
        private IFillEngine _fillEngine;
        private FillStatus _status;

        public FillApplication(IBoardInput input, IMoveDelay moveDelay)
        {
            _input = input;
            _moveDelay = moveDelay;
            _status = FillStatus.InProgress;
        }

        public bool Initialized => _fillSetup != null;
        public FillStatus Status => _status;

        public void StartNew(IFillEngineSetup fillEngineSetup)
        {
            _fillSetup = fillEngineSetup;
            _fillEngine = null;
            _status = FillStatus.InProgress;
        }

        public void Update()
        {
            if (_status != FillStatus.InProgress)
                return;

            if (_fillEngine == null)
                Setup();
            else
                Move(_moveDelay);
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