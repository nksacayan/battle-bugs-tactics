using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MouseBehavior : MonoBehaviour
{
    private CharacterBehavior selectedCharacter;
    [SerializeField] private Tilemap map;
    [SerializeField] private Tilemap gridMap;
    [SerializeField] private Tile redTile;
    [SerializeField] private Tile baseTile;
    [SerializeField] private Tile greenTile;


    private Vector2 mousePosition;
    private Vector2 gizmoPosition;
    
    // Recieves player input message
    private void OnMouseClick()
    {
        Vector3Int cellPosition = map.WorldToCell(mousePosition);

        TileBase tile = map.GetTile(cellPosition);
        Debug.Log(tile);

    }

    private void OnMouseMove(InputValue inputValue)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(inputValue.Get<Vector2>());

        Vector3Int cellPosition = map.WorldToCell(mousePosition);

        gizmoPosition = new Vector2(cellPosition.x, cellPosition.y);
    }

    private void OnTestButton()
    {
        Debug.Log("Button");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(gizmoPosition, new Vector3(.5f, .5f, 0));
    }
}
