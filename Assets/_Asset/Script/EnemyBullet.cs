using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float BulletSpeed, soundTime;
    [SerializeField] int dame = 0;
    [SerializeField] GameObject sound;

    private void OnEnable()
    {
        Destroy(Instantiate(sound), soundTime);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * BulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            enemy.takeDamage(dame);
        }
        Destroy(gameObject);
    }
}
