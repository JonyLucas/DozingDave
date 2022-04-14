using UnityEngine;

namespace Game.GridElements
{
    [RequireComponent(typeof(MovingBlock))]
    public class DragAndDropBlock : MonoBehaviour
    {
        private MovingBlock _moveScript;
        private float _initialXPosition;
        private float _initialYPosition;
        private bool _isBeingHeld = false;

        private void Awake()
        {
            _moveScript = GetComponent<MovingBlock>();
        }

        private void Update()
        {
            if (_isBeingHeld)
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.localPosition = new Vector3(mousePosition.x - _initialXPosition, mousePosition.y - _initialYPosition, transform.localPosition.z);
            }
        }

        private void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                _initialXPosition = mousePosition.x - transform.localPosition.x;
                _initialYPosition = mousePosition.y - transform.localPosition.y;

                _isBeingHeld = true;
            }
        }

        private void OnMouseUp()
        {
            _isBeingHeld = false;
        }
    }

}
