using AV.FillMaster.Application;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    public class UnityInputLibrary : IInputLibrary
    {
        public IBoardInput CreateBoardInput() => new GameObject(nameof(BoardInputRouter)).AddComponent<BoardInputRouter>();

        public IHudInput CreateHudInput() => new GameObject(nameof(HudInputRouter)).AddComponent<HudInputRouter>();
    }
}
