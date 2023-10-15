using System.Collections.Generic;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    internal class CameraPosition : MonoBehaviour
    {
        internal void UpdatePosition(IEnumerable<Vector2Int> cells)
        {
            var minX = 0;
            var minY = 0;
            var maxX = 0;
            var maxY = 0;

            foreach (var cell in cells)
            {
                if (cell.x < minX)
                    minX = cell.x;

                if (cell.y < minY)
                    minY = cell.y;

                if (cell.x > maxX)
                    maxX = cell.x;

                if (cell.y > maxY)
                    maxY = cell.y;
            }

            var center = new Vector2((maxX - minX) / 2f, (maxY - minY) / 2f);

            transform.position = new Vector3(center.x, transform.position.y, center.y);
        }
    }
}
