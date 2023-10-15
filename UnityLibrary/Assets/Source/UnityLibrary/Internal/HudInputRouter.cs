using AV.FillMaster.Application;
using System.Linq;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class HudInputRouter : MonoBehaviour, IHudInput
    {
        private IHudInput _hudInput;

        public bool HintClicked()
        {
            Initialize();
            return _hudInput?.HintClicked() ?? EmptyInput();
        }

        public bool LevelsButtonClicked()
        {
            Initialize();
            return _hudInput?.LevelsButtonClicked() ?? EmptyInput();
        }

        public bool RestartClicked()
        {
            Initialize();
            return _hudInput?.RestartClicked() ?? EmptyInput();
        }

        private void Initialize()
        {
            _hudInput ??= (IHudInput)Object.FindObjectsOfType<MonoBehaviour>().FirstOrDefault(monoBehaviour => monoBehaviour is IHudInput && monoBehaviour != this);
        }

        private bool EmptyInput()
        {
            Debug.LogWarning($"{nameof(IHudInput)} not found");
            return false;
        }
    }
}
