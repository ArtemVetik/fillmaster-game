
namespace AV.FillMaster.Application
{
    public class ClientApplication
    {
        private readonly GameLoopApplication _game;

        public ClientApplication(IInfrastructureLibrary infrastructure, IInputLibrary input, IUserInterfaceLibrary userInterface)
        {
            _game = new GameLoopApplication(infrastructure, input, userInterface);
        }

        public void ExecuteFrame(long milliseconds)
        {
            _game.Update();
        }
    }
}