using AV.FillMaster.FillEngine;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class CellView : MonoBehaviour, ICellView
    {
        [SerializeField] private Renderer _renderer;

        private Color _color;
        private PollButton _pollButton;

        public void Init(Color color)
        {
            _color = color;
        }

        public bool PollButton()
        {
            return _pollButton.Poll();
        }

        public void RenderCell()
        {
            _renderer.material.color = _color;
        }

        public void RenderAffect() { }

        private void OnMouseDown()
        {
            _pollButton.Click();
        }
    }
}
