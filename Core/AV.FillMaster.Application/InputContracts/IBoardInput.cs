using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application
{
    public interface IBoardInput
    {
        bool Click(out BoardPosition position);
        bool Move(out Direction direction);
    }
}