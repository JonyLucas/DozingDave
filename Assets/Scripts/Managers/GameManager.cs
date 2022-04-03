using Game.Grid.ScriptableObjects;
using Game.Spawners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int _width = 4;

        [SerializeField]
        private int _height = 4;

        private readonly GridManager _gridManager = GridManager.Instance;

        private BlockSpawner _spawner;

        // Start is called before the first frame update
        private void Start()
        {
            _gridManager.TargetThoughts = Resources.LoadAll<TargetThought>("ScriptableObjects/TargetThoughts");
            _gridManager.CreateGrid(_width, _height);
        }

        public void SetTargetPicture(TargetThought target)
        {
        }
    }
}