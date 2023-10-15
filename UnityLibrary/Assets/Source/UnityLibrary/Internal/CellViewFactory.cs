using AV.FillMaster.Application;
using AV.FillMaster.FillEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class CellViewFactory : MonoBehaviour, ICellViewFactory, IBoardInput
    {
        [SerializeField] private CellView _viewTemplate;
        [SerializeField] private CellInput _input;

        private readonly Dictionary<BoardPosition, ICellView> _cellViews = new();
        private readonly Dictionary<CellType, Color> _colors = new()
        {
            { CellType.Wall, Color.black },
            { CellType.Empty, Color.white },
            { CellType.Filled, Color.yellow },
            { CellType.Sticky, Color.red },
        };

        private PollButton<Direction> _directionButton;
        private CameraPosition _cameraPosition;

        private void Start()
        {
            var camera = Camera.main;

            if (camera.TryGetComponent(out _cameraPosition) == false)
                _cameraPosition = camera.gameObject.AddComponent<CameraPosition>();

            _input.Init((direction) => _directionButton.Click(direction));
        }

        public ICellView Create(BoardPosition position, CellType cell)
        {
            if (_cellViews.TryGetValue(position, out ICellView view))
            {
                Object.Destroy((view as MonoBehaviour).gameObject);
                _cellViews.Remove(position);
            }

            view = Object.Instantiate(_viewTemplate, position.ToVector3(), Quaternion.identity);
            (view as CellView).Init(_colors[cell]);

            _cellViews.Add(position, view);
            _cameraPosition.UpdatePosition(_cellViews.Keys.Select(position => position.ToVector2Int()));

            return view;
        }

        public void Clear()
        {
            foreach (var view in _cellViews)
                Object.Destroy((view.Value as MonoBehaviour).gameObject);

            _cellViews.Clear();
        }

        public bool Click(out BoardPosition position)
        {
            position = default;

            foreach (var item in _cellViews)
            {
                if ((item.Value as CellView).PollButton())
                {
                    position = item.Key;
                    return true;
                }
            }

            return false;
        }

        public bool Move(out Direction direction)
        {
            return _directionButton.Poll(out direction);
        }
    }
}
