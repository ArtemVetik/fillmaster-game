namespace AV.FillMaster.FillEngine
{
    internal class CellFactory : IFilledCellFactory
    {
        private readonly CellRelation _cellRelation;
        private readonly ICellViewFactory _viewFactory;

        internal CellFactory(CellRelation cellRelation, ICellViewFactory viewFactory)
        {
            _cellRelation = cellRelation;
            _viewFactory = viewFactory;
        }

        internal void Clear()
        {
            _viewFactory.Clear();
        }

        internal ICell Create(CellType cell, BoardPosition position)
        {
            var cellInstance = _cellRelation.CreateCell(cell, _viewFactory.Create(position, cell));
            cellInstance.Visualize();

            return cellInstance;
        }

        ICell IFilledCellFactory.Create(BoardPosition position)
        {
            return Create(CellType.Filled, position);
        }
    }
}
