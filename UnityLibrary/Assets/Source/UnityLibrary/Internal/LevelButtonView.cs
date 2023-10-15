using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AV.FillMaster.UnityLibrary
{
    internal class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _numberText;
        [SerializeField] private Button _button;

        public void Render(int number, bool selected, bool unlocked, Action<int> selectedAction)
        {
            _numberText.text = number.ToString();
            _button.interactable = unlocked;

            if (selected)
                _button.image.color = Color.yellow;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => selectedAction?.Invoke(number));
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}
