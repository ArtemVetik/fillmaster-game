namespace AV.FillMaster.Application
{
    public interface IInputLibrary
    {
        IHudInput HudInput { get; }
        IBoardInput BoardInput { get; }
    }
}