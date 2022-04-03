using System.Collections.Generic;
using UnityEngine;

namespace Game.GridElements
{
    public abstract class GridBoard : MonoBehaviour
    {
        private int _width;
        private int _height;
        private List<GridBlock> _blocks;

        //public bool IsTargetGrid { get; set; }

        public int Width
        { get { return _width; } }

        public int Height
        { get { return _height; } }

        public List<GridBlock> Blocks
        {
            get { return _blocks; }
            set
            {
                _blocks = value;
                var lastBlock = _blocks[_blocks.Count - 1];
                _width = lastBlock.XPosition + 1;
                _height = lastBlock.YPosition + 1;
            }
        }
    }
}