using Game.Managers;
using UnityEngine;

namespace Game.GridElements
{
    public class BackgroundBlock : MonoBehaviour
    {
        private int _xPosition;
        private int _yPosition;

        public int XPosition
        {
            get
            {
                return _xPosition;
            }

            set
            {
                _xPosition = value;
                var auxPosition = transform.localPosition;
                auxPosition.x += _xPosition;
                transform.localPosition = auxPosition;
            }
        }

        public int YPosition
        {
            get
            {
                return _yPosition;
            }

            set
            {
                _yPosition = value;
                var auxPosition = transform.localPosition;
                auxPosition.y -= _yPosition;
                transform.localPosition = auxPosition;
            }
        }

        public Sprite CurrentSprite { get; set; }

        public Sprite TargetSprite { get; set; }

        public bool IsOccupied { get; set; }

        public bool MatchTarget
        {
            get
            {
                return IsOccupied && TargetSprite.name == CurrentSprite.name;
            }
        }
    }
}