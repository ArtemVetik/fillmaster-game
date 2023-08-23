using System;
using System.Collections.Generic;
using System.Linq;

namespace AV.FillMaster.FillEngine
{
    internal class CellRelation
    {
        internal class CellInfo
        {
            private readonly Func<ICellView, ICell> _constructor;
            private readonly Type _classType;

            internal CellInfo(Func<ICellView, ICell> constructor, Type classType)
            {
                _constructor = constructor;
                _classType = classType;
            }

            internal ICell CreateCell(ICellView view) => _constructor?.Invoke(view);
            internal Type ClassType() => _classType;
        }

        private readonly Dictionary<CellType, CellInfo> _relations;

        internal CellRelation(IEnumerable<KeyValuePair<CellType, CellInfo>> relations)
        {
            _relations = new Dictionary<CellType, CellInfo>(relations);
        }

        internal ICell CreateCell(CellType cell, ICellView view) => _relations[cell].CreateCell(view);
        internal Type ClassType(CellType cell) => _relations[cell].ClassType();
        internal CellType CellType(Type classType) => _relations.First(pair => pair.Value.ClassType() == classType).Key;
    }
}
