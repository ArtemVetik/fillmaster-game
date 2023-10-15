using AV.FillMaster.Application;
using AV.FillMaster.FillEngine;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    public class UnityInfrastructureLibrary : IInfrastructureLibrary
    {
        public ISaves Saves => new SaveFacade(Levels);

        public ILevelsDataBase Levels => Resources.Load<LevelDataBase>(nameof(LevelDataBase));

        public IMoveDelay MoveDelay => new MoveDelay();
    }
}
