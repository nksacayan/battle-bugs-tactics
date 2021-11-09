using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHighlighter
{
    private Tilemap highlightMap;
    private Tile highlightTile;

    public TilemapHighlighter(Tilemap highlightMap, Tile highlightTile)
    {
        this.highlightMap = highlightMap;
        this.highlightTile = highlightTile;
    }

    private void SetTileAtWorldPosition(Vector2 worldPosition, Tilemap tilemap, Tile tile)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        tilemap.SetTile(cellPosition, tile);
    }

    public void HighlightMovement(Vector2 position)
    {
        // int movesRemaining = selectedUnit.Stats.Movement;

        SetTileAtWorldPosition(position, highlightMap, highlightTile);
    }

    public void ClearMovementHighlight()
    {
        highlightMap.ClearAllTiles();
    }

    public void RefreshMovementHighlight(Vector2 position)
    {
        ClearMovementHighlight();
        HighlightMovement(position);
    }

}
