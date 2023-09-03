using AV.FillMaster.FillEngine;
using System.Collections.Generic;
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
            
            _solutionView.Render(modifiedSolution.SetupPosition, FillTrail(modifiedSolution));
            _saves.IncreaseSolutionStep(_levelProvider.LevelIndex);
        }

        private IReadOnlyList<BoardPosition> FillTrail(LevelSolution solution)
        {
            var fillEngineSetup = new FillService(_levelProvider.LevelInfo.Cells).Construct();
            var fillEngine = fillEngineSetup.Setup(solution.SetupPosition);

            foreach (var direction in solution.Directions)
                fillEngine.Move(direction);

            return fillEngine.FillTrail;
        }
    }
}