using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerBehavior : MonoBehaviour
{
    private UnitManager playerUnitManager;
    private TilemapHighlighter playerTilemapHighlighter;

    [SerializeField] private Grid gameGrid;
    [SerializeField] private Tilemap highlightTilemap;
    [SerializeField] private Tile highlightTile;

    public UnitManager PlayerUnitManager { get => playerUnitManager; set => playerUnitManager = value; }
    public TilemapHighlighter PlayerTilemapHighlighter { get => playerTilemapHighlighter; set => playerTilemapHighlighter = value; }

    private void Awake()
    {
        playerUnitManager = new UnitManager(gameGrid);
        playerTilemapHighlighter = new TilemapHighlighter(highlightTilemap, highlightTile);
    }
}
