using AV.FillMaster.Application;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AV.FillMaster.UnityLibrary
{
    internal class HudInputView : MonoBehaviour, IHudView, IHudInput
    {
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private TMP_Text _levelNumber;
        [SerializeField] private Button _hintButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _levelsButton;

        private PollButton _hintPollButton;
        private PollButton _restartPollButton;
        private PollButton _levelsPollButton;

        private void OnEnable()
        {
            _hintButton.onClick.AddListener(ClickHint);
            _restartButton.onClick.AddListener(ClickRestart);
            _levelsButton.onClick.AddListener(ClickLevels);
        }

        private void OnDisable()
        {
            _hintButton.onClick.RemoveListener(ClickHint);
            _restartButton.onClick.RemoveListener(ClickRestart);
            _levelsButton.onClick.RemoveListener(ClickLevels);
        }

        void IHudView.Disable()
        {
            _canvas.alpha = 0f;
        }

        void IHudView.Enable()
        {
            _canvas.alpha = 1f;
        }

        void IHudView.RenderLevelNumber(int level)
        {
            _levelNumber.text = level.ToString();
        }

        bool IHudInput.HintClicked() => _hintPollButton.Poll();
        
        bool IHudInput.RestartClicked() => _restartPollButton.Poll();

        bool IHudInput.LevelsButtonClicked() => _levelsPollButton.Poll();

        private void ClickHint() => _hintPollButton.Click();
        
        private void ClickRestart() => _restartPollButton.Click();

        private void ClickLevels() => _levelsPollButton.Click();
    }
}
