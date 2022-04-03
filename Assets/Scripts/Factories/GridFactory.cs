using Game.GridElements;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Factories
{
    public class GridFactory
    {
        private Sprite _emptyBlock;

        public GridBoard CreateGrid(int width, int height)
        {
            if (_emptyBlock == null)
            {
                _emptyBlock = Resources.Load<Sprite>("Sprites/empty_block");
            }

            var gridObject = new GameObject("Grid");
            var grid = gridObject.AddComponent<GridBoard>();

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

                gridBlocks.Add(CreateBlock(grid, i, lineIndex, columnIndex));
            }

            grid.Blocks = gridBlocks;

            return grid;
        }

        private GridBlock CreateBlock(GridBoard grid, int index, int lineIndex, int columnIndex)
        {
            var blockObject = new GameObject($"Block ({index})");
            blockObject.transform.parent = grid.transform;

            var renderer = blockObject.AddComponent<SpriteRenderer>();
            renderer.sprite = _emptyBlock;
            renderer.sortingLayerName = "Grid";

            var blockScript = blockObject.AddComponent<GridBlock>();
            blockScript.XPosition = columnIndex;
            blockScript.YPosition = lineIndex;
            blockScript.IsOccupied = false;

            return blockScript;
        }

        //public GridBoard CreateGridByTarget(TargetPicture target)
        //{
        //    var grid = CreateGrid(target.Width, target.Height);
        //    var fragments = target.PictureFragments;

        //    for (int i = 0; i < grid.Blocks.Count; i++)
        //    {
        //        grid.Blocks[i].TargetSprite = fragments[i];
        //    }
        //}
    }
}