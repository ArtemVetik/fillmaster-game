using System;

namespace AV.FillMaster.Application
{
    public interface ILevelListView
    {
        void Render(int levelCount, int completedCount, int currentLevel, Action<int> selected);
        void Close();
    }
}