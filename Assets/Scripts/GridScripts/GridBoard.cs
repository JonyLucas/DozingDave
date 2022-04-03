using Game.Grid.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GridScripts
{
    public class GridBoard : MonoBehaviour
    {
        public List<Block> Blocks { get; set; }
        public bool IsTargetGrid { get; set; }
        public TargetPicture TargetPicture { get; set; }
    }
}