using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationEuler = transform.rotation.eulerAngles;
    }

    public bool IsStanding()
    {
        Vector3 rotationEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationEuler.x); //Offet 270 because hardcode on position of pin
        float tiltInZ = Mathf.Abs(rotationEuler.z);

        if ((tiltInX < standingThreshold) && (tiltInZ < standingThreshold)){
            return true;
        }

        return false;
    }
}
