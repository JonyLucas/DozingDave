using Game.Managers;
using UnityEngine;

namespace Game.GridScripts
{
    public class Block : MonoBehaviour
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

        public Sprite CurrentSprite
        {
            get
            {
                return transform.GetComponent<SpriteRenderer>().sprite;
            }
            set
            {
                var renderer = transform.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    renderer.sprite = value;
                }
            }
        }

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