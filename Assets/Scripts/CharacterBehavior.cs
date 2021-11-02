using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CharacterBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Move(Vector2 vector)
    {
        rb.MovePosition(rb.position + vector);
    }
}
