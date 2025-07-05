using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float exploTime = 1;
    protected int currentHealth;
    public System.Action OnDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Die()
    {
        GameObject exploInstant = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(exploInstant, exploTime);
        Destroy(gameObject);
        OnDead?.Invoke();
    }

    public virtual void takeDamage(int dame)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        currentHealth -= dame;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
}
