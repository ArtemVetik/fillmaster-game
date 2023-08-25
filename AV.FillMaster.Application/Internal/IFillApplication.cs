using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application
{
    internal interface IFillApplication
    {
        bool Initialized { get; }
        FillStatus Status { get; }

        void StartNew(IFillEngineSetup fillEngineSetup);
    }
}