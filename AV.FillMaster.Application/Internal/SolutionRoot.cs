using System.Linq;

namespace AV.FillMaster.Application
{
    internal class SolutionRoot
    {
        private readonly ISaves _saves;
        private readonly ISolutionView _solutionView;
        private readonly LevelProvider _levelProvider;

        public SolutionRoot(ISaves saves, ISolutionView solutionView, LevelProvider levelProvider)
        {
            _saves = saves;
            _solutionView = solutionView;
            _levelProvider = levelProvider;
        }

        public void ShowSolution()
        {
            var solutionIndex = _saves.SolutionStep(_levelProvider.LevelIndex);
            var solution = _levelProvider.LevelInfo.Solution;
            var modifiedSolution = new LevelSolution(solution.SetupPosition, solution.Directions.Take(solutionIndex));
            
            _solutionView.Render(modifiedSolution);
            _saves.IncreaseSolutionStep(_levelProvider.LevelIndex);
        }
    }
}