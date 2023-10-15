using AV.FillMaster.FillEngine;
using System.Threading.Tasks;

namespace AV.FillMaster.Application
{
    internal class LevelProvider
    {
        private readonly ILevelsDataBase _levelDataBase;
        private readonly ICellViewFactory _cellViewFactory;

        public LevelProvider(ILevelsDataBase levelDataBase, ICellViewFactory cellViewFactory)
        {
            _levelDataBase = levelDataBase;
            _cellViewFactory = cellViewFactory;
        }

        public int LevelIndex { get; private set; }
        public LevelInfo LevelInfo { get; private set; }

        public async Task<IFillEngineSetup> LoadLevel(int index)
        {
            LevelIndex = index;

            LevelInfo = await _levelDataBase.LoadLevel(index);
            return new FillService(LevelInfo.Cells, _cellViewFactory).Construct();
        }
    }
}