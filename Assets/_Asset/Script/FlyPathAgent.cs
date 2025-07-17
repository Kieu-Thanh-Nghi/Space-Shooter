using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed;
    private int nextIndex = 1;
    public float sa;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (flyPath == null) return;
        if (nextIndex >= flyPath.waypoints.Length) 
        {
            EnemyHealth.LivingEnemyCount--;
            Destroy(gameObject);
            return;
        }
        if (transform.position != flyPath[nextIndex])
        {
            FlyToNextWaypoint();
            LookAt(flyPath[nextIndex]);
        }
        else
        {
            nextIndex++;
        }
    }

    private void FlyToNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, flyPath[nextIndex], flySpeed * Time.deltaTime);
    }
    private void LookAt(Vector2 destination)
    {
        Vector2 position = transform.position;
        var lookDirection = destination - position;
        if (lookDirection.magnitude < 0.01f) return;
        var angle = Vector2.SignedAngle(-transform.up, lookDirection);
        if (Mathf.Abs(angle) < 0.1f) return;
        transform.Rotate(Vector3.forward, angle / 50);
    }
}

