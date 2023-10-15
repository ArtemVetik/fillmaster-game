using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AV.FillMaster.UnityLibrary
{
    internal class LevelListPanel : MonoBehaviour
    {
        [SerializeField] private LevelButtonView _template;
        [SerializeField] private Transform _container;
        [SerializeField] private Button _closeButton;

        private readonly List<LevelButtonView> _buttons = new();

        public void Render(int levelCount, int completedCount, int currentLevel, Action<int> onSelected, Action onClose)
        {
            foreach (var button in _buttons)
                Destroy(button.gameObject);

            _buttons.Clear();

            for (int number = 0; number < levelCount; number++)
            {
                var button = Instantiate(_template, _container);
                button.Render(number, number == currentLevel, number <= completedCount, onSelected);

                _buttons.Add(button);
            }

            _closeButton.onClick.RemoveAllListeners();
            _closeButton.onClick.AddListener(() => onClose?.Invoke());
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}
