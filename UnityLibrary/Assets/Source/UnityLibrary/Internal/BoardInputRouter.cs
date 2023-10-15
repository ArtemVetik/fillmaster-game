using AV.FillMaster.Application;
using AV.FillMaster.FillEngine;
using System.Linq;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class BoardInputRouter : MonoBehaviour, IBoardInput
    {
        private IBoardInput _boardInput;

        public bool Click(out BoardPosition position)
        {
            Initialize();

            if (_boardInput != null)
                return _boardInput.Click(out position);

            Debug.LogWarning($"Not found {nameof(IBoardInput)}");
            position = default;
            return false;
        }

        public bool Move(out Direction direction)
        {
            Initialize();

            if (_boardInput != null)
                return _boardInput.Move(out direction);

            Debug.LogWarning($"Not found {nameof(IBoardInput)}");
            direction = default;
            return false;
        }

        private void Initialize()
        {
            _boardInput ??= (IBoardInput)Object.FindObjectsOfType<MonoBehaviour>().FirstOrDefault(monoBehaviour => monoBehaviour is IBoardInput && monoBehaviour != this);
        }
    }
}
