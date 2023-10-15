using AV.FillMaster.FillEngine;
using UnityEngine;

namespace AV.FillMaster.UnityLibrary
{
    public static class Extentions
    {
        public static BoardPosition ToBoardPosition(this Vector2Int vector) => new BoardPosition(vector.x, vector.y);
        public static Vector2Int ToVector2Int(this BoardPosition position) => new Vector2Int(position.X, position.Y);
        public static Vector2 ToVector2(this BoardPosition position) => new Vector2(position.X, position.Y);
        public static Vector3 ToVector3(this BoardPosition position) => new Vector3(position.X, 0, position.Y);
    }
}
