using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector3 fingerPointOffset;
    [SerializeField] float flightSpeed;
    // Update is called once per frame
    void Update()
    {
        var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) + fingerPointOffset;
        worldPoint.z = 0;
        transform.
        transform.position = Vector3.MoveTowards(transform.position, worldPoint, flightSpeed * Time.deltaTime);
    }
}
