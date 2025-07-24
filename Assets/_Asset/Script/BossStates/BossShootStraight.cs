using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootStraight : MonoBehaviour
{
    [SerializeField] GameObject Guns;
    [SerializeField] gun[] Gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float cuong_do;
    float tg;

    private void OnEnable()
    {
        tg = Time.time - cuong_do - 1;
        Gun = Guns.GetComponentsInChildren<gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - tg > cuong_do)
        {
            tg = Time.time;
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        foreach(var g in Gun)
        {
            Transform gunPos = g.GetComponent<Transform>(); 
            Instantiate(bulletPrefab, gunPos.position, gunPos.rotation);
        }
    }
}
