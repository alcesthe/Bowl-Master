using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinSetter : MonoBehaviour
{
    public int lastStandingCount = -1;
    [SerializeField] TextMeshProUGUI standingDisplay;
    public float distanceToRaise = 40f;

    private BownlingBall bownlingBall;
    private float lastChangeTime;
    private bool isBallEnteredBox = false;
    // Start is called before the first frame update
    void Start()
    {
        bownlingBall = FindObjectOfType<BownlingBall>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();

        if (isBallEnteredBox)
        {
            CheckStanding();
        }
    }

    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.transform.position = new Vector3(pin.transform.position.x, distanceToRaise, pin.transform.position.z); ;
            }
        }
    }

    public void LowerPins()
    {
        
    }

    public void RenewPins()
    {

    }

    private void CheckStanding()
    {
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        bownlingBall.Reset();
        lastStandingCount = -1;
        isBallEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    public int CountStanding()
    {
        int countStanding = 0;

        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                countStanding++;
            }

        }
        return countStanding;
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;
        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;

        if (thingHit.GetComponent<BownlingBall>())
        {
            standingDisplay.color = Color.red;
            isBallEnteredBox = true;
        }
    }
}