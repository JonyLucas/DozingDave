using System.Collections;
using UnityEngine;

namespace Game.GridElements
{
    public class SpawnedBlock : MonoBehaviour
    {
        [SerializeField]
        private float _moveRate = 1;

        public GridBlock TargetBlock { get; set; }

        private bool _isMoving = true;

        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(MoveCoroutine());
        }

        private IEnumerator MoveCoroutine()
        {
            var targetY = TargetBlock.transform.position.y;
            while (transform.position.y > targetY)
            {
                var newPosition = transform.position;
                newPosition.y -= 1;
                transform.position = newPosition;
                _isMoving = true;
                yield return new WaitForSeconds(_moveRate);
            }
            _isMoving = false;
        }

        private void Update()
        {
            if (!_isMoving)
            {
            }
        }
    }
}