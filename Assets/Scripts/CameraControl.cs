using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] BownlingBall bownlingBall;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - bownlingBall.transform.position;
    }
    void FixedUpdate()
    {
        var posX = bownlingBall.transform.position.x + offset.x;
        var posY = bownlingBall.transform.position.y + offset.y;
        var posZ = bownlingBall.transform.position.z + offset.z;

        if (transform.position.z < 1829)
        {
            transform.position = new Vector3(posX, posY, posZ);
        } 
    }
}
