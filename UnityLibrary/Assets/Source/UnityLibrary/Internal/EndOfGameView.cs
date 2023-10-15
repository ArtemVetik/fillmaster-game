using AV.FillMaster.Application;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class EndOfGameView : MonoBehaviour, IEndOfGameView
    {
        [SerializeField] private TMP_Text _endText;

        public async Task RenderLose()
        {
            _endText.text = "LOSE";
            _endText.enabled = true;

            var delayTime = Time.realtimeSinceStartup + 2f;

            while (Time.realtimeSinceStartup < delayTime)
                await Task.Yield();

            _endText.enabled = false;
        }

        public async Task RenderWin()
        {
            _endText.text = "WIN";
            _endText.enabled = true;

            var delayTime = Time.realtimeSinceStartup + 2f;

            while (Time.realtimeSinceStartup < delayTime)
                await Task.Yield();

            _endText.enabled = false;
        }
    }
}
