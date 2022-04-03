using Game.GridElements;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Factories
{
    public class GridFactory
    {
        private Sprite _emptyBlock;
        private readonly BlockFactory _blockFactory;

        public GridFactory()
        {
            _blockFactory = new BlockFactory();
        }

        public GridBoard CreateMainGrid(int width, int height)
        {
            if (_emptyBlock == null)
            {
                _emptyBlock = Resources.Load<Sprite>("Sprites/empty_block");
            }

            var gridObject = new GameObject("Grid");
            var grid = gridObject.AddComponent<MainGrid>();

            var gridBlocks = new List<GridBlock>();

            var size = width * height;
            var lineIndex = 0;
            var columnIndex = 0;

            for (int i = 0; i < size; i++)
            {
                if (i != 0)
                {
                    columnIndex++;

                    if (i % width == 0)
                    {
                        lineIndex++;
                        columnIndex = 0;
                    }
                }

                gridBlocks.Add(_blockFactory.CreateGridBlock(grid, i, lineIndex, columnIndex));
            }

            grid.Blocks = gridBlocks;

            return grid;
        }
    }
}