namespace AV.FillMaster.FillEngine
{
    internal class StickyCell : ICell
    {
        private readonly ICellView _view;

        internal StickyCell(ICellView view)
        {
            _view = view;
        }

        public bool CanFill => true;

        public void FillAffect(ICellAffect affect)
        {
            affect.ForceStop();
            _view.RenderAffect();
        }

        public void Visualize()
        {
            _view.RenderCell();
        }
    }
}
