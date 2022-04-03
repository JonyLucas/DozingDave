using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GridElements
{
    public class TargetGrid : BaseGrid
    {
        public override bool IsTargetGrid { get => true; }

        public bool ValidateGrid()
        {
            var result = true;
            //if (IsTargetGrid)
            //{
            foreach (var block in Blocks)
            {
                if (!block.MatchTarget)
                {
                    result = false;
                    break;
                }
            }
            //}

            return result;
        }
    }
}