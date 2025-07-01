using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] GameObject gameOverCanvas;
    protected override void Die()
    {
        base.Die();
        gameOverCanvas.SetActive(true);
        Debug.Log("Player died");
    }
}
