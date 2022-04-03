using System.Collections.Generic;
using UnityEngine;

namespace Game.GridScripts
{
    public class GridBuilder
    {
        public GridBoard CreateGrid(int width, int height)
        {
            var gridObject = new GameObject("Grid");
            var grid = gridObject.AddComponent<GridBoard>();

            var gridBlocks = new List<Block>();

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

                gridBlocks.Add(CreateBlock(grid, i, lineIndex, columnIndex));
            }

            grid.Blocks = gridBlocks;

            return grid;
        }

        private Block CreateBlock(GridBoard grid, int index, int lineIndex, int columnIndex)
        {
            var blockObject = new GameObject($"Block ({index})");
            blockObject.transform.parent = grid.transform;

            var blockScript = blockObject.AddComponent<Block>();
            blockScript.XPosition = columnIndex;
            blockScript.YPosition = lineIndex;
            blockScript.IsOccupied = false;

            return blockScript;
        }
    }
}