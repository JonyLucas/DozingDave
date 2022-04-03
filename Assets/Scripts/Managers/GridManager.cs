using Game.Factories;
using Game.Grid.ScriptableObjects;
using Game.GridElements;

namespace Game.Managers
{
    public class GridManager
    {
        private static GridManager _instance;
        private readonly GridFactory _builder;
        private GridBoard _grid;
        private GridBoard _targetGrid;

        public static GridManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GridManager();
                }
                return _instance;
            }
        }

        private GridManager()
        {
            _builder = new GridFactory();
        }

        public void CreateGrid(int width, int heigth)
        {
            _grid = _builder.CreateGrid(width, heigth);
        }

        public void ClearGrid()
        {
            _grid.Blocks.ForEach(block => block.IsOccupied = false);
        }

        public void CreateTargetGrid(TargetPicture target)
        {
        }

        public void ClearTargetGrid()
        {
        }
    }
}