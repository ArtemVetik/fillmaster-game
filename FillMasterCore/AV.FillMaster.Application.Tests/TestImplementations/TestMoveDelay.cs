using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application.Tests
{
    internal class TestMoveDelay : IMoveDelay
    {
        public async Task Delay()
        {
            await Task.Delay(0);
        }
    }
}