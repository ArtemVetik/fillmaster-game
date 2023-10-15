namespace AV.FillMaster.FillEngine
{
    internal interface IFillRule
    {
        FillStatus Status(IReadOnlyBoard board, BoardPosition header);
    }
}
