using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame};

    // private int[] bowls = new int[21];
    private int bowl = 1;

    public Action Bowl (int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid pins");
        }

        if (pins == 10)
        {
            bowl += 2;
            return Action.EndTurn;
        }

        if (bowl % 2 != 0)
        {
            bowl += 1;
            return Action.Tidy;
        } else if (bowl % 2 == 0)
        {
            return Action.EndTurn;
        }

        // Other behaviour here
        throw new UnityException("Don't have action to return");
    }
}
