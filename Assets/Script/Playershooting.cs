using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float cuong_do;
    float tg;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - tg > cuong_do)
            {
                tg = Time.time;
                ShootBullet();
            }   
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
