using System.Collections.Generic;
using System.Threading.Tasks;

namespace AV.FillMaster.FillEngine
{
    public interface IFillEngine
    {
        IReadOnlyList<BoardPosition> FillTrail { get; }

        Task<FillStatus> MoveAsync(Direction direction, IMoveDelay moveDelay);
        FillStatus Move(Direction direction);
    }
}
