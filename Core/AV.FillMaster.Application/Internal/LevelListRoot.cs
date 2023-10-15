using System;

namespace AV.FillMaster.Application
{
    internal class LevelListRoot
    {
        private readonly int _levelCount;
        private readonly ISaves _saves;
        private readonly ILevelListView _view;
        private readonly LevelRoot _levelRoot;

        public LevelListRoot(int levelCount, ISaves saves, ILevelListView view, LevelRoot levelRoot)
        {
            _levelCount = levelCount;
            _saves = saves;
            _view = view;
            _levelRoot = levelRoot;
        }

        public void Open()
        {
            _view.Render(_levelCount, _saves.LastCompletedLevel, _saves.CurrentLevel, SelectLevel);
        }

        private void SelectLevel(int levelIndex)
        {
            if (levelIndex > _saves.LastCompletedLevel)
                throw new InvalidOperationException();

            _levelRoot.Load(levelIndex);
            _view.Close();
        }
    }
}