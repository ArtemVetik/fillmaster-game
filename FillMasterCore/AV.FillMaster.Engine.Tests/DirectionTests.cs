using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Engine.Tests
{
    public class DirectionTests
    {
        [Test]
        public void Next_AllDirections_ChangePositionToOne()
        {
            var position = new BoardPosition(0, 0);

            Assert.Multiple(() =>
            {
                Assert.That(Direction.Up.Next(position), Is.EqualTo(new BoardPosition(0, 1)));
                Assert.That(Direction.Down.Next(position), Is.EqualTo(new BoardPosition(0, -1)));
                Assert.That(Direction.Left.Next(position), Is.EqualTo(new BoardPosition(-1, 0)));
                Assert.That(Direction.Right.Next(position), Is.EqualTo(new BoardPosition(1, 0)));
            });
        }

        [Test]
        public void Turn_AllTurns_ChangeDirection()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Direction.Up.TurnLeft(), Is.EqualTo(Direction.Left));
                Assert.That(Direction.Up.TurnRight(), Is.EqualTo(Direction.Right));

                Assert.That(Direction.Down.TurnLeft(), Is.EqualTo(Direction.Right));
                Assert.That(Direction.Down.TurnRight(), Is.EqualTo(Direction.Left));

                Assert.That(Direction.Left.TurnLeft(), Is.EqualTo(Direction.Down));
                Assert.That(Direction.Left.TurnRight(), Is.EqualTo(Direction.Up));

                Assert.That(Direction.Right.TurnLeft(), Is.EqualTo(Direction.Up));
                Assert.That(Direction.Right.TurnRight(), Is.EqualTo(Direction.Down));
            });
        }

        [Test]
        public void Equals_SameDirections_ShouldEqual()
        {
            var firstDirection = Direction.Right;
            var secondDirection = Direction.Right;

            Assert.Multiple(() =>
            {
                Assert.That(firstDirection, Is.EqualTo(secondDirection));
                Assert.That(secondDirection, Is.EqualTo(firstDirection));
            });
        }

        [Test]
        public void EqualsOperator_NullCheck_DoesNotThrow()
        {
            Assert.That(Direction.Right == null, Is.False);
            Assert.That(Direction.Right != null, Is.True);
            Assert.That(null == Direction.Up, Is.False);
            Assert.That(null != Direction.Up, Is.True);

            Direction direction = null;
            Assert.That(direction == Direction.Left, Is.False);
            Assert.That(direction == null, Is.True);
        }
    }
}