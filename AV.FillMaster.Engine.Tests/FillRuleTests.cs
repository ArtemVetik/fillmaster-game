using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Engine.Tests
{
    public class FillRuleTests
    {
        [Test]
        public void Status_InProgressState_ReturnInProgress()
        {
            var cells = new Dictionary<BoardPosition, ICell>()
            {
                { new BoardPosition(0, 0), new TestCell(false) }, { new BoardPosition(0, 1), new TestCell(true) }, { new BoardPosition(0, 2), new TestCell(false) },
                { new BoardPosition(1, 0), new TestCell(false) }, { new BoardPosition(1, 1), new TestCell(true) }, { new BoardPosition(1, 2), new TestCell(true) },
                { new BoardPosition(2, 0), new TestCell(false) }, { new BoardPosition(2, 1), new TestCell(true) }, { new BoardPosition(2, 2), new TestCell(false) },
            };

            var board = new Board(cells, new TestFilledCellFactory());
            var fillRule = new FillRule();

            Assert.That(fillRule.Status(board, new BoardPosition(2, 1)), Is.EqualTo(FillStatus.InProgress));
        }

        [Test]
        public void Status_LoseState_ReturnLose()
        {
            var cells = new Dictionary<BoardPosition, ICell>()
            {
                { new BoardPosition(0, 0), new TestCell(true) }, { new BoardPosition(0, 1), new TestCell(true) }, { new BoardPosition(0, 2), new TestCell(false) },
                { new BoardPosition(1, 0), new TestCell(true) }, { new BoardPosition(1, 1), new TestCell(false) }, { new BoardPosition(1, 2), new TestCell(true) },
                { new BoardPosition(2, 0), new TestCell(true) }, { new BoardPosition(2, 1), new TestCell(true) }, { new BoardPosition(2, 2), new TestCell(false) },
            };

            var board = new Board(cells, new TestFilledCellFactory());
            var fillRule = new FillRule();

            Assert.That(fillRule.Status(board, new BoardPosition(1, 2)), Is.EqualTo(FillStatus.Lose));
        }

        [Test]
        public void Status_WinState_ReturnWin()
        {
            var cells = new Dictionary<BoardPosition, ICell>()
            {
                { new BoardPosition(0, 0), new TestCell(false) }, { new BoardPosition(0, 1), new TestCell(false) }, { new BoardPosition(0, 2), new TestCell(false) },
                { new BoardPosition(1, 0), new TestCell(false) }, { new BoardPosition(1, 1), new TestCell(false) }, { new BoardPosition(1, 2), new TestCell(false) },
                { new BoardPosition(2, 0), new TestCell(false) }, { new BoardPosition(2, 1), new TestCell(false) }, { new BoardPosition(2, 2), new TestCell(false) },
            };

            var board = new Board(cells, new TestFilledCellFactory());
            var fillRule = new FillRule();

            Assert.That(fillRule.Status(board, new BoardPosition(1, 1)), Is.EqualTo(FillStatus.Win));
        }
    }
}