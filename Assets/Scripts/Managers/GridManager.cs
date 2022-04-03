using Game.Factories;
using Game.Grid.ScriptableObjects;
using Game.GridElements;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{
    public class GridManager
    {
        private static GridManager _instance;
        private readonly GridFactory _builder;
        private BaseGrid _grid;
        private BaseGrid _targetGrid;

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

        public BaseGrid MainGrid { get { return _grid; } }
        public TargetThought[] TargetThoughts { get; set; }

        private GridManager()
        {
            _builder = new GridFactory();
        }

        public void CreateGrid(int width, int heigth)
        {
            _grid = _builder.CreateMainGrid(width, heigth);
        }

        public void ClearGrid()
        {
            _grid.Blocks.ForEach(block => block.IsOccupied = false);
        }

        public void CreateTargetGrid(TargetThought target)
        {
        }

        public void ClearTargetGrid()
        {
            _grid.Blocks.ForEach(block => block.IsOccupied = false);
        }
    }
}