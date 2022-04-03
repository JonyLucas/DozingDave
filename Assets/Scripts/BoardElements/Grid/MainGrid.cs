using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.GridElements
{
    public class MainGrid : BaseGrid
    {
        public override bool IsTargetGrid { get => false; }
        public bool HasSpaceAvailable => Blocks.Count(block => !block.IsOccupied) > 1;

        public BackgroundBlock AvailablePositionAtColumn(int columnIndex)
        {
            return Blocks.LastOrDefault(block => !block.IsOccupied && block.XPosition == columnIndex);
        }
    }
}