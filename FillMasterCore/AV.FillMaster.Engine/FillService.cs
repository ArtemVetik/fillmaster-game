
namespace AV.FillMaster.FillEngine
{
    public class FillService
    {
        private readonly IEnumerable<KeyValuePair<BoardPosition, CellType>> _cells;
        private readonly ICellViewFactory _viewFactory;

        public FillService(IEnumerable<KeyValuePair<BoardPosition, CellType>> cells, ICellViewFactory viewFactory)
        {
            _cells = cells;
            _viewFactory = viewFactory;
        }

        public IFillEngineSetup Construct()
        {
            var cellRelationsData = new Dictionary<CellType, CellRelation.CellInfo>()
            {
                {CellType.Wall, new CellRelation.CellInfo((view) => new WallCell(view), typeof(WallCell)) },
                {CellType.Empty, new CellRelation.CellInfo((view) => new EmptyCell(view), typeof(EmptyCell)) },
                {CellType.Filled, new CellRelation.CellInfo((view) => new FilledCell(view), typeof(FilledCell)) },
                {CellType.Sticky, new CellRelation.CellInfo((view) => new StickyCell(view), typeof(StickyCell)) },
            };

            var cellRelations = new CellRelation(cellRelationsData);
            var cellFactory = new CellFactory(cellRelations, _viewFactory);

            var convertedCells = _cells.Select(cell => new KeyValuePair<BoardPosition, ICell>(cell.Key, cellFactory.Create(cell.Value, cell.Key)));
            var board = new Board(convertedCells, cellFactory);

            return new FillEngine(board, new FillRule());
        }
    }
}