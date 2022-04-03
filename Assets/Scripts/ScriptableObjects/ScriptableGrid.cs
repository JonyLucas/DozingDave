using Game.GridScripts;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableGrid : ScriptableObject
{
    private GridBoard _grid;

    [SerializeField]
    private Vector3 GridPosition;

    [SerializeField]
    private int _width = 4;

    [SerializeField]
    private int _height = 4;

    [SerializeField]
    private Sprite emptyBlock;

    [SerializeField]
    private List<Sprite> ImageBlocks;

    public GridBoard Grid
    { get { return _grid; } }

    public void CreateGrid()
    {
        var builder = new GridBuilder();
        _grid = builder.CreateGrid(_width, _height);
    }

    public void ClearGrid()
    {
        _grid.Blocks.ForEach(block =>
        {
            block.IsOccupied = false;
            block.CurrentSprite = emptyBlock;
        });
    }
}