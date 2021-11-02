using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    // Recieves player input message
    private void OnMouseClick()
    {
        Debug.Log("Click");
    }

    private void OnMouseMove()
    {
        Debug.Log("Move");
    }

    private void OnTestButton()
    {
        Debug.Log("Button");
    }
}
