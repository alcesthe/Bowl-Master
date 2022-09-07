using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> rolls = new List<int>();
    private PinSetter pinSetter;
    private BownlingBall bownlingBall;
    private ScoreDisplay scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        pinSetter = FindObjectOfType<PinSetter>();
        bownlingBall = FindObjectOfType<BownlingBall>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl (int pinFall)
    {
        try
        {
            rolls.Add(pinFall);
            bownlingBall.Reset();

            pinSetter.PerformAction(ActionMasterOld.NextAction(rolls));
        }
        catch
        {
            Debug.LogWarning("Something went wrong !");

        }

        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch
        {
            Debug.LogWarning("FillRollCard fail !");
        }
        
    }

}
