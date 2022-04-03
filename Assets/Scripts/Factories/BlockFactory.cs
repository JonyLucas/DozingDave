using Game.Grid.ScriptableObjects;
using Game.GridElements;
using UnityEngine;

namespace Game.Factories
{
    public class BlockFactory
    {
        private Sprite _emptyBlock;

        public BackgroundBlock CreateGridBlock(BaseGrid grid, int index, int lineIndex, int columnIndex)
        {
            if (_emptyBlock == null)
            {
                _emptyBlock = Resources.Load<Sprite>("Sprites/empty_block");
            }

            var blockObject = new GameObject($"Block ({index})");
            blockObject.transform.parent = grid.transform;

            var renderer = blockObject.AddComponent<SpriteRenderer>();
            renderer.sprite = _emptyBlock;
            renderer.sortingLayerName = "Grid";

            var blockScript = blockObject.AddComponent<BackgroundBlock>();
            blockScript.XPosition = columnIndex;
            blockScript.YPosition = lineIndex;
            blockScript.IsOccupied = false;

            return blockScript;
        }

        //public GridBoard CreateSpawnedBlock(TargetPicture target)
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