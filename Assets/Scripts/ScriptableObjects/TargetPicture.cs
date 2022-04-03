using Game.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Grid.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TargetPicture", menuName = "TargetPicture", order = 48)]
    public class TargetPicture : ScriptableObject
    {
        [SerializeField]
        private int _width = 3;

        [SerializeField]
        private List<Sprite> _pictureFragments;

        [SerializeField]
        private ThoughtType _thoughtType;

        public ThoughtType ThoughtType
        { get { return _thoughtType; } }

        public int Width
        { get { return _width; } }

        public int Height
        {
            get
            {
                if (_pictureFragments != null)
                {
                    return _pictureFragments.Count / _width;
                }

                return 0;
            }
        }

        public List<Sprite> PictureFragments
        { get { return new List<Sprite>(_pictureFragments); } }
    }
}