using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMasterOld {
	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};
    private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMasterOld actionMaster = new ActionMasterOld();
        Action currentAction = new Action();

        foreach (int pinFall in pinFalls)
        {
            currentAction = actionMaster.Bowl(pinFall);
        }

        return currentAction;
    }
	private Action Bowl (int pins) // TODO Make in private
    {
        if (pins < 0 || pins > 10) { throw new UnityException("Invalid pins !"); };

        bowls[bowl - 1] = pins;

        if (bowl == 21) { return Action.EndGame; }

        //Handle the last frame
        if (bowl >= 19 && pins == 10)
        {
            bowl++;
            return Action.Reset;
        } else if (bowl == 20)
        {
            bowl++;
            if(bowls[19-1]==10 && bowls[20 - 1] == 0)
            {
                return Action.Tidy;
            }
            else if ((bowls[19-1] + bowls[20-1]) % 10 == 0)
            {
                return Action.Reset;
            } else if (Bowl21Awarded())
            {
                return Action.Tidy;
            }
            else
            {
                return Action.EndGame;
            }
        }

        /*if (bowl >= 19 && Bowl21Awarded())
        {
            bowl += 1;
            return Action.Reset;
        } else if (bowl == 20 && !Bowl21Awarded())
        {
            return Action.EndGame;
        }*/

        if (bowl % 2 != 0)
        {
            if (pins == 10)
            {
                bowl += 2;
                return Action.EndTurn;
            } else
            {
                bowl += 1;
                return Action.Tidy;
            }
            
        } else if (bowl % 2 == 0)
        {
            bowl += 1;
            return Action.EndTurn;
        }



        // Other Exception
        throw new UnityException("Not sure what action to return !");
    }
     
    private bool Bowl21Awarded()
    {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }
}