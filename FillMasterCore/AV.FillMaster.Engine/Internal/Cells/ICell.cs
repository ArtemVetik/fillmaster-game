namespace AV.FillMaster.FillEngine
{
    internal interface ICell
    {
        bool CanFill { get; }
        void FillAffect(ICellAffect affect);
        void Visualize();
    }
}
