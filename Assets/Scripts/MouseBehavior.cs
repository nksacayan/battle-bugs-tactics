using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MouseBehavior : MonoBehaviour
{
    private CharacterBehavior selectedCharacter;

    [SerializeField] private Tilemap map;

    private Vector2 mouseScreenPosition;
    private Vector2 mouseWorldPosition;
    private Vector2 gizmoPosition;
    
    // Recieves player input message
    private void OnMouseClick()
    {
        Collider2D overlap = Physics2D.OverlapPoint(mouseWorldPosition);

        Debug.Log(overlap.gameObject);
    }

    private void OnMouseMove(InputValue inputValue)
    {
        mouseScreenPosition = inputValue.Get<Vector2>();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Vector3Int cellPosition = map.WorldToCell(mouseWorldPosition);

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
