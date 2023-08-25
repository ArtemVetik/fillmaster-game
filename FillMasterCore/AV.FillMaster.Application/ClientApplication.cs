
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
            var hoodRoot = new HoodRoot(input.CreateHudInput(), userInterface.CreateHudView(), levelRoot);

            _updatables = new IUpdate[] { fillApplication, levelRoot, hoodRoot };
        }

        public void ExecuteFrame(long milliseconds)
        {
            foreach (var updatable in _updatables)
                updatable.Update();
        }
    }
}