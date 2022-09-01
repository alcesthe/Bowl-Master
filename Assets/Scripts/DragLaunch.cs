using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BownlingBall))]
public class DragLaunch : MonoBehaviour
{
    private BownlingBall bownlingBall;
    private float startTime, endTime;
    private Vector3 startPos, endPos;
    private float laneWidth;
    
    void Start()
    {
        bownlingBall = GetComponent<BownlingBall>();
    }

    public void MoveStart(float amount)
    {
        if (!bownlingBall.inPlay)
        {
            gameObject.transform.Translate(amount,0,0);
        }
    }

    public void DragStart()
    {
        startTime = Time.time;
        startPos = Input.mousePosition;       
    }

    public void DragEnd()
    {
        endTime = Time.time;
        endPos = Input.mousePosition;

        float lauchSpeed = endTime - startTime;
        float lauchSpeedX = (endPos.x - startPos.x) / lauchSpeed;
        float lauchSpeedZ = (endPos.y - startPos.y) / lauchSpeed;

        Vector3 lauchVelocity = new Vector3(lauchSpeedX, 0 , lauchSpeedZ);
        bownlingBall.Lauch(lauchVelocity);
    }
}
