using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinSetter : MonoBehaviour
{
   
    [SerializeField] GameObject setOfPins;
    private Animator animator;
    private PinCounter pinCounter;
    private BownlingBall bownlingBall;

    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
        bownlingBall = FindObjectOfType<BownlingBall>();
    }
    
    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pin.RaiseIfStanding();
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

    //TODO Bad reference
    public void SetInPlayToBowlingBall(int value)
    {
        bownlingBall.inPlay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;
        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }
    public void PerformAction (ActionMasterOld.Action action)
    {
        if (action == ActionMasterOld.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMasterOld.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMasterOld.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMasterOld.Action.EndGame)
        {
            throw new UnityException("Don't know how to deal that yet !");
        }
    }
}
