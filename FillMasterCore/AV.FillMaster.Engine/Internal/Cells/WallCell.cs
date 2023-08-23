
namespace AV.FillMaster.FillEngine
{
    internal class WallCell : ICell
    {
        private readonly ICellView _view;

        internal WallCell(ICellView view)
        {
            _view = view;
        }

        public bool CanFill => false;

        public void FillAffect(ICellAffect affect)
        {
            throw new NotImplementedException();
        }

        public void Visualize()
        {
            _view.RenderCell();
        }
    }
}
