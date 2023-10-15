using AV.FillMaster.Application;
using System;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class LevelListView : MonoBehaviour, ILevelListView
    {
        [SerializeField] private LevelListPanel _panelTemplate;

        private LevelListPanel _panelInstance;

        public void Render(int levelCount, int completedCount, int currentLevel, Action<int> selected)
        {
            if (_panelInstance == null)
                _panelInstance = Instantiate(_panelTemplate);

            _panelInstance.Render(levelCount, completedCount, currentLevel, selected, Close);
        }

        public void Close()
        {
            Destroy(_panelInstance.gameObject);
            _panelInstance = null;
        }
    }
}
