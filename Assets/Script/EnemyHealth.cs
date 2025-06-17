using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject explotionPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    void Die()
    {
        var exploObj = Instantiate(explotionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(exploObj, 0.5f);
    }
}
