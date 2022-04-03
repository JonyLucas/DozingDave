using Game.Grid.ScriptableObjects;
using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Spawners
{
    [RequireComponent(typeof(GameManager))]
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _spawnRate = 5;

        private List<GameObject> framgmentsList;

        private TargetThought _coffeeThought;
        private TargetThought _targetThought;

        // Start is called before the first frame update
        private void Start()
        {
        }

        private IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(_spawnRate);
        }

        public void SetTarget(TargetThought target)
        {
            _targetThought = target;
        }
    }
}