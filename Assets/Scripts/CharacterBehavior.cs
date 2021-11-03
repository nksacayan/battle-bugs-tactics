using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 vector)
    {
        rb.MovePosition(vector);
    }
}
