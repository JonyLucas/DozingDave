using System.Collections.Generic;
using UnityEngine;

namespace Game.Grid.ScriptableObjects
{
    public class TargetPicture : ScriptableObject
    {
        [SerializeField]
        private int _sideLength = 3;

        [SerializeField]
        private List<Sprite> _pictureFragments;

        public int SideLength
        { get { return _sideLength; } }

        public List<Sprite> PictureFragments
        { get { return new List<Sprite>(_pictureFragments); } }
    }
}