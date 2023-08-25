namespace AV.FillMaster.Application
{
    public interface IInputLibrary
    {
        IHudInput CreateHudInput();
        IBoardInput CreateBoardInput();
    }
}