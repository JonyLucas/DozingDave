using Game.GridScripts;

namespace Game.Managers
{
    public class GridManager
    {
        private static GridManager _instance;
        private readonly GridBuilder _builder;
        private GridBoard _grid;

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
            _builder = new GridBuilder();
        }

        public void CreateGrid(int width, int heigth)
        {
            _grid = _builder.CreateGrid(width, heigth);
        }

        public void ClearGrid()
        {
            _grid.Blocks.ForEach(block => block.IsOccupied = false);
        }
    }
}