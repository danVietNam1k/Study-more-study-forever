using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDead;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");

        OnPlayerDead?.Invoke();
    }
}