using AV.FillMaster.Application;
using AV.FillMaster.FillEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class SolutionView : MonoBehaviour, ISolutionView
    {
        [SerializeField] private GameObject _solutionCellTemplate;

        private readonly List<GameObject> _solutionCells = new();

        private Coroutine _solutionRendering;

        public void Render(BoardPosition setupPosition, IReadOnlyList<BoardPosition> fillTrail)
        {
            if (_solutionRendering != null)
                StopCoroutine(_solutionRendering);

            foreach (var cell in _solutionCells)
                if (cell != null)
                    Destroy(cell);

            _solutionCells.Clear();

            _solutionRendering = StartCoroutine(RenderSolution(setupPosition, fillTrail));
        }

        private IEnumerator RenderSolution(BoardPosition setupPosition, IReadOnlyList<BoardPosition> fillTrail, float delay = 0.1f)
        {
            var waitForSeconds = new WaitForSeconds(delay);

            var setupCell = Instantiate(_solutionCellTemplate, setupPosition.ToVector3(), Quaternion.identity);
            _solutionCells.Add(setupCell);

            yield return waitForSeconds;

            foreach (var position in fillTrail)
            {
                var fillTrailCell = Instantiate(_solutionCellTemplate, position.ToVector3(), Quaternion.identity);
                _solutionCells.Add(fillTrailCell);

                yield return waitForSeconds;
            }

            yield return new WaitForSeconds(1f);

            foreach (var cell in _solutionCells)
                Destroy(cell);

            _solutionCells.Clear();

            _solutionRendering = null;
        }
    }
}
