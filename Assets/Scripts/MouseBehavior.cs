using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(PlayerBehavior))]
public class MouseBehavior : MonoBehaviour
{ 
    private PlayerBehavior playerBehavior;

    private Vector2 mouseScreenPosition;
    private Vector2 mouseWorldPosition;

    private void Awake()
    {
        playerBehavior = GetComponent<PlayerBehavior>();
    }

    #region PlayerInputMessageHandlers
    // Recieves player input message
    private void OnMouseLeft()
    {
        if (playerBehavior.PlayerUnitManager.SelectedUnit == null)
        {
            if (playerBehavior.PlayerUnitManager.SelectUnitAtWorldPosition(mouseWorldPosition))
            {
                playerBehavior.PlayerTilemapHighlighter.HighlightMovement(mouseWorldPosition);
            }
        }
        else
        {
            playerBehavior.PlayerUnitManager.MoveSelectedUnitWithSnap(mouseWorldPosition);
            playerBehavior.PlayerTilemapHighlighter.RefreshMovementHighlight(mouseWorldPosition);
        }
    }

    private void OnMouseRight()
    {
        if (playerBehavior.PlayerUnitManager.SelectedUnit)
        {
            playerBehavior.PlayerUnitManager.ClearSelectedUnit();
            playerBehavior.PlayerTilemapHighlighter.ClearMovementHighlight();
        }
    }

    private void OnMouseMove(InputValue inputValue)
    {
        mouseScreenPosition = inputValue.Get<Vector2>();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    private void OnTestButton()
    {
        Debug.Log("Button");
    }
    // -----------------------------------------------------
    #endregion
}
