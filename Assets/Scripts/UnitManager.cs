using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class UnitManager
{
    private static UnitBehavior selectedUnit;
    public static UnitBehavior SelectedUnit { get => selectedUnit; private set => selectedUnit = value; }

    // Returns true if selected a unit, else false
    public static bool SelectUnitAtWorldPosition(Vector2 worldPosition)
    {
        Collider2D overlap = Physics2D.OverlapPoint(worldPosition);
        if (overlap != null)
        {
            selectedUnit = overlap.GetComponent<UnitBehavior>();
            return true;
        }

        return false;
    }

    public static void MoveSelectedUnitWithSnap(Vector2 worldPosition, Tilemap tilemap)
    {
        Vector3 cellDestination = tilemap.WorldToCell(worldPosition);
        selectedUnit.MoveTo(tilemap.GetCellCenterWorld(Vector3Int.RoundToInt(cellDestination)));
    }

    //private void HighlightMovement()
    //{
    //    // int movesRemaining = selectedUnit.Stats.Movement;

    //    TilemapUtilities.SetTileAtWorldPosition(selectedUnit.transform.position, highlightMap, highlightedTile);
    //}

    //private void ClearMovementHighlight()
    //{
    //    highlightMap.ClearAllTiles();
    //}
}
