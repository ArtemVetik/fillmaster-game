using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application
{
    internal class GameLoopApplication
    {
        private readonly IInfrastructureLibrary _infrastructure;
        private readonly IInputLibrary _input;
        private readonly IUserInterfaceLibrary _userInterace;

        private ICellViewFactory _cellViewFactory;
        private IHudView _hudView;
        private IEndOfGameView _endOfGameView;
        private FillApplication _loop;
        private bool _executing;

        public GameLoopApplication(IInfrastructureLibrary infrastructure, IInputLibrary input, IUserInterfaceLibrary userInterface)
        {
            _infrastructure = infrastructure;
            _input = input;
            _userInterace = userInterface;
        }

        public async void Update()
        {
            if (_executing)
                return;

            _executing = true;

            if (_loop == null)
                await CreateLevel();

            var status = _loop.Update(_infrastructure.MoveDelay);

            if (_input.HudInput.RestartClicked())
            {
                _loop = null;
                _executing = false;
                return;
            }

            if (status == FillStatus.Lose)
            {
                _endOfGameView ??= _userInterace.CreateEndOfGameView();
                await _endOfGameView.RenderLose();
                _loop = null;
            }
            if (status == FillStatus.Win)
            {
                _endOfGameView ??= _userInterace.CreateEndOfGameView();
                _infrastructure.Saves.IncreaseLevelIndex();
                await _endOfGameView.RenderWin();
                _loop = null;
            }

            _executing = false;
        }

        private async Task CreateLevel()
        {
            _cellViewFactory ??= _userInterace.CreateCellViewFactory();
            _hudView ??= _userInterace.CreateHudView();
            
            var currentLevel = _infrastructure.Saves.CurrentLevelIndex();
            var levelInfo = await _infrastructure.Levels.LoadLevel(currentLevel);
            var fillEngineSetup = new FillService(levelInfo.Cells, _cellViewFactory).Construct();
            
            _loop = new FillApplication(fillEngineSetup, _input.BoardInput);
            _hudView.RenderLevelNumber(currentLevel + 1);
        }
    }
}