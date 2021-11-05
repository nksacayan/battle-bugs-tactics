using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MouseBehavior : MonoBehaviour
{

    [SerializeField] private Tilemap backgroundMap;
    [SerializeField] private Tilemap highlightMap;

    [SerializeField] private Tile highlightedTile;

    private Vector2 mouseScreenPosition;
    private Vector2 mouseWorldPosition;

    private Vector2 gizmoPosition;


    #region MessageHandlers
    // Recieves player input message
    private void OnMouseLeft()
    {
        
    }

    private void OnMouseRight()
    {

    }

    private void OnMouseMove(InputValue inputValue)
    {
        mouseScreenPosition = inputValue.Get<Vector2>();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Vector3 cellPosition = backgroundMap.WorldToCell(mouseWorldPosition);
        Vector3 cellCenter = backgroundMap.GetCellCenterWorld(Vector3Int.RoundToInt(cellPosition));

        gizmoPosition = cellCenter;
    }

    private void OnTestButton()
    {
        Debug.Log("Button");
    }
    // -----------------------------------------------------
    #endregion

    #region DebugStuff
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(gizmoPosition, new Vector3(.5f, .5f, 0));
    }

    #endregion
}
