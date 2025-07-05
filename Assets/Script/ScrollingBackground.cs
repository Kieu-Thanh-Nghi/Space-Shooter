using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRen;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        meshRen.material.mainTextureOffset = new Vector2(0, speed * Time.time);
    }
}
