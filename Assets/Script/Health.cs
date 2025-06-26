using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected int maxHealth;
    protected int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Die()
    {
        GameObject exploInstant = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(exploInstant, 0.3f);
        Destroy(gameObject);
    }

    public virtual void takeDamage(int dame)
    {
        currentHealth -= dame;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
}
