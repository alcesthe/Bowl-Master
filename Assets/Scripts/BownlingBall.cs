using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BownlingBall : MonoBehaviour
{
    public bool inPlay = false;
    private Rigidbody rgbody;

    private void Start()
    {
        rgbody = GetComponent<Rigidbody>();
        rgbody.useGravity = false;
    }

    public void Lauch(Vector3 lauchVelocity)
    {
        inPlay = true;
        rgbody.useGravity = true;
        rgbody.velocity = lauchVelocity;

        GetComponent<AudioSource>().Play();
    }
}
