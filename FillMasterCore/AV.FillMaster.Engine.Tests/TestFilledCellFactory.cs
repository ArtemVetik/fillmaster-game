using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Engine.Tests
{
    public class TestFilledCellFactory : IFilledCellFactory
    {
        ICell IFilledCellFactory.Create(BoardPosition position)
        {
            return new TestCell(false);
        }
    }
}