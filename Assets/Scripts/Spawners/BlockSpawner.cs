using Game.Grid.ScriptableObjects;
using Game.GridElements;
using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Spawners
{
    [RequireComponent(typeof(GameManager))]
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _spawnRate = 5;

        [SerializeField]
        private GameObject _movingBlockPrefab;

        private List<GameObject> _movingBlocks;
        private TargetThought _coffeeThought;
        private TargetThought _targetThought;

        private MainGrid _mainGrid;
        private TargetThought[] _thoughtsList;

        // Start is called before the first frame update
        private void Start()
        {
            _mainGrid = (MainGrid) GridManager.Instance.MainGrid;
            _thoughtsList = GridManager.Instance.TargetThoughts;
            InstantiateMovingBlocks();
        }

        private void InstantiateMovingBlocks()
        {
            _movingBlocks = new List<GameObject>();
            var moveBlockParent = new GameObject("Moving Blocks");
            foreach(var thought in _thoughtsList)
            {
                foreach(var fragment in thought.PictureFragments)
                {
                    var movingBlock = GameObject.Instantiate(_movingBlockPrefab, moveBlockParent.transform);
                    movingBlock.GetComponent<SpriteRenderer>().sprite = fragment;
                    movingBlock.name = $"Moving Block - {fragment.name}";
                    movingBlock.SetActive(false);
                }
                
            }
        }

        private IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(_spawnRate);

        }

        private BackgroundBlock GetBlockSpawnLocation()
        {
            var availableBlocks = _mainGrid.Blocks.Where(block => block.YPosition == 0 && !block.IsOccupied).ToList();
            var randomIndex = Random.Range(0, availableBlocks.Count);
            return _mainGrid.AvailablePositionAtColumn(availableBlocks[randomIndex].XPosition);
        }

        public void SetTarget(TargetThought target)
        {
            _targetThought = target;
        }
    }
}