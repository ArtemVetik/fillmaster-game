namespace AV.FillMaster.FillEngine
{
    public interface ICellViewFactory
    {
        public ICellView Create(BoardPosition position, CellType cell);
    }
}