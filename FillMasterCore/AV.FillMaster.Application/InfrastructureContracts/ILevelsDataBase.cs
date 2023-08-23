
namespace AV.FillMaster.Application
{
    public interface ILevelsDataBase
    {
        public int Count { get; }
        public Task<LevelInfo> LoadLevel(int index);
    }
}