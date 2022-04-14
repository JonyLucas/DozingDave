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

        [SerializeField]
        private Canvas _canvas;

        private List<GameObject> _movingBlocks;
        private List<GameObject> _availableBlocks;

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
            StartCoroutine(SpawnCoroutine());
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
                    _movingBlocks.Add(movingBlock);
                }
                
            }
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                _availableBlocks = _movingBlocks.Where(block => !block.activeInHierarchy).ToList();
                yield return new WaitForSeconds(_spawnRate);
                if (_mainGrid.HasSpaceAvailable && _availableBlocks.Count > 0)
                {   
                    var randomIndex = Random.Range(0, _availableBlocks.Count);
                    var selectedBlock = _availableBlocks[randomIndex];
                    SetMobingBlockLocation(selectedBlock);
                    selectedBlock.SetActive(true);
                }                
            }

        }

        private void SetMobingBlockLocation(GameObject movingBlock)
        {
            var availableBlocks = _mainGrid.Blocks.Where(block => block.YPosition == 0 && !block.IsOccupied).ToList();
            var randomIndex = Random.Range(0, availableBlocks.Count);
            movingBlock.transform.position = availableBlocks[randomIndex].transform.position;

            var blockScript = movingBlock.GetComponent<MovingBlock>();
            blockScript.TargetBlock = _mainGrid.AvailablePositionAtColumn(availableBlocks[randomIndex].XPosition);

            Debug.Log($"Select Block: {blockScript.TargetBlock.transform.name} - Position: {movingBlock.transform.position}");
        }

        public void SetTarget(TargetThought target)
        {
            _targetThought = target;
        }
    }
}