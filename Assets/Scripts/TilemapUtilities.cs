using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilemapUtilities
{
    public static void SetTileAtWorldPosition(Vector2 worldPosition, Tilemap tilemap, Tile tile)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        tilemap.SetTile(cellPosition, tile);
    }


}
