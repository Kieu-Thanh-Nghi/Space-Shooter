using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public static int LivingEnemyCount = 0;

    private void Awake()
    {
        LivingEnemyCount++;
    }
    protected override void Die()
    {
        base.Die();
        LivingEnemyCount--;
        Debug.Log("enemy died");
    }
}
