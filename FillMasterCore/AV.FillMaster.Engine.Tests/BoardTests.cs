using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Engine.Tests
{
    public class BoardTests
    {
        private Board _board;

        [SetUp]
        public void Setup()
        {
            var cells = new Dictionary<BoardPosition, ICell>()
            {
                { new BoardPosition(0, 0), new TestCell(true) },
                { new BoardPosition(0, 1), new TestCell(true) },
                { new BoardPosition(0, 2), new TestCell(true) },
                { new BoardPosition(1, 0), new TestCell(true) },
                { new BoardPosition(1, 1), new TestCell(true) },
                { new BoardPosition(1, 2), new TestCell(true) },
                { new BoardPosition(2, 0), new TestCell(true) },
                { new BoardPosition(2, 1), new TestCell(true) },
                { new BoardPosition(2, 2), new TestCell(true) },
            };

            _board = new Board(cells, new TestFilledCellFactory());
        }

        [Test]
        public void CanFill_EmptyBoard_MustReturnTrueForEveryone()
        {
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                    Assert.That(_board.CanFill(new BoardPosition(x, y)), Is.True);
        }

        [Test]
        public void Fill_DoubleFill_ThrowException()
        {
            var position = new BoardPosition(0, 0);

            Assert.DoesNotThrow(() => _board.Fill(position));
            Assert.Throws<InvalidOperationException>(() => _board.Fill(position));
        }

        [Test]
        public void CanFill_SingleFill_MustReturnFalse()
        {
            var position = new BoardPosition(0, 0);

            _board.Fill(position);
            Assert.That(_board.CanFill(position), Is.False);
        }
    }
}