using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnitBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    private UnitStats stats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = new UnitStats(100, 100, 3);
    }

    public void Move(Vector2 vector)
    {
        rb.MovePosition(vector);
    }
}
