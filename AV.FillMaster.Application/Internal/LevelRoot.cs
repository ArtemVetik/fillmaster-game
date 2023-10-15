using AV.FillMaster.FillEngine;
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
        private bool _loading;

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
                await InitializeFillApplication(_saves.LastCompletedLevel);

            if (_fillApplication.Status == FillStatus.Lose)
            {
                await _endOfGameView.RenderLose();
                await InitializeFillApplication(_saves.CurrentLevel);
            }

            if (_fillApplication.Status == FillStatus.Win)
            {
                await _endOfGameView.RenderWin();
                _saves.CompleteCurrentLevel();
                await InitializeFillApplication(_saves.CurrentLevel);
            }
        }

        public void Load(int levelIndex)
        {
            LoadLevel(levelIndex);
        }

        public void Restart()
        {
            LoadLevel(_saves.CurrentLevel);
        }

        private async void LoadLevel(int levelIndex)
        {
            if (_loading)
                return;

            _saves.SetCurrentLevel(levelIndex);

            _loading = true;
            await InitializeFillApplication(_saves.CurrentLevel);
            _loading = false;
        }

        private async Task InitializeFillApplication(int levelIndex)
        {
            var levelSetup = await _levelProvider.LoadLevel(levelIndex);

            _fillApplication.StartNew(levelSetup);
        }
    }
}