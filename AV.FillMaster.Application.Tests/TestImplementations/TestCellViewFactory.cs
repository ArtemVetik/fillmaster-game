using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application.Tests
{
    internal class TestCellViewFactory : ICellViewFactory
    {
        public ICellView Create(BoardPosition position, CellType cell)
        {
            return new TestCellView();
        }
    }
}