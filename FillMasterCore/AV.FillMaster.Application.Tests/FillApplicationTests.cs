using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application.Tests
{
    public class FillApplicationTests
    {
        private TestBoardInput _input;
        private FillApplication _fillApplication;

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

            var fillService = new FillService(cells, new TestCellViewFactory());

            _input = new TestBoardInput();
            _fillApplication = new FillApplication(_input, new TestMoveDelay());
            _fillApplication.StartNew(fillService.Construct());
        }

        [Test]
        public void Update_ShouldLose()
        {
            _input.SetupClick(new BoardPosition(3, 2));

            Assert.DoesNotThrow(() =>
            {
                ushort iteration = 0;
                while (_fillApplication.Status == FillStatus.InProgress)
                {
                    _input.SetupDirection(Direction.Down);
                    _fillApplication.Update();

                    if (++iteration >= ushort.MaxValue)
                        break;
                }

                TestContext.WriteLine($"{iteration} iterations...");
            });

            Assert.That(_fillApplication.Status, Is.EqualTo(FillStatus.Lose));
        }

        [Test]
        public void Update_ShouldWin()
        {
            _input.SetupClick(new BoardPosition(3, 0));

            var directions = new Queue<Direction>();
            directions.Enqueue(Direction.Up);
            directions.Enqueue(Direction.Left);
            directions.Enqueue(Direction.Up);
            directions.Enqueue(Direction.Left);
            directions.Enqueue(Direction.Down);
            directions.Enqueue(Direction.Right);
            directions.Enqueue(Direction.Up);

            Assert.DoesNotThrow(() =>
            {
                ushort iteration = 0;
                while (_fillApplication.Status == FillStatus.InProgress)
                {
                    if (_input.HasDirection == false)
                        _input.SetupDirection(directions.Dequeue());

                    _fillApplication.Update();

                    if (++iteration >= ushort.MaxValue)
                        break;
                }

                TestContext.WriteLine($"{iteration} iterations...");
            });

            Assert.That(_fillApplication.Status, Is.EqualTo(FillStatus.Win));
        }
    }
}