using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health { get; private set; }

    [Range(1f, 200f)]
    public float MaxHealth;

    private void Start()
    {
        Health = MaxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;

        if (Health <= 0f)
            Death();
    }

    private void Death()
    {
        Debug.Log("GAME OVER");
    }
}
