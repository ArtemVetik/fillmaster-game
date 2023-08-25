namespace AV.FillMaster.FillEngine
{
    internal class EmptyCell : ICell
    {
        private readonly ICellView _view;

        internal EmptyCell(ICellView view)
        {
            _view = view;
        }

        public bool CanFill => true;

        public void FillAffect(ICellAffect affect) { }

        public void Visualize()
        {
            _view.RenderCell();
        }
    }
}
