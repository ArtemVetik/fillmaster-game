
using System;
using System.Diagnostics;

namespace AV.FillMaster.Application
{
    public class ClientApplication
    {
        private readonly IUpdate[] _updatables;

        public ClientApplication(IInfrastructureLibrary infrastructure, IInputLibrary input, IUserInterfaceLibrary userInterface)
        {
            var levelProvider = new LevelProvider(infrastructure.Levels, userInterface.CreateCellViewFactory());

            var fillApplication = new FillApplication(input.CreateBoardInput(), infrastructure.MoveDelay);
            var levelRoot = new LevelRoot(infrastructure.Saves, userInterface.CreateEndOfGameView(), fillApplication, levelProvider);
            var solutionRoot = new SolutionRoot(infrastructure.Saves, userInterface.CreateSolutionView(), levelProvider);
            var levelListRoot = new LevelListRoot(infrastructure.Levels.Count, infrastructure.Saves, userInterface.CreateLevelListView(), levelRoot);
            var hoodRoot = new HoodRoot(input.CreateHudInput(), userInterface.CreateHudView(), levelRoot, solutionRoot, levelListRoot);

            _updatables = new IUpdate[] { fillApplication, levelRoot, hoodRoot };
        }

        public void ExecuteFrame(long milliseconds)
        {
            try
            {
                foreach (var updatable in _updatables)
                    updatable.Update();
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }
        }
    }
}