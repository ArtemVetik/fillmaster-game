using AV.FillMaster.FillEngine;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AV.FillMaster.Application
{
    internal class LevelRoot : IUpdate
    {
        private readonly ISaves _saves;
        private readonly IEndOfGameView _endOfGameView;
        private readonly IFillApplication _fillApplication;
        private readonly LevelProvider _levelProvider;

        private Task _updateAsync;
        private bool _restarting;

        public LevelRoot(ISaves saves, IEndOfGameView endOfGameView, IFillApplication fillApplication, LevelProvider levelProvider)
        {
            _saves = saves;
            _endOfGameView = endOfGameView;
            _fillApplication = fillApplication;
            _levelProvider = levelProvider;
        }

        public int CurrentLevel => _levelProvider.LevelIndex;

        public void Update()
        {
            if (_updateAsync?.IsCompleted == false)
                return;

            _updateAsync = UpdateAsync();
        }

        private async Task UpdateAsync()
        {
            if (_fillApplication.Initialized && _fillApplication.Status == FillStatus.InProgress)
                return;

            if (_fillApplication.Initialized == false)
                await InitializeFillApplication(_saves.CurrentLevelIndex());

            if (_fillApplication.Status == FillStatus.Lose)
            {
                await _endOfGameView.RenderLose();
                await InitializeFillApplication(_saves.CurrentLevelIndex());
            }

            if (_fillApplication.Status == FillStatus.Win)
            {
                await _endOfGameView.RenderWin();
                _saves.IncreaseLevelIndex();
                await InitializeFillApplication(_saves.CurrentLevelIndex());
            }
        }

        public async void Restart()
        {
            if (_restarting)
                return;

            _restarting = true;
            _fillApplication.StartNew(null);
            await InitializeFillApplication(_saves.CurrentLevelIndex());
            _restarting = false;
        }

        private async Task InitializeFillApplication(int levelIndex)
        {
            var levelSetup = await _levelProvider.LoadLevel(levelIndex);

            _fillApplication.StartNew(levelSetup);
        }
    }
}