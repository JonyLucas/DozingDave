using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    [SerializeField]
    private float _moveRate = 1;

    [SerializeField]
    private float _targetY = 0;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (transform.position.y > _targetY)
        {
            var newPosition = transform.position;
            newPosition.y -= 1;
            transform.position = newPosition;
            yield return new WaitForSeconds(_moveRate);
        }
    }
}