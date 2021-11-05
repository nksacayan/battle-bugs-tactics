using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnitBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    private UnitStats stats;

    public UnitStats Stats { get => stats; private set => stats = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Stats = new UnitStats(100, 100, 3);
    }

    public void MoveTo(Vector2 vector)
    {
        rb.MovePosition(vector);
    }
}
