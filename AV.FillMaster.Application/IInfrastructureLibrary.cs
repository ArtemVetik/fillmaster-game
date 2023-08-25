using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application
{
    public interface IInfrastructureLibrary
    {
        ISaves Saves { get; }
        ILevelsDataBase Levels { get; }
        IMoveDelay MoveDelay { get; }
    }
}