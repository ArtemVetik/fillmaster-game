using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Engine.Tests
{
    public class TestCell : ICell
    {
        private readonly bool _canFill;

        public TestCell(bool canFill)
        {
            _canFill = canFill;
        }

        public bool CanFill => _canFill;

        public void Visualize() { }

        void ICell.FillAffect(ICellAffect affect) { }
    }
}