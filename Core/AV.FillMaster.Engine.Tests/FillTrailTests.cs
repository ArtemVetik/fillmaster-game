using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Engine.Tests
{
    public class FillTrailTests
    {
        private IFillEngineSetup _setup;

        [SetUp]
        public void Setup()
        {
            var cells = new Dictionary<BoardPosition, CellType>()
            {
                { new (0, 0), CellType.Empty }, { new (1, 0), CellType.Empty }, { new (2, 0), CellType.Wall },  { new (3, 0), CellType.Empty },
                { new (0, 1), CellType.Empty }, { new (1, 1), CellType.Empty }, { new (2, 1), CellType.Wall },  { new (3, 1), CellType.Empty },
                { new (0, 2), CellType.Empty }, { new (1, 2), CellType.Empty }, { new (2, 2), CellType.Sticky },{ new (3, 2), CellType.Empty },
                { new (0, 3), CellType.Empty }, { new (1, 3), CellType.Empty }, { new (2, 3), CellType.Empty }, { new (3, 3), CellType.Wall },
            };

            _setup = new FillService(cells).Construct();
        }

        [Test]
        public void FillTrail_AfterMove_ReturnNotEmptyList()
        {
            var fillEngine = _setup.Setup(new BoardPosition(0, 0));
            fillEngine.Move(Direction.Right);

            Assert.That(fillEngine.FillTrail.Count, Is.EqualTo(1));
            
            fillEngine.Move(Direction.Up);
            
            Assert.That(fillEngine.FillTrail.Count, Is.EqualTo(4));
        }
    }
}