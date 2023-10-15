using AV.FillMaster.FillEngine;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AV.FillMaster.UnityLibrary
{
    internal class CellInput : MonoBehaviour
    {
        [SerializeField] private Button _right;
        [SerializeField] private Button _left;
        [SerializeField] private Button _up;
        [SerializeField] private Button _down;

        private Action<Direction> _clicked;

        private void OnDisable()
        {
            _right.onClick.RemoveAllListeners();
            _left.onClick.RemoveAllListeners();
            _up.onClick.RemoveAllListeners();
            _down.onClick.RemoveAllListeners();
        }

        internal void Init(Action<Direction> clicked)
        {
            OnDisable();

            _clicked = clicked;
            _right.onClick.AddListener(() => _clicked?.Invoke(Direction.Right));
            _left.onClick.AddListener(() => _clicked?.Invoke(Direction.Left));
            _up.onClick.AddListener(() => _clicked?.Invoke(Direction.Up));
            _down.onClick.AddListener(() => _clicked?.Invoke(Direction.Down));
        }

        private void Update()
        {
            if (_clicked == null)
                return;

            if (Input.GetKeyDown(KeyCode.A))
                _clicked?.Invoke(Direction.Left);
            if (Input.GetKeyDown(KeyCode.W))
                _clicked?.Invoke(Direction.Up);
            if (Input.GetKeyDown(KeyCode.D))
                _clicked?.Invoke(Direction.Right);
            if (Input.GetKeyDown(KeyCode.S))
                _clicked?.Invoke(Direction.Down);
        }
    }
}
