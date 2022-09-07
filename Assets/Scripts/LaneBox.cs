using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour
{
    private PinSetter pinSetter;

    private void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
    }

}
