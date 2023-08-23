using System.Threading.Tasks;

namespace AV.FillMaster.FillEngine
{
    public interface IFillEngine
    {
        Task<FillStatus> MoveAsync(Direction direction, IMoveDelay moveDelay);
        FillStatus Move(Direction direction);
    }
}
