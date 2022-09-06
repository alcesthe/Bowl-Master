using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BownlingBall : MonoBehaviour
{
    public bool inPlay = false;
    private Rigidbody rgbody;
    Vector3 startPos;
    AudioSource audioSource;

    private void Start()
    {
        rgbody = GetComponent<Rigidbody>();
        rgbody.useGravity = false;
        startPos = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    public void Lauch(Vector3 lauchVelocity)
    {
        inPlay = true;
        rgbody.useGravity = true;
        rgbody.velocity = lauchVelocity;

        audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;

        transform.rotation = Quaternion.identity;
        transform.position = startPos;
        rgbody.velocity = Vector3.zero;
        rgbody.angularVelocity = Vector3.zero;
        rgbody.useGravity = false;

        audioSource.Stop();
    }
}
