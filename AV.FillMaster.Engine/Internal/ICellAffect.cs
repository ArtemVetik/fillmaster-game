namespace AV.FillMaster.FillEngine
{
    internal interface ICellAffect
    {
        void Fill(BoardPosition position);
        void ForceStop();
    }
}
