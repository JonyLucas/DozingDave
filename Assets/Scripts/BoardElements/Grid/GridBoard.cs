using System.Collections.Generic;
using UnityEngine;

namespace Game.GridElements
{
    public class GridBoard : MonoBehaviour
    {
        public List<GridBlock> Blocks { get; set; }
        public bool IsTargetGrid { get; set; }

        public bool ValidateGrid()
        {
            var result = true;
            if (IsTargetGrid)
            {
                foreach (var block in Blocks)
                {
                    if (!block.MatchTarget)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}