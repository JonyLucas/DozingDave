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

        // Start is called before the first frame update
        private void Start()
        {
            GridManager.Instance.CreateGrid(_width, _height);
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}