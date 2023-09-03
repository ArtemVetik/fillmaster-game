namespace AV.FillMaster.FillEngine
{
    internal class EmptyCellViewFactory : ICellViewFactory
    {
        public ICellView Create(BoardPosition position, CellType cell)
        {
            return new EmptyCellView();
        }
    }
}