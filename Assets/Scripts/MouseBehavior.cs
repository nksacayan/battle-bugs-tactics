using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MouseBehavior : MonoBehaviour
{
    [SerializeField] private CharacterBehavior selectedCharacter;

    [SerializeField] private Tilemap map;

    private Vector2 mouseScreenPosition;
    private Vector2 mouseWorldPosition;
    private Vector2 gizmoPosition;

    public CharacterBehavior SelectedCharacter { get => selectedCharacter; set => selectedCharacter = value; }

    // Recieves player input message
    private void OnMouseLeft()
    {
        if (selectedCharacter == null)
        {
            Collider2D overlap = Physics2D.OverlapPoint(mouseWorldPosition);
            if (overlap != null)
            {
                SelectedCharacter = overlap.GetComponent<CharacterBehavior>();
            }
        }
        else
        {
            Vector3 cellDestination = map.WorldToCell(mouseWorldPosition);
            SelectedCharacter.Move(map.GetCellCenterWorld(Vector3Int.RoundToInt(cellDestination)));
        }
        
    }

    private void OnMouseRight()
    {
        SelectedCharacter = null;
    }

    private void OnMouseMove(InputValue inputValue)
    {
        mouseScreenPosition = inputValue.Get<Vector2>();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Vector3 cellPosition = map.WorldToCell(mouseWorldPosition);
        Vector3 cellCenter = map.GetCellCenterWorld(Vector3Int.RoundToInt(cellPosition));

        gizmoPosition = cellCenter;
    }

    private void OnTestButton()
    {
        Debug.Log("Button");
    }
    // -----------------------------------------------------

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(gizmoPosition, new Vector3(.5f, .5f, 0));
    }
}
