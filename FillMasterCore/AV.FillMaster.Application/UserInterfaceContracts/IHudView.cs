namespace AV.FillMaster.Application
{
    public interface IHudView
    {
        void Enable();
        void Disable();
        void RenderLevelNumber(int level);
    }
}