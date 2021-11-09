using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager
{
    private UnitBehavior selectedUnit;
    private Grid unitGrid;

    public UnitBehavior SelectedUnit { get => selectedUnit; private set => selectedUnit = value; }
    public Grid UnitGrid { get => unitGrid; private set => unitGrid = value; }

    public UnitManager(Grid unitGrid)
    {
        this.unitGrid = unitGrid;
    }

    // Returns true if selected a unit, else false
    public bool SelectUnitAtWorldPosition(Vector2 worldPosition)
    {
        Collider2D overlap = Physics2D.OverlapPoint(worldPosition);
        if (overlap != null)
        {
            selectedUnit = overlap.GetComponent<UnitBehavior>();
            return true;
        }

        return false;
    }

    public void ClearSelectedUnit()
    {
        selectedUnit = null;
    }

    public void MoveSelectedUnitWithSnap(Vector2 worldPosition)
    {
        Vector3 cellDestination = unitGrid.WorldToCell(worldPosition);
        selectedUnit.MoveTo(unitGrid.GetCellCenterWorld(Vector3Int.RoundToInt(cellDestination)));
    }

}
