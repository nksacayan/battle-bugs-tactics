using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats
{
    private int maxHealth;
    private int currentHealth;
    private int movement;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int Movement { get => movement; set => movement = value; }

    public UnitStats(int currentHealth, int maxHealth, int movement)
    {
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        Movement = movement;    
    }
}
