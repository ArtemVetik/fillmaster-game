namespace AV.FillMaster.FillEngine
{
    public interface ICellViewFactory
    {
        ICellView Create(BoardPosition position, CellType cell);
    }
}