namespace AV.FillMaster.FillEngine
{
    internal interface IFilledCellFactory
    {
        ICell Create(BoardPosition position);
    }
}