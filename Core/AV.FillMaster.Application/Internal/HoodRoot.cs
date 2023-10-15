namespace AV.FillMaster.Application
{
    internal class HoodRoot : IUpdate
    {
        private readonly IHudInput _hudInput;
        private readonly IHudView _hudView;
        private readonly LevelRoot _levelRoot;
        private readonly SolutionRoot _solutionRoot;
        private readonly LevelListRoot _levelList;

        public HoodRoot(IHudInput hudInput, IHudView hudView, LevelRoot levelRoot, SolutionRoot solutionRoot, LevelListRoot levelList)
        {
            _hudInput = hudInput;
            _hudView = hudView;
            _levelRoot = levelRoot;
            _solutionRoot = solutionRoot;
            _levelList = levelList;
        }

        public void Update()
        {
            if (_hudInput.RestartClicked())
                _levelRoot.Restart();

            if (_hudInput.HintClicked())
                _solutionRoot.ShowSolution();

            if (_hudInput.LevelsButtonClicked())
                _levelList.Open();

            _hudView.RenderLevelNumber(_levelRoot.CurrentLevel);
        }
    }
}