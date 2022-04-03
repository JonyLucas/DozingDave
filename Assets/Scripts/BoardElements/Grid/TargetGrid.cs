using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GridElements
{
    public class TargetGrid : GridBoard
    {
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