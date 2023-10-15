using System;

namespace AV.FillMaster.FillEngine
{
    internal class FilledCell : ICell
    {
        private readonly ICellView _view;

        internal FilledCell(ICellView view)
        {
            _view = view;
        }

        public bool CanFill => false;

        public void FillAffect(ICellAffect affect)
        {
            throw new InvalidOperationException();
        }

        public void Visualize()
        {
            _view.RenderCell();
        }
    }
}
