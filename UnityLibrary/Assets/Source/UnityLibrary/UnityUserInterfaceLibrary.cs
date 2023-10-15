using AV.FillMaster.Application;
using AV.FillMaster.FillEngine;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    public class UnityUserInterfaceLibrary : IUserInterfaceLibrary
    {
        public ICellViewFactory CreateCellViewFactory() => Object.Instantiate(Resources.Load<CellViewFactory>(nameof(CellViewFactory)));

        public IHudView CreateHudView() => Object.Instantiate(Resources.Load<HudInputView>(nameof(HudInputView)));

        public IEndOfGameView CreateEndOfGameView() => Object.Instantiate(Resources.Load<EndOfGameView>(nameof(EndOfGameView)));

        public ISolutionView CreateSolutionView() => Object.Instantiate(Resources.Load<SolutionView>(nameof(SolutionView)));

        public ILevelListView CreateLevelListView() => Object.Instantiate(Resources.Load<LevelListView>(nameof(LevelListView)));
    }
}
