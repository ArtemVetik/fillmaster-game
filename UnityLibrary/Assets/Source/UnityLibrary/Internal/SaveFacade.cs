using AV.FillMaster.Application;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class SaveFacade : ISaves
    {
        private const string LastCompletedLevelIndexKey = "LastCompletedLevelIndex";
        private const string CurrentLevelIndexKey = "CurrentLevelIndex";
        private const string SolutionSaveKey = "SolutionSaveKey";

        private readonly ILevelsDataBase _levelDataBase;

        public SaveFacade(ILevelsDataBase levelDataBase)
        {
            _levelDataBase = levelDataBase;
        }

        public int CurrentLevel => PlayerPrefs.GetInt(CurrentLevelIndexKey);

        public int LastCompletedLevel => PlayerPrefs.GetInt(LastCompletedLevelIndexKey, 0);

        public void SetCurrentLevel(int levelIndex)
        {
            PlayerPrefs.SetInt(CurrentLevelIndexKey, levelIndex);
        }

        public void CompleteCurrentLevel()
        {
            PlayerPrefs.SetInt(CurrentLevelIndexKey, Mathf.Clamp(CurrentLevel + 1, 0, _levelDataBase.Count - 1));

            if (CurrentLevel > LastCompletedLevel)
                PlayerPrefs.SetInt(LastCompletedLevelIndexKey, CurrentLevel);
        }

        public int SolutionStep(int levelIndex)
        {
            return PlayerPrefs.GetInt(SolutionSaveKey + levelIndex.ToString(), 0);
        }

        public void IncreaseSolutionStep(int levelIndex)
        {
            PlayerPrefs.SetInt(SolutionSaveKey + levelIndex.ToString(), SolutionStep(levelIndex) + 1);
        }
    }
}
