using System.Diagnostics;

namespace AV.FillMaster.Application
{
    internal class HoodRoot : IUpdate
    {
        private readonly IHudInput _hudInput;
        private readonly IHudView _hudView;
        private readonly LevelRoot _levelRoot;

        public HoodRoot(IHudInput hudInput, IHudView hudView, LevelRoot levelRoot)
        {
            _hudInput = hudInput;
            _hudView = hudView;
            _levelRoot = levelRoot;
        }

        public void Update()
        {
            if (_hudInput.RestartClicked())
                _levelRoot.Restart();

            _hudView.RenderLevelNumber(_levelRoot.CurrentLevel);
        }
    }
}