namespace AV.FillMaster.Application
{
    public interface ISaves
    {
        int CurrentLevel { get; }
        int LastCompletedLevel { get; }
        void SetCurrentLevel(int levelIndex);
        void CompleteCurrentLevel();
        int SolutionStep(int levelIndex);
        void IncreaseSolutionStep(int levelIndex);
    }
}