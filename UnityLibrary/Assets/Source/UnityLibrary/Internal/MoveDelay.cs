using AV.FillMaster.FillEngine;
using System.Threading.Tasks;

namespace AV.FillMaster.UnityLibrary
{
    internal class MoveDelay : IMoveDelay
    {
        public async Task Delay()
        {
            await Task.Yield();
        }
    }
}
