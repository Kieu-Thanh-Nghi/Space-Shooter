using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected float exploTime = 1;
    [SerializeField] protected int maxHealth;
    protected int currentHealth;
    public System.Action OnDead;
    public System.Action onHealthChanged;

    public int maxHp()
    {
        return maxHealth;
    }    
    public int currentHp()
    {
        return currentHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged?.Invoke();
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
        onHealthChanged?.Invoke();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
