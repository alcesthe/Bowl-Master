using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinSetter : MonoBehaviour
{
    private int lastStandingCount = -1;
    [SerializeField] TextMeshProUGUI standingDisplay;
    [SerializeField] GameObject setOfPins;
    private bool ballOutOfPlay = false;

    private BownlingBall bownlingBall;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private Animator animator;
    private ActionMaster actionMaster = new ActionMaster();

    // Start is called before the first frame update
    void Start()
    {
        bownlingBall = FindObjectOfType<BownlingBall>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            CheckStanding();
            standingDisplay.color = Color.red;
        }
    }
    
    public void SetBallOutOfPlay(bool value)
    {
        ballOutOfPlay = value;
    }

    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.RaiseIfStanding();
                pin.transform.rotation = Quaternion.Euler(-90, 0, 0);
            }
        }
    }
    
    public void LowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.Lower();
            }
        }
    }


    public void RenewPins()
    {
        Instantiate(setOfPins, new Vector3(0, 1.4f, 1750), transform.rotation);
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
    
    int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to deal that yet !");
        }

        bownlingBall.Reset();
        lastStandingCount = -1;
        ballOutOfPlay = false;
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
}
