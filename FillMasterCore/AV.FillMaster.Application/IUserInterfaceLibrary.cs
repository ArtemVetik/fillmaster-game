using AV.FillMaster.FillEngine;

namespace AV.FillMaster.Application
{
    public interface IUserInterfaceLibrary
    {
        ICellViewFactory CreateCellViewFactory();
        IHudView CreateHudView();
        IEndOfGameView CreateEndOfGameView();
    }
}