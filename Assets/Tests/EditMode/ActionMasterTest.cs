using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

public class ActionMasterTest
{
    private List<int> pinFalls;
    private ActionMasterOld.Action endTurn = ActionMasterOld.Action.EndTurn;
    private ActionMasterOld.Action endGame = ActionMasterOld.Action.EndGame;
    private ActionMasterOld.Action tidy = ActionMasterOld.Action.Tidy;
    private ActionMasterOld.Action reset = ActionMasterOld.Action.Reset;
    
    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(pinFalls));
    }
    
    [Test]
    public void T03Bowl28SpareReturnsEdnTurn()
    {
        int[] rolls = { 2, 8 };
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05ChekcResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};
        Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T06ChekcResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
        Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    }
     
    [Test]
    public void T07RollsEndInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9};
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08BowlEndsAt20()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09Bowl20Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 10, 5};
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10Bowl20Is0Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11BowlIndexTest()
    {
        int[] rolls = {0,10,5, 1};
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T12Frame10Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));

    }

    [Test]
    public void T13TestEndInSecond()
    {
        int[] rolls = {0,1};
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    }
}
